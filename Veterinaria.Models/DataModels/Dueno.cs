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
    public class Dueno
    {
        public Dueno() { }

        
        public Dueno(DuenoInputModel input)
        {
            Update(input);
        }
        

        [Key]
        public int IdDueno { get; set; }

        [DisplayName("Nombre del Dueño")]
        public string Nombre { get; set; }

        [MaxLength(40)]
        public string Apellido { get; set; }

        [MaxLength(40)]
        public string Cedula { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Correo { get; set; }

        
        public void Update(DuenoInputModel input)
        {
            IdDueno = input.IdDueno;
            Nombre = input.Nombre;
            Apellido = input.Apellido;
            Cedula = input.Cedula;
            Correo = input.Correo;
        }

        
    }
}
