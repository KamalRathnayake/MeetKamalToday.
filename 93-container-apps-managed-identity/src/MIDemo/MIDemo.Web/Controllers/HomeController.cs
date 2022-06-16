using Microsoft.AspNetCore.Mvc;
using MIDemo.Web.Models;
using System.Diagnostics;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;

namespace MIDemo.Web.Controllers
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
            try
            {
                SecretClientOptions options = new SecretClientOptions()
                {
                    Retry =
                    {
                        Delay= TimeSpan.FromSeconds(2),
                        MaxDelay = TimeSpan.FromSeconds(16),
                        MaxRetries = 5,
                        Mode = RetryMode.Exponential
                     }
                };
                var keyValueName = Environment.GetEnvironmentVariable("KEY_VAULT_NAME");
                var client = new SecretClient(new Uri($"https://{keyValueName}.vault.azure.net/"), new DefaultAzureCredential(), options);

                KeyVaultSecret secret = client.GetSecret("MySecret");

                ViewBag.SecretValue = secret.Value;
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.ToString();
            }
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