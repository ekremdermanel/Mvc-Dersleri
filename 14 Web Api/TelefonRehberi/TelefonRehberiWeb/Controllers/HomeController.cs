using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TelefonRehberiWeb.Models;

namespace TelefonRehberiWeb.Controllers;

public class HomeController : Controller
{

    string apiUrl = "http://telefonrehberi.somee.com/api/Kisi";

    public HomeController(ILogger<HomeController> logger)
    {
    }

    public IActionResult Index()
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = client.GetAsync(apiUrl + "/Liste").Result;
        List<Kisi> kisiler = JsonConvert.DeserializeObject<List<Kisi>>(response.Content.ReadAsStringAsync().Result);
        return View(kisiler);
    }

    public IActionResult Ekle()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Ekle(Kisi model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        string json = JsonConvert.SerializeObject(model);
        HttpClient client = new HttpClient();
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = client.PostAsync(apiUrl + "/Ekle", content).Result;
        return RedirectToAction("Index");
    }

    public IActionResult Guncelle(int id)
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = client.GetAsync(apiUrl + string.Format("/Detay/{0}", id)).Result;
        Kisi kayit = JsonConvert.DeserializeObject<Kisi>(response.Content.ReadAsStringAsync().Result);
        return View(kayit);
    }

    [HttpPost]
    public IActionResult Guncelle(Kisi model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        string json = JsonConvert.SerializeObject(model);
        HttpClient client = new HttpClient();
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = client.PutAsync(apiUrl + "/Guncelle", content).Result;
        return RedirectToAction("Index");
    }

    public IActionResult Sil(int id)
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = client.DeleteAsync(apiUrl + string.Format("/Sil/{0}", id)).Result;
        return RedirectToAction("Index");
    }

    public IActionResult Detay(int id)
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = client.GetAsync(apiUrl + string.Format("/Detay/{0}", id)).Result;
        Kisi kayit = JsonConvert.DeserializeObject<Kisi>(response.Content.ReadAsStringAsync().Result);
        return View(kayit);
    }

}
