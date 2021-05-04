using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DTO.DTOs.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace HospitalAppointment.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISuperAdminService _superAdminService;
        private readonly IPatientService _patientService;
        private readonly IPatientRegistrarService _patientRegistrarService;
        private readonly IDoctorService _doctorService;
        public HomeController(IUserService userService, ISuperAdminService superAdminService, IPatientService patientService, IDoctorService doctorService, IPatientRegistrarService patientRegistrarService)
        {
            _userService = userService;
            _superAdminService = superAdminService;
            _patientService = patientService;
            _patientRegistrarService = patientRegistrarService;
            _doctorService = doctorService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PatientLogIn()
        {
            return View(new UserLoginDto());
        }

        public IActionResult PersonelLogIn()
        {
            return View(new UserLoginDto());
        }

        [HttpPost]
        public IActionResult UserLogIn(UserLoginDto userLoginDto)
        {
            if (_userService.CheckUserforLogin(userLoginDto.Tcno, userLoginDto.Password))
            {
                var user = _userService.GetUserByTcNo(userLoginDto.Tcno);
                var userRole = _userService.GetUserRoleByTcNo(userLoginDto.Tcno);
                var claims = new List<Claim>()
                {
                    new Claim("UserId",user.Id.ToString()),
                    //new Claim("TCNo", user.Tcno.ToString()),
                    //new Claim(ClaimTypes.Name, user.Name),
                    //new Claim(ClaimTypes.Surname,user.SurName),
                    //new Claim(ClaimTypes.Email,user.Email),
                    //new Claim(ClaimTypes.DateOfBirth,user.BirthDate.ToString()),
                    //new Claim(ClaimTypes.MobilePhone,user.Telephone.ToString()),
                    //new Claim(ClaimTypes.Gender,user.Gender == true ? "Erkek":"Kadın")
                };
                if (userRole == "SuperAdmin")
                {
                    claims.Add(new Claim(ClaimTypes.Role, "SuperAdmin"));
                    var superAdmin = _superAdminService.GetSuperAdminByUserId(user.Id);
                    claims.Add(new Claim("SuperAdminId", superAdmin.Id.ToString()));
                    //claims.Add(new Claim("Apellation", superAdmin.Apellation));
                    return LoginWithClaims(claims, "SuperAdmin");
                }
                else if (userRole == "Patient")
                {

                }
                else if (userRole == "Doctor")
                {
                }
                else if (userRole == "PatientRegistrar")
                {
                    claims.Add(new Claim(ClaimTypes.Role, "PatientRegistrar"));
                    var patientRegistrar = _patientRegistrarService.GetPatientRegistrarByUserId(user.Id);
                    claims.Add(new Claim("PatientRegistrarId", patientRegistrar.Id.ToString()));
                    return LoginWithClaims(claims, "PatientRegistrar");
                }

                ModelState.AddModelError("", "Bir şeyler yanlış gitti");
                return View(userLoginDto.LoginPath, userLoginDto);
            }
            else
            {
                ModelState.AddModelError("", "TC no yada Parola Hatalı");
                return View(userLoginDto.LoginPath, userLoginDto);
            }

        }

        public IActionResult LoginWithClaims(List<Claim> claims, string areaPath)
        {
            var claimsIdentity = new ClaimsIdentity(claims, "Login");
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return RedirectToAction("Index", "Home", new { area = areaPath });
        }

        [HttpPost]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }


      
    }
}
