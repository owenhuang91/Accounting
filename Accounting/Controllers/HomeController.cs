using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Accounting.Models;
using Accounting.Models.ViewModels;

namespace Accounting.Controllers {

    public class HomeController : Controller {
        private AccountingService accountingService;

        public HomeController() {
            accountingService = new AccountingService();
        }

        /// <summary>
        /// 記帳功能頁面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index() {
            var accountingDetails = new List<AccountingDetailViewModel>();

            try {
                accountingDetails = accountingService.GetAllAccountingDetail()
                    .Select((m, i) => new AccountingDetailViewModel() {
                        No = i + 1,
                        Type = m.Type,
                        Date = m.Date.ToString("yyyy-MM-dd"),
                        Price = m.Price.ToString("#,0"),
                    }).ToList();
            } catch (Exception) {
                //TODO:寫log
                //導向錯誤頁
                return RedirectToAction("Error");
            }

            return View(accountingDetails);
        }

        /// <summary>
        /// 錯誤頁面
        /// </summary>
        /// <returns></returns>
        public ActionResult Error() {
            return View();
        }
    }
}