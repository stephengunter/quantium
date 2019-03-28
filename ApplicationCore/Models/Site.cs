using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Entities;

namespace ApplicationCore.Models
{
	public class Site : BaseRecord
	{
		public string Name { get; set; }

		public string Url { get; set; }

		public ICollection<Page> Pages { get; set; } = new List<Page>();
	}
}
