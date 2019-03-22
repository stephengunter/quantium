using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;


namespace Infrastructure.DataAccess
{
	public abstract class BaseSpecification<T> : ISpecification<T>
	{
		protected BaseSpecification(Expression<Func<T, bool>> criteria = null)
		{
			if(criteria!=null) Criteria = criteria;
		}
		public Expression<Func<T, bool>> Criteria { get; set; }
		public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
		public List<string> IncludeStrings { get; } = new List<string>();
		public Expression<Func<T, object>> OrderBy { get; private set; }
		public Expression<Func<T, object>> OrderByDescending { get; private set; }

		public int Take { get; private set; }
		public int Skip { get; private set; }
		public bool isPagingEnabled { get; private set; } = false;

		protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
		{
			Includes.Add(includeExpression);
		}
		protected virtual void AddInclude(string includeString)
		{
			IncludeStrings.Add(includeString);
		}
		protected virtual void ApplyPaging(int skip, int take)
		{
			Skip = skip;
			Take = take;
			isPagingEnabled = true;
		}
		protected virtual void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
		{
			OrderBy = orderByExpression;
		}
		protected virtual void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
		{
			OrderByDescending = orderByDescendingExpression;
		}
	}


	public class SpecificationEvaluator<T> where T : class
	{

		public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
		{
			var query = inputQuery;

			// modify the IQueryable using the specification's criteria expression
			if (specification.Criteria != null)
			{
				query = query.Where(specification.Criteria);
			}

			// Includes all expression-based includes
			query = specification.Includes.Aggregate(query,
									(current, include) => current.Include(include));

			// Include any string-based include statements
			query = specification.IncludeStrings.Aggregate(query,
									(current, include) => current.Include(include));

			// Apply ordering if expressions are set
			if (specification.OrderBy != null)
			{
				query = query.OrderBy(specification.OrderBy);
			}
			else if (specification.OrderByDescending != null)
			{
				query = query.OrderByDescending(specification.OrderByDescending);
			}

			// Apply paging if enabled
			if (specification.isPagingEnabled)
			{
				query = query.Skip(specification.Skip)
							 .Take(specification.Take);
			}
			return query;
		}
	}
}