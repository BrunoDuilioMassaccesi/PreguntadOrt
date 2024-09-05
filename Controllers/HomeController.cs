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
        ViewBag.ListaCategorias = Juego.ObtenerCategorias();
        ViewBag.ListaDificultades = Juego.ObtenerDificultades();
        return View();
    }
     public IActionResult Comenzar(string username, int dificultad, int categoria)
    {
        Juego.CargarPartida(username, dificultad, categoria);
        return RedirectToAction("Comenzar");
    }
    public IActionResult Jugar()
    {
        if (Juego.CantidadPreguntas()>0)
        {
            ViewBag.ListaPregunta = Juego.ObtenerProximaPregunta();         
            ViewBag.ListaRespuesta = Juego.ObtenerProximasRespuestas();            
            return View();
        }
        else
        {
            //poner aca el fin|
        }
    }
    public IActionResult Creditos()
    {
        return View();
    }
       
}
