using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Areas.ThongTin.Controllers
{
    public class PhatHanhController : Controller
    {
        // GET: ThongTin/PhatHanh
        public ActionResult Index(int id = 0 )
        {
            if(id ==0)
            {

            }   
            else
            {

            }                
            return View();
        }

        // GET: ThongTin/ListPhatHanh
        public ActionResult ListPhatHanh(int id = 0)
        {
            if (id == 0)
            {

            }
            else
            {

            }
            return View();
        }
        // GET: ThongTin/_PhatHanhDetail
        public ActionResult _PhatHanhDetail(int id = 0)
        {
            if (id == 0)
            {

            }
            else
            {

            }
            return View();
        }
    }
}