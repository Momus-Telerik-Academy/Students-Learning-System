using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(StudentsLearning.Server.Api.Startup))]

namespace StudentsLearning.Server.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureAuth(app);
        }
    }
}
