using System.Linq;
using MyTested.WebApi.Builders.Contracts.Controllers;

namespace StudentsLearning.Services.Api.Tests.ControllerTests
{
    #region

    using System.Web.Http.Results;

    using MyTested.WebApi;

    using NUnit.Framework;

    using StudentsLearning.Data.Models;
    using StudentsLearning.Server.Api.Controllers;
    using StudentsLearning.Services.Data.Contracts;
    using StudentsLearning.Server.Api.Models.SectionTransferModels;

    #endregion

    [TestFixture]
    public class SectionsControllerTests
    {
        private ISectionService sectionsService;

        [TestFixtureSetUp]
        public void Init()
        {
            this.sectionsService = TestObjectFactory.GetSectionService();
        }

        [Test]
        public void SectionsControllerGetShouldReturnOkResultWithData()
        {
            var controller = new SectionsController(this.sectionsService);

            var result = controller.Get(1);

            var okResult = result as OkNegotiatedContentResult<SectionResponseModel>;

            //var debug = sectionsService.All().ToList();
            Assert.IsNotNull(okResult);
        }

        [TestCase(999999)]
        [TestCase(-3)]
        public void SectionsControllerGetWithInvalidIdShouldNotReturnOkResultWithData(int id)
        {
            MyWebApi.Controller<SectionsController>()
                .WithResolvedDependencyFor(TestObjectFactory.GetSectionServiceNotFoundMock())
                .Calling(c => c.Get(id))
                .ShouldReturn()
                .NotFound();
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("a")]
        public void SectionsControllerPostWithInvalidNameShouldReturnBadRequest(string name)
        {
            MyWebApi.Controller<SectionsController>()
                .WithResolvedDependencyFor(TestObjectFactory.GetSectionService())
                .Calling(c => c.Post(new SectionRequestModel() { Name = name, Description = "Lorem ipsum dor..."}))
                .ShouldReturn()
                .BadRequest();
        }

        [TestCase(null)]
        [TestCase("")]
        public void SectionsControllerPostWithInvalidDescriptionShouldReturnBadRequest(string description)
        {
            MyWebApi.Controller<SectionsController>()
                .WithResolvedDependencyFor(TestObjectFactory.GetSectionService())
                .Calling(c => c.Post(new SectionRequestModel() { Name = "Lorem ipsum", Description = description }))
                .ShouldReturn()
                .BadRequest();
        }

        [Test]
        public void SectionsControllerPostWithNullDataShouldReturnBadRequest()
        {
            MyWebApi.Controller<SectionsController>()
                .WithResolvedDependencyFor(TestObjectFactory.GetSectionService())
                .Calling(c => c.Post(null))
                .ShouldReturn()
                .BadRequest();
        }
    }
}
