﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Day1Homework.ViewModels.Home
{
    public class MoneyDetailViewModel
    {
        [Display(Name = "類別")]
        public string Category { get; set; }

        [Required]
        [Display(Name = "金額")]
        [Range(0, 2147483647, ErrorMessage = "數值區間 0 ~ 2,147,483,647")]
        public decimal Money { get; set; }

        [Display(Name = "日期")]
        public DateTime Date { get; set; }

        [Display(Name = "備註")]
        [StringLength(500, ErrorMessage = "最大字數是500字，最小字數是3字。", MinimumLength = 3)]
        public string Description { get; set; }
    }
}