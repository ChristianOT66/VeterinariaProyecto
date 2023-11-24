using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Models.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.Models.InputModels
{
    public class CitaInputModel
    {
        public CitaInputModel()
        {

        }

        public CitaInputModel(Cita cita)
        {
            IdCita = cita.IdCita;
            Fecha = cita.Fecha;
            IdDueno = cita.IdDueno;
            IdVeterinario = cita.IdVeterinario;
            Veterinario = cita.Veterinario;
        }
        [DisplayName("Id de la cita")]
        public int IdCita { get; set; }

        public DateTime Fecha { get; set; }

        [DisplayName("Id del dueño")]
        public string IdDueno { get; set; }

        [DisplayName("Id del Veterinario")]
        public string IdVeterinario { get; set; }

        public Veterinario Veterinario { get; set; }
    }
}
