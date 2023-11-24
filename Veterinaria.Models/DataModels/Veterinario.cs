using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Models.InputModels;

namespace Veterinaria.Models.DataModels
{
    public class Veterinario
    {
        public Veterinario() { }
        
        public Veterinario(VeterinarioInputModel input)
        {
            Update(input);
        }
        
        [Key]
        public int IdVeterinario { get; set; }

        [DisplayName("Nombre Veterinario")]
        public string Nombre { get; set; }

        [MaxLength(40)]
        public string Apellido { get; set; }

        [MaxLength(40)]
        public string Cedula { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Correo { get; set; }
        
        public void Update(VeterinarioInputModel input)
        {
            IdVeterinario = input.IdVeterinario;
            Nombre = input.Nombre;
            Apellido = input.Apellido;
            Cedula = input.Cedula;
            Correo = input.Correo;
        }

        
    }
}
