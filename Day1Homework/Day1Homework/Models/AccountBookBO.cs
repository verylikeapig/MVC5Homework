﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
//BO = business object  可以很多service一起共用，或用來兩兩互相傳遞型態(BL, DAL, views, controller)。
//描述一份同性質的資料
//序列化、反序列化
//ADO.NET
namespace Day1Homework.Models
{
    public class AccountBookBO
    {
        public string Category { get; set; }

        public DateTime RecordDate { get; set; }

        public decimal Amount { get; set; }

        public DateTime Updatetime { get; set; }
    }

    public class Categories
    {
        public int CategoryId { get; set; }

        public string Category { get; set; }
    }
}