using Demo.IBLL;
using Demo.IDAL;

namespace Demo.BLL
{
    public class DemoBLL : IDemoBLL
    {
        private readonly IDemoDAL _demoDal;

        public DemoBLL(IDemoDAL demoDal)
        {
            _demoDal = demoDal;
        }


        public string GetHello(string name)
        {
            return _demoDal.GetHello(name);
        }
    }
}
