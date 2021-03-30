using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Region
    {
        [Key]
        public string Code { get; set; }
        public string Title { get; set; }

        public City City { get; set; }
        public string CityCode { get; set; }
        public List<Settlement> Settlements { get; set; }
    }
}
