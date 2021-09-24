using AutoMapper;
using EfCorePlayground.Core.Mappings;
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
            configuration.CreateMap<Owner, OwnerViewModelFirstOrDefault>()
                .ForMember(
                    m => m.NewestCarYear,
                    y => y.MapFrom(
                        s => s.Cars
                            .OrderByDescending(c => c.Year)
                            .FirstOrDefault().Year);
        }
    }
}
