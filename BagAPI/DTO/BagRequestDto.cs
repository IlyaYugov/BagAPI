using System;

namespace DTO
{
    public class BagRequestDto
    {
        public string FlightNumber { get; set; }
        public DateTime Date { get; set; }
        public byte[] Photo { get; set; }

        public BagDto Bag {get;set;}

        public UserDto SourceUser { get; set; }
        public UserDto SenderUser { get; set; }

        public CityDto SourceDirection { get; set; }
        public CityDto DestinationDirection { get; set; }
    }
}
