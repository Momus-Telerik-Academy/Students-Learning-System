namespace StudentsLearning.Server.Api.Infrastructure.Mapping
{
    #region

    using AutoMapper;

    #endregion

    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration config);
    }
}