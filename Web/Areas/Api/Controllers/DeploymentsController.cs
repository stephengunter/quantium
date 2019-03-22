using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Views;
using ApplicationCore.Services;

namespace Web.Areas.Api.Controllers
{
    public class DeploymentsController : BaseApiController
	{
		private readonly IDeploymentService deploymentService;

		public DeploymentsController(IDeploymentService deploymentService)
		{
			this.deploymentService = deploymentService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
        {
			var deployments = await deploymentService.FetchDeployments();

			deployments = deployments.GetOrdered();

			var pageList = deployments.GetPagedList();

			return Ok(pageList);
		}

		[HttpGet("create")]
		public IActionResult Create()
		{
			var model = new DeploymentViewModel();
			return Ok(model);
		}
	}
}