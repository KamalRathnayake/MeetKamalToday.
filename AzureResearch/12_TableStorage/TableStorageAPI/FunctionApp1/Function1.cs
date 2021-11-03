using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using Azure.Data.Tables;
using Azure.Data.Tables.Models;
using Azure;
using System.Linq;

namespace FunctionApp1
{
    public class Person: TableEntity
    {
        public string RowKey { get; set; }
        public string PartitionKey { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            var tableClient = new TableClient("DefaultEndpointsProtocol=https;AccountName=st20211022;AccountKey=XqgoGgd2kh5IUYc6TIG3rm1A41Ux2RzwTXNrayscJTwDGi/F8dHVyw0oR35pzjtEk39Tx/XFya+F+/RAll3g+g==;EndpointSuffix=core.windows.net", "outTable");

            Pageable<TableEntity> queryResultsFilter = tableClient.Query<TableEntity>(filter: $"PartitionKey eq 'Users'");

            foreach (TableEntity qEntity in queryResultsFilter)
            {
                Console.WriteLine($"{qEntity.GetString("Name")}: {qEntity.GetInt32("Age")}");
            }

            return new OkObjectResult("Done");
        }
    }
}
