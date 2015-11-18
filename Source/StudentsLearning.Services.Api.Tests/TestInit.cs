#region

using System.Reflection;
using System.Web.Http;

using MyTested.WebApi;

using NUnit.Framework;
using StudentsLearning.Data.Models;
using StudentsLearning.Data.Repositories;
using StudentsLearning.Server.Api;
using StudentsLearning.Server.Api.App_Start;
using StudentsLearning.Services.Data.Tests.TestObjects;

#endregion

// DO NOT PUT IN A NAMESPACE!!!
// It will only work for the current namespace and not all namespaces in the project.
[SetUpFixture]
public class TestInit
{
    [SetUp]
    public static void AssemblyInit()
    {
        NinjectConfig.DependenciesRegistration = kernel =>
        {
            kernel.Bind<IRepository<User>>().ToConstant(TestObjectFactory.GetUsersRepository());
        };

        AutoMapperConfig.RegisterMappings(Assembly.Load("StudentsLearning.Server.Api"));
        MyWebApi.IsRegisteredWith(WebApiConfig.Register);
    }
}