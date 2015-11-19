using System.Web.Http;
using StudentsLearning.Server.Api.Models.CategoryTransferModels;

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

        [TestCase(null)]
        [TestCase("")]
        [TestCase("a")]
        public void CategoriesControllerPostWithInvalidDataShouldReturnBadRequest(string name)
        {
            MyWebApi.Controller<CategoriesController>()
                .WithResolvedDependencyFor(TestObjectFactory.GetCategoriesService())
                .Calling(c => c.Post(new CategoryRequestModel() { Name=name}))
                .ShouldReturn()
                .BadRequest();
        }

        [Test]
        public void CategoriesControllerPostWithNullDataShouldReturnBadRequest()
        {
            MyWebApi.Controller<CategoriesController>()
                .WithResolvedDependencyFor(TestObjectFactory.GetCategoriesService())
                .Calling(c => c.Post(null))
                .ShouldReturn()
                .BadRequest();
        }
    }
}