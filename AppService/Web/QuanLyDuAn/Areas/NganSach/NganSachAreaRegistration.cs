using System.Web.Mvc;

namespace QuanLyDuAn.Areas.NganSach
{
    public class NganSachAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "NganSach";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "NganSach_default",
                "NganSach/{controller}/{action}/{id}",
                new { controller="Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "QuanLyDuAn.Areas.NganSach.Controllers" }
            );
        }
    }
}