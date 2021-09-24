using EfCorePlayground.Data;
using EfCorePlayground.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EfCorePlayground.Core.Business
{
    public static class DataSeeder
    {
        public static void Seed()
        {
            using var dbContext = new ApplicationDbContext();

            dbContext.Database.Migrate();

            if(dbContext.Cars.Any())
            {
                return;
            }

            dbContext.Owners.AddRange(GetOwners());
            dbContext.SaveChanges();
        }

        public static IEnumerable<Owner> GetOwners()
            => new List<Owner>
            {
                new Owner
                {
                    Name = "Atanas Vasilev",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Brand = "Lexus",
                            Model = "IS 250",
                            Year = 2010,
                        },
                        new Car
                        {
                            Brand = "BMW",
                            Model = "530d",
                            Year = 2008,
                        }
                    }
                },
                new Owner
                {
                    Name = "Niki Vasilev",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Brand = "Lexus",
                            Model = "IS 2020",
                            Year = 2009,
                        },
                    }
                }
            };
    }
}
