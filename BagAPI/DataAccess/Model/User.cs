using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DTO.Interfaces;

namespace DataAccess.Model
{
    public class User : BaseUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Skype{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [InverseProperty("TransfererUser")]
        public List<BagRequest> SourceRequests { get; set; }
        [InverseProperty("SenderUser")]
        public List<BagRequest> SenderRequests { get; set; }
    }
}
