using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class BagDbContext : DbContext
    {
        public BagDbContext(DbContextOptions<BagDbContext> options)
            : base(options)
        { }

        public DbSet<Bag> Bags { get; set; }
        public DbSet<BagType> BagTypes { get; set; }
        public DbSet<City> Cites { get; set; }
        public DbSet<MessengerType> MessengerTypes { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestStatus> RequestStatuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserMessenger> UserMessengers { get; set; }
    }
}
