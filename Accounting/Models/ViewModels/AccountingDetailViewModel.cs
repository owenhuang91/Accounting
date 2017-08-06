using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting.Models.ViewModels {
    public class AccountingDetailViewModel {

        [Display(Name ="類別")]
        public string Type { get; set; }
        [Display(Name = "日期")]
        public string Date { get; set; }
        [Display(Name = "金額")]
        public string Price { get; set; }
    }
}