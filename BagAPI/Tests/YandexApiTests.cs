using NUnit.Framework;
using System.Threading.Tasks;
using YandexAPIWorker;
using YandexAPIWorker.Emun;
using System.Linq;
using static YandexAPIWorker.ResponseType.CityResponse;

namespace Tests
{
    [TestFixture]
    public class YandexApiTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Countres_Should_BeNotEmpty_AfterRequestToApi()
        {
            var countries = await HttpRequestFactory.GetCountres(Languages.ru_RU.ToString());

           /* var russia = countries.countries.First(s => s.title == "Россия");
            var moscow = russia.regions.First(r => r.title.Contains("Московская"));

            moscow.settlements = moscow.settlements.Where(s => s.stations.Any(s => s.station_type == "airport")).Select(s =>
                new Settlement
                {
                    codes = s.codes,
                    title = s.title,
                    stations = s.stations.Where(st => st.station_type == "airport").ToList()
                }).ToList();


            var volgograd = russia.regions.First(r => r.title.Contains("Волгоградская"));

            volgograd.settlements = volgograd.settlements.Where(s => s.stations.Any(s => s.station_type == "airport")).Select(s =>
                new Settlement
                {
                    codes = s.codes,
                    title = s.title,
                    stations = s.stations.Where(st => st.station_type == "airport").ToList()
                }).ToList();*/

            Assert.NotZero(countries.countries.Count);
        }
    }
}