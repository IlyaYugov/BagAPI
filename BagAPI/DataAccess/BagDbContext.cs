using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class BagDbContext : DbContext
    {
        public BagDbContext(DbContextOptions<BagDbContext> options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMessenger>()
                .HasKey(c => new
                {
                    c.UserId,
                    c.MessengerTypeId
                });
        }

        public DbSet<Bag> Bag { get; set; }
        public DbSet<BagType> BagType { get; set; }
        public DbSet<City> Cite { get; set; }
        public DbSet<MessengerType> MessengerType { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<RequestStatus> RequestStatus { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserMessenger> UserMessenger { get; set; }
    }
}
