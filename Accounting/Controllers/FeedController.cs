using Accounting.CustomerResults;
using Accounting.Models;
using Accounting.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web.Mvc;

namespace Accounting.Controllers
{
    public class FeedController : Controller
    {
        private AccountingService accountingService;

        public FeedController()
        {
            var unitOfWork = new UnitOfWork();
            accountingService = new AccountingService(unitOfWork);
        }

        // GET: Orders
        public ActionResult Index()
        {
            var feed = this.GetFeedData();
            return new RssResult(feed);
        }

        private SyndicationFeed GetFeedData()
        {
            var feed = new SyndicationFeed(
                "記帳系統測試資料",
                "訂單RSS！",
                new Uri(Url.Action("Rss", "Feed", null, "http")));

            var items = new List<SyndicationItem>();

            var accountingDetails = accountingService.GetAllAccountingDetail()
                .Where(x => x.Date <= DateTime.Now)
                .OrderByDescending(x => x.Date);

            foreach (var accountingDetail in accountingDetails)
            {
                var item = new SyndicationItem(
                    accountingDetail.Category.ToString(),
                    $"{accountingDetail.Price}-{accountingDetail.Description}",
                    new Uri(Url.Action("Detail", "Home", new { id = accountingDetail.id }, "http")),
                    "ID",
                    DateTime.Now);

                items.Add(item);
            }

            feed.Items = items;
            return feed;
        }
    }
}