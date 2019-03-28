using ApplicationCore.Helpers;
using ApplicationCore.Models;
using Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;


namespace ApplicationCore.Specifications
{

	public class PageFilterSpecifications : BaseSpecification<Page>
	{
		public PageFilterSpecifications(string url) : base(p => p.Url == url)
		{
			
		}

		public PageFilterSpecifications(IList<int> ids) : base(p => ids.Contains(p.Id))
		{
			
		}
	}

	
}

