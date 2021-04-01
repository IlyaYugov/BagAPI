using DataAccess.Model;
using System.Collections.Generic;
using YandexAPIWorker;
using YandexAPIWorker.Emun;
using System.Linq;
using System.Threading.Tasks;

namespace YandexApiParser
{
    public class YandexApiParser
    {
        public async Task<List<Country>> ParseCountries()
        {
            var countries = await HttpRequestFactory.GetCountres("e5e79353-129f-4f08-bf58-36337edb6386", Languages.ru_RU.ToString());

            var сountries = countries.countries.Select(s => new Country 
            {
                Code = s.codes.yandex_code, 
                Title = s.title,
                Regions = s.regions.Select(r => new Region 
                { 
                    Code = r.codes.yandex_code,
                    Title = r.title,
                    Settlements = r.settlements.Select( st => new Settlement
                    {
                        Code = st.codes.yandex_code,
                        Title = st.title,
                        Stations = st.stations.Select( station => new Station 
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
