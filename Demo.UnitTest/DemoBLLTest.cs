using System;
using Autofac;
using Demo.Autofac;
using Demo.Common;
using Demo.IBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace DataSourceTest
{
    [TestClass]
    public class DemoBLLTest
    {
        private IContainer _container;

        [TestInitialize]
        public void TestInit()
        {
            GlobalAttribute.RepositoryName = "NetCoreDemo";
            _container = AutofacModule.InitTest();
        }

        [TestMethod]
        public void GetHelloTest()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                Console.WriteLine(scope.Resolve<IDemoBLL>().GetHello("单元测试"));
            }
        }
    }
}