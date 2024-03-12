using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagazaWeb.Models;
using MagazaWeb.ViewModels;

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

        [HttpPost]
        public IActionResult UrunEkle(UrunViewModel viewModel)
        {
            if(!ModelState.IsValid) {
                return View(viewModel);
            }
            return RedirectToAction("Urun");
        }

        public IActionResult UrunGuncelle()
        {
            UrunViewModel viewModel = new UrunViewModel();
            viewModel.UrunAdi="Iphone";
            viewModel.Fiyat=1000;
            viewModel.Stok=10;
            viewModel.Aciklama="İyidir";
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UrunGuncelle(UrunViewModel viewModel)
        {
            if(!ModelState.IsValid) {
                return View(viewModel);
            }
            return RedirectToAction("Urun");
        }

        public IActionResult UrunSil()
        {
            return RedirectToAction("Urun");
        }
    }
}