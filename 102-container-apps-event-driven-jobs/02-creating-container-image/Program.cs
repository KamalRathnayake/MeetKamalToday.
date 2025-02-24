using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

class Program
{
    static async Task Main()
    {
        Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Running job...");
        await ProcessMessagesAsync();
        Console.WriteLine("Job completed.");
    }

    static async Task ProcessMessagesAsync()
    {
        var (connectionString, topicName, subscriptionName) = GetServiceBusConfig();
        if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(topicName) || string.IsNullOrEmpty(subscriptionName))
        {
            Console.WriteLine("Missing Service Bus configuration. Please set the required environment variables.");
            return;
        }

        await using var client = new ServiceBusClient(connectionString);
        var receiver = client.CreateReceiver(topicName, subscriptionName);

        Console.WriteLine("Polling messages...");
        var messages = await receiver.ReceiveMessagesAsync(10);

        if (messages.Count == 0)
        {
            Console.WriteLine("No new messages. Exiting...");
            return;
        }

        Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Received {messages.Count} messages.");
        foreach (var message in messages)
        {
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Processing message: {message.Body}");
            await Task.Delay(1000);
            await receiver.CompleteMessageAsync(message);
        }
    }

    static (string connectionString, string topicName, string subscriptionName) GetServiceBusConfig() => (
        Environment.GetEnvironmentVariable("SERVICEBUS_CONNECTION_STRING"),
        Environment.GetEnvironmentVariable("SERVICEBUS_TOPIC_NAME"),
        Environment.GetEnvironmentVariable("SERVICEBUS_SUBSCRIPTION_NAME")
    );
}
