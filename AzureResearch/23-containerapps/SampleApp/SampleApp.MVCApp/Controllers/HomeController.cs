using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SampleApp.MVCApp.Models;
using System.Diagnostics;

namespace SampleApp.MVCApp.Controllers
{
    public class Todo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; }
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            // https://my-sample-api.calmbush-7a3a87fb.eastus.azurecontainerapps.io/
            // <APP_NAME>.internal.<UNIQUE_IDENTIFIER>.<REGION_NAME>.azurecontainerapps.io/todos
            var result = await client.GetAsync("https://my-sample-api.internal.calmbush-7a3a87fb.eastus.azurecontainerapps.io/todos");
            var text = await result.Content.ReadAsStringAsync();
            ViewBag.Todos = JsonConvert.DeserializeObject<List<Todo>>(text);

            if (ViewBag.Todos == null)
                ViewBag.Todos = new List<Todo>
                {
                    new Todo
                    {
                        Id = 1,
                        Name = "Fix the APIs"
                    },

                    new Todo
                    {
                        Id = 1,
                        Name = "Then try again"
                    }
                };

            return View();
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