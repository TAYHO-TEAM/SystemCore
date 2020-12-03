using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Areas.ThongTin.Controllers
{
    public class HomeController : Controller
    {
        // GET: ThongTin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}