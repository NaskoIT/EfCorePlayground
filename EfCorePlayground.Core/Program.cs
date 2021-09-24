using EfCorePlayground.Common.Mappings;
using EfCorePlayground.Core.Business;
using EfCorePlayground.Core.Tests;
using System.Reflection;

namespace EfCorePlayground.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DataSeeder.Seed();

            AutoMapperConfig.RegisterMappings(Assembly.GetExecutingAssembly());

            FirstOrDefaultVsSelectTest.Run();
        }
    }
}
