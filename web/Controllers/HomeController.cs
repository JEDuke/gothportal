using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using gothportal.Models;
using gothportal.Services;

namespace gothportal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGothApiService gothApiService;

        private readonly ILogger<HomeController> logger;

        public HomeController(
            ILogger<HomeController> _logger,
            IGothApiService _gothApiService)
        {
            logger = _logger;
            gothApiService = _gothApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Image(string name)
        {
            return File(gothApiService.GetImage(name ?? "homepage1.jpeg"), "image/jpeg");
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