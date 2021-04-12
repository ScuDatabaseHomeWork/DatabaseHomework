using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using VeritbaniDeneme.DTO.HastaDtos;
using VeritbaniDeneme.Database.Entities;
using VeritbaniDeneme.Database.Repositories;

namespace VeritbaniDeneme.Areas.Veznedar.Controllers
{
    [Area("Veznedar")]
    public class HomeController : Controller
    {
        EfHastaRepository _efHastaRepository = new EfHastaRepository();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HastaEkle()
        {
            return View(new HastaEkleDto());
        }

        [HttpPost]
        public IActionResult HastaEkle(HastaEkleDto model)
        {
            Database.Entities.Hasta hasta = new Database.Entities.Hasta();
            hasta.Ad = model.Ad;
            hasta.Soyad = model.Soyad;
            hasta.Tcno = model.Tcno;
            hasta.AnaAdi = model.AnaAdi;
            hasta.BabaAdi = model.BabaAdi;
            hasta.Telefon = model.Telefon;
            hasta.Parola = model.Parola;
            _efHastaRepository.Kaydet(hasta);
            return RedirectToAction("Index");
        }

        public IActionResult RandevuSorgula()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RandevuSorgula(long tcNo)
        {
            Database.Entities.Hasta hasta = _efHastaRepository.HastaGetirileTc(tcNo);
            if (hasta != null)
            {
                return RedirectToAction();
            }
            else
            {
                ViewBag.GecersizTc = "Tc no geçersiz";
                return View();
            }
        }
    }
}
