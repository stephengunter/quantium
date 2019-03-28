using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Entities;

namespace ApplicationCore.Models
{
	public class Health : BaseRecord
	{
		public int PageId { get; set; }

		public bool OK { get; set; }

		public double Time { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.Now;


		public Page Page { get; set; }
	}
}
