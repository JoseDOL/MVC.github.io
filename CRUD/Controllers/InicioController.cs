using CRUD.Models;
using CRUD.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class InicioController : Controller
    {
        private readonly IServicioConexion servicioConexion;

        public InicioController(IServicioConexion servicioConexion) 
        {
            this.servicioConexion = servicioConexion;
        }
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(CUsuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }
            await servicioConexion.Crear(usuario);
            if (usuario.resultado == 0)
            {
                ModelState.AddModelError(nameof(usuario.dpi),
                    $"El DPI No.  {usuario.dpi} ya existe.");

                return View(usuario);
            }
            return RedirectToAction("Crear");
        }
        public IActionResult Modificar()
        {
            return View();
        }
        public IActionResult Desactivar()
        {
            return View();
        }
        public async Task<IActionResult> Eliminar()
        {
            var eusuario = await servicioConexion.EObetener();
            return View(eusuario);
        }

        public async Task<IActionResult> REliminar()
        {
            var eusuario = await servicioConexion.EObetener();
            return View("Eliminar", eusuario);
        }
        [HttpPost]
        public async Task<IActionResult> Eliminar([FromBody] string ids)
        {
            await servicioConexion.Eliminar(ids);
            return Ok();
        }
    }
}
