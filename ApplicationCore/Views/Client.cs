using Infrastructure.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Views
{
	public class ClientViewModel : BaseRecordView
	{
		public int id { get; set; }

		public string name { get; set; }

		public string phone { get; set; }

		public string email { get; set; }

	}

	
}
