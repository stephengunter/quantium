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
		Task<IEnumerable<Client>> FetchClients(string keyword = "");

		Task<IEnumerable<Client>> FetchByIdsAsync(IList<int> ids);		

		Task<Client> GetByIdAsync(int id);

		Client GetById(int id);

		Client GetByName(string name);

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

		public async Task<IEnumerable<Client>> FetchClients(string keyword = "")
		{
			
			if (String.IsNullOrEmpty(keyword)) return await GetAllAsync();

			return await GetByKeywordAsync(keyword);
		}

		public async Task<IEnumerable<Client>> FetchByIdsAsync(IList<int> ids)
		{
			var spec = new ClientFilterSpecifications(ids);
			return await clientRepository.ListAsync(spec);
		}


		public async Task<Client> GetByIdAsync(int id) => await clientRepository.GetByIdAsync(id);

		public Client GetById(int id)
		{
			var spec = new ClientFilterSpecifications(id);
			return clientRepository.GetSingleBySpec(spec);
		}

		public Client GetByName(string name)
		{
			var spec = new ClientFilterSpecifications(name);
			return clientRepository.GetSingleBySpec(spec);
		}

		public async Task<Client> CreateAsync(Client client) => await clientRepository.AddAsync(client);

		public async Task UpdateAsync(Client client) => await clientRepository.UpdateAsync(client);

		public void UpdateRange(IEnumerable<Client> clients) => clientRepository.UpdateRange(clients);

		public async Task DeleteAsync(Client client) => await clientRepository.DeleteAsync(client);

		public async Task DeleteAsync(IList<int> ids)
		{
			var clients = await GetByIdsAsync(ids);
			clientRepository.DeleteRange(clients);
		}

		async Task<IEnumerable<Client>> GetByKeywordAsync(string keyword)
		{
			var filter = new ClientKeywordFilterSpecifications(keyword);

			return await clientRepository.ListAsync(filter);
		}

		async Task<IEnumerable<Client>> GetAllAsync() => await clientRepository.ListAllAsync();


		async Task<IEnumerable<Client>> GetByIdsAsync(IList<int> ids)
		{
			var filter = new ClientFilterSpecifications(ids);

			return await clientRepository.ListAsync(filter);
		}

	}
}
