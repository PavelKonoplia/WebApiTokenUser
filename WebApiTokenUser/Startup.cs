using Autofac;
using Autofac.Integration.WebApi;
using BusinessLogic.Interfaces;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using WebApiTokenUser.DAL;
using WebApiTokenUser.Entity.Models;
using WebApiTokenUser.Services;


[assembly: OwinStartup(typeof(WebApiTokenUser.Startup))]
namespace WebApiTokenUser
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //
            var builder = new ContainerBuilder();

            // Register Web API controller in executing assembly.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            
            // Also hook the filters up to controllers.
            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<DatabaseContext>().As<DbContext>().SingleInstance();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();

            // via method
            //builder.Register(c => {
            //    var result = new ApplicationOAuthProvider();
            //    var dep = c.Resolve<Repository<User>>();
            //    result.GetContext(dep);
            //    return result; });

            // via property
            // builder.RegisterType<ApplicationOAuthProvider>().PropertiesAutowired();
            // builder.Register(c => new ApplicationOAuthProvider()).OnActivated(e => e.Instance.UserContext = e.Context.Resolve<IRepository<User>>());
            // builder.RegisterType<ApplicationOAuthProvider>().WithProperty("Context", typeof(IRepository<User>));

            builder.RegisterWebApiFilterProvider(config);

            var container = builder.Build();

            ;

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);          
            //
            WebApiConfig.Register(config);
            ConfigureOAuth(app, container.Resolve<IRepository<User>>());
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app, IRepository<User> repository)
        {
            OAuthAuthorizationServerOptions OAuthserverOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                Provider = new ApplicationOAuthProvider(repository)
            };

            app.UseOAuthAuthorizationServer(OAuthserverOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}