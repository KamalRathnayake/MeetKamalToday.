```bash
$loc = "southeastasia"
$grp = "06OverloadTestRG"
$pln = "06OLTEST-SEA"
$appname = "seasiaapp2021"

az group create --name $grp --location $loc
az appservice plan create --name 03TFPlan --resource-group $grp --location $loc --sku S1
az webapp create --name $appname --plan 03TFPlan --resource-group $grp
az webapp deployment user set --user-name kamal1 --password kamal12345
```

# CREATING DOTNET APPLICATION
```bash
mkdir mywebapi
cd mywebapi
dotnet new webapi --framework netcoreapp3.1 --no-restore
```

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace mywebapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrimesController : ControllerBase
    {
        [HttpGet]
        [Route("{n}")]
        public IActionResult Get(int n)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var count = PrimeCount(n);
            watch.Stop();
            return Ok($"Primes - {count}, Time Taken - {watch.ElapsedMilliseconds}ms, Instance Id - {Environment.GetEnvironmentVariable("WEBSITE_INSTANCE_ID")}");
        }

        public static int PrimeCount(int lessThanN)
        {
            Func<int, bool> isPrime = new Func<int, bool>((n) =>
              {
                  int i, m = 0, flag = 0;
                  m = n / 2;
                  for (i = 2; i <= m; i++)
                  {
                      if (n % i == 0)
                      {
                          return false;
                          flag = 1;
                          break;
                      }
                  }
                  return flag == 0;
              });

            int primeCount = 0;
            for (int i = 1; i < lessThanN; i++)
                primeCount += isPrime(i) ? 1 : 0;
            return primeCount;
        }

    }
}

```
```bash
git init
git add .
git commit -m initial


# PUBLISHING DOTNET APP TO AZURE
az webapp deployment source config-local-git --name $appname --resource-group $grp
$url=$(az webapp deployment source config-local-git --name $appname --resource-group $grp --output json --query url)

git remote add azure1 $url
git push azure1 master
```