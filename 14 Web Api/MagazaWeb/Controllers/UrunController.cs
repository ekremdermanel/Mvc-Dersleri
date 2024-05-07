using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagazaWeb.Models;
using Newtonsoft.Json;

namespace MagazaWeb.Controllers
{
  public class UrunController : Controller
  {
    string apiUrl = "http://localhost:5122/Urun";

    public UrunController()
    {
    }

    public IActionResult Index()
    {
      HttpClient client = new HttpClient();
      HttpResponseMessage response = client.GetAsync(apiUrl + "/Liste").Result;
      List<Urun> urunler = JsonConvert.DeserializeObject<List<Urun>>(response.Content.ReadAsStringAsync().Result);
      return View(urunler);
    }

    public IActionResult Detay(int id)
    {
      HttpClient client = new HttpClient();
      HttpResponseMessage response = client.GetAsync(apiUrl + string.Format("/Detay/{0}", id)).Result;
      Urun kayit = JsonConvert.DeserializeObject<Urun>(response.Content.ReadAsStringAsync().Result);
      return View(kayit);
    }
  }
}