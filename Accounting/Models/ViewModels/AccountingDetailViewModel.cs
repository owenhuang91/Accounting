using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Accounting.Filters;

namespace Accounting.Models.ViewModels {

    public class AccountingDetailViewModel {

        [Display(Name = "日期")]
        [RemoteDoublePlus("LessThanOrEqualToToday", "Valid", "", ErrorMessage = "日期不得大於今天")]
        public DateTime Date { get; set; }

        [Display(Name = "金額")]
        //[RemoteDoublePlus("GreaterThanZero", "Valid", "", ErrorMessage = "金額只能輸入正整數")]
        [GreaterThanZero(ErrorMessage = "金額只能輸入正整數")]
        public decimal Price { get; set; }

        [Display(Name = "類別")]
        public CategoryEumn Category { get; set; }

        [Display(Name = "備註")]
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
    }
}