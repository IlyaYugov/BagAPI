using NUnit.Framework;
using System.Threading.Tasks;
using YandexAPIWorker;
using YandexAPIWorker.Emun;

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
            var countries = await HttpRequestFactory.GetCountres("", Languages.ru_RU.ToString());

            Assert.NotZero(countries.countries.Count);
        }
    }
}