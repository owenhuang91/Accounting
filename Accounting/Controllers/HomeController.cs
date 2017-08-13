using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Accounting.Models;
using Accounting.Models.ViewModels;
using PagedList;

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
        public ActionResult Index(int page = 1, int count = 10) {

            IPagedList<AccountingDetailViewModel> accountingDetails;

            try {
                //TODO：需再調整寫法，不應讀回全部資料
                accountingDetails = accountingService.GetAllAccountingDetail()
                    .OrderByDescending(m => m.Date)
                    .Select((m, i) => new AccountingDetailViewModel() {
                        No = i + 1,
                        Type = m.Type,
                        Date = m.Date.ToString("yyyy-MM-dd"),
                        Price = m.Price.ToString("#,0"),
                    }).ToPagedList(page, count);

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