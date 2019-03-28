using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Api.Controllers
{
    public class HealthController : BaseApiController
	{
		[HttpGet]
		public async Task<IActionResult> Index()
        {
			using (var client = new HttpClient())
			{
				var startTime = DateTime.Now;
				try
				{
					var result = await client.GetAsync("https://quantium-cdb.chinacloudsites.cn");
					if (result.IsSuccessStatusCode)
					{
						var endTime = DateTime.Now;
						var Content = result.Content;

						var test = OnSuccess(startTime, endTime);
						return Ok(test);
					}
					else
					{
						var x = result.Content;

						return BadRequest();
					}
				}
				catch (Exception ex)
				{
					return Ok(ex.Data);
				}
				
			}

			
        }

		string OnSuccess(DateTime startTime, DateTime endTime)
		{
			TimeSpan ts1 = new TimeSpan(startTime.Ticks);
			TimeSpan ts2 = new TimeSpan(endTime.Ticks);
			TimeSpan ts = ts1.Subtract(ts2).Duration();

			var time = ts.TotalMilliseconds;

			return ts.TotalSeconds.ToString();

			//dateDiff = ts.Days.ToString() + "天" + ts.Hours.ToString() + "小時" + ts.Minutes.ToString() + "分鐘" + ts.Seconds.ToString() + "秒";
			//return dateDiff;
		}


		void OnFailed()
		{
			// LOG Failed
		}
    }
}