using System.Web.Http;
using System.Web.Http.Results;
using MyTested.WebApi;
using StudentsLearning.Data.Models;
using StudentsLearning.Server.Api.Controllers;
using StudentsLearning.Server.Api.Models.CategoryTransferModels;
using StudentsLearning.Services.Data.Contracts;

namespace StudentsLearning.Services.Api.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class CategoriesControllerTests
    {
        private ICategoriesService categoriesService;

        [TestFixtureSetUp]
        public void Init()
        {
            this.categoriesService = TestObjectFactory.GetCategoriesService();
        }

        [Test]
        public void CategoriesControllerGetShouldReturnOkResultWithData()
        {
            var controller=new CategoriesController(this.categoriesService);

            var result = controller.Get(1);

            var okResult = result as OkNegotiatedContentResult<Category>;

            Assert.IsNotNull(okResult);
        }

        [TestCase(999999)]
        [TestCase(-3)]
        public void CategoriesControllerGetWithInvalidIdShouldNotReturnOkResultWithData(int id)
        {
            //var controller = new CategoriesController(this.categoriesService);
            //IHttpActionResult result = controller.Get(id);

            MyWebApi
                .Controller<CategoriesController>()
                .WithResolvedDependencyFor(TestObjectFactory.GetCategoriesService())
                .Calling(c => c.Get(id))
                .ShouldReturn()
                .NotFound();
        }
    }
}
