using AutoMapper;

namespace EfCorePlayground.Core.Mappings
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
