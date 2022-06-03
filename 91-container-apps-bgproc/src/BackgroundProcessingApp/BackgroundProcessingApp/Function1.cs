using System;
using System.Threading;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace BackgroundProcessingApp
{
    public class Function1
    {
        [FunctionName("Function1")]
        public void Run([QueueTrigger("myqueue", Connection = "connectionString")]string myQueueItem, ILogger log)
        {
            Thread.Sleep(10000);
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
