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
	public class PageViewModel : BaseRecordView
	{
		public int id { get; set; }

		public int siteId { get; set; }

		public string url { get; set; }

		public bool auth { get; set; }

		public SiteViewModel site { get; set; }



		public void SetValues(Page entity)
		{
			SetBaseRecordValues(entity);

			entity.SiteId = siteId;
			entity.Url = url;
			entity.Auth = auth;

		}
	}

}
