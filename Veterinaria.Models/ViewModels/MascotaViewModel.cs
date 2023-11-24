using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Models.DataModels;
using Veterinaria.Models.InputModels;

namespace Veterinaria.Models.ViewModels
{
    public class MascotaViewModel
    {
        public MascotaViewModel()
        {
            Mascota = new MascotaInputModel();
        }

        public MascotaInputModel Mascota { get; set; }
    }
}
