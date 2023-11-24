using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Infrastructure.Contracts.Repository
{
    public interface IRepository<T>
        where T : class
    {
        T Get(object id);

        T Get(Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetAll();

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(object id);

        IEnumerable<T> List(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
    }
}
