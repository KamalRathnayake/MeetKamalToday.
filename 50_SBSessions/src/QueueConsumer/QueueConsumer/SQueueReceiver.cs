using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QueueConsumer.Data;

namespace QueueConsumer
{
    public class SQueueReceiver
    {
        [FunctionName("SessionQueueReceiver")]
        public void Run([ServiceBusTrigger("s-queue", Connection = "QueueConnection", IsSessionsEnabled = true)] string myQueueItem, ILogger log)
        {
            var context = new MydatabaseContext();
            var input = JsonConvert.DeserializeObject<SessionMessages>(myQueueItem);
            context.SessionMessages.Add(input);
            context.SaveChanges();
            
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
