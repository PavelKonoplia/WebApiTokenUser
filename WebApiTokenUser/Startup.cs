using Autofac;
using Autofac.Integration.WebApi;
using BusinessLogic.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using WebApiTokenUser.BLL;
using WebApiTokenUser.DAL;
using WebApiTokenUser.Entity.Models;


[assembly: OwinStartup(typeof(WebApiTokenUser.Startup))]
namespace WebApiTokenUser
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            // autofac configuration zone

            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();

           // var x = new IdentityDatabaseContext();

            builder.RegisterType<IdentityDatabaseContext>().As(typeof(DbContext)).SingleInstance();
            builder.RegisterType<CustomUserStore>().As(typeof(IUserStore<User, long>)).SingleInstance();
            builder.RegisterType<IdentityUserManager>().SingleInstance();

            builder.RegisterType<IdentityFactoryOptions<IdentityUserManager>>().SingleInstance();

            builder.RegisterWebApiFilterProvider(config);

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);

            // end of autofac configure 

            WebApiConfig.Register(config);
            ConfigureAuth(app, container.Resolve<IdentityUserManager>());
            app.UseWebApi(config);
        }


        public void ConfigureAuth(IAppBuilder app, IdentityUserManager userManager)
        {

            // Configure the application for OAuth based flow
            var OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new ApplicationOAuthProvider(userManager),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}