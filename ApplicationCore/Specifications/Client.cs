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
		public ClientFilterSpecifications(IList<int> ids) : base(c => ids.Contains(c.Id))
		{

		}
	}
}

