
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace YandexApiParser
{
    public class CountriesDbFiller
    {
        private readonly YandexApiParser parser;
        private readonly BagDbContext dbContext;

        public CountriesDbFiller()
        {
            parser = new YandexApiParser();
            var builder = new DbContextOptionsBuilder();
            //dbContext = new BagDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions.<BagDbContext>().Us)
        }

        public void Fill()
        {
            var сountries = parser.ParseCountries();
        }
    }
}
