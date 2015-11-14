using StudentsLearning.Server.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using NUnit.Framework;

namespace StudentsLearning.Services.Api.Tests.IntegrationTests
{
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

            Config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            Config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            HttpServer = new HttpServer(Config);
            HttpInvoker = new HttpMessageInvoker(HttpServer);
        }
    }
}
