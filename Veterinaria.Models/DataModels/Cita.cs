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
    public class Cita
    {
        public Cita() { }
        
        public Cita(CitaInputModel input)
        {
            Update(input);
        }

        [Key]
        public int IdCita { get; set; }

        [Required]
        public DateTime Fecha { get; set; }


        [Required]
        [DisplayName("Nombre del Dueño")]
        [ForeignKey("IdDueno")]
        public string IdDueno { get; set; }

        [Required]
        [DisplayName("Id del Veterinario")]
        [ForeignKey("IdVeterinario")]
        public string IdVeterinario { get; set; }

        public Veterinario Veterinario { get; set; }

        
        public void Update(CitaInputModel input)
        {
            IdCita = input.IdCita;
            Fecha = input.Fecha;
            IdDueno = input.IdDueno;
            IdVeterinario = input.IdVeterinario;
        }
        

    }
}
