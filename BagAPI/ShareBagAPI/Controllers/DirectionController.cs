using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ShareBagAPI.Controllers
{
    [Route("api/direction")]
    [ApiController]
    public class DirectionController : ControllerBase
    {
        [Route("getDirections")]
        [HttpGet]
        public List<CityDto> GetDirections(string search)
        {
            return new DirectionsResponseModel();
        }

        [Route("getFlights")]
        [HttpGet]
        public List<FlightDto> GetFlights(int skip, int take, string departure, string arrival)
        {
            return new DirectionsResponseModel();
        }
    }
}
