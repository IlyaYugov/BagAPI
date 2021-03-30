
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace YandexApiParser
{
    public class CitiesDbFiller
    {
        private readonly YandexApiParser parser;
        private readonly BagDbContext dbContext;

        public CitiesDbFiller()
        {
            parser = new YandexApiParser();
            var builder = new DbContextOptionsBuilder();
            //dbContext = new BagDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions.<BagDbContext>().Us)
        }

        public void Fill()
        {
            var cities = parser.ParseCities();
        }
    }
}
