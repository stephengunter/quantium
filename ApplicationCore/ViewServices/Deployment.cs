using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Views;
using ApplicationCore.Models;
using ApplicationCore.Paging;
using ApplicationCore.Helpers;
using System.Threading.Tasks;
using System.Linq;
using Infrastructure.Views;

namespace ApplicationCore.Views
{
	public static class DeploymentViewService
	{
		public static DeploymentViewModel MapViewModel(this Deployment deployment)
		{
			var model = new DeploymentViewModel()
			{
				id = deployment.Id,
				date = deployment.Date.ToShortDateString(),
				clientId = deployment.ClientId
			};

			model.SetBaseRecordValues(deployment);
			return model;
		}

		public static PagedList<Deployment, DeploymentViewModel> GetPagedList(this IEnumerable<Deployment> deployments, int page = 1, int pageSize = 999)
		{
			var pageList = new PagedList<Deployment, DeploymentViewModel>(deployments, page, pageSize);

			pageList.ViewList = deployments.Select(s => MapViewModel(s)).ToList();

			pageList.List = null;

			return pageList;
		}

		public static IEnumerable<Deployment> GetOrdered(this IEnumerable<Deployment> deployments)
		{
			return deployments.OrderBy(d => d.Date);
		}

	}
}
