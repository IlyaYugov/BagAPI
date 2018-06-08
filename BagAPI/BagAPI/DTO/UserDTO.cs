using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BagAPI.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public int PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Messengers { get; set; }
    }
}
