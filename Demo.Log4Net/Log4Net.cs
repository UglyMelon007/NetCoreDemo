using System.IO;
using Autofac;
using Demo.Common;
using log4net;
using log4net.Config;
using log4net.Repository;

namespace Demo.Log4Net
{
    public class Log4Net
    {
        public ContainerBuilder Log4NetInit(ContainerBuilder containerBuilder)
        {
            //log4net配置
            ILoggerRepository repository = LogManager.CreateRepository(GlobalAttribute.RepositoryName);
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));

            //注册日志类
            containerBuilder.RegisterModule(new LoggingModule
            {
                RepositoryName = repository.Name
            });
            return containerBuilder;
        }
    }
}
