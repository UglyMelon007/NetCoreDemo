using Autofac;
using NHibernate;
using NHibernate.Cfg;

namespace Demo.NHibernate
{
    public class NHibernate
    {
        public ContainerBuilder MsSqlInit(ContainerBuilder containerBuilder)
        {
            //NHibernate配置
            var nhibernateConfig = new Configuration().Configure("sqlserver.config");
            return NHibernateInit(nhibernateConfig, containerBuilder);
        }

        public ContainerBuilder OracleInit(ContainerBuilder containerBuilder)
        {
            //NHibernate配置
            var nhibernateConfig = new Configuration().Configure("oracle.config");
            return NHibernateInit(nhibernateConfig, containerBuilder);
        }
        public ContainerBuilder NHibernateInit(Configuration nhibernateConfig, ContainerBuilder containerBuilder)
        {
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
