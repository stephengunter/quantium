using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Entities;

namespace ApplicationCore.Models
{
	public class Page : BaseRecord
	{
		public int SiteId { get; set; }

		public string Url { get; set; }

		public bool Auth { get; set; }

		public Site Site { get; set; }

		public ICollection<Health> HealthList { get; set; } = new List<Health>();

	}
}
