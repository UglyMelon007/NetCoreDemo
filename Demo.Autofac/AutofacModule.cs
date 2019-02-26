using Autofac;
using Autofac.Extensions.DependencyInjection;
using Demo.BLL;
using Demo.DAL;
using Demo.IBLL;
using Demo.IDAL;
using Demo.Log4Net;
using log4net.Repository;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.IO;
using log4net;
using log4net.Config;

namespace Demo.Autofac
{
    public static class AutofacModule
    {
        public static IServiceProvider InitWeb(ILoggerRepository  repository, IServiceCollection services)
        {
            //NHibernate
            var config = new Configuration().Configure("nhibernate.config");
            var sessionFactory = config.BuildSessionFactory();

            var containerBuilder = new ContainerBuilder();

            //将NHiberate的核心类注入到容器
            containerBuilder.RegisterInstance(config).As<Configuration>().SingleInstance();
            containerBuilder.RegisterInstance(sessionFactory).As<ISessionFactory>().SingleInstance();
            containerBuilder.Register(x => x.Resolve<ISessionFactory>().OpenSession()).As<NHibernate.ISession>()
                .InstancePerLifetimeScope();

            //注册日志类
            containerBuilder.RegisterModule(new LoggingModule
            {
                RepositoryName = repository.Name
            });

            //注册项目操作类
            containerBuilder.RegisterType<DemoDAL>().As<IDemoDAL>();
            containerBuilder.RegisterType<DemoBLL>().As<IDemoBLL>();
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }
        public static IContainer InitTest()
        {
            //log4net配置
            var repository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));

            //NHibernate
            var config = new Configuration().Configure("nhibernate.config");
            var sessionFactory = config.BuildSessionFactory();

            var containerBuilder = new ContainerBuilder();

            //将NHiberate的核心类注入到容器
            containerBuilder.RegisterInstance(config).As<Configuration>().SingleInstance();
            containerBuilder.RegisterInstance(sessionFactory).As<ISessionFactory>().SingleInstance();
            containerBuilder.Register(x => x.Resolve<ISessionFactory>().OpenSession()).As<NHibernate.ISession>()
                .InstancePerLifetimeScope();

            //注册日志类
            containerBuilder.RegisterModule(new LoggingModule
            {
                RepositoryName = repository.Name
            });

            //注册项目操作类
            containerBuilder.RegisterType<DemoDAL>().As<IDemoDAL>();
            containerBuilder.RegisterType<DemoBLL>().As<IDemoBLL>();

            return containerBuilder.Build();
        }
    }
}