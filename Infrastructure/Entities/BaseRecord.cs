using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Entities
{
	

	public abstract class BaseRecord : BaseEntity
	{
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public DateTime LastUpdated { get; set; } = DateTime.Now;
		public string UpdatedBy { get; set; }

		public string PS { get; set; }

		public int Order { get; set; }
		public bool Removed { get; set; }

		public virtual bool Active => Order >= 0 && !Removed;

		public void SetUpdated(string updatedBy)
		{
			this.UpdatedBy = updatedBy;
			this.LastUpdated= DateTime.Now;
		}


	}
}
