using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using gothportal.Models;
using System.IO;
using gothportal.Services;

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
            var path = "wwwroot/images/";
            ViewBag.homepageImageCount = Directory.GetFiles(path, "homepage*.jpeg", SearchOption.AllDirectories).Length;
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Notes()
        {
            return View();
        }

        public IActionResult Privacy(string keyId)
        {
            var message = gothApiService.GetMessage(keyId);
            ViewBag.message = message;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
