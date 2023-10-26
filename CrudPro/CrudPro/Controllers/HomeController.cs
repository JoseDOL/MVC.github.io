using CrudPro.Models;
using CrudPro.Servicios;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CrudPro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GiphyService giphyService;
        private string apiKey = "UeBIgmYzAAAGOMS46p6BuaCQebasYCND";
        private readonly IServicioConexion servicioConexion;
        public HomeController(ILogger<HomeController> logger, IServicioConexion servicioConexion)
        {
            _logger = logger;
            this.giphyService = new GiphyService(apiKey);
            this.servicioConexion = servicioConexion;
        }

        public async Task<ActionResult> Index()
        {
            string query = "microsoft";
            var giphyData = await giphyService.GetGiphyDataAsync(query);

            if (giphyData != null)
            {
                return View("Index", giphyData);
            }
            else
            {
                return View("Error");
            }

        }

        public ActionResult addData()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> addData(Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return View(persona);
            }
            var result = await servicioConexion.Crear(persona);
            if (result == 0 || result == -2)
            {
                
                ModelState.AddModelError(nameof(persona.dpi),
                    result == -2 ? $"El DPI No.  {persona.dpi} ya existe.": $"Error al Insertar Registro.");

                return View(persona);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> readData()
        {
            var eusuario = await servicioConexion.EObetener();
            return View(eusuario);
        }
        public ActionResult updateData()
        {
            return View();
        }
        public ActionResult deleteData()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> deleteData(PersonId personId)
        {

            if (!ModelState.IsValid)
            {
                return View(personId);
            }
            
            var existe = await servicioConexion.verificaPersona(personId.dpi,0);

            if (existe == 0)
            {
                ModelState.AddModelError(nameof(personId.dpi),
                    $"El DPI No.  {personId.dpi} no existe.");

                return View(personId);
            }
            var eliminacion = await servicioConexion.Eliminar(personId);
            if (eliminacion == 0) {
                ModelState.AddModelError(nameof(personId.dpi),
                    $"Error al eliminar DPI No.  {personId.dpi}.");
                return View(personId); 
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}