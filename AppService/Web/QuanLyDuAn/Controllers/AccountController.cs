using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Controllers
{
    public class AccountController : BaseController
    { 
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult NoAuthentication()
        {
            return View();
        }
    }
}