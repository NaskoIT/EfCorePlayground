using EfCorePlayground.Core.Business;
using EfCorePlayground.Core.Mappings;
using EfCorePlayground.Core.Models;

namespace EfCorePlayground.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DataSeeder.Seed();

            AutoMapperConfig.RegisterMappings(typeof(OwnerViewModel).Assembly);
        }
    }
}
