﻿
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMVCUI.Controllers
{
    public class HomeController : Controller
    {
   

        public HomeController()
        {
          
        }
        public ActionResult Index()
        {
           
            return View();
        }
    }
}