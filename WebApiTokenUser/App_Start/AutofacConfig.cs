using Autofac;
using Autofac.Integration.WebApi;
using BusinessLogic.Interfaces;
using DataAccess.Models.Context;
using System.Reflection;
using System.Web.Http;

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