using System.Collections.Generic;

namespace DTO
{
    public class FlightsDto
    {
        public int Total { get; set; }

        public IEnumerable<FlightDto> Flights { get; set; }
    }
}
