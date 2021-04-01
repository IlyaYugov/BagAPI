using Domain;
using DTO;
using System;
using System.Linq;
using System.Threading.Tasks;
using YandexAPIWorker.Emun;

namespace YandexAPIWorker
{
    public class FlightsGetter : IFlightsGetter
    {
        public async Task<FlightsDto> GetFlights(string from, string to, DateTime date, string offset, string limit, string lang = null)
        {
            lang ??= Languages.ru_RU.ToString();
            var shedule = await HttpRequestFactory.GetSchedule(from, to, date, offset, limit, lang);

            var flights = new FlightsDto
            {
                Total = shedule.pagination.total,
                Flights = shedule.segments.Select(s => new FlightDto
                {
                    FlightNumber = s.thread.number,
                    ArrivalStationCode = s.to.code,
                    DepatrureStationCode = s.from.code,
                    ArrivalTime = s.arrival,
                    DepartureTime = s.departure
                })
            };

            return flights;
        }
    }
}
