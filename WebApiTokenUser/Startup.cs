using Autofac;
using Autofac.Integration.WebApi;
using BusinessLogic.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
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

            // autofac configuration zone

            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<IdentityDatabaseContext>().As<DbContext>().SingleInstance();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();

           // builder.RegisterType<CustomUserStore>().As<IUserStore<User, long>>().InstancePerDependency();
           // builder.RegisterType<IdentityUserManager>().As<UserManager<User, long>>().InstancePerDependency();

            builder.RegisterWebApiFilterProvider(config);

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);

            // end of autofac configure 

            WebApiConfig.Register(config);
            ConfigureAuth(app, container.Resolve<IRepository<User>>());
            app.UseWebApi(config);
        }


        public void ConfigureAuth(IAppBuilder app, IRepository<User> repository)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(IdentityDatabaseContext.Create);
            app.CreatePerOwinContext<IdentityUserManager>(IdentityUserManager.Create);

            // Configure the application for OAuth based flow
            var OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new ApplicationOAuthProvider(repository),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}