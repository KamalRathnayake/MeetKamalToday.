using ManagedIdentityDemo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagedIdentityDemo.Controllers
{
    [ApiController]
    [Route("/")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly SqldatabaseContext _context;

        public WeatherForecastController(SqldatabaseContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var customers = _context.Customers.ToListAsync().GetAwaiter().GetResult();
            return Ok(JsonConvert.SerializeObject(customers));
        }
    }
}
