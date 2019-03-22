using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Entities;

namespace ApplicationCore.Models
{
	public class Deployment : BaseRecord
	{
		public DateTime Date { get; set; }

		public int ClientId { get; set; }

		public Client Client { get; set; }

	}


	public enum DeploymentType
	{
		Local,
		Cloud
	}
}
