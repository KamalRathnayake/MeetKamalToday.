using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace BindingsDemo
{
    public static class F2_SBQueueTrigger
    {
        [FunctionName("F2_SBQueueTrigger")]
        public static void Run([ServiceBusTrigger("the-queue", Connection = "ServiceBusConnection")]string myQueueItem,
            [Blob("container1/{sys.randguid}", FileAccess.Write, Connection = "StorageAccountConnection")] Stream document,
            ILogger log)
        {
            StreamWriter writer = new StreamWriter(document);
            writer.WriteLine(myQueueItem);
            writer.Flush();
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }

        public class User
        {
            public string PartitionKey { get; set; }
            public string RowKey { get; set; }
            public string Name { get; set; }
        }

    }
}
