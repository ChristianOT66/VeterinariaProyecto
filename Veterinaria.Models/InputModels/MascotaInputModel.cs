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
    public class MascotaInputModel
    {
        public MascotaInputModel()
        {

        }

        public MascotaInputModel(Mascota mascota)
        {
            IdMascota = mascota.IdMascota;
            Nombre = mascota.Nombre;
            Raza = mascota.Raza;
            IdDueno = mascota.IdDueno;
            Dueno = mascota.Dueno;
        }
        public int IdMascota { get; set; }
        public string Nombre { get; set; }

        public string Raza { get; set; }

        [DisplayName("Id del dueño")]
        public int IdDueno { get; set; }

        public Dueno Dueno { get; set; }
    }
}
