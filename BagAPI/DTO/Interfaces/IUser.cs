using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Interfaces
{
    public abstract class BaseUser
    {
        int Id { get; set; }
        string Login { get; set; }
        string Email { get; set; }
        int PhoneNumber { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
