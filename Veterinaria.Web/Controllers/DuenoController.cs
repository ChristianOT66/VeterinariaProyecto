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
    public class DuenoController : Controller
    {
        public DuenoController
            (
                ILogger<DuenoController> logger,
                // IEmailSenderService emailSender,
                IUnitOfWork<ApplicationDbContext> unitOfWork
            )
        {
            _logger = logger;
            // _emailSender = emailSender;
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<Dueno>();
        }

        readonly ILogger<DuenoController> _logger;
        // readonly IEmailSenderService _emailSender;

        readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        readonly IRepository<Dueno> _repository;

        public IActionResult Index()
        {
            // Carga de la fuente de datos la lista de autores
            // utilizando el repositorio de autores
            List<Dueno> DuenosList = _repository.GetAll().ToList();

            // Convierte el Data Model a Input Model
            return View
                (
                    DuenosList.ConvertAll
                    (
                        e =>
                            new DuenoInputModel
                            {
                                IdDueno = e.IdDueno,
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
            DuenoViewModel model = new DuenoViewModel();

            if (id > 0)
            {
                // Busca el Dueno en la fuente de datos
                Dueno Dueno = _repository.Get(id);

                // Si no existe devuelve un 404  
                if (Dueno == null)
                    return NotFound();

                model.Dueno = new DuenoInputModel(Dueno);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Upsert(DuenoViewModel model)
        {
            if (ModelState.IsValid)
            {
                // crea un nuevo Dueno o lo busca en la fuente de datos
                Dueno Dueno =
                    model.Dueno.IdDueno == 0
                        ? new Dueno(model.Dueno)
                        : _repository.Get(model.Dueno.IdDueno);

                if (model.Dueno.IdDueno > 0)
                {

                    Dueno.Update(model.Dueno);
                    _repository.Update(Dueno);
                }
                else
                {
                    _repository.Insert(Dueno);
                }


                _unitOfWork.Save();
                /*
                var email =
                    new Email
                    {
                        Receiver = model.Dueno.Email,
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
