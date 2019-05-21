using Autofac.Integration.WebApi;
using Challenge.IoC;
using System.Web.Http;

namespace Challenge
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(ContainerFactory.GetContainer());
        }
    }
}
