using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace BindingsSample
{
    public static class F2_SBQueueTrigger
    {
        [FunctionName("F2_SBQueueTrigger")]
        public static void Run([ServiceBusTrigger("the-queue", Connection = "SBConnection")]string myQueueItem,
            [Blob("container1/{sys.randguid}", System.IO.FileAccess.Write, Connection = "StorageConnection")] Stream stream,
            ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(myQueueItem);
            writer.Flush();
        }
    }
}
