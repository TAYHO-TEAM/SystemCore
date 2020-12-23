using System.Web.Mvc;

namespace QuanLyDuAn.Areas.PhatHanh
{
    public class PhatHanhAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PhatHanh";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PhatHanh_default",
                "PhatHanh/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}