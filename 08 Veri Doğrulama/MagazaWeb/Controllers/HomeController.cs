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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Hakkimizda()
        {
            return View();
        }


        public IActionResult YorumEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YorumEkle(Yorum model)
        {
            if(!ModelState.IsValid) {
                return View(model);
            } 
            return RedirectToAction("YorumGonder",model);
        }

        public IActionResult YorumGonder(Yorum model)
        {
            return View("YorumGonder",model);
        }

        public IActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Kayit(Kullanici model)
        {
            if(!ModelState.IsValid) {
                return View(model);
            } 
            return RedirectToAction("Index");
        }
        
    }
}