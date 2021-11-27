using Azure.Core;
using Azure.Messaging.WebPubSub;
using System;
using System.Threading;

namespace WebPubSubBackendConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Endpoint=https://webpubsubdemo2021.webpubsub.azure.com;AccessKey=xbsecfIWtQEGgGpwvkHMoG17HhmcLEKfQKbC7CfJt1o=;Version=1.0;";
            var hubName = "first_hub";
            var serviceClient = new WebPubSubServiceClient(connectionString,
                                                           hubName);
            int index = 1;
            while (true)
            {
                serviceClient.SendToAll(RequestContent.Create(
                new
                {
                    Foo = $"Hello World! {index++}",
                }),
                ContentType.ApplicationJson);
                Thread.Sleep(1000);
            }
        }
    }
}
