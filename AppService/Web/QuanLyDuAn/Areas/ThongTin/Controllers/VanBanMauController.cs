using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Areas.ThongTin.Controllers
{
    public class VanBanMauController : Controller
    {
        // GET: ThongTin/VanBanMau
        public ActionResult Index()
        {
            return View();
        }
        // GET: ThongTin/VanBanMau
        public ActionResult VanBanMau()
        {
            return View();
        } 
        // GET: ThongTin/VanBanMau
        public ActionResult _VanBanMauDetail()
        {
            return PartialView();
        }
    }
}