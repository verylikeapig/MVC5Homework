using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//BO = business object  可以很多service一起共用，或用來兩兩互相傳遞型態(BL, DAL, views, controller)。
//序列化、反序列化
//ADO.NET
namespace Day1Homework.Models
{
    public class AccountBookBO
    {
        public string Category { get; set; }

        public DateTime RecordDate { get; set; }

        public decimal Amount { get; set; }
    }
}