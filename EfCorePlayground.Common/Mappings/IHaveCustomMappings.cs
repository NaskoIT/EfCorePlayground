using AutoMapper;

namespace EfCorePlayground.Common.Mappings
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
