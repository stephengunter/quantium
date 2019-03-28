using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Views;
using ApplicationCore.Models;
using ApplicationCore.Paging;
using ApplicationCore.Helpers;
using System.Threading.Tasks;
using System.Linq;
using Infrastructure.Views;

namespace ApplicationCore.Views
{
	public static class HealthViewService
	{
		public static HealthViewModel MapViewModel(this Health health)
		{
			var model = new HealthViewModel()
			{
				id = health.Id,
				pageId = health.PageId,
				url = health.Url,
				ok = health.OK,
				duration = health.Duration,
				status = health.Status,
				time = health.CreatedAt.ToDateTimeString()
			};

			model.SetBaseRecordValues(health);

			if (health.Page != null)
			{
				model.page = health.Page.MapViewModel();
			}

			return model;
		}

		public static PagedList<Health, HealthViewModel> GetPagedList(this IEnumerable<Health> healths, int page = 1, int pageSize = 999)
		{
			var pageList = new PagedList<Health, HealthViewModel>(healths, page, pageSize);

			pageList.ViewList = healths.Select(h => MapViewModel(h)).ToList();

			pageList.List = null;

			return pageList;
		}


		public static IEnumerable<Health> GetOrdered(this IEnumerable<Health> healths)
		{
			return healths.OrderByDescending(c => c.CreatedAt);
		}


		public static SiteViewModel MapViewModel(this Site site)
		{
			var model = new SiteViewModel()
			{
				id = site.Id,
				name = site.Name,
				url = site.Url
			};

			model.SetBaseRecordValues(site);

			if (!site.Pages.IsNullOrEmpty())
			{
				model.pages = site.Pages.Select(p => p.MapViewModel()).ToList();
			}

			return model;
		}

		public static PageViewModel MapViewModel(this Page page)
		{
			var model = new PageViewModel()
			{
				id = page.Id,
				url = page.Url,
				auth = page.Auth,
				siteId = page.SiteId
			};

			model.SetBaseRecordValues(page);

			return model;
		}

	}
}
