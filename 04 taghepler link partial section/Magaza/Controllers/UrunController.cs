using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Magaza.Controllers
{
    public class UrunController : Controller
    {
        public IActionResult Listele()
        {
            return View();
        }

        public IActionResult Detay()
        {
            return View();
        }
    }
}