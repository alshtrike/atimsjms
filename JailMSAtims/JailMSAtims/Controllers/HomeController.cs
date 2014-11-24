﻿using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {[Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        [Authorize]
        public ActionResult InmateTab()
        {
            ViewBag.Message = "This is JailTab";

            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
