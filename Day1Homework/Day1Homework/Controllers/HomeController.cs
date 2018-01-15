using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day1Homework.BL;

namespace Day1Homework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var dataProvider = new Day1HomeworkDataProvider();
            var data = dataProvider.GetData();

            return View(data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Contact - from controller";
            ViewBag.Message = "Your contact page. - from controller";

            return View();
        }

        [ChildActionOnly]
        public ActionResult MoneyDetail()
        {
            ViewBag.Title = "我的記帳本";
            ViewBag.Message = "收入與支出 - Child Action";

            var dataProvider = new Day1HomeworkDataProvider();
            var data = dataProvider.GetData();

            return View(data);
        }
    }
}