using Microsoft.EntityFrameworkCore;

namespace Franchises.UI.Persistance
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) => Database.Migrate();


        public DbSet<Models.Franchise> Franchises { get; set; }

    }
}
