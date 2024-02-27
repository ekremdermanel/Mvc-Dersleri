using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagazaWeb.Models;

namespace MagazaWeb.Controllers
{
  public class UrunController : Controller
  {
    public UrunController()
    {
    }

    public IActionResult Index()
    {
      List<Urun> urunler = new List<Urun> {
        new Urun { Id = 1, UrunAdi = "Iphone 14", Fiyat = 40000, Aciklama = "Çok pahalı almayın" },
        new Urun { Id = 2, UrunAdi = "Samsung A22", Fiyat = 30000, Aciklama = "Güzel ürün" },
        new Urun { Id = 3, UrunAdi = "Xiaomi Note 9", Fiyat = 15000, Aciklama = "İyi" },
        new Urun { Id = 4, UrunAdi = "Noika 3310", Fiyat = 1000, Aciklama = "Tuğla" },
        new Urun { Id = 5, UrunAdi = "Huawei P40", Fiyat = 30000, Aciklama = "Güzel ürün" },
        new Urun { Id = 6, UrunAdi = "Oppo A15", Fiyat = 15000, Aciklama = "Kamerası iyi" }
        };

      return View(urunler);
    }

    public IActionResult Detay()
    {
      Urun urun = new Urun { Id = 5, UrunAdi = "Huawei P40", Fiyat = 30000, Aciklama = "Güzel ürün" };
      
      return View(urun);
    }
  }
}