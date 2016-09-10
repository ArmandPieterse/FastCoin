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

namespace FastCoinTrader.Areas.SellDashboard.Controllers
{
    public class SellDashboardApiController : ApiController
    {
        public SellDashboardApiController()
        {

        }

        //[System.Web.Http.HttpPost]
        //public CreateSaleResponse SellBitCoin(CreateSaleRequest request)
        //{
        //    return FastCoinTrader.EnitityModels.EntityHelper.SalesEntityHelper.CreateSaleEntry(request.Amount, request.Price, request.Total, request.Amount, EnitityModels.Enums.BuyStatus.Pending.ToString(),
        //        WalletEntityHelper.GetWalletByUserAccount(UserAccountEntityHelper.GetUserAccountKeyByEmail(User.Identity.Name)).pk_tbl_Wallet);
        //    //throw new NotImplementedException();
        //}

        //[System.Web.Http.HttpGet]
        //public GetAvailableBuyOffersResponse GetAvailableBuyOffers()
        //{
        //    return EnitityModels.EntityHelper.BuysEntityHelper.GetPendingBuyOffers();
        //}



    }
}