using Domain.IRepositories;
using DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Implementations
{
    public class DirectionRepository : IDirectionRepository
    {
        private BagDbContext _bagDbContext;
        public DirectionRepository(BagDbContext bagDbContext)
        {
            _bagDbContext = bagDbContext;
        }

        public IEnumerable<CityDto> GetDirections(string search)
        {
            var cities = _bagDbContext
                .Settlement
                .Where(s => s.Title.Contains(search))
                .Include(s => s.Stations)
                .ToList();

            var result = cities.Select(c => new CityDto
            {
                CityCode = c.Code,
                CityTitle = c.Title,
                Stations = c.Stations.Select(st => new StationDto
                {
                    StationCode = st.Code,
                    StationTitle = st.Title
                })
            });

            return result;
        }
    }
}
