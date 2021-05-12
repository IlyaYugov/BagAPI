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
                .AddDbContext<BagDbContext>(opt => 
                opt.UseNpgsql("User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=ShareBagDb;Integrated Security=true;Pooling=true;"))
                .BuildServiceProvider();

            ApiOptions.ApiKey = "";

            var bagContext = serviceProvider
                .GetService<BagDbContext>();

            var statuses = GetBagRequestStatuses();
            var requests = GetBagRequestTypes();
            var countries = GetCountries();

            bagContext.AddRange(statuses);
            bagContext.AddRange(requests);
            bagContext.AddRange(countries);

            bagContext.Save();
        }

        private static List<BagRequestStatus> GetBagRequestStatuses()
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

            return statuses;
        }
        private static List<BagRequestType> GetBagRequestTypes()
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

            return types;
        }
        public static List<Country> GetCountries()
        {
            var parser = new YandexApiParser();
            var сountries = parser.GetCountriesWithAiroports().Result;

            return сountries;
        }
    }
}
