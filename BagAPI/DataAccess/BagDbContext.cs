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
            modelBuilder.Entity<UserMessenger>()
                .HasKey(c => new
                {
                    c.UserId,
                    c.MessengerTypeId
                });
        }

        internal DbSet<Bag> Bag { get; set; }
        internal DbSet<BagType> BagType { get; set; }
        internal DbSet<City> City { get; set; }
        internal DbSet<MessengerType> MessengerType { get; set; }
        internal DbSet<Request> Request { get; set; }
        internal DbSet<RequestStatus> RequestStatus { get; set; }
        internal DbSet<User> User { get; set; }
        internal DbSet<UserMessenger> UserMessenger { get; set; }
    }
}
