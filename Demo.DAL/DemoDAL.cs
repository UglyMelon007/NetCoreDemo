using Demo.IDAL;

namespace Demo.DAL
{
    public class DemoDAL: IDemoDAL
    {
        public string GetHello(string name)
        {
            return $"Hello {name} ！ ！";
        }
    }
}
