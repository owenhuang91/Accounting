using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accounting.Controllers
{
    public class ValidController : Controller
    {
        public ActionResult LessThanOrEqualToToday(DateTime date) {
            bool isValidate = date < DateTime.Now.Date.AddDays(1);
            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GreaterThanZero(decimal price) {
           bool isValidate = price > 0m;
            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }
    }
}