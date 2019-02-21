using Demo.IBLL;
using Demo.IDAL;

namespace Demo.BLL
{
    public class DemoBLL : IDemoBLL
    {
        public IDemoDAL DemoDal { get; set; }


        public string GetHello(string name)
        {
            return DemoDal.GetHello(name) + " 超";
        }
    }
}
