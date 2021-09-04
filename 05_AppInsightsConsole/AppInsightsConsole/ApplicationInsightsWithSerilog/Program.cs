using Microsoft.ApplicationInsights.Extensibility;
using Serilog;
using System.Threading;

namespace ApplicationInsightsWithSerilog
{
    class Program
    {
        static void Main(string[] args)
        {
            using var log = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("file.txt")
                   .WriteTo.ApplicationInsights(new TelemetryConfiguration { InstrumentationKey = "2d938b53-d209-47e7-906a-aa31a28a099a" }, TelemetryConverter.Traces)
                   .CreateLogger();
            int i = 0;
            while (true)
            {
                log.Information($"Hello From Serilog! {++i}");
                Thread.Sleep(1000);
            }
        }
    }
}