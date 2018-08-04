using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [InverseProperty("Source")]
        public List<Flight> SourceFlights { get; set; }
        [InverseProperty("Destination")]
        public List<Flight> DestinationFlights { get; set; }
    }
}