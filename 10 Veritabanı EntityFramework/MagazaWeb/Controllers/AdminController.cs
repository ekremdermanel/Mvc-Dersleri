using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagazaWeb.Models;

namespace MagazaWeb.Controllers
{
    public class AdminController : Controller
    {
        private readonly MagazaContext context;
        public AdminController(MagazaContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Urun()
        {
            return View(context.Urunler.ToList());
        }

        public IActionResult UrunEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UrunEkle(Urun model)
        {
            if(!ModelState.IsValid) {
                return View(model);
            }
            model.EklenmeTarihi=DateTime.Now;
            context.Urunler.Add(model);
            context.SaveChanges();
            return RedirectToAction("Urun");
        }

        public IActionResult UrunGuncelle(int id)
        {
            Urun kayit = context.Urunler.FirstOrDefault(x=>x.Id==id);
            return View(kayit);
        }

        [HttpPost]
        public IActionResult UrunGuncelle(Urun model)
        {
            if(!ModelState.IsValid) {
                return View(model);
            }
            context.Urunler.Update(model);
            context.SaveChanges();
            return RedirectToAction("Urun");
        }

        public IActionResult UrunSil(int id)
        {
            Urun kayit = context.Urunler.FirstOrDefault(x=>x.Id==id);
            context.Urunler.Remove(kayit);
            context.SaveChanges();
            return RedirectToAction("Urun");
        }
    }
}