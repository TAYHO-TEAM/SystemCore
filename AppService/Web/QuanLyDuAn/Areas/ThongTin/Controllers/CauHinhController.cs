using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Areas.ThongTin.Controllers
{
    public class CauHinhController : Controller
    {
        // GET: ThongTin/CauHinh
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HangMuc()
        {
            return View();
        }
        public ActionResult PhanQuyenPheDuyet()
        {
            return View();
        }
        public ActionResult QuyTrinh()
        {
            return View();
        }
        public ActionResult KeHoachDeTrinh()
        {
            return View();
        }
        public ActionResult _KeHoachShow()
        {
            return PartialView(1);
        }
        public ActionResult TaiLieu()
        {
            return View();
        }
    }
}