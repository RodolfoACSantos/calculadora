﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalculadoraCompleta.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        // POST: Home
        [HttpPost]
        public ActionResult Index(string bt, string display)
        {
            return View();
        }
    }
}