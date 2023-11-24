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
    public class MascotaRepository : Repository<Mascota>, IRepository<Mascota>
    {
        public MascotaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
