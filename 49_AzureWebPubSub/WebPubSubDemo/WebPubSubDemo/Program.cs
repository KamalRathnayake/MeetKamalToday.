using Azure;
using Azure.Core;
using Azure.Messaging.WebPubSub;
using System;
using System.IO;

namespace WebPubSubDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceClient = new WebPubSubServiceClient("Endpoint=https://webpub1.webpubsub.azure.com;AccessKey=spi5sANERUCA4Q7ZarTfKfu6rt+yTVSkbZv5NROi+I0=;Version=1.0;", "first_hub");

            serviceClient.SendToAll("Hello World!");

            serviceClient.SendToAll(RequestContent.Create(
            new
            {
                Foo = "Hello World!",
                Bar = 42
            }),
            ContentType.ApplicationJson);

            Stream stream = BinaryData.FromString("Hello World!").ToStream();
            serviceClient.SendToAll(RequestContent.Create(stream), ContentType.ApplicationOctetStream);
        }
    }
}
