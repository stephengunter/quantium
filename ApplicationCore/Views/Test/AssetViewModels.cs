using ApplicationCore.Helpers;
using ApplicationCore.Models.Test;
using Infrastructure.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Views.Test
{
	public class AssetViewModel
	{
		public int id { get; set; }
		public string name { get; set; }
		public string chineseName { get; set; }

		public bool listed { get; set; }
		public string market { get; set; }
		public string code { get; set; }

		public ICollection<TradeViewModel> trades { get; set; } = new List<TradeViewModel>();

		public void SetValues(Asset entity)
		{
			entity.Name = name;
			entity.ChineseName = chineseName;
			entity.Listed = listed;
			entity.Code = code;
			entity.Market = market;

		}

	}

	public class TradeViewModel
	{
		public int id { get; set; }
		public string date { get; set; }
		public decimal Shares { get; set; }
		public decimal Price { get; set; }

		public int assetId { get; set; }

		public void SetValues(Trade entity)
		{
			entity.Date = date.ToDatetimeOrDefault(DateTime.Today);
			entity.Shares = Shares;
			entity.Price = Price;	

		}
	}

	public class AssetEditForm
	{
		public AssetViewModel asset { get; set; } = new AssetViewModel();

		public IList<BaseOption> markets { get; set; }
	}
}
