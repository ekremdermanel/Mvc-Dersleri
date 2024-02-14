using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OrnekProje.Models;

namespace OrnekProje.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public int yazdir() 
    {
        return 10;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Hakkimizda()
    {
        return View();
    }

    public IActionResult Iletisim()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
