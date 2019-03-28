using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Models;
using Infrastructure.Views;

namespace ApplicationCore.ViewServices
{
	public class RegionViewService
	{
		public static IList<BaseOption> RegionOptions()
		{
			var options = new List<BaseOption>();
			foreach (Region region in (Region[])Enum.GetValues(typeof(Region)))
			{
				options.Add(new BaseOption(region.ToString(), region.ToString()));
			}
			return options;
		}

		
	}
}
