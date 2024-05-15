using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagazaWeb.Models;
using Newtonsoft.Json;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace MagazaWeb.Controllers
{
  public class AdminController : Controller
  {
    string apiUrl = "http://localhost:5122/Urun";

    public AdminController()
    {
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Urun()
    {
      HttpClient client = new HttpClient();
      HttpResponseMessage response = client.GetAsync(apiUrl + "/Liste").Result;
      List<Urun> urunler = JsonConvert.DeserializeObject<List<Urun>>(response.Content.ReadAsStringAsync().Result);
      return View(urunler);
    }

    public IActionResult UrunEkle()
    {
      return View();
    }

    [HttpPost]
    public IActionResult UrunEkle(Urun model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      string json = JsonConvert.SerializeObject(model);
      HttpClient client = new HttpClient();
      StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
      HttpResponseMessage response = client.PostAsync(apiUrl + "/Ekle", content).Result;
      return RedirectToAction("Urun");
    }

    public IActionResult UrunGuncelle(int id)
    {
      HttpClient client = new HttpClient();
      HttpResponseMessage response = client.GetAsync(apiUrl + string.Format("/Detay/{0}", id)).Result;
      Urun kayit = JsonConvert.DeserializeObject<Urun>(response.Content.ReadAsStringAsync().Result);
      return View(kayit);
    }

    [HttpPost]
    public IActionResult UrunGuncelle(Urun model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      string json = JsonConvert.SerializeObject(model);
      HttpClient client = new HttpClient();
      StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
      HttpResponseMessage response = client.PutAsync(apiUrl + "/Guncelle", content).Result;
      return RedirectToAction("Urun");
    }

    public IActionResult UrunSil(int id)
    {
      HttpClient client = new HttpClient();
      HttpResponseMessage response = client.DeleteAsync(apiUrl + string.Format("/Sil/{0}", id)).Result;
      return RedirectToAction("Urun");
    }
  }
}