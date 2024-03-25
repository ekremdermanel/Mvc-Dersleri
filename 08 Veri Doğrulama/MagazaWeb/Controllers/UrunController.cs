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

        List<Urun> urunler = new List<Urun> {
            new Urun { Id = 1, UrunAdi = "Iphone 14", Fiyat = 40000, Stok = 10, Aciklama = "Çok pahalı almayın" },
            new Urun { Id = 2, UrunAdi = "Samsung A22", Fiyat = 30000, Stok = 5 , Aciklama = "Güzel ürün"},
            new Urun { Id = 3, UrunAdi = "Xiaomi Note 9", Fiyat = 15000, Stok = 50, Aciklama = "İyi" },
            new Urun { Id = 4, UrunAdi = "Noika 3310", Fiyat = 1000, Stok = 1 , Aciklama = "Tuğla"},
            new Urun { Id = 5, UrunAdi = "Huawei P40", Fiyat = 30000, Stok = 3, Aciklama = "Güzel ürün" },
            new Urun { Id = 6, UrunAdi = "Oppo A15", Fiyat = 15000, Stok = 10, Aciklama = "Kamerası iyi" }
        };
  
        public UrunController()
        {
        }

        public IActionResult Index()
        {
            return View(urunler);
        }

        public IActionResult Detay(int id)
        {
            Urun urun = urunler.FirstOrDefault(x=>x.Id==id);
            return View(urun);
        }
        
    }
}