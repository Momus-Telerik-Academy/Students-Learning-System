using MyTested.WebApi;
using NUnit.Framework;
using StudentsLearning.Server.Api.Controllers;
using StudentsLearning.Server.Api.Models.SectionTransferModels;
using StudentsLearning.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using StudentsLearning.Server.Api.Models.CommentTransferModels;

namespace StudentsLearning.Services.Api.Tests.ControllerTests
{
    class CommentsControllerTests
    {
        [Test]
        public void CommentsControllerGetShouldAuthorizeAttribute()
        {
            MyWebApi.Controller<CommentsController>()
                .WithResolvedDependencyFor(TestObjectFactory.GetCommentService())
                .Calling(c => c.Post(new CommentRequestModel()
                {
                    Content = "First!",
                    TopicId = 1
                }))
                .ShouldHave()
                .ActionAttributes(a => a
                    .RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldHave()
                .ValidModelState();
        }

        //[TestCase(999999)]
        //[TestCase(-3)]
        //public void SectionsControllerGetWithInvalidIdShouldNotReturnOkResultWithData(int id)
        //{
        //    MyWebApi.Controller<SectionsController>()
        //        .WithResolvedDependencyFor(TestObjectFactory.GetSectionServiceNotFoundMock())
        //        .Calling(c => c.Get(id))
        //        .ShouldReturn()
        //        .NotFound();
        //}
    }
}
