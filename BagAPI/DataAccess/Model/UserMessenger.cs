namespace DataAccess.Model
{
    public class UserMessenger
    {
        public int MessengerTypeId { get; set; }
        public int UserId { get; set; }
        public string Contact { get; set; }

        public MessengerType MessengerType { get; set; }
        public User User { get; set; }
    }
}