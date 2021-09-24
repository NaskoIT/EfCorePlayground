using AutoMapper;
using EfCorePlayground.Common.Mappings;
using EfCorePlayground.Data.Models;
using System.Linq;

namespace EfCorePlayground.Core.Tests.Model
{
    public class OwnerViewModelFirstOrDefault : IMapFrom<Owner>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public int NewestCarYear { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            // Keep in mind that System.InvalidOperationException: Nullable object must have a value can be thrown if the owner don't have any cars
            configuration.CreateMap<Owner, OwnerViewModelFirstOrDefault>()
                .ForMember(
                    m => m.NewestCarYear,
                    y => y.MapFrom(
                        s => s.Cars
                            .OrderByDescending(c => c.Year)
                            .FirstOrDefault().Year));
        }
    }
}
