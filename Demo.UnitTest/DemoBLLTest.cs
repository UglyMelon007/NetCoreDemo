using System;
using Autofac;
using Demo.Autofac;
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
