﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoadIt.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "RoadIt";
            if (Session["Username"] == null)
            {
                Session["Username"] = "Login";
                Session["email"] = "";
                Session["password"] = "";
                Session["RoleId"] = "";
            }
            
            return View();
        }
    }
}
