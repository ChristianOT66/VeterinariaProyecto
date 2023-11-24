using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Models.DataModels;

namespace Veterinaria.Infrastructure.Contracts
{
    public interface IApplicationDbContext
    {

        DbSet<Veterinario> Veterinarios { get; set; }
        DbSet<Dueno> Dueno { get; set; }
        DbSet<Mascota> Mascota { get; set; }
        DbSet<Cita> Cita { get; set; }
        DbSet<Historial> Historial { get; set; }

        void SaveChanges();

        void Update<T>(T entity);
    }
}
