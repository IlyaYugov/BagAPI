using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShareBagAPI.Controllers
{
    [Route("api/bagRequest")]
    [ApiController]
    public class BagRequestController : ControllerBase
    {
        // GET: api/<BagRequestController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BagRequestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BagRequestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BagRequestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BagRequestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
