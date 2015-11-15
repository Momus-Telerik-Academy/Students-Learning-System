namespace StudentsLearning.Services.Api.Tests.IntegrationTests
{
    #region

    using System.Net.Http;
    using System.Web.Http;

    using NUnit.Framework;

    using StudentsLearning.Server.Api.Controllers;

    #endregion

    [SetUpFixture]
    public class TestInit
    {
        internal static HttpConfiguration Config;

        internal static HttpServer HttpServer;

        internal static HttpMessageInvoker HttpInvoker;

        [SetUp]
        public static void Init()
        {
            var controller = typeof(CategoriesController);

            Config = new HttpConfiguration();
            Config.MapHttpAttributeRoutes();

            Config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            Config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            HttpServer = new HttpServer(Config);
            HttpInvoker = new HttpMessageInvoker(HttpServer);
        }
    }
}