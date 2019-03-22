using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Entities;

namespace ApplicationCore.Models
{
	public class DbServer : BaseRecord
	{
		public string Name { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }


		public int CloudId { get; set; }

		public Cloud Cloud { get; set; }
	}
}
