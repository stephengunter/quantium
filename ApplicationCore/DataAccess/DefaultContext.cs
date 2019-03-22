using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ApplicationCore.DataAccess
{

	public class DefaultContext : DbContext
	{
		public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
		{
		}

		public DefaultContext(string connectionString) : base(new DbContextOptionsBuilder<DefaultContext>().UseSqlServer(connectionString).Options)
		{

		}
		public DbSet<Client> Clients { get; set; }
		public DbSet<Contact> Contacts { get; set; }

		public DbSet<Deployment> Deployments { get; set; }
		
		
		public DbSet<Cloud> Clouds { get; set; }
		public DbSet<DbServer> DbServers { get; set; }

	}
}
