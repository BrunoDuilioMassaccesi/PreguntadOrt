using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PreguntadOrt.Models;

namespace PreguntadOrt.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult ConfigurarJuego()
    {
        ViewBag.Bd.ObtenerCategorias;
        ViewBag.Bd.ObtenerDificultades;
        return View();
    }
    public IActionResult Creditos()
    {
        return View();
    }

}
