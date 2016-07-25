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

        public class randomresponse
        {
            public bool success;
        }

        [System.Web.Http.HttpPost]
        public randomresponse BuyBitCoin(CreateBuyRequest request)
        {
            EnitityModels.EntityHelper.BuysEntityHelper.CreateBuyEntry(request.Amount, request.Price, request.Total, request.Amount, EnitityModels.Enums.BuyStatus.Pending.ToString(), Guid.Parse("D258CC9B-9BC8-4E3A-B980-1FDA7DDD577E"));

            return new randomresponse { success = true };
            //throw new NotImplementedException();
        }

        [System.Web.Http.HttpGet]
        public List<EnitityModels.tbl_Buys> GetAvailableOffers()
        {
            return EnitityModels.EntityHelper.BuysEntityHelper.GetAllBuysList();
            //throw new NotImplementedException();
        }

    }
}
