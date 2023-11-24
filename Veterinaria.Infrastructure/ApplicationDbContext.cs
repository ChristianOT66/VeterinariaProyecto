
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Infrastructure.Contracts;
using Veterinaria.Models.DataModels;

namespace Veterinaria.Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Veterinario> Veterinarios {get; set;}
        public DbSet<Dueno> Dueno {get; set;}
        public DbSet<Mascota> Mascota {get; set;}
        public DbSet<Cita> Cita {get; set;}
        public DbSet<Historial> Historial {get; set;}

        void IApplicationDbContext.SaveChanges()
        {
            base.SaveChanges();
        }

        void IApplicationDbContext.Update<T>(T entity)
        {
            base.Update(entity);
        }
    }
}
