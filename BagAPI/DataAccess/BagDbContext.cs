using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class BagDbContext : DbContext
    {
        public BagDbContext(DbContextOptions<BagDbContext> options)
            : base(options)
        { }

        //public DbSet<Blog> Blogs { get; set; }
        //public DbSet<Post> Posts { get; set; }
    }
}
