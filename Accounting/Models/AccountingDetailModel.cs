using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting.Models {
    public class AccountingDetailModel {

        [Display(Name ="類別")]
        public string Type { get; set; }
        [Display(Name = "日期")]
        public DateTime Date { get; set; }
        [Display(Name = "金額")]
        public decimal Price { get; set; }
    }
}