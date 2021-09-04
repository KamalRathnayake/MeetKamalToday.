# Approach 1

## Installing Packages
```bash
install-package Microsoft.ApplicationInsights
install-package Microsoft.ApplicationInsights.WindowsServer.TelemetryChannel
install-package Microsoft.Extensions.DependencyInjection
install-package Microsoft.Extensions.Logging
install-package Microsoft.Extensions.Logging.ApplicationInsights
```

## Code Snippet
```csharp
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.WindowsServer.TelemetryChannel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace ApplicationInsightsWithSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            var channel1 = new ServerTelemetryChannel();
            services.Configure<TelemetryConfiguration>(
                (config) =>
                {
                    config.TelemetryChannel = channel1;
                }
            );

            services.AddLogging(builder =>
            {
                builder.AddApplicationInsights("INSIGHTS KEY");
            });

            var provider = services.BuildServiceProvider();
            var logger = provider.GetService<ILogger<Program>>();
            int i = 0;
            while (true)
            {
                logger.LogInformation($"Hello From Console {++i}");
                Thread.Sleep(1000);
            }
        }
    }
}
```


# Approach 2

## Installing Packages
```bash
install-package Microsoft.Extensions.Configuration.Abstractions
install-package Serilog
install-package Serilog.Sinks.Console
install-package Serilog.Sinks.File
install-package Serilog.Sinks.ApplicationInsights
```

## Code Snippet
```csharp
using Microsoft.ApplicationInsights.Extensibility;
using Serilog;
using System.Threading;

namespace _11_console_serilog
{
    class Program
    {
        static void Main(string[] args)
        {
            using var log = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("file.txt")
                   .WriteTo.ApplicationInsights(new TelemetryConfiguration { InstrumentationKey = "INSIGHTS KEY" }, TelemetryConverter.Traces)
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
```