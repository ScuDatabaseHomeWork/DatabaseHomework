using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.UI.Tools.ActiveUserContext;
using Microsoft.AspNetCore.Http;

namespace HospitalAppointment.UI.Areas.PatientRegistrar.Controllers
{
    [Area("PatientRegistrar")]
    public class HomeController : Controller
    {

        private ActivePatientRegistrar _activePatientRegistrar;
        public HomeController(IHttpContextAccessor httpContextAccessor, IUserService userService, IPatientRegistrarService patientRegistrarService)
        {
            _activePatientRegistrar = new ActivePatientRegistrar(httpContextAccessor, userService, patientRegistrarService);
        }
        public IActionResult Index()
        {
            TempData["ActiveSuperAdmin"] = _activePatientRegistrar.GetActivePatientRegistrar();
            return View();
        }
    }
}
