namespace StudentsLearning.Services.Api.Tests.IntegrationTests
{
    #region

    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;

    using NUnit.Framework;

    #endregion

    [TestFixture]
    public class CategoriesIntegrationTests
    {
        [Test]
        public void CategoriesShouldReturnCorrrectResponse()
        {
                var request = new HttpRequestMessage
                                  {
                                      RequestUri = new Uri("http://test.com/api/Categories"), 
                                      Method = HttpMethod.Get
                                  };

                var result = TestInit.HttpInvoker.SendAsync(request, CancellationToken.None).Result;

                Assert.IsNotNull(result);
                Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void CategoriesShouldReturnNotFoundWithInvalidId()
        {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://test.com/api/Categories/9334422"),
                    Method = HttpMethod.Get
                };

                var result = TestInit.HttpInvoker.SendAsync(request, CancellationToken.None).Result;

                Assert.IsNotNull(result);
                Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }
    }
}