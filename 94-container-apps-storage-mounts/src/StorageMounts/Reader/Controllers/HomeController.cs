using Microsoft.AspNetCore.Mvc;
using Reader.Models;
using System.Diagnostics;

namespace Reader.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var directory = Path.Combine(Directory.GetCurrentDirectory(), "images");
            ViewBag.Files = Directory.EnumerateFiles(directory)
                                     .Select(x => new FileInfo(x).Name)
                                     .ToList();
            return View();
        }
    }
}