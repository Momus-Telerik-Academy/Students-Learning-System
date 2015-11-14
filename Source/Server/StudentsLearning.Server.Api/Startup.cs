#region

using Microsoft.Owin;

using StudentsLearning.Server.Api;

#endregion

[assembly: OwinStartup(typeof(Startup))]

namespace StudentsLearning.Server.Api
{
    #region

    using Microsoft.Owin.Cors;

    using Owin;

    #endregion

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            this.ConfigureAuth(app);
        }
    }
}