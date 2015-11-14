namespace StudentsLearning.Services.Api.Tests.RouteTests
{
    #region

    using MyTested.WebApi;

    using NUnit.Framework;

    using StudentsLearning.Server.Api.Controllers;

    #endregion

    [TestFixture]
    public class CategoriesControllerTests
    {
        [Test]
        public void CategoriesControllerShouldMapCorrectly()
        {
            MyWebApi.Routes().ShouldMap("api/Categories").To<CategoriesController>(c => c.Get());
        }
    }
}