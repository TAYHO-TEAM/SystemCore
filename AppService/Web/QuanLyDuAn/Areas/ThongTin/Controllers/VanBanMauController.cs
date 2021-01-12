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
        public ActionResult _VanBanMauDetail(int id)
        {
            return PartialView(id);
        }
        // GET: ThongTin/VanBanMau
        public ActionResult DanhSachVanBan()
        {
            return View();
        }
        // GET: ThongTin/VanBanMau
        public ActionResult _DienVanBan(int id)
        {
            return PartialView(id);
        }
    }
}