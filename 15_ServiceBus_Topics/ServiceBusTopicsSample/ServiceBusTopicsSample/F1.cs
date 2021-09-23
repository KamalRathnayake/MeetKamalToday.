using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ServiceBusTopicsSample
{
    public static class F1
    {
        [FunctionName("F1")]
        public static void Run([ServiceBusTrigger("messagecreated", "function1", Connection = "SBConnection")] string mySbMsg, ILogger log)
        {
            log.LogInformation($"F1: {mySbMsg}");
        }

        [FunctionName("F2")]
        public static void RunF2([ServiceBusTrigger("messagecreated", "function2", Connection = "SBConnection")] string mySbMsg, ILogger log)
        {
            log.LogInformation($"F2: {mySbMsg}");
        }
    }
}
