using System;
using System.IO;
using Autofac;
using Demo.BLL;
using Demo.DAL;
using Demo.IBLL;
using Demo.IDAL;
using Demo.Log4Net;
using log4net;
using log4net.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;

namespace DataSourceTest
{
    [TestClass]
    public class DemoDALTest
    {
        private IContainer _container;

        [TestInitialize]
        public void TestInit()
        {
            //log4net����
            var repository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));

            //NHibernate
            var config = new Configuration().Configure("nhibernate.config");
            var sessionFactory = config.BuildSessionFactory();

            var containerBuilder = new ContainerBuilder();

            //��NHiberate�ĺ�����ע�뵽����
            containerBuilder.RegisterInstance(config).As<Configuration>().SingleInstance();
            containerBuilder.RegisterInstance(sessionFactory).As<ISessionFactory>().SingleInstance();
            containerBuilder.Register(x => x.Resolve<ISessionFactory>().OpenSession()).As<ISession>()
                .InstancePerLifetimeScope();

            //ע����Ŀ������
            containerBuilder.RegisterType<DemoDAL>().As<IDemoDAL>();
            containerBuilder.RegisterType<DemoBLL>().As<IDemoBLL>();
            containerBuilder.RegisterType<DemoDALTest>();

            //ע����־��
            containerBuilder.RegisterModule(new LoggingModule {RepositoryName = repository.Name});

            _container = containerBuilder.Build();
        }

        [TestMethod]
        public void GetHelloTest()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                Console.WriteLine(scope.Resolve<IDemoDAL>().GetHello("��Ԫ����"));
            }
        }
    }
}