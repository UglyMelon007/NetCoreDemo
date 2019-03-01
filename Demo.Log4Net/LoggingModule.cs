using System.Linq;
using System.Reflection;
using Autofac.Core;
using log4net;

namespace Demo.Log4Net
{
    public class LoggingModule : Autofac.Module
    {
        public string RepositoryName { get; set; }

        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry,
            IComponentRegistration registration)
        {
            registration.Preparing += OnComponentPreparing;

            registration.Activated += (sender, e) => InjectLoggerProperties(e.Instance);
        }

        /// <summary>
        /// 属性注入
        /// </summary>
        /// <param name="instance"></param>
        private void InjectLoggerProperties(object instance)
        {
            var instanceType = instance.GetType();

            var properties = instanceType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType == typeof(ILog) && p.CanWrite && p.GetIndexParameters().Length == 0);

            foreach (var propToSet in properties)
            {
                propToSet.SetValue(RepositoryName, LogManager.GetLogger(instanceType));
            }
        }

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnComponentPreparing(object sender, PreparingEventArgs e)
        {
            e.Parameters = e.Parameters.Union(
                new[]
                {
                    new ResolvedParameter(
                        (p, i) => p.ParameterType == typeof(ILog),
                        (p, i) => LogManager.GetLogger(RepositoryName, p.Member.DeclaringType)
                    )
                });
        }
    }
}