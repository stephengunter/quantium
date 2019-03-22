using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Views;
using ApplicationCore.Services;

namespace Web.Areas.Api.Controllers
{
    public class ClientsController : BaseApiController
	{
		private readonly IClientService clientService;

		public ClientsController(IClientService clientService)
		{
			this.clientService = clientService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
        {
			var clients = await clientService.FetchClients();

			clients = clients.GetOrdered();

			var pageList = clients.GetPagedList();

			return Ok(pageList);
		}

		[HttpGet("create")]
		public IActionResult Create()
		{
			var model = new ClientViewModel();
			return Ok(model);
		}
	}
}