using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Views;
using ApplicationCore.Services;
using ApplicationCore.Models;
using Infrastructure.Views;
using ApplicationCore.ViewServices;
using ApplicationCore.Helpers;
using System.Net.Http;
using Microsoft.Extensions.Options;

namespace Web.Areas.Api.Controllers
{
    public class HealthController : BaseApiController
	{
		private readonly ISiteService siteService;
		private readonly IHealthService healthService;

		private readonly AdminSettings adminSettings;

		public HealthController(IHealthService healthService, ISiteService siteService, IOptions<AdminSettings> adminSettings)
		{
			this.healthService = healthService;
			this.siteService = siteService;

			this.adminSettings = adminSettings.Value;
		}

		

		[HttpGet]
		public async Task<IActionResult> Index(int site = 0, int pageId = 0, int page = 0, int pageSize = 10)
		{
			var model = new HealthIndexViewModel();
			if (page < 1)
			{
				var sites = await siteService.FetchSitesAsync();
				model.sites = sites.Select(s => s.MapViewModel()).ToList();
				page = 1;
			}


			var healthRecords = await healthService.FetchHealths();


			healthRecords = healthRecords.GetOrdered();

			model.pageList = healthRecords.GetPagedList(page, pageSize);

			return Ok(model);
		}

		

		async Task<IList<Page>> FetchPagesAsync()
		{
			var sites = await siteService.FetchSitesAsync();
			var pages = new List<Page>();
			foreach (var site in sites)
			{
				pages.AddRange(site.Pages);
			}
			return pages;
		}

		[HttpPost("check")]
		public async Task<ActionResult> Check([FromBody] AdminRequest model)
		{
			ValidateRequest(model);

			if (!ModelState.IsValid) return BadRequest(ModelState);

			var pages = await FetchPagesAsync();
			foreach (var page in pages)
			{
				var health = await CheckAsync(page);
				if (!health.OK) OnFailed(page);

				await healthService.CreateAsync(health);
			}


			return Ok();

		}

		void ValidateRequest(AdminRequest model)
		{
			if (model.Key != adminSettings.Key) ModelState.AddModelError("key", "Key Error");
		}

		async Task<Health> CheckAsync(Page page)
		{
			var health = new Health() { PageId = page.Id, OK = false, Url = page.Url };

			using (var client = new HttpClient())
			{
				var startTime = DateTime.Now;
				try
				{
					var result = await client.GetAsync(page.Url);
					health.Status = (int)result.StatusCode;

					health.Duration = CalculateTime(startTime, DateTime.Now);
					health.OK = result.IsSuccessStatusCode;					
				}
				catch (Exception)
				{
					
				}

			}


			return health;
		}

		double CalculateTime(DateTime startTime, DateTime endTime)
		{
			TimeSpan ts1 = new TimeSpan(startTime.Ticks);
			TimeSpan ts2 = new TimeSpan(endTime.Ticks);
			TimeSpan ts = ts1.Subtract(ts2).Duration();

			return Math.Round(ts.TotalSeconds, 2, MidpointRounding.AwayFromZero);
		}

		void OnFailed(Page page)
		{

		}
	}
}