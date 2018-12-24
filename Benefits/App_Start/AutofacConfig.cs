using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Benefits.Configuration;
using Benefits.DAL.Context;
using Benefits.DAL.Repositories.Implementations;
using Benefits.DAL.Repositories.Interfaces;
using Benefits.Services.Implementations;
using Benefits.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Benefits.App_Start
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

            builder.RegisterType<ClientRestaurantRepository>()
                   .As<IClientRestaurantRepository>()
                   .InstancePerRequest();
            builder.RegisterType<GymRepository>()
                  .As<IGymRepository>()
                  .InstancePerRequest();
            builder.RegisterType<ClientRestaurantRepository>()
                   .As<IClientRestaurantRepository>()
                   .InstancePerRequest();
            builder.RegisterType<RestaurantRepository>()
                  .As<IRestaurantRepository>()
                  .InstancePerRequest();

            builder.RegisterType<ClientObjectService>()
                  .As<IClientObjectService>()
                  .InstancePerRequest();
            builder.RegisterType<GymService>()
                   .As<IGymService>()
                   .InstancePerRequest();
            builder.RegisterType<RestaurantService>()
                  .As<IRestaurantService>()
                  .InstancePerRequest();
            builder.RegisterType<WebApiContext>()
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            builder.RegisterInstance<IMapper>(mapper)
                  .SingleInstance();
            Container = builder.Build();

            return Container;
        }

    }
}