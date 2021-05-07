using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.UI.Tools.ActiveUserContext;
using Microsoft.AspNetCore.Http;

namespace HospitalAppointment.UI.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class HomeController : Controller
    {
        private ActivePatient _activePatient;
        private readonly IMapper _mapper;
        public HomeController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IUserService userService, IPatientService patientService)
        {
            _activePatient = new ActivePatient(httpContextAccessor, userService, patientService);
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["ActiveSuperAdmin"] = _activePatient.GetActivePatient();
            return View();
        }

        public IActionResult MyProfile()
        {
            TempData["ActiveSuperAdmin"] = _activePatient.GetActivePatient();
            return View();
        }
    }
}
