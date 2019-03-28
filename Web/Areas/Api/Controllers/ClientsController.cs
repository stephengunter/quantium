using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Views;
using ApplicationCore.Services;
using ApplicationCore.Models;
using Infrastructure.Views;
using ApplicationCore.ViewServices;
using ApplicationCore.Helpers;

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
		public async Task<IActionResult> Index(int page = 0, string region = "", string keyword = "")
        {
			var model = new ClientIndexViewModel();
			if (page < 1)
			{
				model.regions = RegionViewService.RegionOptions();
				page = 1;
			}


			var clients = await clientService.FetchClients(keyword);

			try
			{
				Region regionSelected = region.ToEnum<Region>();
				clients = clients.FilterByRegion(regionSelected);
			}
			catch (Exception) { }


			clients = clients.GetOrdered();

			model.pageList = clients.GetPagedList(page);

			return Ok(model);

		}

		[HttpGet("create")]
		public IActionResult Create()
		{
			var editForm = new ClientEditForm();
			editForm.regions = RegionViewService.RegionOptions();
			editForm.client.region = editForm.regions.FirstOrDefault().value;
			return Ok(editForm);
		}

		[HttpPost("")]
		public async Task<ActionResult> Store([FromBody] ClientViewModel model)
		{

			if (!ModelState.IsValid) return BadRequest(ModelState);
			ValidateRequest(model);
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var client = new Client();
			model.SetValues(client);
			client.SetUpdated(CurrentUserId);

			client = await clientService.CreateAsync(client);

			return Ok(client);
		}

		[HttpGet("{id}/edit")]
		public ActionResult Edit(int id)
		{
			var client = clientService.GetById(id);
			if (client == null) return NotFound();		

			var editForm = new ClientEditForm();
			editForm.regions = RegionViewService.RegionOptions();
			editForm.client = client.MapViewModel();

			return Ok(editForm);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Update(int id, [FromBody] ClientViewModel model)
		{
			var client = clientService.GetById(id);
			if (client == null) return NotFound();

			if (!ModelState.IsValid) return BadRequest(ModelState);
			ValidateRequest(model);
			if (!ModelState.IsValid) return BadRequest(ModelState);

			model.SetValues(client);
			client.SetUpdated(CurrentUserId);

			await clientService.UpdateAsync(client);

			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var client = await clientService.GetByIdAsync(id);
			if (client == null) return NotFound();

			await clientService.DeleteAsync(client);
			return Ok();
		}

		void ValidateRequest(ClientViewModel model)
		{
			if (model.name.Trim().IsNullOrEmpty())
			{
				ModelState.AddModelError("name", "Name is required");
			}
			else
			{
				var existClient = clientService.GetByName(model.name);
				if (existClient != null && existClient.Id != model.id)
				{
					ModelState.AddModelError("name", "Duplicate Name");
				}
			}

			try
			{
				Region region = model.region.ToEnum<Region>();
			}
			catch (Exception)
			{
				ModelState.AddModelError("region", "Wrong Region");
			}

			
		}
	}
}