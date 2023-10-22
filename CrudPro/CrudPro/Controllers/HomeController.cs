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
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            this.giphyService = new GiphyService(apiKey);
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}