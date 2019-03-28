using ApplicationCore.Helpers;
using ApplicationCore.Models;
using Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;


namespace ApplicationCore.Specifications
{

	public class HealthFilterSpecifications : BaseSpecification<Health>
	{
		public HealthFilterSpecifications() : base()
		{
			AddInclude(h => h.Page.Site);
		}

		public HealthFilterSpecifications(bool ok) : base(h => h.OK == ok)
		{
			AddInclude(h => h.Page.Site);
		}

		public HealthFilterSpecifications(int pageId) : base(h => h.PageId == pageId)
		{
			AddInclude(h => h.Page.Site);
		}

		public HealthFilterSpecifications(double time) : base(h => h.Duration > time)
		{
			AddInclude(h => h.Page.Site);
		}

		public HealthFilterSpecifications(IList<int> ids) : base(h => ids.Contains(h.Id))
		{
			AddInclude(h => h.Page.Site);
		}
	}

	
}

