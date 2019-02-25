using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Demo.BLL;
using Demo.DAL;
using Demo.IBLL;
using Demo.IDAL;
using Demo.Web.MVC.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Autofac
{
    public static class Repository
    {
        public static IServiceProvider AutofacInit(IServiceCollection services)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<DemoDAL>().As<IDemoDAL>().PropertiesAutowired();
            containerBuilder.RegisterType<DemoBLL>().As<IDemoBLL>().PropertiesAutowired();
            containerBuilder.RegisterType<HomeController>().PropertiesAutowired();
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();

            return new AutofacServiceProvider(container);
        }
    }
}
