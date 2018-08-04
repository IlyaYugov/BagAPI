using System.Collections.Generic;

namespace DataAccess.Model
{
    public class MessengerType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<UserMessenger> UserMessengers { get; set; }
    }
}