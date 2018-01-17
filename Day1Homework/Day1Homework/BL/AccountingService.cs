using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Day1Homework.Models;

namespace Day1Homework.BL
{
    public class AccountingService
    {
        public List<AccountBook> GetData()
        {
            List<AccountBook> list = new List<AccountBook>();

            Random random = new Random(9);

            for (int i = 0; i < 100; i++)
            {
                AccountBook day1 = new AccountBook
                {
                    Category = (random.Next() % 2 == 0) ? "支出" : "收入",
                    RecordDate = DateTime.Now.AddDays(random.Next(-100, 100)),
                    Amount = Convert.ToDecimal(random.Next(333, 99999999))
                };

                list.Add(day1);
            }

            return list;
        }
    }
}