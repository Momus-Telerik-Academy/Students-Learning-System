namespace SourceControlSystem.Api.Tests
{
    using System.Reflection;
    using System.Web.Http;
    using NUnit.Framework;
    using StudentsLearning.Server.Api;
    using MyTested.WebApi;

    [SetUpFixture]
    public class TestInit
    {
        [SetUp]
        public static void AssemblyInit(TestContext context)
        {
            AutoMapperConfig.RegisterMappings(Assembly.Load("StudentsLearning.Server.Api"));

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            MyWebApi.IsUsing(config);
        }
    }
}
