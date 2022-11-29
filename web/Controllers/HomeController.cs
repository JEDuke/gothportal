using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using gothportal.Models;
using gothportal.Services;
using Microsoft.Extensions.Configuration;

namespace gothportal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGothApiService gothApiService;
        private readonly IConfiguration configuration;
        private readonly ILogger<HomeController> logger;

        public HomeController(
            ILogger<HomeController> _logger,
            IGothApiService _gothApiService,
            IConfiguration _configuration)
        {
            logger = _logger;
            gothApiService = _gothApiService;
            configuration = _configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Image(string name)
        {
            var defaultImageName = configuration["defaultImageName"];
            return File(gothApiService.GetImage(name ?? defaultImageName), "image/jpeg");
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