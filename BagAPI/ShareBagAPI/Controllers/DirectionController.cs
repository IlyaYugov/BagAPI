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

        //[Authorize(AuthenticationSchemes = "Bearer")]
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
        public async Task<FlightsDto> GetFlights(string from, string to, DateTime date, string offset, string limit, string lang = null)
        {
            return await directionDomain.GetFlights(from, to, date, offset, limit, lang);
        }
    }
}
