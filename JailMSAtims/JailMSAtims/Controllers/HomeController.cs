using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JailMSAtims.Controllers
{
    public class HomeController : Controller
    {    [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            ViewBag.Message = "This is User Management Tab";

            return View();
        }

        public ActionResult PreBook()
        {
            ViewBag.Message = "This is pre-book tab";

            return View();
        }
        public ActionResult Intake()
        {
            ViewBag.Message = "This is intake tab";

            return View();
        }
        public ActionResult Booking()
        {
            ViewBag.Message = "This is booking tab";

            return View();
        }
        public ActionResult PreScreen()
        {
            ViewBag.Message = "This is pre-screen tab";

            return View();
        }
        public ActionResult Classification()
        {
            ViewBag.Message = "This is classification tab";

            return View();
        }
        public ActionResult JailTab()
        {
            ViewBag.Message = "This is Jail tab";

            return View();
        }
    }
}