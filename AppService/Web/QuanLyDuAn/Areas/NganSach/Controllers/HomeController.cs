﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Areas.NganSach.Controllers
{
    public class HomeController : Controller
    {
        // GET: NganSach/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GiaiDoan()
        {
            return View();
        }
    }
}