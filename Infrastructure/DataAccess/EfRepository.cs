using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;

namespace Infrastructure.DataAccess
{

	public abstract class EfRepository<T> : IRepository<T>, IAsyncRepository<T> where T : class
	{
		protected readonly DbContext _dbContext;
		protected readonly DbSet<T> _dbSet;

		public EfRepository(DbContext dbContext)
		{
			this._dbContext = dbContext;
			this._dbSet = dbContext.Set<T>();
		}

		public DbSet<T> DbSet { get { return _dbSet; } }

		void Save() => _dbContext.SaveChanges();
		async Task SaveAsync() => await _dbContext.SaveChangesAsync();

		public virtual T GetById(int id)
		{
			return DbSet.Find(id);
		}

		public T GetSingleBySpec(ISpecification<T> spec)
		{
			return List(spec).FirstOrDefault();
		}

		public virtual async Task<T> GetByIdAsync(int id)
		{
			return await DbSet.FindAsync(id);
		}

		public IEnumerable<T> ListAll()
		{
			return DbSet.AsEnumerable();
		}

		public async Task<IEnumerable<T>> ListAllAsync()
		{
			return await DbSet.ToListAsync();
		}

		public IEnumerable<T> List(ISpecification<T> spec)
		{
			return ApplySpecification(spec).AsEnumerable();
		}
		public async Task<IEnumerable<T>> ListAsync(ISpecification<T> spec)
		{
			return await ApplySpecification(spec).ToListAsync();
		}

		public int Count(ISpecification<T> spec)
		{
			return ApplySpecification(spec).Count();
		}

		public async Task<int> CountAsync(ISpecification<T> spec)
		{
			return await ApplySpecification(spec).CountAsync();
		}

		public T Add(T entity)
		{
			DbSet.Add(entity);
			Save();

			return entity;
		}


		public async Task<T> AddAsync(T entity)
		{
			DbSet.Add(entity);
			await SaveAsync();

			return entity;
		}


		public void Update(T entity)
		{
			_dbContext.Entry(entity).State = EntityState.Modified;
			Save();
		}

		public async Task UpdateAsync(T entity)
		{
			_dbContext.Entry(entity).State = EntityState.Modified;
			await SaveAsync();
		}

		public void Delete(T entity)
		{
			DbSet.Remove(entity);
			Save();
		}

		public async Task DeleteAsync(T entity)
		{
			DbSet.Remove(entity);
			await SaveAsync();
		}

		private IQueryable<T> ApplySpecification(ISpecification<T> spec)
		{
			return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
		}

		public T Get(Expression<Func<T, bool>> criteria)
		{
			return DbSet.Where(criteria).FirstOrDefault();
		}

		public List<T> GetMany(Expression<Func<T, bool>> criteria)
		{
			return DbSet.Where(criteria).ToList();
		}

		

		public void AddRange(IEnumerable<T> entityList)
		{
			DbSet.AddRange(entityList);
			Save();
		}

		public void UpdateRange(IEnumerable<T> entityList)
		{
			DbSet.UpdateRange(entityList);
			Save();
		}

		public void DeleteRange(IEnumerable<T> entityList)
		{
			DbSet.RemoveRange(entityList);
			Save();
		}

		
	}
}