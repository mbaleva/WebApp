namespace WebApp.Common.Application.Mapping
{
    using AutoMapper;
    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
