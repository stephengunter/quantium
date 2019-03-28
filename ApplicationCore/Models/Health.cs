using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Entities;

namespace ApplicationCore.Models
{
	public class Health : BaseRecord
	{
		public int PageId { get; set; }

		public string Url { get; set; }

		public int Status { get; set; }

		public bool OK { get; set; }

		public double Duration { get; set; }
	


		public Page Page { get; set; }
	}
}
