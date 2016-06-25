using System.Web;
using System.Web.Mvc;

namespace YouZan.Plugin.AutoShipment
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
