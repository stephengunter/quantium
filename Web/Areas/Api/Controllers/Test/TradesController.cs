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
	public class TradesController : BaseApiController
	{
		private readonly TestContext testContext;

		public TradesController(TestContext testContext)
		{
			this.testContext = testContext;
		}


		[HttpPost("")]
		public ActionResult Store([FromBody] TradeViewModel model)
		{
			ValidateRequest(model);
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var trade = new Trade();
			model.SetValues(trade);

			testContext.Trades.Add(trade);
			testContext.SaveChanges();

			return Ok(trade.Id);
		}
		
		[HttpPut("{id}")]
		public ActionResult Update(int id, [FromBody] TradeViewModel model)
		{
			var trade = testContext.Trades.Find(id);
			if (trade == null) return NotFound();

			ValidateRequest(model);
			if (!ModelState.IsValid) return BadRequest(ModelState);

			model.SetValues(trade);

			testContext.Entry(trade).State = EntityState.Modified;
			testContext.SaveChanges();

			return Ok();
		}

		[HttpDelete("{id}")]
		public ActionResult Delete(string id)
		{
			var ids = id.Split(',').Select(i => i.ToInt()).ToList();

			foreach (var item in ids.Where(val => val > 0))
			{
				var trade = testContext.Trades.Find(item);
				if (trade != null)
				{
					testContext.Trades.Remove(trade);
				}
			}

			testContext.SaveChanges();
			return Ok();
		}

		
		void ValidateRequest(TradeViewModel model)
		{
			if (model.date.Trim().IsNullOrEmpty())
			{
				ModelState.AddModelError("date", "Date is required");
			}

		}
	}
}