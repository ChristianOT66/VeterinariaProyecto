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
    public class MascotaController : Controller
    {
        public MascotaController
            (
                ILogger<MascotaController> logger,
                // IEmailSenderService emailSender,
                IUnitOfWork<ApplicationDbContext> unitOfWork
            )
        {
            _logger = logger;
            // _emailSender = emailSender;
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<Mascota>();
        }

        readonly ILogger<MascotaController> _logger;
        // readonly IEmailSenderService _emailSender;

        readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        readonly IRepository<Mascota> _repository;

        public IActionResult Index()
        {
            // Carga de la fuente de datos la lista de autores
            // utilizando el repositorio de autores
            List<Mascota> MascotasList = _repository.GetAll().ToList();

            // Convierte el Data Model a Input Model
            return View
                (
                    MascotasList.ConvertAll
                    (
                        e =>
                            new MascotaInputModel
                            {
                                IdMascota = e.IdMascota,
                                Nombre = e.Nombre,
                                Raza = e.Raza,
                                IdDueno = e.IdDueno,
                                Dueno = e.Dueno

                            }
                    )
                );
        }

        [HttpGet]
        public IActionResult Upsert(int id = 0)
        {
            MascotaViewModel model = new MascotaViewModel();

            if (id > 0)
            {
                // Busca el Mascota en la fuente de datos
                Mascota Mascota = _repository.Get(id);

                // Si no existe devuelve un 404  
                if (Mascota == null)
                    return NotFound();

                model.Mascota = new MascotaInputModel(Mascota);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Upsert(MascotaViewModel model)
        {
            if (ModelState.IsValid)
            {
                // crea un nuevo Mascota o lo busca en la fuente de datos
                Mascota Mascota =
                    model.Mascota.IdMascota == 0
                        ? new Mascota(model.Mascota)
                        : _repository.Get(model.Mascota.IdMascota);

                if (model.Mascota.IdMascota > 0)
                {

                    Mascota.Update(model.Mascota);
                    _repository.Update(Mascota);
                }
                else
                {
                    _repository.Insert(Mascota);
                }


                _unitOfWork.Save();
                /*
                var email =
                    new Email
                    {
                        Receiver = model.Mascota.Email,
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
