using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Areas.ThongTin.Controllers
{
    public class QLTienDoController : Controller
    {
        // GET: ThongTin/QLTienDo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _TienDoDetail()
        {
            return PartialView();
        }
        public ActionResult _TienDoReport(int id)
        {
            return PartialView(id);
        }
    }
}