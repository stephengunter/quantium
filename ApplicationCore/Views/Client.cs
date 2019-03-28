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
	public class ClientViewModel : BaseRecordView
	{
		public int id { get; set; }

		public int accountId { get; set; }
		
		public string name { get; set; }

		public string address { get; set; }

		public string region { get; set; }


		public void SetValues(Client entity)
		{
			SetBaseRecordValues(entity);

			entity.Name = name;
			entity.AccountId = accountId;
			entity.Address = address;
			entity.Region = region.ToEnum<Region>();

		}
	}

	public class ClientIndexViewModel
	{
		public IList<BaseOption> regions { get; set; }

		public IPagedList<Client, ClientViewModel> pageList { get; set; }

	}

	public class ClientEditForm
	{
		public IList<BaseOption> regions { get; set; }

		public ClientViewModel client { get; set; } = new ClientViewModel();

	}


}
