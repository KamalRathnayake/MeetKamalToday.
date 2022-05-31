using HPDemoApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HPDemoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<string> logs = new List<string>();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        void Log(string message)
        {
            Console.WriteLine("CW - " + message);
            this._logger.LogInformation(message);
            logs.Add(message);
        }
        public IActionResult Index()
        {
            ViewBag.Logs = logs;
            ViewBag.InstanceId = Environment.GetEnvironmentVariable("HOSTNAME");
            return View();
        }

        public IActionResult Liveness()
        {
            Log($"{DateTime.UtcNow} -- Liveness {logs.Count}");
            if (logs.Count <= 10)
                return Ok();
            else
                return BadRequest();
        }
        public IActionResult Readiness()
        {
            Log($"{DateTime.UtcNow} -- Readiness {logs.Count}");
            return Ok();
        }
        public IActionResult Startup()
        {
            Log($"{DateTime.UtcNow} -- Startup {logs.Count}");
            return Ok();
        }
    }
}