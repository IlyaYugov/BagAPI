using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class BagDbContext : DbContext
    {
        public BagDbContext(DbContextOptions<BagDbContext> options)
            : base(options)
        { }

        public DbSet<User> Blogs { get; set; }
        public DbSet<Request> Posts { get; set; }
    }
}
