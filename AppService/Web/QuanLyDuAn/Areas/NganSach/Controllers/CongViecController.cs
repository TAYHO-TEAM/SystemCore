using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Areas.NganSach.Controllers
{
    public class CongViecController : Controller
    {  
        public ActionResult ChiTiet(int? id = 0)
        {
            if (id != 0) return View(id);
            else return RedirectToAction("ChiTiet", "NhomCongViec", new { area = "NganSach" });
        } 
    }
}