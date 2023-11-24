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
    public class VeterinarioInputModel
    {
        public VeterinarioInputModel()
        {

        }

        public VeterinarioInputModel(Veterinario veterinario)
        {
            IdVeterinario = veterinario.IdVeterinario;
            Nombre = veterinario.Nombre;
            Apellido = veterinario.Apellido;
            Cedula = veterinario.Cedula;
            Correo = veterinario.Correo;
        }
        public int IdVeterinario { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Cedula { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Correo { get; set; }

        public string FullName
        {
            get { return string.Join(" ", Nombre,Apellido); }
        }
    }
}
