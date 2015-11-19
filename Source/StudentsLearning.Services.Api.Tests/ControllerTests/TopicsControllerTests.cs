using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using MyTested.WebApi;
using MyTested.WebApi.Builders.Contracts.Controllers;
using NUnit.Framework;
using StudentsLearning.Server.Api.Controllers;
using StudentsLearning.Server.Api.Models.SectionTransferModels;
using StudentsLearning.Services.Data.Contracts;

namespace StudentsLearning.Services.Api.Tests.ControllerTests
{
    [TestFixture]
    public class TopicsControllerTests
    {
        //private ITopicsServices topicsService;
        //private IAndControllerBuilder<TopicsController> topicsConteoller;

        //[TestFixtureSetUp]
        //public void Init()
        //{
        //    this.topicsService = TestObjectFactory.GetSectionService();
        //    this.topicsConteoller = MyWebApi.Controller<SectionsController>()
        //        .WithResolvedDependencyFor(TestObjectFactory.GetSectionService());
        //}

        //[Test]
        //public void SectionsControllerGetShouldReturnOkResultWithData()
        //{
        //    var controller = new SectionsController(this.topicsService);

        //    var result = controller.Get(1);

        //    var okResult = result as OkNegotiatedContentResult<SectionResponseModel>;

        //    var debug = topicsService.All().ToList();
        //    Assert.IsNotNull(okResult);
        //}

        //[TestCase(999999)]
        //[TestCase(-3)]
        //public void SectionsControllerGetWithInvalidIdShouldNotReturnOkResultWithData(int id)
        //{
        //    topicsConteoller
        //        .Calling(c => c.Get(id))
        //        .ShouldReturn()
        //        .NotFound();
        //}
    }
}
