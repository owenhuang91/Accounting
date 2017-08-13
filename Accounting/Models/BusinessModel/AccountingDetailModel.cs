using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting.Models.BusinessModel {
    public class AccountingDetailModel {

        public string Type { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
    }
}