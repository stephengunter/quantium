using ApplicationCore.Helpers;
using ApplicationCore.Models;
using Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;


namespace ApplicationCore.Specifications
{

	public class SiteFilterSpecifications : BaseSpecification<Site>
	{
		public SiteFilterSpecifications() : base()
		{
			AddInclude(s => s.Pages);
		}

		public SiteFilterSpecifications(string name) : base(s => s.Name == name)
		{
			AddInclude(s => s.Pages);
		}

		public SiteFilterSpecifications(int id) : base(s => s.Id == id)
		{
			AddInclude(s => s.Pages);
		}

		public SiteFilterSpecifications(IList<int> ids) : base(s => ids.Contains(s.Id))
		{
			AddInclude(s => s.Pages);
		}
	}

	public class SiteNameFilterSpecifications : BaseSpecification<Site>
	{
		public SiteNameFilterSpecifications(string name) : base(s => s.Name == name)
		{
			AddInclude(s => s.Pages);
		}
	}

	public class SiteUrlFilterSpecifications : BaseSpecification<Site>
	{
		public SiteUrlFilterSpecifications(string url) : base(s => s.Url == url)
		{
			AddInclude(s => s.Pages);
		}
	}

	public class SiteKeywordFilterSpecifications : BaseSpecification<Site>
	{
		public SiteKeywordFilterSpecifications(string keyword) 
			: base(s => s.Name.CaseInsensitiveContains(keyword) || s.Url.CaseInsensitiveContains(keyword))

		{
			AddInclude(s => s.Pages);
		}
	}

	
}

