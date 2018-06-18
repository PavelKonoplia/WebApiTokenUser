using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using WebApiTokenUser.DAL;

namespace WebApiTokenUser
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // System.Data.Entity.Database.SetInitializer(new DatabaseInitializer());
            // System.Data.Entity.Database.SetInitializer(new IdentityDbInit());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            // BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}