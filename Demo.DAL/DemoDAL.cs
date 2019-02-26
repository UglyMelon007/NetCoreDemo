using Demo.IDAL;
using Demo.Model.Domain;
using NHibernate;
using System.Linq;
using log4net;

namespace Demo.DAL
{
    public class DemoDAL : IDemoDAL
    {
        private readonly ISession _session;
        private readonly ILog _log;

        public DemoDAL(ISession session, ILog log)
        {
            _session = session;
            _log = log;
        }

        public string GetHello(string name)
        {
            var temp = _session.Query<TESTDEMO>().ToList().Last();
            _log.Info("Hello world");
            return $"Hello {temp.STAFFNAME}  {name} ！ ！";
        }
    }
}