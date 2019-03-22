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
	public interface IDeploymentService
	{
		Task<IEnumerable<Deployment>> FetchDeployments();

		Task<IEnumerable<Deployment>> FetchByIdsAsync(IList<int> ids);

		

		Task<Deployment> GetByIdAsync(int id);

		Task<Deployment> CreateAsync(Deployment deployment);

		Task UpdateAsync(Deployment deployment);

		Task DeleteAsync(Deployment deployment);

		Task DeleteAsync(IList<int> ids);

		void UpdateRange(IEnumerable<Deployment> deployments);
	}
	public class DeploymentService : IDeploymentService
	{
		private readonly IDefaultRepository<Deployment> deploymentRepository;

		public DeploymentService(IDefaultRepository<Deployment> deploymentRepository)
		{
			this.deploymentRepository = deploymentRepository;
		}

		public async Task<IEnumerable<Deployment>> FetchDeployments()
		{
			var deployments = await GetAllAsync();

			return deployments;
		}

		public async Task<IEnumerable<Deployment>> FetchByIdsAsync(IList<int> ids)
		{
			var spec = new DeploymentFilterSpecifications(ids);
			return await deploymentRepository.ListAsync(spec);
		}


		public async Task<Deployment> GetByIdAsync(int id) => await deploymentRepository.GetByIdAsync(id);



		public async Task<Deployment> CreateAsync(Deployment deployment) => await deploymentRepository.AddAsync(deployment);

		public async Task UpdateAsync(Deployment deployment) => await deploymentRepository.UpdateAsync(deployment);

		public void UpdateRange(IEnumerable<Deployment> deployments) => deploymentRepository.UpdateRange(deployments);

		public async Task DeleteAsync(Deployment deployment) => await deploymentRepository.DeleteAsync(deployment);

		public async Task DeleteAsync(IList<int> ids)
		{
			var deployments = await GetByIdsAsync(ids);
			deploymentRepository.DeleteRange(deployments);
		}

		async Task<IEnumerable<Deployment>> GetAllAsync() => await deploymentRepository.ListAllAsync();


		async Task<IEnumerable<Deployment>> GetByIdsAsync(IList<int> ids)
		{
			var filter = new DeploymentFilterSpecifications(ids);

			return await deploymentRepository.ListAsync(filter);
		}
	}
}
