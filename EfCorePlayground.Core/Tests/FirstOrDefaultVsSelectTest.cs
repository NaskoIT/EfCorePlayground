using EfCorePlayground.Core.Mappings;
using EfCorePlayground.Core.Tests.Model;
using EfCorePlayground.Data;
using System.Collections.Generic;
using System.Linq;

namespace EfCorePlayground.Core.Tests
{
    public static class FirstOrDefaultVsSelectTest
    {
        public static IEnumerable<OwnerViewModelFirstOrDefault> Run()
        {
            using var db = new ApplicationDbContext();

            return db.Owners
                .To<OwnerViewModelFirstOrDefault>()
                .ToList();
        }
    }
}
