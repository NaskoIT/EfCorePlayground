using EfCorePlayground.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace EfCorePlayground.Data
{
    public class ApplicationDbContext : DbContext
    {
        private static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { 
            builder.AddConsole(); 
        });

        public DbSet<Car> Cars { get; set; }

        public DbSet<Owner> Owners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseLoggerFactory(loggerFactory)
                .EnableSensitiveDataLogging()
                .UseSqlServer(Settings.ConnectionString);
    }
}
