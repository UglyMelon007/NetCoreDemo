using Demo.IDAL;
using Demo.Model.Domain;
using log4net;
using NHibernate;
using System.Linq;

namespace Demo.DAL
{
    public class DemoDAL : IDemoDAL
    {
        private readonly ILog _log;
        private ISession _session;

        public DemoDAL(ILog log, ISession session)
        {
            _log = log;
            _session = session;
        }

        public string GetHello(string name)
        {
            var temp = _session.Query<TestDemo>().ToList().Last();
            return $"Hello {temp.Name} ！ ！";
        }
    }
}