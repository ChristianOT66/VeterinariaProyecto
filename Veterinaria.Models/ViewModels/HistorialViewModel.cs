using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Models.DataModels;
using Veterinaria.Models.InputModels;

namespace Veterinaria.Models.ViewModels
{
    public class HistorialViewModel
    {
        public HistorialViewModel()
        {
            Historial = new HistorialInputModel();
        }

        public HistorialInputModel Historial { get; set; }
    }
}
