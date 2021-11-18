using System.Collections.Generic;
using System.Linq;
using System.Net;
using AzFunctionsDITest.Data;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzFunctionsDITest
{
    public class Function1
    {
        public readonly ISampleService _sampleService;
        private readonly MydatabaseContext _context;

        public Function1(ISampleService sampleService, MydatabaseContext context)
        {
            this._sampleService = sampleService;
            this._context = context;
        }

        [Function("Function1")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Function1");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            var message = JsonConvert.SerializeObject(_context.Customers.ToList());
            response.WriteString(message);

            return response;
        }
    }
}
