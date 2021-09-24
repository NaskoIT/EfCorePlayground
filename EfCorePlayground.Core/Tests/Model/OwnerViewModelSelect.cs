using AutoMapper;
using EfCorePlayground.Common.Mappings;
using EfCorePlayground.Data.Models;
using System.Linq;

namespace EfCorePlayground.Core.Tests.Model
{
    public class OwnerViewModelSelect : IMapFrom<Owner>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public int NewestCarYear { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Owner, OwnerViewModelSelect>()
                .ForMember(
                    m => m.NewestCarYear,
                    y => y.MapFrom(
                        s => s.Cars
                            .OrderByDescending(c => c.Year)
                            .Select(c => c.Year)
                            .FirstOrDefault()));
        }
    }
}
