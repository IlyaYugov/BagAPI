using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BagAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Sheduler")]
    public class ShedulerController : Controller
    {
        [HttpGet]
        public IEnumerable<string> GetCities()
        {
            return new[] { "value1", "value2" };
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }
    }
}