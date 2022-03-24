using CosmosDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosDemo.Web.Controllers
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // ADD THIS PART TO YOUR CODE

        // The Azure Cosmos DB endpoint for running this sample.
        private static readonly string EndpointUri = "https://cosmosx123.documents.azure.com:443/";
        // The primary key for the Azure Cosmos account.
        private static readonly string PrimaryKey = "6GPnqBPKjF7BKrZLysaRMKpW0QU4FPJiZFysfQv1WExJghtzXgk32nIsNwxIdyHJN1JVFzfvdbuNPpq84rvWXQ==";

        // The Cosmos client instance
        private CosmosClient cosmosClient;

        // The database we will create
        private Database database;

        // The container we will create.
        private Container container;

        // The name of the database and container we will create
        private string databaseId = "users";
        private string containerId = "users";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            // Create a new instance of the Cosmos Client
            this.cosmosClient = new CosmosClient(EndpointUri, PrimaryKey);
            this.database = await this.cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
            this.container = await this.database.CreateContainerIfNotExistsAsync(containerId, "/id");


            var sqlQueryText = "SELECT * FROM c";


            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            FeedIterator<User> queryResultSetIterator = this.container.GetItemQueryIterator<User>(queryDefinition);

            List<User> users = new List<User>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<User> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (var user in currentResultSet)
                {
                    users.Add(user);
                }
            }
            ViewBag.Users = users;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
