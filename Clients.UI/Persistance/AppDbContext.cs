using Microsoft.EntityFrameworkCore;

namespace Clients.UI.Persistance
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options) => Database.Migrate();


        public DbSet<Models.Client> Clients { get; set; }

    }
}
