﻿using System;
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
            return View();
        }

        [HttpGet]
        public ActionResult MyAccountBook()
        {
            ViewBag.Title = "我的記帳本";
            ViewBag.Message = "收入與支出 - Child Action";

            var categories = new AccountingService().GetCategories();
            var viewmodel = new MoneyDetailViewModel
            {
                Categories = new SelectList(categories, "CategoryId", "Category"),
                SelectedCategoryId = -1
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult MyAccountBook(MoneyDetailViewModel viewModel)
        {
            ViewBag.Title = "我的記帳本 - Post";
            ViewBag.Message = "收入與支出 - Child Action";

            // 處理(CUD) viewModel 的東西
            
            if (ModelState.IsValid)
            {
                var NewRecord = new AccountingService();
                NewRecord.CreateNewRecord(viewModel.SelectedCategoryId, viewModel.Money, viewModel.Date, viewModel.Description);
                viewModel.PageInformation = "OK!! Get it :　" + viewModel.Money.ToString();
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

        [ChildActionOnly]
        public ActionResult MoneyDetail()
        {

            var dataProvider = new AccountingService();

            //var data = dataProvider.GetData();
            var data = dataProvider.GetDataFromEF();

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
            if (ModelState.IsValid)
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
    }
}