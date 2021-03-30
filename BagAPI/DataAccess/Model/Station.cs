﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Station
    {
        [Key]
        public string Code { get; set; }
        public string Title { get; set; }

        public Settlement Settlement { get; set; }
        public string SettlementCode { get; set; }

        public List<Trip> SourceTrips { get; set; }
        public List<Trip> DestinationTrips { get; set; }
    }
}
