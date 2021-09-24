using EfCorePlayground.Common.Mappings;
using EfCorePlayground.Core.Tests.Model;
using EfCorePlayground.Data;
using System;
using EfCorePlayground.Common.Extensions;
using System.Linq;

namespace EfCorePlayground.Core.Tests
{
    public static class FirstOrDefaultVsSelectTest
    {
        public static void Run()
        {
            using var db = new ApplicationDbContext();

            Console.WriteLine("Start execute the query using FirstOrDefault");

            var resultsWithFirstOrDefault = db.Owners
                .To<OwnerViewModelFirstOrDefault>()
                .ToList();

            Console.WriteLine(resultsWithFirstOrDefault.ToJson());

            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Start executing the query using Select");

            var resultWithSelect = db.Owners
                .To<OwnerViewModelSelect>()
                .ToList();

            Console.WriteLine(resultWithSelect.ToJson());
        }
    }
}
