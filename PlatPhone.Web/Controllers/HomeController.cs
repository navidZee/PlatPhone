﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PlatPhone.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
         
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
