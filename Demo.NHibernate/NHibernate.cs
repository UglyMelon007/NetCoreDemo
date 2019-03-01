using System;
using Autofac;
using NHibernate;
using NHibernate.Cfg;

namespace Demo.NHibernate
{
    public class NHibernate
    {
        public ContainerBuilder NhibernateInit(ContainerBuilder containerBuilder)
        {
            //NHibernate配置
            var nhibernateConfig = new Configuration().Configure("nhibernate.config");
            var sessionFactory = nhibernateConfig.BuildSessionFactory();

            //将NHiberate的核心类注入到容器
            containerBuilder.RegisterInstance(nhibernateConfig).As<Configuration>().SingleInstance();
            containerBuilder.RegisterInstance(sessionFactory).As<ISessionFactory>().SingleInstance();
            containerBuilder.Register(x => x.Resolve<ISessionFactory>().OpenSession()).As<ISession>()
                .InstancePerLifetimeScope();
            return containerBuilder;
        }
    }
}
