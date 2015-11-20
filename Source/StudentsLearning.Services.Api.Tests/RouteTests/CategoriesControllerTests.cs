using StudentsLearning.Server.Api.Models.CategoryTransferModels;

namespace StudentsLearning.Services.Api.Tests.RouteTests
{
    #region

    using MyTested.WebApi;

    using NUnit.Framework;

    using StudentsLearning.Server.Api.Controllers;
    using System.Net.Http;

    #endregion

    [TestFixture]
    public class CategoriesControllerTests
    {
        [Test]
        public void CategoriesControllerShouldMapCorrectly()
        {
            MyWebApi.Routes().ShouldMap("api/Categories").To<CategoriesController>(c => c.Get());
        }

        [TestCase(1)]
        [TestCase(2)]
        public void CategoriesControllerByIdShouldMapCorrectly(int id)
        {
            MyWebApi.Routes().ShouldMap("api/Categories/" + id).To<CategoriesController>(c => c.Get(id));
        }

        [Test]
        public void CategoriesControllerPostShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Categories/")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{ ""Name"": ""Test"" }")
                .To<CategoriesController>(c => c.Post(new CategoryRequestModel
                {
                    Name = "Test"
                }));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void CategoriesControllerPutShouldMapCorrectly(int id)
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Categories/"+id)
                .WithHttpMethod(HttpMethod.Put)
                .WithJsonContent(@"{ ""Name"": ""Test"" }")
                .To<CategoriesController>(c => c.Put(id, new CategoryRequestModel
                {
                    Name = "Test"
                }));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void CategoriesControllerDeleteShouldMapCorrectly(int id)
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Categories/" + id)
                .WithHttpMethod(HttpMethod.Delete)
                .To<CategoriesController>(c => c.Delete(id));
        }
    }
}