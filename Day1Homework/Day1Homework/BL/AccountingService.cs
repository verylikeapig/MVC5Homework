using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViewModel = Day1Homework.Models;
using Domain = Day1Homework.Domain;

namespace Day1Homework.BL
{
    public class AccountingService
    {
        public List<ViewModel::AccountBook> GetData()
        {
            List<ViewModel::AccountBook> list = new List<ViewModel::AccountBook>();

            Random random = new Random(9);

            for (int i = 0; i < 100; i++)
            {
                ViewModel::AccountBook day1 = new ViewModel::AccountBook
                {
                    Category = (random.Next() % 2 == 0) ? "支出" : "收入",
                    RecordDate = DateTime.Now.AddDays(random.Next(-100, 100)),
                    Amount = Convert.ToDecimal(random.Next(333, 99999999))
                };

                list.Add(day1);
            }

            return list;
        }

        public List<ViewModel::AccountBook> GetDataFromEF()
        {
            Domain::SkillTreeHomeworkEntities homeworkEntities = new Domain.SkillTreeHomeworkEntities();

            List<ViewModel::AccountBook> list = new List<ViewModel::AccountBook>();

            list = (
                    from x in homeworkEntities.AccountBook
                    select new ViewModel::AccountBook
                    {
                        Amount = x.Amounttt,
                        //Category = x.Categoryyy.ToString(),
                        Category = (x.Categoryyy==1) ? "支出" : "收入",
                        RecordDate = x.Dateee
                    }
                    ).ToList();

            return list;
        }
    }
}