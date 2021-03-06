﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Day1Homework.Models;
using Day1Homework.DAL;
using MvcPaging;

namespace Day1Homework.BL   // Business Logic
{
    public class AccountingService
    {
        public List<AccountBookBO> GetData()
        {
            List<AccountBookBO> list = new List<AccountBookBO>();

            Random random = new Random(9);

            for (int i = 0; i < 100; i++)
            {
                AccountBookBO day1 = new AccountBookBO
                {
                    Category = (random.Next() % 2 == 0) ? "支出" : "收入",
                    RecordDate = DateTime.Now.AddDays(random.Next(-100, 100)),
                    Amount = Convert.ToDecimal(random.Next(333, 99999999))
                };

                list.Add(day1);
            }

            return list;
        }

        public List<AccountBookBO> GetDataFromEF()
        {
            var dal = new AccountBookDAL();

            //若是沒有實做 GenericRepository 就要寫客製化的select
            //List<AccountBookBO> list = dal.GetAllAccountBook();
            
            return dal.GetAccountBook();
        }

        public List<AccountBookBO> GetLimitedDataFromEF()
        {
            var dal = new AccountBookDAL();

            return dal.GetAccountBook(33);
        }

        public IPagedList<AccountBookBO> GetDataFromEFwithPaging(int currentPageIndex, int yyyy, int mm)
        {
            var dal = new AccountBookDAL();
            
            return dal.GetAccountBookWithPagedList(currentPageIndex, 5, yyyy, mm);
        }

        public List<Categories> GetCategories()
        {
            var dal = new AccountBookDAL();

            return dal.GetCategories();
        }

        public void CreateNewRecord(int category, int amount, DateTime date, string remark)
        {
            var dal = new AccountBookDAL();
            Domain.AccountBook accountBook = new Domain.AccountBook
            {
                Id = Guid.NewGuid(),
                Categoryyy = category,
                Amounttt = amount,
                Dateee = date.Date,
                Remarkkk = remark,
                Updatetime = DateTime.Now
            };
            dal.Create(accountBook);
        }
    }
}