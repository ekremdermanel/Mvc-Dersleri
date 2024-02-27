using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagazaWeb.Models;

namespace MagazaWeb.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        

        public IActionResult Hakkimizda()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult VeriAlGet1()
        {
            string adsoyad = HttpContext.Request.Query["adsoyad"];
            int sinav1 = int.Parse(HttpContext.Request.Query["sinav1"]);
            int sinav2 = int.Parse(HttpContext.Request.Query["sinav2"]);
            double ort = ((double) sinav1 + (double) sinav2)/2;
            return Content("1. Merhaba " + adsoyad + " Ortalama " + ort);
        }

        public IActionResult VeriAlGet2(string adsoyad, int sinav1, int sinav2)
        {
            double ort = ((double) sinav1 + (double) sinav2)/2;
            return Content("2. Merhaba " + adsoyad + " Ortalama " + ort);
        }


        public IActionResult VeriAlPost1(IFormCollection collection)
        {
            string adsoyad = collection["adsoyad"];
            int sinav1 = int.Parse(collection["sinav1"]);
            int sinav2 = int.Parse(collection["sinav2"]);
            double ort = ((double) sinav1 + (double) sinav2)/2;
            return Content("3. Merhaba " + adsoyad + " Ortalama " + ort);
        }


        public IActionResult VeriAlPost2(string adsoyad, int sinav1, int sinav2)
        {
            double ort = ((double) sinav1 + (double) sinav2)/2;
            return Content("4. Merhaba " + adsoyad + " Ortalama " + ort);
        }

        public IActionResult VeriAlPost3(Ogrenci ogrenci)
        {
            double ort = ((double) ogrenci.Sinav1 + (double) ogrenci.Sinav2)/2;
            return Content("5. Merhaba " + ogrenci.AdSoyad + " Ortalama " + ort);
        }

        [HttpPost]
        public IActionResult Index(Ogrenci ogrenci)
        {
            double ort = ((double) ogrenci.Sinav1 + (double) ogrenci.Sinav2)/2;
            return Content("6. Merhaba " + ogrenci.AdSoyad + " Ortalama " + ort);
        }


        public IActionResult Yukle(Ogrenci ogrenci)
        {
            if (ogrenci.Resim == null || ogrenci.Resim.Length == 0)
            {
                return Content("Dosya yüklenemedi");
            }
            
            var yol=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot",ogrenci.Resim.FileName);
            ogrenci.Resim.CopyTo(new FileStream(yol,FileMode.Create));
            return View(ogrenci);
        }
        
    }
}