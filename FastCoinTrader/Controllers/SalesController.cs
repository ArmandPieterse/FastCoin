using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FastCoinTrader.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            if (!String.IsNullOrEmpty(User.Identity.Name))
            {
                return View();
            }
            return RedirectToAction("../Account/Login");
        }

        public ActionResult _BuyOffers()
        {
            return PartialView();
        }
    }
}