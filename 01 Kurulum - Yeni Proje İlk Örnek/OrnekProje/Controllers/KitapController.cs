using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrnekProje.Models;

namespace OrnekProje.Controllers
{
    public class KitapController : Controller
    {
        public KitapController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public int KitapSayisi()
        {
            return 10;
        }

        public string KitapAdi()
        {
            return "Güzel kitap";
        }

        public JsonResult KitapBilgileri()
        {
            return Json(new
            {
            Id = 1,
            Seviye = "11. Sınıf",
            KitapAdi = "WEB TABANLI UYGULAMA GELİŞTİRME"
            });
        }

        public FileResult Resim()
        {
            return File("~/resimler/meblogo.png", "image/png");
        }

        public string Yazdir(int id)
        {
            return $"Gönderilen parametre {id}";
        }

        public string Yazdir2(int sayi, string isim)
        {
            return $"Gönderilen parametreler {sayi} {isim}";
        }

        [Route("Kitap/Yazdir3/{sayi}/{isim}")]
        public string Yazdir3(int sayi, string isim)
        {
            return $"Gönderilen parametreler {sayi} {isim}";
        }

        public void Yeni()
        {
            KitapModel kitap = new KitapModel();
            kitap.KitapId=5;
            kitap.KitapAdi="Güzel kitap";
            kitap.SayfaSayisi=100;
        }
        


   
    }
}