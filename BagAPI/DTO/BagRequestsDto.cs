using System;

namespace DTO
{
    public class BagRequestsDto
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public DateTime Date { get; set; }
        public int BagWeight { get; set; }
        public int BagPrice { get; set; }
        public string DepatrureStation { get; set; }
        public string ArrivalStation { get; set; }
    }
}
