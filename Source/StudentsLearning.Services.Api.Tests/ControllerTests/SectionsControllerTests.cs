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
    using StudentsLearning.Services.Data.SectionTransferModels;

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

            var okResult = result as OkNegotiatedContentResult<SectionResponsetModel>;

            Assert.IsNotNull(okResult);
        }
    }
}
