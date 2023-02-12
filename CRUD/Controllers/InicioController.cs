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
            return View(new cDpi());
        }
        [HttpGet]
        public IActionResult ModificarE(EUsuario usuario)
        {
            return View("ModificarE", usuario);
        }
        [HttpPost]
        public async Task<IActionResult> ModificarEp(EUsuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View("ModificarE", usuario);
            }
            await servicioConexion.ModUsuario(usuario);
            if (usuario.sn_activo == 0)
            {
                ModelState.AddModelError(nameof(usuario.dpi),
                    $"El DPI No.  {usuario.dpi} ya existe.");

                return View("ModificarE", usuario);
            }
            return View("Modificar");
        }

        [HttpPost]
        public async Task<IActionResult> _ParcialActualizar2(cDpi respuesta)
        { 
            var res = await servicioConexion.BuscarUs(respuesta.dpi);

            if (res)
            {
                var eusuario = await servicioConexion.BuscarU(respuesta.dpi);
                //return PartialView("~/Views/Shared/_ParcialActualizar.cshtml", eusuario);
                //return Ok(eusuario);
                return View("ModificarE", eusuario);
            }
            else
            {
                return View("pError");
            }
     
        }
        public async Task<IActionResult> Desactivar()
        {
            var eusuario = await servicioConexion.EObetener();
            return View(eusuario);
        }
        [HttpPost]
        public async Task<IActionResult> Desactivar([FromBody] string ids)
        {
            await servicioConexion.DesactrivarU(ids);
            return Ok();
        }
        //--------------------
        public async Task<IActionResult> Activar()
        {
            var eusuario = await servicioConexion.EObetener();
            return View(eusuario);
        }
        [HttpPost]
        public async Task<IActionResult> Activar([FromBody] string ids)
        {
            await servicioConexion.ActrivarU(ids);
            return Ok();
        }


        public async Task<IActionResult> Eliminar()
        {
            var eusuario = await servicioConexion.EObetener();
            return View(eusuario);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar([FromBody] string ids)
        {
            await servicioConexion.Eliminar(ids);
            return Ok();
        }

        public IActionResult pError () 
        {
            return View();
        }
    }
}
