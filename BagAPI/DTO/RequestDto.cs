using System;

namespace DTO
{
    public class RequestDto
    {
        public string FlightNumber { get; set; }
        public string Weight { get; set; }
        public string Way { get; set; }
        public DateTime Date { get; set; }
        public UserDto Source { get; set; }
        public UserDto Sender { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public byte[] Photo { get; set; }
        public int TypeId { get; set; }
    }
}
