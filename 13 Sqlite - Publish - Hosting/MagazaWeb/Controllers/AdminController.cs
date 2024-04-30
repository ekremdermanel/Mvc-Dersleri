using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagazaWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

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
            SelectList kategoriler = new SelectList(context.Kategoriler, "Id", "KategoriAdi");
            ViewBag.Kategoriler = kategoriler;
            return View();
        }

        [HttpPost]
        public IActionResult UrunEkle(Urun model)
        {
            if(!ModelState.IsValid) {
                SelectList kategoriler = new SelectList(context.Kategoriler, "Id", "KategoriAdi");
                ViewBag.Kategoriler = kategoriler;
                return View(model);
            }

            if(model.Resim != null) {
                string resimUzantisi = Path.GetExtension(model.Resim.FileName);
                string resimAdi = Guid.NewGuid() + resimUzantisi;
                string resimYolu = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/image/{resimAdi}");
                var img = Image.Load(model.Resim.OpenReadStream());
                img.Mutate(x => x.Resize(750,510));
                img.Save(resimYolu);
                model.ResimAdi=resimAdi;
            }

            model.EklenmeTarihi=DateTime.Now;
            context.Urunler.Add(model);
            context.SaveChanges();
            return RedirectToAction("Urun");
        }

        public IActionResult UrunGuncelle(int id)
        {
            SelectList kategoriler = new SelectList(context.Kategoriler, "Id", "KategoriAdi");
            ViewBag.Kategoriler = kategoriler;
            Urun kayit = context.Urunler.FirstOrDefault(x=>x.Id==id);
            return View(kayit);
        }

        [HttpPost]
        public IActionResult UrunGuncelle(Urun model)
        {
            if(!ModelState.IsValid) {
                SelectList kategoriler = new SelectList(context.Kategoriler, "Id", "KategoriAdi");
                ViewBag.Kategoriler = kategoriler;
                return View(model);
            }

            if(model.Resim != null) {
                string resimYolu = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/image/{model.ResimAdi}");
                FileInfo file = new FileInfo(resimYolu);
                if(file.Exists) {
                    file.Delete();
                }

                string resimUzantisi = Path.GetExtension(model.Resim.FileName);
                string resimAdi = Guid.NewGuid() + resimUzantisi;
                resimYolu = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/image/{resimAdi}");
                var img = Image.Load(model.Resim.OpenReadStream());
                img.Mutate(x => x.Resize(750,510));
                img.Save(resimYolu);
                model.ResimAdi=resimAdi;
            }

            context.Urunler.Update(model);
            context.SaveChanges();
            return RedirectToAction("Urun");
        }

        public IActionResult UrunSil(int id)
        {
            Urun kayit = context.Urunler.FirstOrDefault(x=>x.Id==id);

            string resimYolu = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/image/{kayit.ResimAdi}");
            FileInfo file = new FileInfo(resimYolu);
            if(file.Exists) {
                file.Delete();
            }

            context.Urunler.Remove(kayit);
            context.SaveChanges();
            return RedirectToAction("Urun");
        }

        public IActionResult Kategori()
        {
            return View(context.Kategoriler.ToList());
        }

        public IActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KategoriEkle(Kategori model)
        {
           if(!ModelState.IsValid) {
                return View(model);
            }
            context.Kategoriler.Add(model);
            context.SaveChanges();
            return RedirectToAction("Kategori");
        }

        public IActionResult KategoriGuncelle(int id)
        {
            Kategori kayit = context.Kategoriler.FirstOrDefault(x=>x.Id==id);
            return View(kayit);
        }

        [HttpPost]
        public IActionResult KategoriGuncelle(Kategori model)
        {
            if(!ModelState.IsValid) {
                return View(model);
            }
            context.Kategoriler.Update(model);
            context.SaveChanges();
            return RedirectToAction("Kategori");
        }

        public IActionResult KategoriSil(int id)
        {
            Kategori kayit = context.Kategoriler.FirstOrDefault(x=>x.Id==id);
            context.Kategoriler.Remove(kayit);
            context.SaveChanges();
            return RedirectToAction("Kategori");
        }

        public IActionResult ResimSil(int id)
        {
            Urun kayit = context.Urunler.FirstOrDefault(x=>x.Id==id);

            string resimYolu = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/image/{kayit.ResimAdi}");
            FileInfo file = new FileInfo(resimYolu);
            if(file.Exists) {
                file.Delete();
            }

            kayit.ResimAdi = null;
            context.Urunler.Update(kayit);
            context.SaveChanges();
            return RedirectToAction("UrunGuncelle", new{ id });
        }
    }
}