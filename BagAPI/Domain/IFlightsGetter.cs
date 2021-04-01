using DTO;
using System;
using System.Threading.Tasks;

namespace Domain
{
    public interface IFlightsGetter
    {
        Task<FlightsDto> GetFlights(string from, string to, DateTime date, string offset, string limit, string lang = null);
    }
}
