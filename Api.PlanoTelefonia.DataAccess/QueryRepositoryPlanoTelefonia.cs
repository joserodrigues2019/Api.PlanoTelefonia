using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Api.PlanoTelefonia.DataAccess
{
    public class QueryRepositoryPlanoTelefonia<T> : IQueryRepositoryPlanoTelefonia<T> where T : BaseEntity
	{
		private readonly IDatabaseContextPlanoTelefonia _dbContext;

        public QueryRepositoryPlanoTelefonia(IDatabaseContextPlanoTelefonia dbContext)
        {
			_dbContext = dbContext;

		}

		public List<U> Listar<U>(Expression<Func<T, bool>> predicate)
		{
			return AutoMapper.Mapper.Map<List<U>>(this.Listar(predicate));
		}

		/// <summary>
		/// https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="orderBy"></param>
		/// <param name="includeProperties"></param>
		/// <returns></returns>
		public List<T> Listar(Expression<Func<T, bool>> filter = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			string includeProperties = "")
		{
			IQueryable<T> query = _dbContext.Set<T>();

			if (filter != null)
			{
				query = query.Where(filter);
			}

			foreach (var includeProperty in includeProperties.Split
				(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			if (orderBy != null)
			{
				return orderBy(query)
					.AsNoTracking()
					.ToList();
			}
			else
			{
				return query
					.AsNoTracking()
					.ToList();
			}
		}

	}
}
