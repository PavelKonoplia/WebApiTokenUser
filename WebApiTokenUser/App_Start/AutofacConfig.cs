using Autofac;
using Autofac.Integration.WebApi;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using WebApiTokenUser.Interfaces;
using WebApiTokenUser.Models;
using WebApiTokenUser.Models.Context;

namespace AutoFacWithWebAPI.App_Start
{
    public class AutofacConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        { 
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //
            builder.RegisterGeneric(typeof(Repository<>))
                   .As(typeof(IRepository<>))
                   .InstancePerRequest();
            /*
            builder.RegisterInstance<IRepository<User>>(new Repository<User>());
            builder.RegisterInstance<IRepository<Data>>(new Repository<Data>());*/
  
            Container = builder.Build();

            return Container;
        }
    }
}