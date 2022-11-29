using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using gothportal.Models;
using System.IO;
using gothportal.Services;
using Azure.Storage.Blobs;

namespace gothportal.Controllers
{
    public class AboutController : Controller
    {
        private readonly IGothApiService gothApiService;

        private readonly ILogger<AboutController> logger;

        public AboutController(
            ILogger<AboutController> _logger,
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
        public IActionResult HomePage()
        {
            return File(gothApiService.GetImage("homepage1.jpeg"), "image/jpeg");
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