using AzFunctionsDITest.Data;
using Microsoft.Azure.Functions.Worker.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace AzFunctionsDITest
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(services =>
                {
                    services.AddDbContext<MydatabaseContext>(options =>
                    {
                        options.UseSqlServer("Server=myserver20211031.database.windows.net;Database=mydatabase;User Id=kamal;Password=Hello@12345#;");
                    });
                    services.AddTransient<ISampleService, GreatService>();
                })
                .Build();

            host.Run();
        }
    }
}