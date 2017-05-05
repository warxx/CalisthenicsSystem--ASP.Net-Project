using System.Web.Mvc;
using CalisthenicsSystem.Data;

namespace CalisthenicsSystem.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
