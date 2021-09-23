using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace DataCenterLatencyTest.FunctionApp
{
    public static class Function3
    {
        [FunctionName("Function3")]
        public static void Run([ServiceBusTrigger("messageinserted", "localfunc1", Connection = "ServiceBusConnection")] string mySbMsg, ILogger log)
        {
            log.LogInformation($"LF1 C# ServiceBus topic trigger function processed message: {mySbMsg}");
        }

        [FunctionName("Function4")]
        public static void Run2([ServiceBusTrigger("messageinserted", "localfunc2", Connection = "ServiceBusConnection")] string mySbMsg, ILogger log)
        {
            log.LogInformation($"LF2 C# ServiceBus topic trigger function processed message: {mySbMsg}");
        }
    }
}
