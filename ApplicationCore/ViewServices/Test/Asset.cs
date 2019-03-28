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
using ApplicationCore.Models.Test;

namespace ApplicationCore.Views.Test
{
	public static class AssetViewService
	{
		public static AssetViewModel MapViewModel(this Asset asset)
		{
			var model = new AssetViewModel()
			{
				id = asset.Id,
				name = asset.Name,
				chineseName = asset.ChineseName,
				code = asset.Code,
				listed = asset.Listed,
				market = asset.Market
			};

			if (!asset.Trades.IsNullOrEmpty())
			{
				model.trades = asset.Trades.Select(t => t.MapViewModel()).ToList();
			}
			
			return model;
		}

		public static PagedList<Asset, AssetViewModel> GetPagedList(this IEnumerable<Asset> assets, int page = 1, int pageSize = 999)
		{
			var pageList = new PagedList<Asset, AssetViewModel>(assets, page, pageSize);

			pageList.ViewList = assets.Select(a => MapViewModel(a)).ToList();

			pageList.List = null;

			return pageList;
		}


		public static IEnumerable<Asset> GetOrdered(this IEnumerable<Asset> assets)
		{
			return assets.OrderBy(a => a.Listed);
		}


		public static TradeViewModel MapViewModel(this Trade trade)
		{
			var model = new TradeViewModel()
			{
				id = trade.Id,
				date = trade.Date.ToShortDateString(),
				 assetId = trade.AssetId,
				Price = trade.Price,
				Shares = trade.Shares
				
			};

			return model;
		}

		public static IList<BaseOption> MarketOptions()
		{
			var options = new List<BaseOption>();
			foreach (Market market in (Market[])Enum.GetValues(typeof(Market)))
			{
				options.Add(new BaseOption(market.ToString(), market.ToDisplayName()));
			}
			return options;
		}

		public static string ToDisplayName(this Market market)
		{
			if (market == Market.HK) return "Hong Kong";
			if (market == Market.SH) return "Shanghai";
			if (market == Market.SZ) return "Shenzhen";

			if (market == Market.US) return "United States";

			return "";
		}
	}
}
