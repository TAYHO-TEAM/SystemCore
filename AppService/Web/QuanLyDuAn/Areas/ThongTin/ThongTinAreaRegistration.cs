using System.Web.Mvc;

namespace QuanLyDuAn.Areas.ThongTin
{
    public class ThongTinAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ThongTin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ThongTin_default",
                "ThongTin/{controller}/{action}/{id}",
                new { controller ="Home",action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}