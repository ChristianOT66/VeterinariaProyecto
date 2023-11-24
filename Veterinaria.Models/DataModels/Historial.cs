using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Models.InputModels;

namespace Veterinaria.Models.DataModels
{
    public class Historial
    {
        public Historial() { }

        
        public Historial(HistorialInputModel input)
        {
            Update(input);
        }
        
        [Key]
        public int IdHistorial { get; set; }


        public DateTime Fecha { get; set; }

        [Required]
        [DisplayName("Id del veterinario")]
        [ForeignKey("IdVeterinario")]
        public string IdVeterinario { get; set; }

        public Veterinario Veterinario { get; set; }

        [DisplayName("Motivo de consulta")]
        public string MotivoConsulta { get; set; }
        public string Diagnostico { get; set; }



        
        public void Update(HistorialInputModel input)
        {
            IdHistorial = input.IdHistorial;
            IdVeterinario = input.IdVeterinario;
            Fecha = input.Fecha;
            MotivoConsulta = input.MotivoConsulta;
            Diagnostico = input.Diagnostico;

        }
        

    }
}
