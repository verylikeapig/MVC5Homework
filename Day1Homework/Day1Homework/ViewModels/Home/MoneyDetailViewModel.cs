using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Day1Homework.Models;
using System.Web.Mvc;

namespace Day1Homework.ViewModels.Home
{
    public class MoneyDetailViewModel
    {
        [Display(Name = "類別")]
        public string Category { get; set; }

        //public IEnumerable<Categories> Categories { get; set; }
        public SelectList Categories { get; set; }
        public int SelectedCategoryId { get; set; }

        [Required]
        [Display(Name = "金額")]
        [Range(0, Int32.MaxValue, ErrorMessage = "只能輸入正整數，數值區間 {1} ~ {2}")]
        public int Money { get; set; }

        [Display(Name = "日期")]
        [DataType(DataType.Date)]
        [DatetimeAnnotationHelper]
        //[Range(typeof(DateTime),"2000-01-01","9999-12-31", ErrorMessage = "{0}只能在 {1} ~ {2} 之間")]  
        //無法實作，明明是20111/11/11，但還是會跑出錯誤訊息？！
        public DateTime Date { get; set; }

        [Display(Name = "備註")]
        [StringLength(100, ErrorMessage = "最多輸入{1}個字元。")]
        public string Description { get; set; }

        public string PageInformation { get; set; }

        public IEnumerable<AccountBookBO> MoneyDetailForPartialView { get; set; }
    }
}