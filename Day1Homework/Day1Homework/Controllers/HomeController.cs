using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day1Homework.BL;
using Day1Homework.ViewModels.Home;

namespace Day1Homework.Controllers  // 調度資源和組裝ViewModel
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var dataProvider = new AccountingService();
            var data = dataProvider.GetData();

            return View(data);
        }

        [HttpGet]
        public ActionResult MyAccountBook()
        {
            ViewBag.Title = "我的記帳本";
            ViewBag.Message = "收入與支出 - Child Action";

            return View(new MoneyDetailViewModel());
        }

        [HttpPost]
        public ActionResult MyAccountBook(MoneyDetailViewModel viewModel)
        {
            ViewBag.Title = "我的記帳本 - Post";
            ViewBag.Message = "收入與支出 - Child Action";

            // 處理(CUD) viewModel 的東西

            ViewBag.Result = "OK!!";

            return View(viewModel);
        }

        [ChildActionOnly]
        public ActionResult MoneyDetail()
        {

            var dataProvider = new AccountingService();

            //var data = dataProvider.GetData();
            var data = dataProvider.GetDataFromEF();

            return View(data);
        }
    }
}