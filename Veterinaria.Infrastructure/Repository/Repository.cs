using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Infrastructure.Contracts.Repository;

namespace Veterinaria.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T>, IDisposable
        where T : class
    {
        // Crea una instancia del Gestor de Repositorio asociado al tipo modelo
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        // Atributos para el contexto de base de datos y el conjunto asociado al modelo
        readonly DbContext _dbContext;
        readonly DbSet<T> _dbSet;

        bool isDisposed = false;

        // Devuelve la primera entidad asociada con el id
        public T Get(object id)
        {
            return _dbSet.Find(id);
        }

        // Devuelve la primera entidad asociado con el criterio de busqueda
        public T Get(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(predicate);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return List();
        }

        // Inserta una nueva entidad en el conjunto si y sólo si ésta no es nula
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Add(entity);
        }

        // Actualiza una entidad existente en el conjunto si y sólo si ésta no es nula
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Update(entity);
        }

        // Borra una entidad existente en el conjunto si y sólo si ésta no es nula
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Remove(entity);
        }

        // Borra la primera entidad existente asociada al id
        public void Delete(object id)
        {
            T entity = Get(id);
            Delete(entity);
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = _dbSet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }

        public void Dispose()
        {
            if (!isDisposed)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                }
            }

            isDisposed = true;
        }
    }
}
