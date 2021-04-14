using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeritbaniDeneme.Database.Entities;
using VeritbaniDeneme.Database.Repositories;
using VeritbaniDeneme.DTO.HastaDtos;
using VeritbaniDeneme.DTO.PersonelDtos;

namespace VeritbaniDeneme.Controllers
{
    public class HomeController : Controller
    {
        EfHastaRepository _efHastaRepository = new EfHastaRepository();
        EfPersonelRepository _efPersonelRepository = new EfPersonelRepository();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HastaGiris()
        {
            return View(new HastaGirisiDto());
        }

        [HttpPost]
        public IActionResult HastaGiris(HastaGirisiDto model)
        {
            if (model != null)
            {
                if (_efHastaRepository.HastaDogrula(model.Tcno, model.Parola))
                {
                    return RedirectToAction("Index", "Home", new { area = "Hasta" });
                }
                else
                {
                    return View(new HastaGirisiDto());
                }
            }
            return View(new HastaGirisiDto());
        }


        public IActionResult PersonelGiris()
        {
            return View(new PersonelGirisiDto());
        }

        [HttpPost]
        public IActionResult PersonelGiris(PersonelGirisiDto model)
        {
            if (model != null)
            {
                Personel personel = _efPersonelRepository.PersonelDogrula(model.KullaniciAdi, model.Parola);
                if (personel != null)
                {
                    string x = _efPersonelRepository.PersonelRolu(personel);
                    if (x.Contains("Veznedar"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Veznedar" });
                    }
                    else if (x.Contains("Başhekim"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Bashekim" });
                    }
                    return View(new PersonelGirisiDto());
                }
                else
                {
                    return View(new PersonelGirisiDto());
                }
            }
            return View(new PersonelGirisiDto());
        }
    }
}
