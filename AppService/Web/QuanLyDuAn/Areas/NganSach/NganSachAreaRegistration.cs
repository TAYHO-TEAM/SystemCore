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
            //GiaiDoan
            context.MapRoute(
                "NganSach_GiaiDoan",
                "NganSach/GiaiDoan/{id}",
                new { controller = "Home", action = "GiaiDoan", id = UrlParameter.Optional },
                namespaces: new[] { "QuanLyDuAn.Areas.NganSach.Controllers" }
            );
        //INDEX
            context.MapRoute(
                "NganSach_default",
                "NganSach/{controller}/{action}/{id}",
                new { controller="Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "QuanLyDuAn.Areas.NganSach.Controllers" }
            );
        }
    }
}