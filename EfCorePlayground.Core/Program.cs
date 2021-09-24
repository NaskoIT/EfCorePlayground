using EfCorePlayground.Core.Business;
using EfCorePlayground.Core.Mappings;
using System.Reflection;

namespace EfCorePlayground.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DataSeeder.Seed();

            AutoMapperConfig.RegisterMappings(Assembly.GetExecutingAssembly());
        }
    }
}
