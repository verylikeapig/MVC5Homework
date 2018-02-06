using Day1Homework.Domain;
using Day1Homework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day1Homework.DAL  // Data Access Layer 資料中心抽象層 Datacenter Abstraction Layer (DAL)  可以實作 ADO.NET 的方法。
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
                        Category = (x.Categoryyy == 1) ? "支出" : "收入",
                        RecordDate = x.Dateee,
                        Updatetime = x.Updatetime
                    }
                    ).OrderByDescending(y => y.Updatetime).ToList();
            return list;
        }

        public List<AccountBookBO> GetAccountBook(int TopNumber)
        {
            List<AccountBookBO> list = new List<AccountBookBO>();
            list = (
                    from x in GetAll()
                    select new AccountBookBO
                    {
                        Amount = x.Amounttt,
                        Category = (x.Categoryyy == 1) ? "支出" : "收入",
                        RecordDate = x.Dateee, 
                        Updatetime = x.Updatetime
                    }
                    ).OrderByDescending(y => y.Updatetime).Take(TopNumber).ToList();
            return list;
        }

        public List<Categories> GetCategories()
        {
            List<Categories> list = new List<Categories>();
            list = (
                    from x in GetAll()
                    select new Categories
                    {
                        CategoryId = x.Categoryyy,
                        Category = (x.Categoryyy == 1) ? "支出" : "收入"
                    }
                    ).Distinct().OrderBy(y => y.CategoryId).ToList();

            return list;
        }
    }
}