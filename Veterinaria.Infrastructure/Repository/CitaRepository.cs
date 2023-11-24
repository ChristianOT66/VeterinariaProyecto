using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Infrastructure.Contracts.Repository;
using Veterinaria.Models.DataModels;

namespace Veterinaria.Infrastructure.Repository
{
    public class CitaRepository : Repository<Cita>, IRepository<Cita>
    {
        public CitaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
