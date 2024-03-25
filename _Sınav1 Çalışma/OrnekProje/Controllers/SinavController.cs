using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrnekProje.Models;

namespace OrnekProje.Controllers
{
    public class SinavController : Controller
    {
        public SinavController()
        {
        }

        public IActionResult Soru1()
        {
          ViewData["selamla"] = "Selam Formu Doldur";
            return View();
        }

        [HttpPost]
        public IActionResult Soru1(int sayi1, int sayi2)
        {
          int toplam = sayi1 + sayi2;
          ViewData["selamla"] = "Selam Toplam Hazır";
          ViewData["mesaj"] = sayi1 + " ve " + sayi2 + " toplamı " + toplam + "eder.";
            return View(toplam);
        }

        [HttpGet]
        public IActionResult Soru2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Soru2(Araba model)
        {
          
          return View(model);
        }
    }
}