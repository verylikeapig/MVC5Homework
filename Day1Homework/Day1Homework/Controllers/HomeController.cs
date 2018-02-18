using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day1Homework.BL;
using Day1Homework.ViewModels.Home;
using System.Web.Security;
using MvcPaging;

namespace Day1Homework.Controllers  // 調度資源和組裝ViewModel
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MyAccountBook(int? page, int? yyyy, int? mm)
        {
            ViewBag.Title = "我的記帳本";
            ViewBag.Message = "收入與支出 - Child Action";
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            var categories = new AccountingService().GetCategories();
            var viewmodel = new MoneyDetailViewModel
            {
                Categories = new SelectList(categories, "CategoryId", "Category"),
                SelectedCategoryId = -1,
                MoneyDetailForPaging = new AccountingService().GetDataFromEF().ToPagedList(currentPageIndex,5)
        };

            ViewBag.yyyy = yyyy.HasValue ? yyyy.Value : 0;
            ViewBag.mm = mm.HasValue ? mm.Value : 0;

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult MyAccountBook(MoneyDetailViewModel viewModel)
        {
            ViewBag.Title = "我的記帳本 - Post";
            ViewBag.Message = "收入與支出 - Child Action";

            // 處理(CUD) viewModel 的東西

            if (ModelState.IsValid && LoginCheck())
            {
                var NewRecord = new AccountingService();
                NewRecord.CreateNewRecord(viewModel.SelectedCategoryId, viewModel.Money, viewModel.Date, viewModel.Description);
                viewModel.PageInformation = "OK!! Get it :　" + viewModel.Money;
            }
            else
            {
                viewModel.PageInformation = "Not OK!!";
            }

            var categories = new AccountingService().GetCategories();
            viewModel.Categories = new SelectList(categories, "CategoryId", "Category");
            viewModel.SelectedCategoryId = -1;

            return View(viewModel);
            //return RedirectToAction("MyAccountBook");
        }

        private bool LoginCheck()
        {
            Boolean LoginTicket = (Boolean?)Session["auth"] ?? false;

            if (!LoginTicket)
            {
                ModelState.AddModelError("Description", "請登入才能新增資料!!");
            }

            return LoginTicket;
        }

        [ChildActionOnly]
        public ActionResult MoneyDetail(int? page, int? yyyy, int? mm)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;

            var dataProvider = new AccountingService();

            //var data = dataProvider.GetData();
            //var data = dataProvider.GetDataFromEF();
            int year = yyyy.HasValue ? yyyy.Value : 0;
            int month = mm.HasValue ? mm.Value : 0;

            var data = dataProvider.GetDataFromEFwithPaging(currentPageIndex, year, month);

            return View(data);
        }

        public ActionResult MyAccountBookByAjax()
        {
            ViewBag.Title = "我的記帳本 - By Ajax";
            ViewBag.Message = "收入與支出 - Partial View";

            var categories = new AccountingService().GetCategories();

            var moneydetail = new AccountingService().GetLimitedDataFromEF();

            var viewmodel = new MoneyDetailViewModel
            {
                Categories = new SelectList(categories, "CategoryId", "Category"),
                SelectedCategoryId = -1,
                MoneyDetailForPartialView = moneydetail
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult MoneyDetailPartialView(MoneyDetailViewModel viewModel)
        {
            var NewRecord = new AccountingService();
            if (ModelState.IsValid && LoginCheck())
            {
                NewRecord.CreateNewRecord(viewModel.SelectedCategoryId, viewModel.Money, viewModel.Date, viewModel.Description);
            }

            var categories = NewRecord.GetCategories();
            var moneydetail = NewRecord.GetLimitedDataFromEF();
            var NewviewModel = new MoneyDetailViewModel
            {
                Categories = new SelectList(categories, "CategoryId", "Category"),
                SelectedCategoryId = -1,
                MoneyDetailForPartialView = moneydetail,
                PageInformation = (ModelState.IsValid == true) ? "OK!!get it :　" + viewModel.Money.ToString() : "Not OK!! It's not working!!"
            };

            return View(NewviewModel);
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (model.Account == "aaa" & model.Password == "bbb")
            {
                //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.Account, DateTime.Now, DateTime.Now.AddMinutes(5),
                //    true, "userData", FormsAuthentication.FormsCookiePath);
                //string encTicket = FormsAuthentication.Encrypt(ticket);
                //var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                //cookie.HttpOnly = true;

                //Response.Cookies.Add(cookie);

                Session["auth"] = true;
            }

            return RedirectToAction("index");
        }

        public ActionResult Logout()
        {
            Session["auth"] = false;
            return RedirectToAction("index");
        }
    }
}
