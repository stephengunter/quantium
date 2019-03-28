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
	public interface IHealthService
	{
		Task<IEnumerable<Health>> FetchHealths();

		Task<IEnumerable<Health>> FetchByIdsAsync(IList<int> ids);		

		Task<Health> GetByIdAsync(int id);

		Health GetById(int id);


		Task<Health> CreateAsync(Health health);

		Task UpdateAsync(Health health);

		Task DeleteAsync(Health health);

		Task DeleteAsync(IList<int> ids);

		void UpdateRange(IEnumerable<Health> healths);

		
	}
	public class HealthService : IHealthService
	{
		private readonly IDefaultRepository<Health> healthRepository;

		public HealthService(IDefaultRepository<Health> healthRepository)
		{
			this.healthRepository = healthRepository;
		}

		public async Task<IEnumerable<Health>> FetchHealths()
		{
			return await GetAllAsync();
		}

		public async Task<IEnumerable<Health>> FetchByIdsAsync(IList<int> ids)
		{
			var spec = new HealthFilterSpecifications(ids);
			return await healthRepository.ListAsync(spec);
		}


		public async Task<Health> GetByIdAsync(int id) => await healthRepository.GetByIdAsync(id);

		public Health GetById(int id)
		{
			var spec = new HealthFilterSpecifications(id);
			return healthRepository.GetSingleBySpec(spec);
		}

		

		public async Task<Health> CreateAsync(Health health) => await healthRepository.AddAsync(health);

		public async Task UpdateAsync(Health health) => await healthRepository.UpdateAsync(health);

		public void UpdateRange(IEnumerable<Health> healths) => healthRepository.UpdateRange(healths);

		public async Task DeleteAsync(Health health) => await healthRepository.DeleteAsync(health);

		public async Task DeleteAsync(IList<int> ids)
		{
			var healths = await GetByIdsAsync(ids);
			healthRepository.DeleteRange(healths);
		}



		public async Task<IEnumerable<Health>> GetAllAsync()
		{
			var spec = new HealthFilterSpecifications();
			return await healthRepository.ListAsync(spec);
		}


		async Task<IEnumerable<Health>> GetByIdsAsync(IList<int> ids)
		{
			var filter = new HealthFilterSpecifications(ids);

			return await healthRepository.ListAsync(filter);
		}

	}
}
