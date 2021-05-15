using Domain;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShareBagAPI.Controllers
{
    [Route("api/bagRequest")]
    [ApiController]
    [Authorize]
    public class BagRequestController : ControllerBase
    {
        private readonly BagRequestDomain bagRequestDomain;

        public BagRequestController(BagRequestDomain bagRequestDomain)
        {
            this.bagRequestDomain = bagRequestDomain;
        }

        // GET: api/<BagRequestController>
        [HttpGet]
        public IEnumerable<BagRequestsDto> Get(DateTime from, DateTime to, string depatrureStationCode, string arrivalStationCode, int typeId)
        {
            return bagRequestDomain.GetBagRequests(from, to, depatrureStationCode, arrivalStationCode, typeId);
        }

        // GET api/<BagRequestController>/5
        [HttpGet("{id}")]
        public BagRequestDto Get(int id)
        {
            return bagRequestDomain.GetBagRequest(id);
        }

        // POST api/<BagRequestController>
        [HttpPost]
        public ActionResult Post(BagRequestDto bagRequest)
        {
            var userId = Convert.ToInt32(User.Claims.First(c => c.Type == AuthOptions.Id).Value);
            bagRequestDomain.CreateBagRequest(bagRequest, userId);

            return Ok(new { });
        }

        // PUT api/<BagRequestController>/5
        [HttpPatch("deal/{id}")]
        public BagRequestDto Deal(int id)
        {
            var email = User.Identity.Name;

            return bagRequestDomain.Deal(id, email);
        }

        // PUT api/<BagRequestController>/5
        [HttpPatch("unDeal/{id}")]
        public BagRequestDto unDeal(int id)
        {
            var email = User.Identity.Name;

            return bagRequestDomain.UnDeal(id, email);
        }

        // DELETE api/<BagRequestController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var userId = Convert.ToInt32(User.Claims.First(c => c.Type == AuthOptions.Id).Value);

            var isSuccessfulDelete = bagRequestDomain.DeleteBagRequest(id, userId);

            if(isSuccessfulDelete)
            {
                return Ok(new { });
            }
            else
            {
                return BadRequest("You can't delete this request");
            }
        }
    }
}
