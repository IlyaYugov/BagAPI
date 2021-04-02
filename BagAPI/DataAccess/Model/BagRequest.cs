namespace DataAccess.Model
{
    public class BagRequest
    {
        public int Id { get; set; }

        public int BagId { get; set; }
        public Bag Bag { get; set; }

        public int TransfererUserId { get; set; }
        public User TransfererUser { get; set; }

        public int SenderUserId { get; set; }
        public User SenderUser { get; set; }

        public int RequestStatusId { get; set; }
        public RequestStatus RequestStatus { get; set; }

        public int FlightId { get; set; }
        public Flight Flight { get; set; }

        public int RequestTypeId { get; set; }
        public RequestType RequestType { get; set; }
    }
}