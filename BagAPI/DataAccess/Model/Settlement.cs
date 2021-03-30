using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Settlement
    {
        [Key]
        public string Code { get; set; }
        public string Title { get; set; }

        public Region Region { get; set; }
        public string RegionCode { get; set; }
        public List<Station> Stations { get;set;}
    }
}
