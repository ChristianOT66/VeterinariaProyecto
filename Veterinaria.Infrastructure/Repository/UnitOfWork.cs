using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Infrastructure.Contracts.Repository;

namespace Veterinaria.Infrastructure.Repository
{
    public class UnitOfWork<T> : IUnitOfWork<T>, IDisposable
        where T : DbContext
    {
        public UnitOfWork(T dbContext)
        {
            _dbContext = dbContext;
            _repositories = new Dictionary<string, object>();
        }

        readonly T _dbContext;

        IDbContextTransaction _transaction;
        IDictionary<string, object> _repositories;
        bool isDisposed = false;

        public T Context
        {
            get { return _dbContext; }
        }

        public void CreateTransaction()
        {
            if (_transaction != null)
            {
                throw new InvalidOperationException();
            }

            _transaction = _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (_transaction == null)
            {
                throw new NullReferenceException();
            }

            _transaction.Commit();

            _transaction.Dispose();
            _transaction = null;
        }

        public void Rollback()
        {
            if (_transaction == null)
            {
                throw new NullReferenceException();
            }

            _transaction.Rollback();

            _transaction.Dispose();
            _transaction = null;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public IRepository<TEntity> Repository<TEntity>()
            where TEntity : class
        {
            var repository = Context.GetService<IRepository<TEntity>>();
            if (repository != null)
            {
                return repository;
            }

            var type = typeof(TEntity);
            var typeName = type.Name;

            if (!_repositories.ContainsKey(typeName))
            {
                var repositoryInstance = new Repository<TEntity>(_dbContext);
                _repositories.Add(typeName, repositoryInstance);
            }

            return (IRepository<TEntity>)_repositories[typeName];
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!isDisposed)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                    }

                    _dbContext.Dispose();
                }
            }

            isDisposed = true;
        }
    }
}
