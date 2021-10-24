using Azure.Identity;
using Azure.Storage.Blobs;
using ManagedIdentityDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagedIdentityDemo.Controllers
{
    [ApiController]
    [Route("/")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly SqldatabaseContext _context;

        public WeatherForecastController(SqldatabaseContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var customers = _context.Customers.ToListAsync().GetAwaiter().GetResult();
            return Ok(JsonConvert.SerializeObject(customers));
        }
        [HttpGet]
        [Route("/storage")]
        public IActionResult GetImage()
        {
            // Construct the blob container endpoint from the arguments.
            string containerEndpoint = string.Format("https://{0}.blob.core.windows.net/{1}",
                                                        "cs1100320011d7e69f4",
                                                        "container1");

            // Get a credential and create a service client object for the blob container.
            BlobContainerClient containerClient = new BlobContainerClient(new Uri(containerEndpoint),
                                                                            new DefaultAzureCredential());

            BlobClient blobClient = containerClient.GetBlobClient("map.PNG");

            var bytes = blobClient.DownloadContent().Value.Content.ToArray();
            return File(bytes, "image/png");
        }
    }
}
