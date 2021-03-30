namespace DataAccess.Model
{
    public class BugRequest
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Descrition { get; set; }

        public int BagId { get; set; }
        public Bag Bag { get; set; }

        public int SourceUserId { get; set; }
        public User SourceUser { get; set; }

        public int SenderUserId { get; set; }
        public User SenderUser { get; set; }

        public int StatusId { get; set; }
        public RequestStatus RequestStatus { get; set; }

        public int TripId { get; set; }
        public Trip Trip { get; set; }
    }
}