using Azure.Identity;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagedIdentityStorageSample.Controllers
{
    [ApiController]
    [Route("/")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string containerEndpoint = string.Format("https://{0}.blob.core.windows.net/{1}",
                                                        "funcappstorage2021",
                                                        "container1");

            BlobContainerClient containerClient = new BlobContainerClient(new Uri(containerEndpoint),
                                                                            new DefaultAzureCredential());

            BlobClient blobClient = containerClient.GetBlobClient("map.PNG");

            var bytes = blobClient.DownloadContent().Value.Content.ToArray();

            return File(bytes, "image/png");
        }
    }
}
