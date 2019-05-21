using Autofac;
using Autofac.Integration.WebApi;
using Challenge.Repository.CartRepository;
using Challenge.Repository.CartRepository.Contract;
using Challenge.Repository.Context;
using Challenge.Repository.ProductRepository;
using Challenge.Repository.ProductRepository.Contract;
using Challenge.Repository.SaleRepository;
using Challenge.Repository.SaleRepository.Contract;
using Challenge.Repository.UserRepository;
using Challenge.Repository.UserRepository.Contract;
using Challenge.Services.CartService;
using Challenge.Services.CartService.Contract;
using Challenge.Services.ProductService;
using Challenge.Services.ProductService.Contract;
using Challenge.Services.UserService;
using Challenge.Services.UserService.Contract;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Challenge.IoC
{
    public static class ContainerFactory
    {

        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();

            builder.Register<IMongoClient>((c, p) =>
            {
                return new MongoClient(ConfigurationManager.AppSettings["mongo.connection"]);
            });

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces().InstancePerLifetimeScope();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterWebApiModelBinderProvider();

            return builder.Build();
        }
    }
}