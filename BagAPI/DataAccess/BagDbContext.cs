using DataAccess.Model;
using DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class BagDbContext : DbContext
    {
        private readonly ICountriesProvidred _countriesProvidred;

        internal DbSet<Bag> Bag { get; set; }
        internal DbSet<BagRequestType> BagRequestType { get; set; }
        internal DbSet<Country> Country { get; set; }
        internal DbSet<Region> Region { get; set; }
        internal DbSet<Settlement> Settlement { get; set; }
        internal DbSet<Station> Station { get; set; }
        internal DbSet<BagRequest> BagRequest { get; set; }
        internal DbSet<BagRequestStatus> BagRequestStatus { get; set; }
        internal DbSet<User> User { get; set; }

        private static volatile bool _isInitialized;
        private static readonly object Mutex = new object();

        public BagDbContext(DbContextOptions<BagDbContext> options, ICountriesProvidred countriesProvidred)
            : base(options)
        {
            _countriesProvidred = countriesProvidred;
            if (_isInitialized)
            {
                return;
            }

            lock (Mutex)
            {
                if (_isInitialized)
                {
                    return;
                }

                Database.Migrate();

                _isInitialized = true;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            AddRelationships(modelBuilder);
            AddDefaultValues(modelBuilder);
        }

        private void AddRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>()
            .HasOne(p => p.Country)
            .WithMany(b => b.Regions)
            .HasForeignKey(p => p.CityCode);

            modelBuilder.Entity<Settlement>()
            .HasOne(p => p.Region)
            .WithMany(b => b.Settlements)
            .HasForeignKey(p => p.RegionCode);

            modelBuilder.Entity<Station>()
            .HasOne(p => p.Settlement)
            .WithMany(b => b.Stations)
            .HasForeignKey(p => p.SettlementCode);

            modelBuilder.Entity<Flight>()
            .HasOne(p => p.SourceStation)
            .WithMany(b => b.SourceFlights)
            .HasForeignKey(p => p.SourceStationCode);

            modelBuilder.Entity<Flight>()
            .HasOne(p => p.DestinationStation)
            .WithMany(b => b.DestinationFlights)
            .HasForeignKey(p => p.DestinationStationCode);

            modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
        }

        private void AddDefaultValues(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BagRequestType>()
                        .HasData(GetBagRequestTypes());

            modelBuilder.Entity<BagRequestStatus>()
                        .HasData(GetBagRequestStatuses());

            var countriesData = _countriesProvidred.GetCountries().Result.ToList();

            var stationsData = countriesData.SelectMany(co=> co.Regions.SelectMany(r=>r.Settlements.SelectMany(s=>s.Stations))).ToList();
            var settlementsData = countriesData.SelectMany(co => co.Regions.SelectMany(r => r.Settlements)).ToList();
            var regionsData = countriesData.SelectMany(co => co.Regions).ToList();


            foreach (var country in countriesData)
            {
                country.Regions = null;
            }
            foreach (var region in regionsData)
            {
                region.Settlements = null;
            }
            foreach (var settlement in settlementsData)
            {
                settlement.Stations = null;
            }

            modelBuilder.Entity<Country>()
            .HasData(countriesData);

            modelBuilder.Entity<Region>()
            .HasData(regionsData);

            modelBuilder.Entity<Settlement>()
            .HasData(settlementsData);

            modelBuilder.Entity<Station>()
                        .HasData(stationsData);
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

    }
}
