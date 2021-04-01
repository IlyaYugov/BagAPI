
using System.Collections.Generic;

namespace DTO
{
    public class CityDto
    {
        public string CityCode { get; set; }
        public string CityTitle { get; set; }

        public IEnumerable<StationDto> Stations { get; set; }
    }
}
