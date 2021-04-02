using DataAccess;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using YandexAPIWorker;

namespace YandexApiParser
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddDbContext<BagDbContext>(opt => opt.UseNpgsql("User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=ShareBagDb;Integrated Security=true;Pooling=true;"))
                .BuildServiceProvider();

            ApiOptions.ApiKey = "";

            //configure console logging
            var bagContext = serviceProvider
                .GetService<BagDbContext>();

            var parser = new YandexApiParser();
            var сountries = parser.GetCountriesWithAiroports().Result;

            var regions = сountries.SelectMany(c => c.Regions).GroupBy(s => s.Code).Where(s => s.Count() > 1);

            bagContext.AddRange(сountries);
            bagContext.Save();

            Console.WriteLine("Hello World!");
        }
    }
}
