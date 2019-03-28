using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Helpers;

namespace Web.Areas.Api.Controllers
{
	[Area("Api")]
	[Route("api/[controller]")]
	[ApiController]
	public abstract class BaseApiController : ControllerBase
	{
		protected string RemoteIpAddress => Request.HttpContext.Connection.RemoteIpAddress?.ToString();

		protected string CurrentUserName
		{
			get
			{
				if (User == null) return "";
				if (User.Claims.IsNullOrEmpty()) return "";
				return User.Claims.Where(c => c.Type == "sub").FirstOrDefault().Value;
			}
		}

		protected string CurrentUserId
		{
			get
			{
				if (User == null) return "";
				if (User.Claims.IsNullOrEmpty()) return "";
				return User.Claims.Where(c => c.Type == "id").FirstOrDefault().Value;
			}
		}

		protected IActionResult RequestError(string key, string msg)
		{
			ModelState.AddModelError(key, msg);
			return BadRequest(ModelState);
		}

	}
}