using System.Collections.Generic;

namespace DTO
{
    public class UserDto //: BaseUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Skype { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
