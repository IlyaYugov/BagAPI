using System;

namespace DTO
{
    public class BagRequestDto
    {
        public int Id { get; set; }
        public int RequestTypeId { get; set; }

        public BagDto Bag {get;set;}

        public UserDto TransfererUser { get; set; }
        public UserDto SenderUser { get; set; }

        public FlightDto Flight { get; set; }
    }
}
