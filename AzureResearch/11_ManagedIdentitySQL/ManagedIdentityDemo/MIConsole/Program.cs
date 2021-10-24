using Azure.Identity;
using Azure.Storage.Blobs;
using Microsoft.Azure.Services.AppAuthentication;
using System;

namespace MIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            AzureServiceTokenProvider provider = new AzureServiceTokenProvider();
            var token = provider.GetAccessTokenAsync("https://database.windows.net").GetAwaiter().GetResult();


            // Construct the blob container endpoint from the arguments.
            string containerEndpoint = string.Format("https://{0}.blob.core.windows.net/{1}",
                                                        "cs1100320011d7e69f4",
                                                        "container1");

            // Get a credential and create a service client object for the blob container.
            BlobContainerClient containerClient = new BlobContainerClient(new Uri(containerEndpoint),
                                                                            new DefaultAzureCredential());

            BlobClient blobClient = containerClient.GetBlobClient("map.PNG");

            var bytes = blobClient.DownloadContent().Value.Content.ToArray();
            Console.WriteLine("Hello World!");
        }
    }
}
