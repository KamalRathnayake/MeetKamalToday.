using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_AZURE_REDIS_DOTNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IDistributedCache _distributedCache;
        public WeatherForecastController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var valueFromCache = await _distributedCache.GetStringAsync("key_1");
            if (!string.IsNullOrEmpty(valueFromCache))
            {
                return Ok(valueFromCache);
            }
            else
            {
                string valueFromStorage = await GetFromStorageAsync("kamalscontainer", "sample_text.txt");
                await _distributedCache.SetStringAsync("key_1", valueFromStorage);
                return Ok(valueFromStorage);
            }
        }

        private async Task<string> GetFromStorageAsync(string containerName, string fileName)
        {
            string storageAccount_connectionString = "DefaultEndpointsProtocol=https;AccountName=funcstoragex1x1;AccountKey=6UehWVFAqRCwdy+DKQ22opUi864+38I1CaQKvmiXAmcOTzX33ynmV+X8F62ckTd/z4rRTK0av1PxNOngnIPMxA==;EndpointSuffix=core.windows.net";

            CloudStorageAccount mycloudStorageAccount = CloudStorageAccount.Parse(storageAccount_connectionString);
            CloudBlobClient blobClient = mycloudStorageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            CloudBlockBlob cloudBlockBlob = container.GetBlockBlobReference(fileName);

            return await cloudBlockBlob.DownloadTextAsync();
        }
    }
}
