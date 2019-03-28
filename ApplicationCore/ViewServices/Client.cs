using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Views;
using ApplicationCore.Models;
using ApplicationCore.Paging;
using ApplicationCore.Helpers;
using System.Threading.Tasks;
using System.Linq;
using Infrastructure.Views;

namespace ApplicationCore.Views
{
	public static class ClientViewService
	{
		public static ClientViewModel MapViewModel(this Client client)
		{
			var model = new ClientViewModel()
			{
				id = client.Id,
				accountId = client.AccountId,
				name = client.Name,
				address = client.Address,
				region = client.Region.ToString()
			};

			model.SetBaseRecordValues(client);
			return model;
		}

		public static PagedList<Client, ClientViewModel> GetPagedList(this IEnumerable<Client> clients, int page = 1, int pageSize = 999)
		{
			var pageList = new PagedList<Client, ClientViewModel>(clients, page, pageSize);

			pageList.ViewList = clients.Select(s => MapViewModel(s)).ToList();

			pageList.List = null;

			return pageList;
		}




		public static IEnumerable<Client> GetOrdered(this IEnumerable<Client> clients)
		{
			return clients.OrderBy(c => c.Order);
		}

		public static IEnumerable<Client> FilterByRegion(this IEnumerable<Client> clients, Region region)
		{
			return clients.Where(c => c.Region == region);
		}

	}
}
