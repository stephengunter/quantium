using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using ApplicationCore.Models.Test;

namespace ApplicationCore.DataAccess.Test
{

	public class TestContext : DbContext
	{
		public TestContext(DbContextOptions<TestContext> options) : base(options)
		{
		}

		public TestContext(string connectionString) : base(new DbContextOptionsBuilder<TestContext>().UseSqlServer(connectionString).Options)
		{

		}

		public DbSet<Asset> Assets { get; set; }
		public DbSet<Trade> Trades { get; set; }


	}
}
