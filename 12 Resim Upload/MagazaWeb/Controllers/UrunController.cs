using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagazaWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace MagazaWeb.Controllers
{
  public class UrunController : Controller
  {
    private readonly MagazaContext context;

    public UrunController(MagazaContext context)
    {
      this.context = context;
    }

    public IActionResult Index(int? id)
    {
      if (id == null)
      {
        ViewBag.ListeBasligi = "Tüm Ürünler";
        return View(context.Urunler.Include("Kategori").ToList());
      }
      else
      {
        Kategori kayit = context.Kategoriler.FirstOrDefault(x => x.Id == id);
        ViewBag.ListeBasligi = kayit.KategoriAdi + " - " + kayit.Slogan;
        return View(context.Urunler.Include("Kategori").Where(x => x.KategoriId == id).ToList());
      }
    }

    public IActionResult Detay(int id)
    {
      Urun kayit = context.Urunler.FirstOrDefault(x => x.Id == id);
      return View(kayit);
    }
  }
}