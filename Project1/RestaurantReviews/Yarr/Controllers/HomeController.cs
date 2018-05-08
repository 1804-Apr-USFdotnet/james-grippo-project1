using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Yarr.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Yarr stands for Yet Another Restaurant Reviewer.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Do not contact me with unsolicited services or offers.";

            return View();
        }
    }
}