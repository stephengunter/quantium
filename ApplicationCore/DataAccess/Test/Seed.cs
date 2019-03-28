using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Models.Test;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Linq;

namespace ApplicationCore.DataAccess.Test
{
	public class Seed
	{
		public static async Task EnsureSeedData(IServiceProvider serviceProvider)
		{

			Console.WriteLine("Seeding database...");

			using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
				var testContext = scope.ServiceProvider.GetRequiredService<TestContext>();
				await testContext.Database.MigrateAsync();

				await SeedAssets(testContext);

			}

			Console.WriteLine("Done seeding database.");
			Console.WriteLine();

		}

		public static async Task SeedAssets(TestContext context)
		{
			var assets = new List<Asset>
			{
				new Asset
				{
					Name = "PingAn" , ChineseName = "中国平安", 
					Listed = true, Market = Market.SH.ToString(), Code = "601318",

					Trades = new List<Trade>
					{
						new Trade
						{
							Date = new DateTime(2016,2,17),
							Price = 45.2M,
							Shares = 1500 * 1000
						}
					}
					
				},
				new Asset
				{
					Name = "CNPC", ChineseName = "中国石油",
					Listed = true, Market = Market.SH.ToString(), Code = "601857",

					Trades = new List<Trade>
					{
						new Trade
						{
							Date = new DateTime(2015,11,25),
							Price = 7.55M,
							Shares = 2000 * 1000
						}
					}

				},
				new Asset
				{
					Name = "Suning.com", ChineseName = "苏宁易购",
					Listed = true, Market = Market.SZ.ToString(), Code = "002024",

					Trades = new List<Trade>
					{
						new Trade
						{
							Date = new DateTime(2017,6,15),
							Price = 12.2M,
							Shares = 4500 * 1000
						}
					}

				},
				new Asset
				{
					Name = "HSBC", ChineseName = "汇丰控股",
					Listed = true, Market = Market.HK.ToString(), Code = "00005",

					Trades = new List<Trade>
					{
						new Trade
						{
							Date = new DateTime(2017,1,10),
							Price = 60M,
							Shares = 5000 * 1000
						}
					}

				},
				new Asset
				{
					Name = "Amazon.com, Inc", ChineseName = "",
					Listed = true, Market = Market.US.ToString(), Code = "AMZN",

					Trades = new List<Trade>
					{
						new Trade
						{
							Date = new DateTime(2016,12,18),
							Price = 1650.5M,
							Shares = 1000 * 1000
						}
					}

				}
			};

			foreach (var asset in assets)
			{
				var exist = await context.Assets.Where(a => a.Code == asset.Code).FirstOrDefaultAsync();
				if (exist == null)
				{
					context.Assets.Add(asset);
					context.SaveChanges();
				}
			}


		}
	}
}
