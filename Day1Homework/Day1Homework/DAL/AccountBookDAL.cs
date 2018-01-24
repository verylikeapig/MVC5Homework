﻿using Day1Homework.Domain;
using Day1Homework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day1Homework.DAL  // Data Access Layer 資料中心抽象層 Datacenter Abstraction Layer (DAL)
{
    public class AccountBookDAL : GenericRepository<AccountBook>
    {

        public AccountBookDAL()
        {
            
        }

        public List<AccountBookBO> GetAccountBook()
        {
            List<AccountBookBO> list = new List<AccountBookBO>();
            list = (
                    from x in GetAll()
                    select new AccountBookBO
                    {
                        Amount = x.Amounttt,
                        //Category = x.Categoryyy.ToString(),
                        Category = (x.Categoryyy == 1) ? "支出" : "收入",
                        RecordDate = x.Dateee
                    }
                    ).ToList();
            return list;
        }
    }
}