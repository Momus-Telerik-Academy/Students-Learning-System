using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using MyTested.WebApi;
using NUnit.Framework;
using StudentsLearning.Server.Api.Controllers;
using StudentsLearning.Server.Api;

namespace StudentsLearning.Services.Api.Tests.RouteTests
{
    [TestFixture]
    public class CategoriesControllerTests
    {
        [Test]
        public void CategoriesControllerShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Categories")
                .To<CategoriesController>(c => c.Get());
        }
    }
}
