using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Writer.Models;

namespace Writer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile upload)
        {
            if (upload != null && upload.Length > 0)
            {
                var fileName = Path.GetFileName(upload.FileName);
                var directory = Path.Combine(Directory.GetCurrentDirectory(), "images");
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
                var filePath = Path.Combine(directory, fileName);
                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                    await upload.CopyToAsync(fileSrteam);
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}