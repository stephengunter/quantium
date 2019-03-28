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
	public class HealthViewModel : BaseRecordView
	{
		public int id { get; set; }

		public int pageId { get; set; }

		public string url { get; set; }

		public bool ok { get; set; }

		public double duration { get; set; }

		public int status { get; set; }

		public string time { get; set; }

		public PageViewModel page { get; set; }

	}

	public class HealthIndexViewModel
	{
		public IList<SiteViewModel> sites { get; set; }

		public IPagedList<Health, HealthViewModel> pageList { get; set; }

	}

	


}
