using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BagAPI.DTO
{
    public class Filter
    {
        public int CityFromId { get; set; }
        public int CityToId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int OrderTypeId { get; set; }
    }
}
