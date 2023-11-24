using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Models.ViewModels;

namespace WebApplication1.Data
{
    public class DA_Usuario
    {
        //USAR REFERENCIAS MODELS

        public List<Usuario> ListaUsuario()
        {

            return new List<Usuario>
            {
                new Usuario{ Nombre ="Aaron", Correo = "administrador@gmail.com", Clave= "12345678" , Roles = new string[]{"Administrador"} },
                new Usuario{ Nombre ="Christian", Correo = "empleado@gmail.com", Clave= "543210" , Roles = new string[]{"Empleado"} }

            };

        }

        public Usuario ValidarUsuario(string _correo, string _clave)
        {

            return ListaUsuario().Where(item => item.Correo == _correo && item.Clave == _clave).FirstOrDefault();

        }

    }
}