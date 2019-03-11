using Autofac;
using Autofac.Extensions.DependencyInjection;
using Demo.BLL;
using Demo.DAL;
using Demo.IBLL;
using Demo.IDAL;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Demo.Autofac
{
    public static class AutofacModule
    {
        public static IServiceProvider InitWeb(IServiceCollection services)
        {
            var containerBuilder = ContainerBuilderInit();
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }

        public static IContainer InitTest()
        {
            var containerBuilder = ContainerBuilderInit();
            return containerBuilder.Build();
        }

        private static ContainerBuilder ContainerBuilderInit()
        {
            var containerBuilder = new ContainerBuilder();
            //NHibernate相关配置信息
            containerBuilder = new NHibernate.NHibernate().MsSqlInit(containerBuilder);
            //AspectCore相关配置信息
            containerBuilder = new AspectCore.AspectCore().AspectCoreInit(containerBuilder);
            //Log4Net相关配置信息
            containerBuilder = new Log4Net.Log4Net().Log4NetInit(containerBuilder);

            //注册项目操作类
            containerBuilder.RegisterType<DemoDAL>().As<IDemoDAL>();
            containerBuilder.RegisterType<DemoBLL>().As<IDemoBLL>();
            return containerBuilder;
        }
    }
}