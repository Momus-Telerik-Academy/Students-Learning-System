namespace StudentsLearning.Server.Api
{
    #region

    using System.Web;
    using System.Web.Http;

    #endregion

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            DatabaseConfig.Initialize();
        }
    }
}