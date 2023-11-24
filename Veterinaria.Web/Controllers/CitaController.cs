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
using Veterinaria.Website.Application.Contracts;

namespace Veterinaria.Website.Controllers
{
    public class CitaController : Controller
    {
        public CitaController
            (
                ILogger<CitaController> logger,
                IEmailSenderService emailSender,
                IUnitOfWork<ApplicationDbContext> unitOfWork
            )
        {
            _logger = logger;
             _emailSender = emailSender;
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<Cita>();
        }

        readonly ILogger<CitaController> _logger;
         readonly IEmailSenderService _emailSender;

        readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        readonly IRepository<Cita> _repository;

        public IActionResult Index()
        {

            List<Cita> CitasList = _repository.GetAll().ToList();

            // Convierte el Data Model a Input Model
            return View
                (
                    CitasList.ConvertAll
                    (
                        e =>
                            new CitaInputModel
                            {
                                IdCita = e.IdCita,
                                Fecha = e.Fecha,
                                IdDueno = e.IdDueno,
                                IdVeterinario = e.IdVeterinario,
                                Veterinario = e.Veterinario

                            }
                    )
                );
        }

        [HttpGet]
        public IActionResult Upsert(int id = 0)
        {
            CitaViewModel model = new CitaViewModel();

            if (id > 0)
            {
                // Busca el Cita en la fuente de datos
                Cita Cita = _repository.Get(id);

                // Si no existe devuelve un 404  
                if (Cita == null)
                    return NotFound();

                model.Cita = new CitaInputModel(Cita);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Upsert(CitaViewModel model)
        {
            if (ModelState.IsValid)
            {
                // crea un nuevo Cita o lo busca en la fuente de datos
                Cita Cita =
                    model.Cita.IdCita == 0
                        ? new Cita(model.Cita)
                        : _repository.Get(model.Cita.IdCita);

                if (model.Cita.IdCita > 0)
                {

                    Cita.Update(model.Cita);
                    _repository.Update(Cita);
                }
                else
                {
                    _repository.Insert(Cita);
                }


                _unitOfWork.Save();
                
                var email =
                    new Email
                    {
                        Receiver = "aaronhyp21@gmail.com",
                        Subject = "Confirmacion de cita en la veterinaria",
                        Body = "Hola! Su cita ha sido recibida"
                    };

                _emailSender.SendEmail(email);
                
            }

            return View(model);
        }
    }
}
