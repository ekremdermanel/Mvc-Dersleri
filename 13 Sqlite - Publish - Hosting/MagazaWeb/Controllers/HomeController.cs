using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagazaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using MagazaWeb.Models;

namespace MagazaWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly MagazaContext context;

        public HomeController(MagazaContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.Kategoriler.ToList());
        }

        public IActionResult Hakkimizda()
        {
            return View();
        }

    }
}