using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy;
using Demo.Common;
using log4net;

namespace Demo.AspectCore
{
    public class LogInterceptor : AbstractInterceptor
    {
        private readonly ILog _log = LogManager.GetLogger(GlobalAttribute.RepositoryName, typeof(LogInterceptor));

        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            try
            {
                _log.Info("Before service call");
                await next(context);
            }
            catch (Exception ex)
            {
                _log.Error($"Service threw an exception!{ex}");
                throw;
            }
            finally
            {
                _log.Info("After service call");
            }
        }
    }
}