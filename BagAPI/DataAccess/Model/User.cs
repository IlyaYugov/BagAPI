using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [InverseProperty("Source")]
        public List<Request> SourceRequests { get; set; }
        [InverseProperty("Sender")]
        public List<Request> SenderRequests { get; set; }
        public List<UserMessenger> UserMessengers { get; set; }
    }
}
