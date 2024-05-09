using Microsoft.EntityFrameworkCore;

namespace Products.UI.Persistance
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options) => Database.Migrate();


        public DbSet<Models.Product> Products { get; set; }

    }
}
