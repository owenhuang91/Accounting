using System;
using System.Collections;
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
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AccountingDetailViewModel newModel) {


            if (ModelState.IsValid) {
                try {
                    accountingService.CreateAccountingDetail(newModel);
                    accountingService.Save();
                } catch (Exception) {
                    //TODO:寫log
                    //導向錯誤頁
                    return RedirectToAction("Error");
                }
            }

            return View("Index", newModel);
        }

        [HttpPost]
        public ActionResult CreateForAjax(AccountingDetailViewModel newModel) {

            if (ModelState.IsValid) {
                try {
                    accountingService.CreateAccountingDetail(newModel);
                    accountingService.Save();
                    return AccountingDetail();
                } catch (Exception) {
                    //TODO:寫log
                    return Content("新增失敗!");
                }
            } else {
                return Content("資料驗證失敗!");
            }
        }

        [ChildActionOnly]
        public ActionResult AccountingDetail(int page = 1, int count = 10) {

            var serviceResult = Enumerable.Empty<AccountingDetailViewModel>();

            try {
                serviceResult = accountingService.GetAllAccountingDetail().ToPagedList(page, count);

            } catch (Exception) {
                //TODO:寫log
                //導向錯誤頁
                return RedirectToAction("Error");
            }

            return PartialView("_AccountingDetail", serviceResult);
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