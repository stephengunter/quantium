using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Views.Test;
using ApplicationCore.Models.Test;
using ApplicationCore.Helpers;
using ApplicationCore.DataAccess.Test;
using Microsoft.EntityFrameworkCore;

namespace Web.Areas.Api.Controllers.Test
{
	public class AssetsController : BaseApiController
	{
		private readonly TestContext testContext;

		public AssetsController(TestContext testContext)
		{
			this.testContext = testContext;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var assets = testContext.Assets.Include(a => a.Trades).ToList();

			var viewList = assets.Select(a => a.MapViewModel());

			return Ok(viewList);
		}


		[HttpGet("create")]
		public IActionResult Create()
		{
			var editForm = new AssetEditForm();
			editForm.markets = AssetViewService.MarketOptions();
			return Ok(editForm);
		}

		[HttpPost("")]
		public ActionResult Store([FromBody] AssetViewModel model)
		{
			ValidateRequest(model);
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var asset = new Asset();
			model.SetValues(asset);

			if (!model.trades.IsNullOrEmpty())
			{
				foreach (var item in model.trades)
				{
					var trade = new Trade();
					item.SetValues(trade);
					asset.Trades.Add(trade);
				}
			}
			

			testContext.Assets.Add(asset);
			testContext.SaveChanges();

			return Ok(asset.Id);
		}

		[HttpGet("{id}/edit")]
		public ActionResult Edit(int id)
		{
			var asset = testContext.Assets.Include(a => a.Trades).SingleOrDefault(a => a.Id == id);
			if (asset == null) return NotFound();

			var editForm = new AssetEditForm();
			editForm.markets = AssetViewService.MarketOptions();
			editForm.asset = asset.MapViewModel();

			return Ok(editForm);
		}

		[HttpPut("{id}")]
		public ActionResult Update(int id, [FromBody] AssetViewModel model)
		{
			var asset = testContext.Assets.Include(a => a.Trades).SingleOrDefault(a => a.Id == id);
			if (asset == null) return NotFound();

			ValidateRequest(model);
			if (!ModelState.IsValid) return BadRequest(ModelState);

			model.SetValues(asset);

			if (asset.Trades.IsNullOrEmpty())
			{
				asset.Trades = new List<Trade>();
			}
			foreach (var item in model.trades)
			{
				var exsit = asset.Trades.Where(t => t.Id == item.id).FirstOrDefault();
				if (exsit == null)
				{
					var newTrade = new Trade();
					item.SetValues(newTrade);
					asset.Trades.Add(newTrade);
				}
				else
				{
					item.SetValues(exsit);
				}
			}

			testContext.Entry(asset).State = EntityState.Modified;
			testContext.SaveChanges();

			return Ok();
		}

		//[HttpDelete("{id}")]
		//public async Task<ActionResult> Delete(int id)
		//{
		//	var client = await clientService.GetByIdAsync(id);
		//	if (client == null) return NotFound();

		//	await clientService.DeleteAsync(client);
		//	return Ok();
		//}

		void ValidateRequest(AssetViewModel model)
		{
			if (model.name.Trim().IsNullOrEmpty())
			{
				ModelState.AddModelError("name", "Name is required");
			}

			if (!model.listed) return;
			if (model.code.Trim().IsNullOrEmpty())
			{
				ModelState.AddModelError("code", "Code is required");
			}

			try
			{
				Market market = model.market.ToEnum<Market>();
			}
			catch (Exception)
			{
				ModelState.AddModelError("market", "Wrong Market");
			}

		}
	}
}