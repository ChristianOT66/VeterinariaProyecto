using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Veterinaria.Infrastructure.Contracts.Repository;
using Veterinaria.Infrastructure;
using Veterinaria.Models.DataModels;
using Veterinaria.Models.InputModels;
using Veterinaria.Models.ViewModels;

namespace Veterinaria.Website.Controllers
{
    public class VeterinarioController : Controller
    {
        public VeterinarioController
            (
                ILogger<VeterinarioController> logger,
                // IEmailSenderService emailSender,
                IUnitOfWork<ApplicationDbContext> unitOfWork
            )
        {
            _logger = logger;
            // _emailSender = emailSender;
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<Veterinario>();
        }

        readonly ILogger<VeterinarioController> _logger;
        // readonly IEmailSenderService _emailSender;

        readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        readonly IRepository<Veterinario> _repository;

        public IActionResult Index()
        {
            // Carga de la fuente de datos la lista de autores
            // utilizando el repositorio de autores
            List<Veterinario> VeterinariosList = _repository.GetAll().ToList();

            // Convierte el Data Model a Input Model
            return View
                (
                    VeterinariosList.ConvertAll
                    (
                        e =>
                            new VeterinarioInputModel
                            {
                                IdVeterinario = e.IdVeterinario,
                                Nombre = e.Nombre,
                                Apellido = e.Apellido,
                                Cedula = e.Cedula,
                                Correo = e.Correo

                            }
                    )
                );
        }

        [HttpGet]
        public IActionResult Upsert(int id = 0)
        {
            VeterinarioViewModel model = new VeterinarioViewModel();

            if (id > 0)
            {
                // Busca el Veterinario en la fuente de datos
                Veterinario Veterinario = _repository.Get(id);

                // Si no existe devuelve un 404  
                if (Veterinario == null)
                    return NotFound();

                model.Veterinario = new VeterinarioInputModel(Veterinario);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Upsert(VeterinarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                // crea un nuevo Veterinario o lo busca en la fuente de datos
                Veterinario Veterinario =
                    model.Veterinario.IdVeterinario == 0
                        ? new Veterinario(model.Veterinario)
                        : _repository.Get(model.Veterinario.IdVeterinario);

                if (model.Veterinario.IdVeterinario > 0)
                {

                    Veterinario.Update(model.Veterinario);
                    _repository.Update(Veterinario);
                }
                else
                {
                    _repository.Insert(Veterinario);
                }


                _unitOfWork.Save();
                /*
                var email =
                    new Email
                    {
                        Receiver = model.Veterinario.Email,
                        Subject = "SC-701 Prueba Correo Electronico",
                        Body = "Hola!"
                    };

                _emailSender.SendEmail(email);
                */
            }

            return View(model);
        }
    }
}
