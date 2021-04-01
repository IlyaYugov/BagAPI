using System;

namespace DTO
{
    public class FlightDto
    {
        public string FlightNumber { get; set; }
        public string DepatrureStationCode { get; set; }
        public string ArrivalStationCode { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
