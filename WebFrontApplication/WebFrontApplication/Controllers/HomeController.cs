﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFrontApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminHome()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult UserInfo()
        {
            return View();
        }
    }
}