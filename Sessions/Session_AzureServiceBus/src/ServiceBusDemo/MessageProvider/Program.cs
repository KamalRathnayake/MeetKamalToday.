using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System;

namespace MessageProvider
{
    class Program
    {
        static string connectionString = "Endpoint=sb://sessionsdemo.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=EtSOBkRhoGdVltbCHZg9EpYoVzoAK3G3TuC/L8Bzr9I=";
        static string queueName = "queue";
        static ServiceBusClient client;
        static ServiceBusSender sender;
        static int index = 1;
        static void Main(string[] args)
        {
            for (int i = 0; i < 50; i++)
            {
                Console.Write($"Sending batch {i}");
                SendBatch(100);
                Console.WriteLine($" - Done. Last Message - {index}");
            }
        }
        public static void SendBatch(int batchSize)
        {
            client = new ServiceBusClient(connectionString);
            sender = client.CreateSender(queueName);
            using ServiceBusMessageBatch messageBatch = sender.CreateMessageBatchAsync().GetAwaiter().GetResult();

            for (int i = 0; i < batchSize; i++)
            {
                var message = new ServiceBusMessage(JsonConvert.SerializeObject(new { inputId = index++ }));
                messageBatch.TryAddMessage(message);
            }

            try
            {
                sender.SendMessagesAsync(messageBatch).GetAwaiter().GetResult();
            }
            finally
            {
                sender.DisposeAsync().GetAwaiter().GetResult();
                client.DisposeAsync().GetAwaiter().GetResult();
            }
        }
    }
}
