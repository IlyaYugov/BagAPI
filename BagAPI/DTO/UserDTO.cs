﻿using System.Collections.Generic;

namespace DTO
{
    public class UserDto //: BaseUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public int PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<string> Messengers { get; set; }
    }
}
