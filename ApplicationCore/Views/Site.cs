using ApplicationCore.Models;
using ApplicationCore.Paging;
using Infrastructure.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Helpers;

namespace ApplicationCore.Views
{
	public class SiteViewModel : BaseRecordView
	{
		public int id { get; set; }

		public string name { get; set; }

		public string url { get; set; }

		public IList<PageViewModel> pages { get; set; } = new List<PageViewModel>();


		public void SetValues(Site entity)
		{
			SetBaseRecordValues(entity);

			entity.Name = name;
			entity.Url = url;

		}
	}


}
