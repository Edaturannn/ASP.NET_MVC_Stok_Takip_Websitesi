using System.Web;
using System.Web.Mvc;

namespace MVC_New_My_Stok_Takip_Website
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
