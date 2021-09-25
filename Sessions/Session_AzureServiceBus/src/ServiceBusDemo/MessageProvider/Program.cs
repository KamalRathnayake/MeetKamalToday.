using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System;

namespace MessageProvider
{
    class Program
    {
        static string connectionString = "";
        static string queueName = "the-queue";
        static ServiceBusClient client;
        static ServiceBusSender sender;
        static int index = 1;
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Sending batch {i}");
                SendBatch(1000);
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
                messageBatch.TryAddMessage(new ServiceBusMessage(JsonConvert.SerializeObject(new { id = index++ })));
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
