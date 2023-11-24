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
    public class HistorialRepository : Repository<Historial>, IRepository<Historial>
    {
        public HistorialRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
