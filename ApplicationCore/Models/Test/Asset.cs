using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Entities;

namespace ApplicationCore.Models.Test
{
	public enum Market
	{
		SH = 1,
		SZ = 2,
		HK = 3,
		US = 4

	}

	public  class Asset : BaseEntity
	{
		public string Name { get; set; }
		public string ChineseName { get; set; }

		public bool Listed { get; set; }
		public string Code { get; set; }
		public string Market { get; set; }


		public ICollection<Trade> Trades { get; set; } = new List<Trade>();

	}

	public class Trade : BaseEntity
	{
		public DateTime Date { get; set; }
		public decimal Shares { get; set; }
		public decimal Price { get; set; }

		public int AssetId { get; set; }
		public Asset Asset { get; set; }
	}
}
