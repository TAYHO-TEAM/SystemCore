using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Areas.ThongTin.Controllers
{
    public class QLCongViecController : Controller
    {
        // GET: ThongTin/QLCongViec
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _CongViecDetail(int id)
        {
            return PartialView(id);
        }

    }
}