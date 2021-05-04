using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DTO.DTOs.PatientRegistrar;
using HospitalAppointment.UI.Tools.ActiveUserContext;
using Microsoft.AspNetCore.Http;

namespace HospitalAppointment.UI.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    public class PatientRegistrarController : Controller
    {
        private readonly ActiveSuperAdmin _activeSuperAdmin;
        private readonly IMapper _mapper;
        private readonly IRolService _rolService;
        private readonly IUserService _userService;
        private readonly IPatientRegistrarService _patientRegistrarService;
        public PatientRegistrarController(IPatientRegistrarService patientRegistrarService, IMapper mapper, IRolService rolService, IHttpContextAccessor httpContextAccessor, IUserService userService, ISuperAdminService superAdminService)
        {
            _activeSuperAdmin = new ActiveSuperAdmin(httpContextAccessor, userService, superAdminService);
            _mapper = mapper;
            _rolService = rolService;
            _userService = userService;
            _patientRegistrarService = patientRegistrarService;
        }

        public IActionResult Index()
        {
            TempData["ActiveSuperAdmin"] = _activeSuperAdmin.GetActiveSuperAdmin();
            var patientRegistrarListDto =
                _mapper.Map<List<PatientRegistrarListDto>>(_patientRegistrarService
                    .GetPatientRegistrarsWithAllTables());
            return View(patientRegistrarListDto);
        }

        public IActionResult CreatePatientRegistrar()
        {
            TempData["ActiveSuperAdmin"] = _activeSuperAdmin.GetActiveSuperAdmin();
            var patientRegistrarAddDto = new PatientRegistrarAddDto(){RolId = _rolService.GetPatientRegistrarRol().Id};
            return View(patientRegistrarAddDto);
        }

        [HttpPost]
        public IActionResult CreatePatientRegistrar(PatientRegistrarAddDto patientRegistrarAddDto)
        {
            var patientRegistrarUser = new User()
            {
                Tcno = patientRegistrarAddDto.Tcno,
                RolId = patientRegistrarAddDto.RolId,
                Name = patientRegistrarAddDto.Name,
                SurName = patientRegistrarAddDto.SurName,
                Email = patientRegistrarAddDto.Email,
                BirthDate = patientRegistrarAddDto.BirthDate,
                Telephone = patientRegistrarAddDto.Telephone,
                Gender = patientRegistrarAddDto.Gender,
                Password = patientRegistrarAddDto.Password
            };
            int userId = _userService.AddWithRetObject(patientRegistrarUser).Id;
            var patientRegistrar = new DataAccess.Concrete.EntityFrameworkCore.Entities.PatientRegistrar()
            {
                UserId = userId,
                TellerNumber = patientRegistrarAddDto.TellerNumber,
                SuperAdminId = 1
            };
            _patientRegistrarService.Add(patientRegistrar);
            return RedirectToAction("Index");
        }
    }
}
