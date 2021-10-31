using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzFunctionsDITest
{
    public interface ISampleService
    {
        Task<string> GetMessage();
    }

    public class GreatService : ISampleService
    {
        Task<string> ISampleService.GetMessage()
        {
            return Task.FromResult($"Hello from {nameof(GreatService)}");
        }
    }
}
