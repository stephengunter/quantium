using ApplicationCore.Helpers;
using ApplicationCore.Models;
using Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;


namespace ApplicationCore.Specifications
{

	public class DeploymentFilterSpecifications : BaseSpecification<Deployment>
	{
		public DeploymentFilterSpecifications(IList<int> ids) : base(d => ids.Contains(d.Id))
		{

		}
	}
}

