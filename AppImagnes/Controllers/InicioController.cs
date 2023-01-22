using AppImagnes.Models;
using AppImagnes.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace AppImagnes.Controllers
{
    public class InicioController : Controller
    {
        private readonly IFuncionesCambio cambio;
        private List<cImagen> _inicio;

        public InicioController(IFuncionesCambio cambio)
        {
            _inicio = new List<cImagen>();
            for (int i = 1; i < 10; i++)
            {
                if (i == 1)
                {
                    _inicio.Add(new cImagen() { srcIm = "/imagen/f" + i + ".jpg", actual = true, posicion = i });
                }
                else
                {
                    _inicio.Add(new cImagen() { srcIm = "/imagen/f" + i + ".jpg", actual = false, posicion = i });
                }
            }

            this.cambio = cambio;
        }

        public IActionResult Index()
        {
            return View(_inicio);
        }
        [HttpPost]
        public IActionResult Index(List<cImagen> list, string ant, string sig, int iman)
        {
            list = _inicio;
            cImagen aux = new cImagen();
            if (sig != null) { cambio.Siguiente(list, iman); }
            else if (ant != null){ cambio.Anterior(list, iman); }
            return View(list);
        }
    }
}
