using Day1Homework.CustomResults;
using Day1Homework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;

namespace Day1Homework.Controllers
{
    public class FeedController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: Orders
        public ActionResult Index()
        {
            var feed = this.GetFeedData();
            return new RssResult(feed);
        }
        private SyndicationFeed GetFeedData()
        {
            var feed = new SyndicationFeed(
                "北風測試資料",
                "訂單RSS！",
                new Uri(Url.Action("Rss", "Feed", null, "http")));

            var items = new List<SyndicationItem>();

            var orders = db.Orders
                .Where(x => x.OrderDate <= DateTime.Now)
                .OrderByDescending(x => x.OrderDate);

            foreach (var order in orders)
            {
                var item = new SyndicationItem(
                    order.ShipName,
                    order.ShipAddress,
                    new Uri(Url.Action("Detail", "Order", new { Controller = "Feed", id = order.OrderID }, "http")),                    
                    "ID",
                    DateTime.Now);

                items.Add(item);
            }

            feed.Items = items;
            return feed;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}