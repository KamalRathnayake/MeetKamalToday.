//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Net;
//using Microsoft.Azure.Functions.Worker;
//using Microsoft.Azure.Functions.Worker.Http;
//using Microsoft.Extensions.Logging;

//namespace TableStorageAPI
//{

//    public class Person
//    {
//        public string RowKey { get; set; }
//        public string PartitionKey { get; set; }
//        public string Name { get; set; }
//        public int Age { get; set; }
//    }
//    public static class Function1
//    {
//        [Function("Function1")]
//        public static HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
//            [Table("SAMPLE")] CloudTable table,
//            FunctionContext executionContext)
//        {
//            var logger = executionContext.GetLogger("Function1");
//            logger.LogInformation("C# HTTP trigger function processed a request.");

//            var response = req.CreateResponse(HttpStatusCode.OK);
//            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

//            response.WriteString("Welcome to Azure Functions!");

//            return response;
//        }
//    }
//}
