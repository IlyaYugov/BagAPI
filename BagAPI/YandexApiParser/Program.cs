using DataAccess;
using DataAccess.Model;
using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
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

            FillBagRequestStatuses(bagContext);
            FillBagRequestTypes(bagContext);
            FillCities(bagContext);
        }

        private static void FillBagRequestStatuses(BagDbContext bagContext)
        {
            var statuses = new List<BagRequestStatus>
            {
                new BagRequestStatus
                {
                    Id = (int)BagRequestStatuses.Created,
                    Name = BagRequestStatuses.Created.ToString()
                },
                new BagRequestStatus
                {
                    Id = (int)BagRequestStatuses.Deal,
                    Name = BagRequestStatuses.Deal.ToString()
                },
                 new BagRequestStatus
                {
                    Id = (int)BagRequestStatuses.Completed,
                    Name = BagRequestStatuses.Completed.ToString()
                },
            };

            bagContext.AddRange(statuses);
            bagContext.Save();
        }
        private static void FillBagRequestTypes(BagDbContext bagContext)
        {
            var types = new List<BagRequestType>
            {
                new BagRequestType
                {
                    Id = (int)BagRequestTypes.TransfererBag,
                    Name = BagRequestTypes.TransfererBag.ToString()
                },
                new BagRequestType
                {
                    Id = (int)BagRequestTypes.SendBag,
                    Name = BagRequestTypes.SendBag.ToString()
                },
            };
         
            bagContext.AddRange(types);
            bagContext.Save();
        }
        public static void FillCities(BagDbContext bagContext)
        {
            ApiOptions.ApiKey = "";

            var parser = new YandexApiParser();
            var сountries = parser.GetCountriesWithAiroports().Result;

            bagContext.AddRange(сountries);
        }
    }
}
