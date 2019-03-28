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
	public interface IPageService
	{
		Task<IEnumerable<Page>> FetchPages();

		Task<IEnumerable<Page>> FetchByIdsAsync(IList<int> ids);		

		Task<Page> GetByIdAsync(int id);

		Page GetById(int id);

		Page GetByUrl(string url);

		Task<Page> CreateAsync(Page page);

		Task UpdateAsync(Page page);

		Task DeleteAsync(Page page);

		Task DeleteAsync(IList<int> ids);

		void UpdateRange(IEnumerable<Page> pages);

		
	}
	public class PageService : IPageService
	{
		private readonly IDefaultRepository<Page> pageRepository;

		public PageService(IDefaultRepository<Page> pageRepository)
		{
			this.pageRepository = pageRepository;
		}

		public async Task<IEnumerable<Page>> FetchPages()
		{

			return await GetAllAsync();
		}

		public async Task<IEnumerable<Page>> FetchByIdsAsync(IList<int> ids)
		{
			var spec = new PageFilterSpecifications(ids);
			return await pageRepository.ListAsync(spec);
		}


		public async Task<Page> GetByIdAsync(int id) => await pageRepository.GetByIdAsync(id);

		public Page GetById(int id)
		{
			return pageRepository.GetById(id);
		}

		public Page GetByUrl(string url)
		{
			var spec = new PageFilterSpecifications(url);
			return pageRepository.GetSingleBySpec(spec);
		}

		public async Task<Page> CreateAsync(Page page) => await pageRepository.AddAsync(page);

		public async Task UpdateAsync(Page page) => await pageRepository.UpdateAsync(page);

		public void UpdateRange(IEnumerable<Page> pages) => pageRepository.UpdateRange(pages);

		public async Task DeleteAsync(Page page) => await pageRepository.DeleteAsync(page);

		public async Task DeleteAsync(IList<int> ids)
		{
			var pages = await GetByIdsAsync(ids);
			pageRepository.DeleteRange(pages);
		}

		

		async Task<IEnumerable<Page>> GetAllAsync() => await pageRepository.ListAllAsync();


		async Task<IEnumerable<Page>> GetByIdsAsync(IList<int> ids)
		{
			var filter = new PageFilterSpecifications(ids);

			return await pageRepository.ListAsync(filter);
		}

	}
}
