using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Day1Homework.Models;

namespace Day1Homework.BL
{
    public class Day1HomeworkDataProvider
    {
        public List<Day1HomeworkData> GetData()
        {
            List<Day1HomeworkData> list = new List<Day1HomeworkData>();

            Random random = new Random(9);

            for (int i = 0; i < 100; i++)
            {
                Day1HomeworkData day1 = new Day1HomeworkData
                {
                    DataCategory = (random.Next() % 2 == 0) ? "支出" : "收入",
                    DataDate = DateTime.Now.AddDays(random.Next(-100, 100)),
                    AmountOfMoney = random.Next(333, 99999999)
                };

                list.Add(day1);
            }

            return list;
        }
    }
}