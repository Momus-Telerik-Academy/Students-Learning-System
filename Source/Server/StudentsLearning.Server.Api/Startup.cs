#region

using System.Web.Http;
using Microsoft.Owin;

using StudentsLearning.Server.Api;
using StudentsLearning.Server.Api.App_Start;

#endregion

[assembly: OwinStartup(typeof(Startup))]

namespace StudentsLearning.Server.Api
{
    #region

    using Microsoft.Owin.Cors;
    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;
    using Owin;
    using System.Reflection;

    #endregion

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutoMapperConfig.RegisterMappings(Assembly.Load("StudentsLearning.Server.Api"));
            app.UseCors(CorsOptions.AllowAll);
            this.ConfigureAuth(app);

            var httpConfig = new HttpConfiguration();

            WebApiConfig.Register(httpConfig);

            httpConfig.EnsureInitialized();

            app
                .UseNinjectMiddleware(NinjectConfig.CreateKernel)
                .UseNinjectWebApi(httpConfig);
        }
    }
}