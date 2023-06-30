using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ejemplomvc.Models;
using ejemplomvc.Data;
using System.Linq;

namespace ejemplomvc.Controllers;

public class HomeController : Controller
{

    private readonly Conexion conexion;

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, Conexion con)
    {
        _logger = logger;
        conexion = con;
    }

    public IActionResult Index()
    {
        return View("Privacy");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult RegresaUsuarios() {
        return Json(conexion.Usuarios);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

