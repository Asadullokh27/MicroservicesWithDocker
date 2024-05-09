using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Employees.UI.Persistance
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) => Database.Migrate();


        public DbSet<Models.Employee> Employees { get; set; }

    }
}
