using EfCorePlayground.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCorePlayground.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Owner> Owners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseSqlServer(Settings.ConnectionString);
    }
}
