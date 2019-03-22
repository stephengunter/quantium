using System.Collections.Generic;
using ApplicationCore.DataAccess;
using ApplicationCore.Models;
using ApplicationCore.Specifications;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Helpers;


namespace ApplicationCore.Services
{
	public interface IClientService
	{
		Task<IEnumerable<Client>> FetchClients();

		Task<IEnumerable<Client>> FetchByIdsAsync(IList<int> ids);

		

		Task<Client> GetByIdAsync(int id);

		Task<Client> CreateAsync(Client client);

		Task UpdateAsync(Client client);

		Task DeleteAsync(Client client);

		Task DeleteAsync(IList<int> ids);

		void UpdateRange(IEnumerable<Client> clients);
	}
	public class ClientService : IClientService
	{
		private readonly IDefaultRepository<Client> clientRepository;

		public ClientService(IDefaultRepository<Client> clientRepository)
		{
			this.clientRepository = clientRepository;
		}

		public async Task<IEnumerable<Client>> FetchClients()
		{
			var clients = await GetAllAsync();

			return clients;
		}

		public async Task<IEnumerable<Client>> FetchByIdsAsync(IList<int> ids)
		{
			var spec = new ClientFilterSpecifications(ids);
			return await clientRepository.ListAsync(spec);
		}


		public async Task<Client> GetByIdAsync(int id) => await clientRepository.GetByIdAsync(id);



		public async Task<Client> CreateAsync(Client client) => await clientRepository.AddAsync(client);

		public async Task UpdateAsync(Client client) => await clientRepository.UpdateAsync(client);

		public void UpdateRange(IEnumerable<Client> clients) => clientRepository.UpdateRange(clients);

		public async Task DeleteAsync(Client client) => await clientRepository.DeleteAsync(client);

		public async Task DeleteAsync(IList<int> ids)
		{
			var clients = await GetByIdsAsync(ids);
			clientRepository.DeleteRange(clients);
		}

		async Task<IEnumerable<Client>> GetAllAsync() => await clientRepository.ListAllAsync();


		async Task<IEnumerable<Client>> GetByIdsAsync(IList<int> ids)
		{
			var filter = new ClientFilterSpecifications(ids);

			return await clientRepository.ListAsync(filter);
		}
	}
}
