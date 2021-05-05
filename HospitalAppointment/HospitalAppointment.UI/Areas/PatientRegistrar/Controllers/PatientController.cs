using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DTO.DTOs.Patient;
using HospitalAppointment.UI.Tools.ActiveUserContext;
using Microsoft.AspNetCore.Http;

namespace HospitalAppointment.UI.Areas.PatientRegistrar.Controllers
{
    [Area("PatientRegistrar")]
    public class PatientController : Controller
    {
        private ActivePatientRegistrar _activePatientRegistrar;
        private readonly IRolService _rolService;
        private readonly IUserService _userService;
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService,IRolService rolService,IHttpContextAccessor httpContextAccessor, IUserService userService, IPatientRegistrarService patientRegistrarService)
        {
            _activePatientRegistrar = new ActivePatientRegistrar(httpContextAccessor, userService, patientRegistrarService);
            _rolService = rolService;
            _userService = userService;
            _patientService = patientService;
        }
  

        public IActionResult CreatePatient()
        {
            TempData["ActiveSuperAdmin"] = _activePatientRegistrar.GetActivePatientRegistrar();
            var patientAddDto = new PatientAddDto() { RolId = _rolService.GetPatientRol().Id };
            return View(patientAddDto);
        }

        [HttpPost]
        public IActionResult CreatePatient(PatientAddDto patientAddDto)
        {
            var patientUser = new User()
            {
                Tcno = patientAddDto.Tcno,
                RolId = patientAddDto.RolId,
                Name = patientAddDto.Name,
                SurName = patientAddDto.SurName,
                Email = patientAddDto.Email,
                BirthDate = patientAddDto.BirthDate,
                Telephone = patientAddDto.Telephone,
                Gender = patientAddDto.Gender,
                Password = patientAddDto.Password
            };
            int userId = _userService.AddWithRetObject(patientUser).Id;
            var patient = new DataAccess.Concrete.EntityFrameworkCore.Entities.Patient()
            {
                AnaAdi = patientAddDto.AnaAdi,
                BabaAdi = patientAddDto.BabaAdi,
                UserId = userId,
                SuperAdminId = 1//Daha sonra refactor et
            };
            _patientService.Add(patient);
            return RedirectToAction("Index","Home");
        }

    }
}
