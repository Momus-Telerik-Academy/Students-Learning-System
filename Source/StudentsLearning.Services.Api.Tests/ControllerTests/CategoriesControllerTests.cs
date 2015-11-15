using System.Web.Http;

namespace StudentsLearning.Services.Api.Tests
{
    #region

    using System.Web.Http.Results;

    using MyTested.WebApi;

    using NUnit.Framework;

    using StudentsLearning.Data.Models;
    using StudentsLearning.Server.Api.Controllers;
    using StudentsLearning.Services.Data.Contracts;

    #endregion

    [TestFixture]
    public class CategoriesControllerTests
    {
        private ICategoriesService categoriesService;

        [TestFixtureSetUp]
        public void Init()
        {
            this.categoriesService = TestObjectFactory.GetCategoriesService();
        }

        [TestCase(999999)]
        [TestCase(-3)]
        public void CategoriesControllerGetWithInvalidIdShouldNotReturnOkResultWithData(int id)
        {
             var controller = new CategoriesController(this.categoriesService);
             IHttpActionResult result = controller.Get(id);
            MyWebApi.Controller<CategoriesController>()
                .WithResolvedDependencyFor(TestObjectFactory.GetCategoriesService())
                .Calling(c => c.Get(id))
                .ShouldReturn()
                .NotFound();
        }

        [Test]
        public void CategoriesControllerGetShouldReturnOkResultWithData()
        {
            var controller = new CategoriesController(this.categoriesService);

            var result = controller.Get(1);

            var okResult = result as OkNegotiatedContentResult<Category>;

            Assert.IsNotNull(okResult);
        }
    }
}