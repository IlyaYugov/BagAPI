using System;

namespace DataAccess.Model
{
    public class Flight
    {
        public int Id { get; set; }
        public int SourceId { get; set; }
        public int DestinationId { get; set; }
        public string Number { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public byte[] TicketPhoto { get; set; }

        public string SourceStationCode { get; set; }
        public Station SourceStation { get; set; }

        public string DestinationStationCode { get; set; }
        public Station DestinationStation { get; set; }

        public BagRequest Request { get; set; }
    }
}