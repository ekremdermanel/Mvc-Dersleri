using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using MagazaWeb.Models;

namespace MagazaWeb.Controllers
{
    public class AdminController : Controller
    {
        public AdminController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Urun()
        {
            return View();
        }

        public IActionResult UrunEkle()
        {
            return View();
        }

        public IActionResult UrunGuncelle()
        {
            return View();
        }

        public IActionResult UrunSil()
        {
            return RedirectToAction("Urun");
        }
    }
}