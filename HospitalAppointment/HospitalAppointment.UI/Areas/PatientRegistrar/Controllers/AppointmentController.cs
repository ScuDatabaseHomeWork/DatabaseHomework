using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DTO.DTOs.Appointment;
using HospitalAppointment.UI.Tools.ActiveUserContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;

namespace HospitalAppointment.UI.Areas.PatientRegistrar.Controllers
{
    [Area("PatientRegistrar")]
    public class AppointmentController : Controller
    {
        private ActivePatientRegistrar _activePatientRegistrar;
        private readonly IPatientService _patientService;
        private readonly IDepartmentService _departmentService;
        private readonly IDoctorService _doctorService;
        private readonly IPoliclinicService _policlinicService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService,IMapper mapper, IPoliclinicService policlinicService, IDoctorService doctorService, IDepartmentService departmentService, IPatientService patientService, IHttpContextAccessor httpContextAccessor, IUserService userService, IPatientRegistrarService patientRegistrarService)
        {
            _activePatientRegistrar = new ActivePatientRegistrar(httpContextAccessor, userService, patientRegistrarService);
            _patientService = patientService;
            _departmentService = departmentService;
            _doctorService = doctorService;
            _policlinicService = policlinicService;
            _mapper = mapper;
            _userService = userService;
            _appointmentService = appointmentService;
        }
        public IActionResult SelectingPatient()
        {
            TempData["ActiveSuperAdmin"] = _activePatientRegistrar.GetActivePatientRegistrar();
            return View();
        }

        [HttpPost]
        public IActionResult SelectingPatient(long tc)
        {
            var checkedPatientUser = _patientService.CheckAndGetPatientByTcNo(tc);
            if (checkedPatientUser != null)
            {
                var appointmentUserDto = new AppointmentUserDto()
                {
                    UserId = checkedPatientUser.Id,
                    Name = checkedPatientUser.Name,
                    SurName = checkedPatientUser.SurName,
                };
                return RedirectToAction("SelectingDepartment", appointmentUserDto);
            }
            else
            {
                TempData["ActiveSuperAdmin"] = _activePatientRegistrar.GetActivePatientRegistrar();
                ModelState.AddModelError("", "Hasta Bulunamadı");
                return View(tc);
            }

        }

        public IActionResult SelectingDepartment(AppointmentUserDto appointmentUserDto)
        {
            TempData["ActiveSuperAdmin"] = _activePatientRegistrar.GetActivePatientRegistrar();
            ViewBag.Departments = new SelectList(_departmentService.GetAll(), "Id", "DepartmanName");
            return View(appointmentUserDto);
        }

        public IActionResult SelectingDoctor(AppointmentUserDto appointmentUserDto)
        {
            TempData["ActiveSuperAdmin"] = _activePatientRegistrar.GetActivePatientRegistrar();
            appointmentUserDto.DepartmentName = _departmentService.GetById(appointmentUserDto.DepartmentId).DepartmanName;
            ViewBag.DepartmentDoctors = new SelectList(_doctorService.GetDepartmentDoctorsByDepartmentId(appointmentUserDto.DepartmentId), "Id", "Name");
            return View(appointmentUserDto);
        }


        public IActionResult SelectingDateDay(AppointmentUserDto appointmentUserDto)
        {
            TempData["ActiveSuperAdmin"] = _activePatientRegistrar.GetActivePatientRegistrar();
            var appointmentDoctorUser = _userService.GetById(appointmentUserDto.DoctorUserId);
            appointmentUserDto.DoctorUserName = appointmentDoctorUser.Name;
            var appointmentDoctor = _doctorService.GetDoctorByUserId(appointmentDoctorUser.Id);
            appointmentUserDto.DoctorId = appointmentDoctor.Id;
            var doctorPoliclinic = _policlinicService.GetById(appointmentUserDto.DoctorId);
            appointmentUserDto.PoliclinicId = doctorPoliclinic.Id;
            appointmentUserDto.PoliclinicName = doctorPoliclinic.PoliclinicName;
            List<DateTime> dateDays = new List<DateTime>();
       
            int i = 1;
            while (true)
            {
                if (DateTime.Today.AddDays(i).DayOfWeek != DayOfWeek.Saturday && DateTime.Today.AddDays(i).DayOfWeek != DayOfWeek.Sunday )
                {
                    dateDays.Add(DateTime.Today.AddDays(i));
                }

                if (dateDays.Count == 7)
                {
                    break;
                }
                i++;
            }
            ViewBag.DateDays = dateDays;
            return View(appointmentUserDto);
        }

        public IActionResult SelectingDateHourTime(AppointmentUserDto appointmentUserDto)
        {
            TempData["ActiveSuperAdmin"] = _activePatientRegistrar.GetActivePatientRegistrar();
            List<DateTime> existDateHourTimes =
                _appointmentService.GetAppointmentsHourTimesByAppointmentDayAndDoctorId(appointmentUserDto.AppointmentDateTime,appointmentUserDto.DoctorId);
            ViewBag.existDateHourTimes = existDateHourTimes;
            return View(appointmentUserDto);
        }
    }
}
