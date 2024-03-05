using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using MagazaWeb.Models;

namespace MagazaWeb.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            ViewBag.Yazi = "Merhaba nasılsın?";
            ViewData["Baslik"] = "Ana Sayfa";

            List<string> maddeler = new List<string>() {"Ucuz","Güvensiz","Kalitesiz","Yavaş","Dandik","Pahalı Kargo","Yüksek Vergi"};

            return View(maddeler);
        }

        public IActionResult Hakkimizda()
        {
            ViewData["Baslik"] = "Hakkımızda";
            string slogan = "En iyi ürünler burada!";
            return View((object)slogan);
        }
        public IActionResult Profil()
        {
            TempData["Hata"] = "Yetkin olmadığı için sayfayı açamadın";
            return RedirectToAction("Index");
        }
        
    }
}