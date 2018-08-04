namespace DataAccess.Model
{
    public class Request
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Descrition { get; set; }
        public int BagId { get; set; }
        public int SourceUserId { get; set; }
        public int SenderUserId { get; set; }
        public int StatusId { get; set; }
        public int FlightId { get; set; }

        public User Source { get; set; }
        public User Sender { get; set; }
        public Bag Bag { get; set; }
        public RequestStatus Status { get; set; }
        public Flight Flight { get; set; }
    }
}