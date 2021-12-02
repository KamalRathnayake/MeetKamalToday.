using System;
using System.Threading;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QueueConsumer.Data;

namespace QueueConsumer
{
    public class QueueReceiver
    {
        [FunctionName("QueueReceiver")]
        public void Run([ServiceBusTrigger("queue", Connection = "QueueConnection")]string myQueueItem, ILogger log)
        {
            var context = new MydatabaseContext();
            var input = JsonConvert.DeserializeObject<Messages>(myQueueItem);
            context.Messages.Add(input);
            context.SaveChanges();

            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
