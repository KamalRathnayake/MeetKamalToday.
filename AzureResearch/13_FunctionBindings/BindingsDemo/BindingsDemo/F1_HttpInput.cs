using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BindingsDemo
{
    public static class HttpInput
    {
        [FunctionName("F1_HttpInput")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [ServiceBus("the-queue", Connection = "ServiceBusConnection")] ICollector<dynamic> serviceBueQueueOutput,
            ILogger log)
        {
            string input = req.Query["input"];
            serviceBueQueueOutput.Add(input);
            return new OkResult();
        }
    }
}
