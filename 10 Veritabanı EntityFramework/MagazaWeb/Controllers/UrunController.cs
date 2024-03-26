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
    private readonly MagazaContext context;

    public UrunController(MagazaContext context)
    {
      this.context = context;
    }

    public IActionResult Index()
    {
      return View(context.Urunler.ToList());
    }

    public IActionResult Detay(int id)
    {
      Urun kayit = context.Urunler.FirstOrDefault(x=>x.Id==id);
      return View(kayit);
    }
  }
}