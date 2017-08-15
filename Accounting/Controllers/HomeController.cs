using System;
using System.Linq;
using System.Web.Mvc;
using Accounting.Models;
using Accounting.Models.BusinessModel;
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
        public ActionResult Index(int page = 1, int count = 10) {
            var accountingDetails = new PagingModel<AccountingDetailViewModel>();

            try {
                var serviceResult = accountingService.GetAllAccountingDetail(page, count);

                accountingDetails.CurrentPage = serviceResult.CurrentPage;
                accountingDetails.LastPage = serviceResult.LastPage;
                accountingDetails.Data = serviceResult.Data
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