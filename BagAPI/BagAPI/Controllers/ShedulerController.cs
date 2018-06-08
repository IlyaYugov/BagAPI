using System.Collections.Generic;
using BagAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BagAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Sheduler")]
    public class ShedulerController : Controller
    {
        [HttpGet("/api/Sheduler/GetCities")]
        public IEnumerable<TwoDto> GetCities()
        {
            return new List<TwoDto>();
        }

        [HttpGet("/api/Sheduler/GetRequestList")]
        public IEnumerable<RequestDto> GetRequestList(Filter filter)
        {
            return new List<RequestDto>();
        }


        [HttpGet("/api/Sheduler/GetOrder")]
        public RequestDto GetOrder(int id)
        {
            return new RequestDto();
        }

        [HttpPut("/api/Sheduler/AproveReuest")]
        public RequestDto AproveReuest(int orderId, int senderId = 0)
        {
            return new RequestDto();
        }

        [HttpPost("/api/Sheduler/CreateRequest")]
        public RequestDto CreateRequest(RequestDto userDto)
        {
            return new RequestDto();
        }

        [HttpPut("/api/Sheduler/UpdateRequest")]
        public RequestDto UpdateRequest(RequestDto userDto)
        {
            return new RequestDto();
        }
    }
}