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
    public class Mascota
    {
        public Mascota() { }

        
        public Mascota(MascotaInputModel input)
        {
            Update(input);
        }
        

        [Key]
        public int IdMascota { get; set; }

        [DisplayName("Nombre Mascota")]
        public string Nombre { get; set; }

        [MaxLength(40)]
        public string Raza { get; set; }

        [Required]
        [ForeignKey("Id del Dueño")]
        public int IdDueno { get; set; }

        public Dueno Dueno { get; set; }    

        
        public void Update(MascotaInputModel input)
        {
            IdMascota = input.IdMascota;
            Nombre = input.Nombre;
            Raza = input.Raza;
            IdDueno = input.IdDueno;

        }
        

    }
}
