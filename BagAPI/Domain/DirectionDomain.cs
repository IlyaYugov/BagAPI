using Domain.IRepositories;
using DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain
{
    public class DirectionDomain
    {
        private readonly IDirectionRepository directionRepository;
        private readonly IFlightsGetter flightsGetter;

        public DirectionDomain(IDirectionRepository directionRepository, IFlightsGetter flightsGetter)
        {
            this.directionRepository = directionRepository;
            this.flightsGetter = flightsGetter;
        }

        public IEnumerable<CityDto> GetDirections(string search)
        {
            return directionRepository.GetDirections(search);
        }

        public async Task<FlightsDto> GetFlights(string from, string to, DateTime date, string offset, string limit, string lang = null)
        {
            return await flightsGetter.GetFlights(from, to, date, offset, limit, lang);
        }
    }
}
