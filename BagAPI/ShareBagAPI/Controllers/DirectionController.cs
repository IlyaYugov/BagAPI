using Domain;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShareBagAPI.Controllers
{
    [Route("api/direction")]
    [ApiController]
    [Authorize]
    public class DirectionController : ControllerBase
    {
        private readonly DirectionDomain directionDomain;

        public DirectionController(DirectionDomain directionDomain)
        {
            this.directionDomain = directionDomain;
        }

        [Route("getDirections")]
        [HttpGet]
        public IEnumerable<CityDto> GetDirections(string search)
        {
            if (search?.Length < 3)
                return new List<CityDto>();

            return directionDomain.GetDirections(search);
        }

        [Route("getFlights")]
        [HttpGet]
        public async Task<ActionResult<FlightsDto>> GetFlights(string from, string to, DateTime date, string offset, string limit, string lang = null)
        {
            if (from == to)
                return BadRequest("Stations source and destination cannot be equal");

            return await directionDomain.GetFlights(from, to, date, offset, limit, lang);
        }
    }
}
