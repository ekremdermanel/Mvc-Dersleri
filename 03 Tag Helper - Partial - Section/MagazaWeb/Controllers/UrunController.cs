using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using MagazaWeb.Models;

namespace MagazaWeb.Controllers
{
    public class UrunController : Controller
    {
        public UrunController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detay()
        {
            return View();
        }
    }
}