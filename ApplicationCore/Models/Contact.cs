using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Entities;

namespace ApplicationCore.Models
{
	public class Contact : BaseRecord
	{
		public string Name { get; set; }

		public string Phone { get; set; }

		public string Email { get; set; }


		public int ClientId { get; set; }

		public Client Client { get; set; }
	}
}
