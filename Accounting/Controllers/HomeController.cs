using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Accounting.Models;
using Accounting.Models.ViewModels;

namespace Accounting.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 記帳類別
        /// </summary>
        private Dictionary<string, string> AccountingType = new Dictionary<string, string>()
        {
            ["expenses"] = "支出",
            ["income"] = "收入",
        };

        /// <summary>
        /// 記帳功能頁面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var accountingDetails = new List<AccountingDetailViewModel>();

            try
            {
                accountingDetails = GetAccountingDetail().Select((m, i) => new AccountingDetailViewModel()
                {
                    No = i + 1,
                    Type = AccountingType[m.Type],
                    Date = m.Date.ToString("yyyy-MM-dd"),
                    Price = m.Price.ToString("#,0"),
                }).ToList();
            }
            catch (Exception)
            {
                //導向錯誤頁
                RedirectToAction("Error");
            }

            return View(accountingDetails);
        }

        /// <summary>
        /// 錯誤頁面
        /// </summary>
        /// <returns></returns>
        public ActionResult Error()
        {
            return View();
        }

        /// <summary>
        /// 由service取得記帳資料
        /// </summary>
        /// <returns></returns>
        private List<AccountingDetailModel> GetAccountingDetail()
        {

            return new List<AccountingDetailModel>() {
                new AccountingDetailModel(){ Type="expenses",Date=new DateTime(2016,01,01),Price=1000 },
                new AccountingDetailModel(){ Type="income",Date=new DateTime(2016,01,02),Price=2000 },
                new AccountingDetailModel(){ Type="expenses",Date=new DateTime(2016,01,03),Price=300 },
                new AccountingDetailModel(){ Type="income",Date=new DateTime(2016,01,04),Price=500 },
                new AccountingDetailModel(){ Type="expenses",Date=new DateTime(2016,01,05),Price=700 },
                new AccountingDetailModel(){ Type="income",Date=new DateTime(2016,01,06),Price=800 },
                new AccountingDetailModel(){ Type="expenses",Date=new DateTime(2016,01,07),Price=1080000 },
                new AccountingDetailModel(){ Type="income",Date=new DateTime(2016,01,08),Price=600 },
                new AccountingDetailModel(){ Type="expenses",Date=new DateTime(2016,01,09),Price=5555 },
            };
        }
    }
}