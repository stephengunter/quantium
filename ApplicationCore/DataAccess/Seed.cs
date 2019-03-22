using ApplicationCore.Helpers;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
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

			}

			Console.WriteLine("Done seeding database.");
			Console.WriteLine();

		}
	}
}
