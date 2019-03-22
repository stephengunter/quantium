using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Entities;

namespace ApplicationCore.Models
{
	public class Client : BaseRecord
	{
		public string Name { get; set; }

		public string Phone { get; set; }

		public string Email { get; set; }

		public ICollection<Deployment> Deployments { get; set; } = new List<Deployment>();

		public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
	}
}
