using ApplicationCore.Helpers;
using ApplicationCore.Models;
using Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;


namespace ApplicationCore.Specifications
{

	public class ClientFilterSpecifications : BaseSpecification<Client>
	{
		public ClientFilterSpecifications(string name) : base(c => c.Name == name)
		{
			AddInclude(c => c.Contacts);
			AddInclude(c => c.Deployments);
		}

		public ClientFilterSpecifications(int id) : base(c => c.Id == id)
		{
			AddInclude(c => c.Contacts);
			AddInclude(c => c.Deployments);
		}

		public ClientFilterSpecifications(IList<int> ids) : base(c => ids.Contains(c.Id))
		{
			AddInclude(c => c.Contacts);
			AddInclude(c => c.Deployments);
		}

		
	}

	public class ClientKeywordFilterSpecifications : BaseSpecification<Client>
	{
		public ClientKeywordFilterSpecifications(string keyword) : base(c => c.Name.CaseInsensitiveContains(keyword) || c.AccountId.ToString().Contains(keyword))
		{
			AddInclude(c => c.Contacts);
			AddInclude(c => c.Deployments);
		}
	}

	public class ClientAccountIdFilterSpecifications : BaseSpecification<Client>
	{
		public ClientAccountIdFilterSpecifications(int accountId) : base(c => c.AccountId == accountId)
		{
			AddInclude(c => c.Contacts);
			AddInclude(c => c.Deployments);
		}
	}
}

