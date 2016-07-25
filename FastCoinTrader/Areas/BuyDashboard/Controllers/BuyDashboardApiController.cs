using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using FastCoinTrader.Areas.BuyDashboard.Models;
using FastCoinTrader.EnitityModels;

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
            FastCoinTrader.EnitityModels.EntityHelper.BuysEntityHelper.CreateBuyEntry(request.Amount, request.Price, request.Total, request.Amount, EnitityModels.Enums.BuyStatus.Pending.ToString(), Guid.Parse("E6C95FF2-C6FB-492D-BECA-4479BDCFD2E9"));
            throw new NotImplementedException();
        }

        [System.Web.Http.HttpGet]
        public ActionResult GetAvailableOffers()
        {
           
            throw new NotImplementedException();
        }

    }
}
