using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DTO.DTOs.Department;
using HospitalAppointment.DTO.DTOs.Doctor;
using HospitalAppointment.UI.Tools.ActiveUserContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalAppointment.UI.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    public class DoctorController : Controller
    {
        private readonly ActiveSuperAdmin _activeSuperAdmin;
        private readonly IMapper _mapper;
        private readonly IDoctorService _doctorService;
        private readonly IUserService _userService;
        private readonly IDepartmentService _departmentService;
        private readonly IRolService _rolService;
        private readonly IPoliclinicService _policlinicService;
        public DoctorController(IRolService rolService, IDoctorService doctorService, IPoliclinicService policlinicService, IMapper mapper, IDepartmentService departmentService, IHttpContextAccessor httpContextAccessor, IUserService userService, ISuperAdminService superAdminService)
        {
            _activeSuperAdmin = new ActiveSuperAdmin(httpContextAccessor, userService, superAdminService);
            _doctorService = doctorService;
            _mapper = mapper;
            _userService = userService;
            _departmentService = departmentService;
            _rolService = rolService;
            _policlinicService = policlinicService;
        }
        public IActionResult Index()
        {
            TempData["ActiveSuperAdmin"] = _activeSuperAdmin.GetActiveSuperAdmin();
            var doctorListDto = _mapper.Map<List<DoctorListDto>>(_doctorService.GetDoctorsWithAllTables());
            return View(doctorListDto);
        }

        public IActionResult CreateDoctor()
        {
            TempData["ActiveSuperAdmin"] = _activeSuperAdmin.GetActiveSuperAdmin();
            ViewBag.Departments = new SelectList(_departmentService.GetAll(), "Id", "DepartmanName");
            var doctorAddDto = new DoctorAddDto() { RolId = _rolService.GetDoctorRol().Id };
            return View(doctorAddDto);
        }

        [HttpPost]
        public IActionResult CreateDoctor(DoctorAddDto doctorAddDto)
        {
            var doctorUser = new User()
            {
                Tcno = doctorAddDto.Tcno,
                RolId = doctorAddDto.RolId,
                Name = doctorAddDto.Name,
                SurName = doctorAddDto.SurName,
                Email = doctorAddDto.Email,
                BirthDate = doctorAddDto.BirthDate,
                Telephone = doctorAddDto.Telephone,
                Gender = doctorAddDto.Gender,
                Password = doctorAddDto.Password
            };
            int userId = _userService.AddWithRetObject(doctorUser).Id;
            var doctor = new DataAccess.Concrete.EntityFrameworkCore.Entities.Doctor()
            {
                Id = userId,
                DepartmentId = doctorAddDto.DepartmentId,
                Apellation = doctorAddDto.Apellation,
                SuperAdminId = _activeSuperAdmin.GetActiveSuperAdmin().UserId
            };
            _doctorService.Add(doctor);
            var policlinic = new Policlinic()
            {
                Id = userId,
                DepartmentId = doctorAddDto.DepartmentId,
                PoliclinicName = doctorAddDto.PoliclinicName
            };
            _policlinicService.Add(policlinic);
            return RedirectToAction("Index");
        }



    }
}
