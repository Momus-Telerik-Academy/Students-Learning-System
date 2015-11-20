using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StudentsLearning.Server.Api.Controllers;
using MyTested.WebApi;
using System.Net.Http;
using StudentsLearning.Server.Api.Models.SectionTransferModels;

namespace StudentsLearning.Services.Api.Tests.RouteTests
{
    [TestFixture]
    public class SectionsControllerTests
    {
        [Test]
        public void SectionsControllerShouldMapCorrectly()
        {
            MyWebApi.Routes().ShouldMap("api/Sections").To<SectionsController>(c => c.Get());
        }

        [TestCase(1)]
        [TestCase(2)]
        public void SectionsControllerByIdShouldMapCorrectly(int id)
        {
            MyWebApi.Routes().ShouldMap("api/Sections/" + id).To<SectionsController>(c => c.Get(id));
        }

        [Test]
        public void SectionsControllerPostShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Sections/")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{ ""Name"": ""Test"", ""Description"": ""Lorem ipsum dor..."", ""CategoryId"": ""1"" }")
                .To<SectionsController>(c => c.Post(new SectionRequestModel
                {
                    Name = "Test",
                    Description = "Lorem ipsum dor...",
                    CategoryId = 1
                }));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void SectionsControllerPutShouldMapCorrectly(int id)
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Sections/" + id)
                .WithHttpMethod(HttpMethod.Put)
                .WithJsonContent(@"{ ""Name"": ""Test"", ""Description"": ""Lorem ipsum dor..."", ""CategoryId"": ""1"" }")
                .To<SectionsController>(c => c.Put(id, new SectionRequestModel
                {
                    Name = "Test",
                    Description = "Lorem ipsum dor...",
                    CategoryId = 1
                }));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void SectionsControllerDeleteShouldMapCorrectly(int id)
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Sections/" + id)
                .WithHttpMethod(HttpMethod.Delete)
                .To<SectionsController>(c => c.Delete(id));
        }
    }
}
