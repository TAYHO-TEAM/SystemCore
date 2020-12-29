using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Areas.ThongTin.Controllers
{
    public class DangKyController : Controller
    {
        // GET: ThongTin/DangKy
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PheDuyet()
        {
            return View();
        }
        public ActionResult _DetailRequestRegist(int Id)
        {
            return PartialView(Id);
        }
        public ActionResult _FormRegister()
        {
            return PartialView();
        }


    }
}