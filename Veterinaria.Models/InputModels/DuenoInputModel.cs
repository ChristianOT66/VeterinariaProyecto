using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Models.DataModels;

namespace Veterinaria.Models.InputModels
{
    public class DuenoInputModel
    {
        public DuenoInputModel()
        {

        }

        public DuenoInputModel(Dueno dueno)
        {
            IdDueno = dueno.IdDueno;
            Nombre = dueno.Nombre;
            Apellido = dueno.Apellido;
            Cedula = dueno.Cedula;
            Correo = dueno.Correo;
        }
        public int IdDueno { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Cedula { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Correo { get; set; }

        public string FullName
        {
            get { return string.Join(" ", Nombre, Apellido); }
        }
    }
}
