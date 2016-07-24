using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using FastCoinTrader.Areas.BuyDashboard.Models;

namespace FastCoinTrader.Areas.BuyDashboard.Controllers
{
    public class BuyDashboardApiController : ApiController
    {
        public BuyDashboardApiController()
        {
            
        }

        [System.Web.Http.HttpPost]
        public ActionResult BuyBitCoin(BuyBitCoinRequest request)
        {

            throw new NotImplementedException();
        }

        [System.Web.Http.HttpGet]
        public ActionResult GetAvailableOffers()
        {
            throw new NotImplementedException();
        }

    }
}
