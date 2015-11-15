namespace StudentsLearning.Server.Api
{
    #region

    using System.Web.Http;

    using Microsoft.Owin.Security.OAuth;

    using Newtonsoft.Json;

    #endregion

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // TODO: [Note] Check if parsing is working without next lines the same way when requesting from client and from Postman on each machine 
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
        }
    }
}