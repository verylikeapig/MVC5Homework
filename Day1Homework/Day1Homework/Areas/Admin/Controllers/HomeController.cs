using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day1Homework.Fliters;

namespace Day1Homework.Areas.Admin.Controllers
{
    [AuthorizePlus]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult History()
        {
            return View();
        }
    }
}