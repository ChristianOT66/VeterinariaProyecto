using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Models.DataModels;
using Veterinaria.Models.InputModels;

namespace Veterinaria.Models.ViewModels
{
    public class DuenoViewModel
    {
        public DuenoViewModel()
        {
            Dueno = new DuenoInputModel();
        }

        public DuenoInputModel Dueno { get; set; }
    }
}
