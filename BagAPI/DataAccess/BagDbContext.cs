using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class BagDbContext : DbContext
    {
        public BagDbContext(DbContextOptions<BagDbContext> options)
            : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /* modelBuilder.Entity<UserMessenger>()
                .HasKey(c => new
                {
                    c.UserId,
                    c.MessengerTypeId
                });*/

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
        }

        internal DbSet<Bag> Bag { get; set; }
        internal DbSet<Country> Country { get; set; }
        internal DbSet<Region> Region { get; set; }
        internal DbSet<Settlement> Settlement { get; set; }
        internal DbSet<Station> Station { get; set; }
        //internal DbSet<MessengerType> MessengerType { get; set; }
        internal DbSet<BagRequest> Request { get; set; }
        internal DbSet<RequestStatus> RequestStatus { get; set; }
        internal DbSet<User> User { get; set; }
        //internal DbSet<UserMessenger> UserMessenger { get; set; }
    }
}
