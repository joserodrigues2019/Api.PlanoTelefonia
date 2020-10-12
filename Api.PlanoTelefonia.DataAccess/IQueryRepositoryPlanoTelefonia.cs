using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Api.PlanoTelefonia.DataAccess
{
    public interface IQueryRepositoryPlanoTelefonia<T> where T : BaseEntity
    {
        List<U> Listar<U>(Expression<Func<T, bool>> predicate);
        List<T> Listar(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                string includeProperties = "");
    }
}
