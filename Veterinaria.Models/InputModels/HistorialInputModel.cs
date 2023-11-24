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
    public class HistorialInputModel
    {
        public HistorialInputModel()
        {

        }

        public HistorialInputModel(Historial historial)
        {
            IdHistorial = historial.IdHistorial;
            Fecha = historial.Fecha;
            IdVeterinario = historial.IdVeterinario;
            Veterinario = historial.Veterinario;
            MotivoConsulta = historial.MotivoConsulta;
            Diagnostico = historial.Diagnostico;

        }
        public int IdHistorial { get; set; }

        public DateTime Fecha { get; set; }

        [DisplayName("Id del veterinario")]
        public string IdVeterinario { get; set; }

        public Veterinario Veterinario { get; set; }

        [DisplayName("Motivo de consulta")]
        public string MotivoConsulta { get; set; }
        public string Diagnostico { get; set; }
    }
}
