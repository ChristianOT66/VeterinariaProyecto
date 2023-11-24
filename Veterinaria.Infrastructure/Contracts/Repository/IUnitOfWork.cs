using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Infrastructure.Contracts.Repository
{
    public interface IUnitOfWork<out T>
        where T : DbContext
    {
        T Context { get; }

        void CreateTransaction();

        void Commit();

        void Rollback();

        void Save();

        IRepository<TEntity> Repository<TEntity>()
            where TEntity : class;
    }
}
