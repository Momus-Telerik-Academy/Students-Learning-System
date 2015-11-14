using AutoMapper;

namespace StudentsLearning.Server.Api.Infrastructure.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration config);
    }
}
