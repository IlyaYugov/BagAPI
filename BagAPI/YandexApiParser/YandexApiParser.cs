using DataAccess.Model;
using System.Collections.Generic;
using YandexAPIWorker;
using YandexAPIWorker.Emun;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;

namespace DirectionsFiller
{
    public class YandexApiParser: ICountriesProvidred
    {
        private const string airport = "airport";

        public async Task<IList<Country>> GetCountries()
        {
            var countries = await HttpRequestFactory.GetCountres(Languages.ru_RU.ToString());

            var planeStationsWithNotEmpty = countries
                .countries
                .Where(c => c.regions.Any() && !string.IsNullOrEmpty(c.title) && !string.IsNullOrEmpty(c.codes.yandex_code))
                .SelectMany(c => c.regions
                            .Where(r => r.settlements.Any() && !string.IsNullOrEmpty(r.title) && !string.IsNullOrEmpty(r.codes.yandex_code))
                            .SelectMany(r => r.settlements
                                        .Where(st => st.stations.Any() && !string.IsNullOrEmpty(st.title) && !string.IsNullOrEmpty(st.codes.yandex_code))
                                        .SelectMany(st => st.stations
                                                    .Where(station => station.station_type == airport)
                                                    .Where(station => !string.IsNullOrEmpty(station.title) && !string.IsNullOrEmpty(station.codes.yandex_code))
                                                    .Select(station => new 
                                                    {
                                                        CountryCode = c.codes.yandex_code,
                                                        RegionCode = r.codes.yandex_code,
                                                        SettlementCode = st.codes.yandex_code,
                                                        StationCode = station.codes.yandex_code
                                                    }))));

            var countryCodes = planeStationsWithNotEmpty.Select(s => s.CountryCode).Distinct().ToHashSet();
            var regionCodes = planeStationsWithNotEmpty.Select(s => s.RegionCode).Distinct().ToHashSet();
            var settlementCodes = planeStationsWithNotEmpty.Select(s => s.SettlementCode).Distinct().ToHashSet();
            var stationCodes = planeStationsWithNotEmpty.Select(s => s.StationCode).Distinct().ToHashSet();

            string value;

            var сountries = countries.countries
                .Where(s => countryCodes.TryGetValue(s.codes.yandex_code, out value))
                .Select(s => new Country
                {
                    Code = s.codes.yandex_code,
                    Title = s.title,
                    Regions = s.regions
                    .Where(r => regionCodes.TryGetValue(r.codes.yandex_code, out value))
                    .Where(r => r.settlements.Any(st => settlementCodes.TryGetValue(st.codes.yandex_code, out value)))
                    .Select(r => new Region
                    {
                        Code = r.codes.yandex_code,
                        Title = r.title,
                        Settlements = r.settlements
                        .Where(st => settlementCodes.TryGetValue(st.codes.yandex_code, out value))
                        .Where(st => st.stations.Any(station => stationCodes.TryGetValue(station.codes.yandex_code, out value)))
                        .Select(st => new Settlement
                        {
                            Code = st.codes.yandex_code,
                            Title = st.title,
                            Stations = st.stations
                            .Where(station => stationCodes.TryGetValue(station.codes.yandex_code, out value))
                            .Select(station => new Station
                            {
                                Code = station.codes.yandex_code,
                                Title = station.title
                            }).ToList()
                        }).ToList()
                    }).ToList()
                }).ToList();

            return сountries;
        }
    }
}
