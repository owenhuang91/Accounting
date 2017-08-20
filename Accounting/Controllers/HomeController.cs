using System;
using System.Linq;
using System.Web.Mvc;
using Accounting.Models;
using Accounting.Models.ViewModels;
using Accounting.Repository;
using PagedList;

namespace Accounting.Controllers {

    public class HomeController : Controller {
        private AccountingService accountingService;

        public HomeController() {
            var unitOfWork = new UnitOfWork();
            accountingService = new AccountingService(unitOfWork);
        }

        /// <summary>
        /// 記帳功能頁面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int page = 1, int count = 10) {

            var serviceResult = Enumerable.Empty<AccountingDetailViewModel>();

            try {
                serviceResult = accountingService.GetAllAccountingDetail().ToPagedList(page, count);

            } catch (Exception) {
                //TODO:寫log
                //導向錯誤頁
                return RedirectToAction("Error");
            }

            return View(serviceResult);
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