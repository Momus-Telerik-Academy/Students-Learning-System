using StudentsLearning.Server.Api.Infrastructure.Filters;
using StudentsLearning.Server.Api.Models.CategoryTransferModels;

namespace StudentsLearning.Services.Api.Tests
{
    #region
    using MyTested.WebApi;
    using MyTested.WebApi.Builders.Contracts.Controllers;
    using NUnit.Framework;
    using StudentsLearning.Server.Api.Controllers;

    #endregion

    [TestFixture]
    public class CategoriesControllerTests
    {
        private IControllerBuilder<CategoriesController> controller;
        private IControllerBuilder<CategoriesController> controllerWithMockedNotFoundService;

        [TestFixtureSetUp]
        public void Init()
        {
            this.controller = MyWebApi.Controller<CategoriesController>()
                .WithResolvedDependencyFor(TestObjectFactory.GetCategoriesService());

            this.controllerWithMockedNotFoundService = MyWebApi.Controller<CategoriesController>()
                 .WithResolvedDependencies(TestObjectFactory.GetCategoriesServiceNotFound());
        }

        [TestCase(999999)]
        [TestCase(-3)]
        public void CategoriesControllerGetWithInvalidIdShouldReturnNotFoundWithNonexistinngId(int id)
        {
            this.controllerWithMockedNotFoundService
                 .Calling(c => c.Get(id))
                 .ShouldReturn()
                 .NotFound();
        }

        [Test]
        public void CategoriesControllerGetShouldReturnOkResultWithValidId()
        {
            this.controller
                .Calling(c => c.Get(1))
                .ShouldReturn()
                .Ok()
                .WithDefaultContentNegotiator();

            //var controller = new CategoriesController(this.mockedCategoriesService);
            //var result = controller.Get(1);
            //var okResult = result as OkNegotiatedContentResult<Category>;
            // Assert.IsNotNull(okResult);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("a")]
        public void CategoriesControllerPostWithInvalidDataShouldReturnBadRequest(string name)
        {
            this.controller
                 .Calling(c => c.Post(new CategoryRequestModel() { Name = name }))
                 .ShouldHave()
                 .InvalidModelState()
                 .AndAlso()
                 .ShouldHave()
                 .ActionAttributes(attributes => attributes
                    .ContainingAttributeOfType<CheckNullAttribute>())
                 .AndAlso()
                 .ShouldHave()
                 .ActionAttributes(attributes => attributes
                    .ContainingAttributeOfType<ValidateModelStateAttribute>());
        }

        [Test]
        public void CategoriesControllerDeleteShouldReturnOkWithAuthorizationAndValidId()
        {
            this.controller
                .Calling(c => c.Delete(1))
                .ShouldHave()
                .ActionAttributes(attr => attr.RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .Ok();
        }

        [Test]
        public void CategoriesControllerDeleteShouldReturnNotFoundWithInvalidId()
        {
            this.controllerWithMockedNotFoundService
                .Calling(c => c.Delete(-10))
                .ShouldHave()
                .ActionAttributes(attr => attr.RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .NotFound();
        }


        //[Test]
        //public void CategoriesControllerPostWithNullDataShouldReturnBadRequest()
        //{
        //    MyWebApi.Controller<CategoriesController>()
        //        .WithResolvedDependencyFor(TestObjectFactory.GetCategoriesService())
        //        .Calling(c => c.Post(null))
        //        .ShouldReturn()
        //        .BadRequest();
        //}
    }
}