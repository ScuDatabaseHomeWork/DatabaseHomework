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
        public HomeController(IUserService userService)
        {
            _userService = userService;
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
                var claims = new List<Claim>()
                {
                    new Claim("TCNo", user.Tcno.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Surname,user.SurName),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.DateOfBirth,user.BirthDate.ToString()),
                    new Claim(ClaimTypes.MobilePhone,user.Telephone.ToString()),
                    new Claim(ClaimTypes.Surname,user.SurName),

                };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "TC no yada Parola Hatalı");
                return View(userLoginDto.LoginPath, userLoginDto);
            }

        }

        [HttpPost]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }


    }
}
