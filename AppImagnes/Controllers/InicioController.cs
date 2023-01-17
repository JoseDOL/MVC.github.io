using AppImagnes.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppImagnes.Controllers
{
    public class InicioController : Controller
    {
        private List<cImagen> _inicio;

        public InicioController()
        {
            _inicio = new List<cImagen>();
            for (int i = 1; i < 10; i++)
            {
                if (i==1)
                {
                    _inicio.Add(new cImagen() { srcIm = "/imagen/f" + i + ".jpg", actual = true, posicion=i });
                }
                else
                {
                    _inicio.Add(new cImagen() { srcIm = "/imagen/f" + i + ".jpg", actual = false, posicion = i });
                }
            }

        }

        public IActionResult Index()
        {
            return View(_inicio);
        }
        [HttpPost]
        private IActionResult Siguiente(List<cImagen> list)
        {
            bool teto = false;
            int ultimo = 0;
            cImagen aux = new cImagen();

            foreach (cImagen item in list)
            {
                if (teto) 
                {
                    item.actual = true;
                    teto = false;
                    aux.actual = false;
                    break;
                }
                if (item.actual && item.posicion != 9) 
                {
                    aux = item;
                    teto = true;
                    ultimo = item.posicion;
                    
                }
                else if (item.posicion == 9)
                {
                    ultimo = 9;
                    break;
                }
            }

            if (ultimo == 9) 
            {
                foreach (cImagen item in list)
                {
                    if (item.posicion == 1)
                    {
                        item.actual = true;
                        break;
                    }
                
                }
            } 
            return View(list);
        }
    }
}
