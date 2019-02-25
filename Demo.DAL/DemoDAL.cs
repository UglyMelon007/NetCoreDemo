using Demo.IDAL;
using Demo.Model.Domain;
using NHibernate;
using System.Linq;

namespace Demo.DAL
{
    public class DemoDAL : IDemoDAL
    {
        private readonly ISession _session;

        public DemoDAL(ISession session)
        {
            _session = session;
        }

        public string GetHello(string name)
        {
            var temp = _session.Query<TestDemo>().ToList().Last();
            return $"Hello {temp.Name}  {name} ！ ！";
        }
    }
}