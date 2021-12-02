//using Azure.Messaging.ServiceBus;
//using Newtonsoft.Json;
//using System;

//namespace MessageProvider
//{
//    class Program
//    {
//        static string connectionString = "Endpoint=sb://servicebusns2021.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=ooWwT+ZzwIwPbqgpulOnUP8cjc8Rej8NuO4jpllwCSs=";
//        static string queueName = "the-queue";
//        static ServiceBusClient client;
//        static ServiceBusSender sender;
//        static int index = 1;
//        static void Main(string[] args)
//        {
//            client = new ServiceBusClient(connectionString);
//            sender = client.CreateSender(queueName);
//            using ServiceBusMessageBatch messageBatch = sender.CreateMessageBatchAsync().GetAwaiter().GetResult();

//            var message = new ServiceBusMessage(JsonConvert.SerializeObject(new { id = 1, name="John" }));
//            message.MessageId = "1234";
//            messageBatch.TryAddMessage(message);

//            try
//            {
//                sender.SendMessagesAsync(messageBatch).GetAwaiter().GetResult();
//            }
//            finally
//            {
//                sender.DisposeAsync().GetAwaiter().GetResult();
//                client.DisposeAsync().GetAwaiter().GetResult();
//            }
//        }
//        public static void SendBatch(int batchSize)
//        {
//        }
//    }
//}
