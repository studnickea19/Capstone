using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestFriendFinder2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Best Friend Finder is your single source for all things dog.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Tell us what you think.";

            return View();
        }
    }
}