using Infrastructure.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Views
{
	public class DeploymentViewModel : BaseRecordView
	{
		public int id { get; set; }

		public string date { get; set; }

		public int clientId { get; set; }
		
	}
}
