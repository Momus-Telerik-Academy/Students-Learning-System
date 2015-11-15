using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.Owin.Hosting;
using StudentsLearning.Server.Api;
using System.Net.Http;
using System.Net;

namespace StudentsLearning.Services.Api.Tests.NetworkIntegrationTests
{
    [TestFixture]
    public class CategoriesNetworkIntegrationTests
    {
        [Test]
        public void CategoriesShouldReturnCorrectResponse()
        {
            using (var webApp = WebApp.Start<Startup>("http://localhost:1234"))
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("http://localhost:1234");

                    var result = httpClient.GetAsync("api/Categories").Result;

                    Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
                }

                webApp.Dispose();
            }
        }
    }
}
