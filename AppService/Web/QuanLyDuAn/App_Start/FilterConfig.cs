using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn
{
    public class FilterConfig : ActionFilterAttribute
    { 
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
