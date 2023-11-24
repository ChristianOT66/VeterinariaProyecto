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
    public class HistorialController : Controller
    {
        public HistorialController
            (
                ILogger<HistorialController> logger,
                // IEmailSenderService emailSender,
                IUnitOfWork<ApplicationDbContext> unitOfWork
            )
        {
            _logger = logger;
            // _emailSender = emailSender;
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<Historial>();
        }

        readonly ILogger<HistorialController> _logger;
        // readonly IEmailSenderService _emailSender;

        readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        readonly IRepository<Historial> _repository;

        public IActionResult Index()
        {
            // Carga de la fuente de datos la lista de autores
            // utilizando el repositorio de autores
            List<Historial> HistorialsList = _repository.GetAll().ToList();

            // Convierte el Data Model a Input Model
            return View
                (
                    HistorialsList.ConvertAll
                    (
                        e =>
                            new HistorialInputModel
                            {
                                IdHistorial = e.IdHistorial,
                                Fecha = e.Fecha,
                                IdVeterinario = e.IdVeterinario,
                                Veterinario = e.Veterinario,
                                MotivoConsulta = e.MotivoConsulta,
                                Diagnostico = e.Diagnostico

                            }
                    )
                );
        }

        [HttpGet]
        public IActionResult Upsert(int id = 0)
        {
            HistorialViewModel model = new HistorialViewModel();

            if (id > 0)
            {
                // Busca el Historial en la fuente de datos
                Historial Historial = _repository.Get(id);

                // Si no existe devuelve un 404  
                if (Historial == null)
                    return NotFound();

                model.Historial = new HistorialInputModel(Historial);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Upsert(HistorialViewModel model)
        {
            if (ModelState.IsValid)
            {
                // crea un nuevo Historial o lo busca en la fuente de datos
                Historial Historial =
                    model.Historial.IdHistorial == 0
                        ? new Historial(model.Historial)
                        : _repository.Get(model.Historial.IdHistorial);

                if (model.Historial.IdHistorial > 0)
                {

                    Historial.Update(model.Historial);
                    _repository.Update(Historial);
                }
                else
                {
                    _repository.Insert(Historial);
                }


                _unitOfWork.Save();
                /*
                var email =
                    new Email
                    {
                        Receiver = model.Historial.Email,
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
