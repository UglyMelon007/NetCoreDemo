using AspectCore.Configuration;
using AspectCore.Extensions.Autofac;
using Autofac;

namespace Demo.AspectCore
{
    public class AspectCore
    {
        public ContainerBuilder AspectCoreInit(ContainerBuilder containerBuilder)
        {
            //注册动态代理的接口和相关拦截器配置AspectCore 
            containerBuilder.RegisterDynamicProxy(config => config.Interceptors.AddTyped<LogInterceptor>(Predicates.ForNameSpace("Demo.IBLL*")));
            return containerBuilder;
        }
    }
}
