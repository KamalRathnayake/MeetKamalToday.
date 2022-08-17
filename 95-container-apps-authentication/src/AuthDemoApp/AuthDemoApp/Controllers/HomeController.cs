using AuthDemoApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AuthDemoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var headers = Request.Headers.ToList();
            ViewBag.Headers = headers;
            ViewBag.Email = headers?.FirstOrDefault(x => x.Key == "X-MS-CLIENT-PRINCIPAL-NAME").Value;
            return View();
        }

        public IActionResult Authentication()
        {
            return View();
        }

        public IActionResult LogoutSuccess()
        {
            return View();
        }
    }
}