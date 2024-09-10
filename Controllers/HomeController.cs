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
        ViewBag.Username=username;
        ViewBag.Dificultad=dificultad;
        ViewBag.Categoria=categoria;
        return View("Comenzar");
    }
    public IActionResult Jugar()
    {
        if (Juego.CantidadPreguntas()>0)
        {
            int idPregunta = 0;
            ViewBag.ListaPregunta = Juego.ObtenerProximaPregunta();        
            ViewBag.ListaRespuesta = Juego.ObtenerProximasRespuestas(idPregunta);       
                 
            return View();
        }
        else
        {
            return View("Fin");
        }
    }
    public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        ViewBag.EsCorrecta = Juego.VerificarRespuesta(idRespuesta);
        ViewBag.Pregunta = Juego.ObtenerProximaPregunta();
        return View("Respuesta");
    }
        public IActionResult Creditos()
    {
        return View();
    }

}
