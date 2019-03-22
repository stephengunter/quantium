using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Entities;

namespace ApplicationCore.Models
{
	public class Cloud : BaseRecord
	{
		public string Name { get; set; }

		public string Url { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }

		public ICollection<DbServer> DbServers { get; set; } = new List<DbServer>();
	}
}
