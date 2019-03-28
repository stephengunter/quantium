using ApplicationCore.Helpers;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApplicationCore.DataAccess
{
	public class Seed
	{
		public static async Task EnsureSeedData(IServiceProvider serviceProvider)
		{

			Console.WriteLine("Seeding database...");

			using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
				var defaultContext = scope.ServiceProvider.GetRequiredService<DefaultContext>();
				await defaultContext.Database.MigrateAsync();

				await SeedAssets(defaultContext);

			}

			Console.WriteLine("Done seeding database.");
			Console.WriteLine();

		}

		public static async Task SeedAssets(DefaultContext context)
		{
			var sites = new List<Site>
			{
				new Site
				{
					Name = "Auth" , Url = "https://accounts-quantium.azurewebsites.net/",
					Pages = new List<Page>
					{
						new Page
						{
							Url = "https://accounts-quantium.azurewebsites.net/",
							Auth = false							
						}
					}

				},
				new Site
				{
					Name = "Auth.CN" , Url = "https://quantium-accounts.chinacloudsites.cn/",
					Pages = new List<Page>
					{
						new Page
						{
							Url = "https://quantium-accounts.chinacloudsites.cn/",
							Auth = false
						}
					}

				},
				new Site
				{
					Name = "CDB.CN" , Url = "https://quantium-cdb.chinacloudsites.cn/",
					Pages = new List<Page>
					{
						new Page
						{
							Url = "https://quantium-cdb.chinacloudsites.cn/",
							Auth = false
						}
					}

				},
				new Site
				{
					Name = "CORE" , Url = "https://quantiumcore.com/",
					Pages = new List<Page>
					{
						new Page
						{
							Url = "https://quantiumcore.com/",
							Auth = false
						}
					}

				},
				new Site
				{
					Name = "CORE.CN" , Url = "https://quantiumcore.chinacloudsites.cn/",
					Pages = new List<Page>
					{
						new Page
						{
							Url = "https://quantiumcore.chinacloudsites.cn/",
							Auth = false
						}
					}

				},
				new Site
				{
					Name = "EDGE" , Url = "https://quantiumedge.com/",
					Pages = new List<Page>
					{
						new Page
						{
							Url = "https://quantiumedge.com/",
							Auth = false
						}
					}

				},
				new Site
				{
					Name = "EDGE.CN" , Url = "https://edge.chinacloudsites.cn/",
					Pages = new List<Page>
					{
						new Page
						{
							Url = "https://edge.chinacloudsites.cn/",
							Auth = false
						}
					}

				},

			};

			foreach (var site in sites)
			{
				var exist = await context.Sites.Where(s => s.Url == site.Url).FirstOrDefaultAsync();
				if (exist == null)
				{
					context.Sites.Add(site);
					context.SaveChanges();
				}
			}
		}
	}
}
