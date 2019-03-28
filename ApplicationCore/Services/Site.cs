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
	public interface ISiteService
	{
		Task<IEnumerable<Site>> FetchSitesAsync();

		Task<IEnumerable<Site>> FetchByIdsAsync(IList<int> ids);		

		Task<Site> GetByIdAsync(int id);

		Site GetById(int id);

		Site GetByName(string name);

		Task<Site> CreateAsync(Site site);

		Task UpdateAsync(Site site);

		Task DeleteAsync(Site site);

		Task DeleteAsync(IList<int> ids);

		void UpdateRange(IEnumerable<Site> sites);

		
	}
	public class SiteService : ISiteService
	{
		private readonly IDefaultRepository<Site> siteRepository;

		public SiteService(IDefaultRepository<Site> siteRepository)
		{
			this.siteRepository = siteRepository;
		}

		public async Task<IEnumerable<Site>> FetchSitesAsync()
		{
			return await GetAllAsync();
		}

		async Task<IEnumerable<Site>> GetAllAsync()
		{
			var spec = new SiteFilterSpecifications();
			return await siteRepository.ListAsync(spec);
		}

		public async Task<IEnumerable<Site>> FetchByIdsAsync(IList<int> ids)
		{
			var spec = new SiteFilterSpecifications(ids);
			return await siteRepository.ListAsync(spec);
		}


		public async Task<Site> GetByIdAsync(int id) => await siteRepository.GetByIdAsync(id);

		public Site GetById(int id)
		{
			var spec = new SiteFilterSpecifications(id);
			return siteRepository.GetSingleBySpec(spec);
		}

		public Site GetByName(string name)
		{
			var spec = new SiteFilterSpecifications(name);
			return siteRepository.GetSingleBySpec(spec);
		}

		public async Task<Site> CreateAsync(Site site) => await siteRepository.AddAsync(site);

		public async Task UpdateAsync(Site site) => await siteRepository.UpdateAsync(site);

		public void UpdateRange(IEnumerable<Site> sites) => siteRepository.UpdateRange(sites);

		public async Task DeleteAsync(Site site) => await siteRepository.DeleteAsync(site);

		public async Task DeleteAsync(IList<int> ids)
		{
			var sites = await GetByIdsAsync(ids);
			siteRepository.DeleteRange(sites);
		}

		async Task<IEnumerable<Site>> GetByKeywordAsync(string keyword)
		{
			var filter = new SiteKeywordFilterSpecifications(keyword);

			return await siteRepository.ListAsync(filter);
		}

		


		async Task<IEnumerable<Site>> GetByIdsAsync(IList<int> ids)
		{
			var filter = new SiteFilterSpecifications(ids);

			return await siteRepository.ListAsync(filter);
		}

	}
}
