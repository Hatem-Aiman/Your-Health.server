﻿using Microsoft.AspNetCore.Mvc;
using Your_Health.server.Services;
using Your_Health.Server.Models;

namespace Your_Health.server.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        public IActionResult Index()
        {
            return Ok("Works");
        }

        public async Task<IActionResult> GetAppointments()
        {
            var result =await _appointmentService.GetAllAppointments();
            return Ok(result);
        }

        public async Task<IActionResult> GetAppointment(int id)
        {
            var result =await _appointmentService.GetAppointmentById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateAppointment(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _appointmentService.CreateAppointment(appointment);
                return Ok(appointment);
            }
            return Ok("Model Not Valid");
        }

        public IActionResult UpdateAppointment(int id, Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return BadRequest();
            }
            return Ok("Updated");
        }

        public IActionResult DeleteAppointment(int id, Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }
    }
}
