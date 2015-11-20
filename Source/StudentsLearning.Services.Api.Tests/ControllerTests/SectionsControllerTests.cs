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
        private IControllerBuilder<SectionsController> controller;
        private IControllerBuilder<SectionsController> controllerWithMockedNotFoundService;

        [TestFixtureSetUp]
        public void Init()
        {
            this.controller = MyWebApi.Controller<SectionsController>()
                .WithResolvedDependencyFor(TestObjectFactory.GetSectionService());

            this.controllerWithMockedNotFoundService = MyWebApi.Controller<SectionsController>()
                            .WithResolvedDependencyFor(TestObjectFactory.GetSectionServiceNotFoundMock());

            this.sectionsService = TestObjectFactory.GetSectionService();
        }

        [Test]
        public void SectionsControllerGetShouldReturnOkResultWithData()
        {
            this.controller
                .Calling(c => c.Get(1))
                .ShouldReturn()
                .Ok()
                .WithDefaultContentNegotiator();
        }

        [TestCase(999999)]
        [TestCase(-3)]
        public void SectionsControllerGetWithInvalidIdShouldNotReturnOkResultWithData(int id)
        {
            this.controllerWithMockedNotFoundService
                .Calling(c => c.Get(id))
                .ShouldReturn()
                .NotFound();
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("a")]
        public void SectionsControllerPostWithInvalidNameShouldReturnBadRequest(string name)
        {
            this.controller
                .Calling(c => c.Post(new SectionRequestModel() { Name = name, Description = "Lorem ipsum dor..." }))
                .ShouldReturn()
                .BadRequest();
        }

        [TestCase(null)]
        [TestCase("")]
        public void SectionsControllerPostWithInvalidDescriptionShouldReturnBadRequest(string description)
        {
            this.controller
                .Calling(c => c.Post(new SectionRequestModel() { Name = "Lorem ipsum", Description = description }))
                .ShouldReturn()
                .BadRequest();
        }

        [Test]
        public void SectionsControllerDeleteShouldReturnOkWithAuthorizationAndValidId()
        {
            this.controller
                .Calling(c => c.Delete(1))
                .ShouldHave()
                .ActionAttributes(attr => attr.RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .Ok();
        }

        //[Test]
        //public void SectionsControllerDeleteShouldReturnNotFoundWithInvalidId()
        //{
        //    this.controllerWithMockedNotFoundService
        //        .Calling(c => c.Delete(-1))
        //        .ShouldHave()
        //        .ActionAttributes(attr => attr.RestrictingForAuthorizedRequests())
        //        .AndAlso()
        //        .ShouldReturn()
        //        .NotFound();
        //}
        // Wait for better times
        //[Test]
        //public void SectionsControllerPostWithNullDataShouldReturnBadRequest()
        //{
        //    MyWebApi.Controller<SectionsController>()
        //        .WithResolvedDependencyFor(TestObjectFactory.GetSectionService())
        //        .Calling(c => c.Post(null))
        //        .ShouldReturn()
        //        .BadRequest();
        //}
    }
}
