using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            StoredbContext context = new StoredbContext();
            var list = context.Customers.ToList();
            return Ok(list);
        }
    }
}
