using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TelefonRehberi.Models;

namespace TelefonRehberi.Controllers;

public class HomeController : Controller
{
    private readonly KisiContext context;

    public HomeController(KisiContext context)
    {
        this.context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Ekle()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Ekle(Kisi model)
    {
        if(!ModelState.IsValid){
            return View(model);
        }
        context.Kisiler.Add(model);
        context.SaveChanges();
        return RedirectToAction("Liste");
    }
    public IActionResult Liste()
    {

        return View(context.Kisiler.ToList());
    }
    public IActionResult Sil(int id)
    {
        Kisi kayit = context.Kisiler.FirstOrDefault(x => x.Id == id);
        context.Kisiler.Remove(kayit);
        context.SaveChanges();
        return RedirectToAction("Liste");
    }

    public IActionResult Guncelle(int id)
    {
        Kisi kayit = context.Kisiler.FirstOrDefault(x => x.Id == id);
        return View(kayit);
    }
    [HttpPost]
    public IActionResult Guncelle(Kisi model)
    {
        if(!ModelState.IsValid){
            return View(model);
        }
        context.Kisiler.Update(model);
        context.SaveChanges();
        return RedirectToAction("Liste");
    }
    public IActionResult Detay(int id)
    {
        Kisi kayit = context.Kisiler.FirstOrDefault(x => x.Id == id);
        return View(kayit);
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
