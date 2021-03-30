using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class BagDbContext : DbContext
    {
        protected BagDbContext(DbContextOptions<BagDbContext> options)
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
            .HasOne(p => p.City)
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

            modelBuilder.Entity<Trip>()
            .HasOne(p => p.SourceStation)
            .WithMany(b => b.SourceTrips)
            .HasForeignKey(p => p.SourceStationCode);

            modelBuilder.Entity<Trip>()
            .HasOne(p => p.DestinationStation)
            .WithMany(b => b.DestinationTrips)
            .HasForeignKey(p => p.DestinationStationCode);
        }

        internal DbSet<Bag> Bag { get; set; }
        internal DbSet<BagType> BagType { get; set; }
        internal DbSet<City> City { get; set; }
        internal DbSet<Region> Region { get; set; }
        internal DbSet<Settlement> Settlement { get; set; }
        internal DbSet<Station> Station { get; set; }
        //internal DbSet<MessengerType> MessengerType { get; set; }
        internal DbSet<BugRequest> Request { get; set; }
        internal DbSet<RequestStatus> RequestStatus { get; set; }
        internal DbSet<User> User { get; set; }
        //internal DbSet<UserMessenger> UserMessenger { get; set; }
    }
}
