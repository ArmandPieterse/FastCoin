using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using FastCoinTrader.Areas.BuyDashboard.Models;
using FastCoinTrader.EnitityModels;
using FastCoinTrader.EnitityModels.API.Models;
using FastCoinTrader.EnitityModels.EntityHelper;

namespace FastCoinTrader.Areas.BuyDashboard.Controllers
{
    public class BuyDashboardApiController : ApiController
    {
        public BuyDashboardApiController()
        {
            
        }

        //[System.Web.Http.HttpPost]
        //public CreateBuyResponse BuyBitCoin(CreateBuyRequest request)
        //{            
        //    return FastCoinTrader.EnitityModels.EntityHelper.BuysEntityHelper.CreateBuyEntry(request.Amount, request.Price, request.Total, request.Amount, EnitityModels.Enums.BuyStatus.Pending.ToString(),
        //        WalletEntityHelper.GetWalletByUserAccount(UserAccountEntityHelper.GetUserAccountKeyByEmail(User.Identity.Name)).pk_tbl_Wallet);
        //    //throw new NotImplementedException();

        //}

        //[System.Web.Http.HttpGet]
        //public GetAvailableSaleOffersResponse GetAvailableSaleOffers()
        //{
        //    return FastCoinTrader.EnitityModels.EntityHelper.SalesEntityHelper.GetPendingSaleOffers();
        //}



    }
}
