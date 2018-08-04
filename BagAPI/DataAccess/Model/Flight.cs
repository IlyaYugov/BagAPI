using System;
using System.Collections.Generic;

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

        public City Source { get; set; }
        public City Destination { get; set; }
        public List<Request> Requests { get; set; }
    }
}