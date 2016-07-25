using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using FastCoinTrader.Areas.BuyDashboard.Models;
using FastCoinTrader.EnitityModels;
using FastCoinTrader.EnitityModels.API.Models;

namespace FastCoinTrader.Areas.BuyDashboard.Controllers
{
    public class BuyDashboardApiController : ApiController
    {
        public BuyDashboardApiController()
        {
            
        }

        [System.Web.Http.HttpPost]
        public CreateBuyResponse BuyBitCoin(CreateBuyRequest request)
        {
            return FastCoinTrader.EnitityModels.EntityHelper.BuysEntityHelper.CreateBuyEntry(request.Amount, request.Price, request.Total, request.Amount, EnitityModels.Enums.BuyStatus.Pending.ToString(), Guid.Parse("D258CC9B-9BC8-4E3A-B980-1FDA7DDD577E"));
            //throw new NotImplementedException();

        }

    

    }
}
