using Microsoft.AspNetCore.Mvc;

using Veterinaria.Models.ViewModels;
using Veterinaria.Models.DataModels;
using WebApplication1.Data;

//1.- REFERENCES AUTHENTICATION COOKIE
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Veterinaria.Website.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //USAR REFERENCIAS Models y Data
        [HttpPost]
        public async Task<IActionResult> Index(Usuario _usuario)
        {
            DA_Usuario _da_usuario = new DA_Usuario();

            var usuario = _da_usuario.ValidarUsuario(_usuario.Correo, _usuario.Clave);

            if (usuario != null)
            {


                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }
        public async Task<IActionResult> Salir()
        {

            return RedirectToAction("Index", "Acceso");

        }
    }
}