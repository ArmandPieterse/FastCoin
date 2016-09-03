using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastCoinTrader.EnitityModels.API.Models;

namespace FastCoinTrader.EnitityModels.EntityHelper
{
    public class BuysEntityHelper
    {
        #region Create Buy Entry
        public static CreateBuyResponse CreateBuyEntry(decimal BTCTargetAmount, decimal ZARPrice, decimal ZARTotal, decimal BTCBoughtAmount, string status, Guid fkWallet)
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                var saleOffers = (from sales in context.tbl_Sales
                                  where sales.tbl_Sales_ZARPrice == ZARPrice
                                  orderby sales.tbl_Sales_BTCTargetAmount descending
                                  select sales).ToList();
               
                decimal toBuy = 0,totalBought = 0;

              
                DateTime dateTimeNow = DateTime.Now;
                Guid pkKey = Guid.NewGuid();
                context.tbl_Buys.Add(
                    new tbl_Buys
                    {
                        pk_tbl_Buys = pkKey,
                        fk_tbl_Wallet = fkWallet,
                        tbl_Buys_BTCTargetAmount = BTCTargetAmount,
                        tbl_Buys_BTCBought = BTCBoughtAmount,
                        tbl_Buys_Status = status,
                        tbl_Buys_ZARPrice = ZARPrice,
                        tbl_Buys_DateCreated = dateTimeNow,
                        tbl_Buys_DateLastModified = dateTimeNow,
                        tbl_Buys_ZARTotal = ZARTotal
                    });
                context.SaveChanges();
                tbl_Buys currentBuy = context.tbl_Buys.Single(x => x.pk_tbl_Buys == pkKey);
                if (saleOffers.Count > 0)
                {
                    for (int i = 0; i < saleOffers.Count; i++)
                    {
                        if (BTCTargetAmount == 0) break;

                        //Get amount to buy after transaction and amount bought within this transaction
                        toBuy = saleOffers[i].tbl_Sales_BTCTargetAmount >= BTCTargetAmount ? BTCTargetAmount : BTCTargetAmount - saleOffers[i].tbl_Sales_BTCTargetAmount;
                        BTCTargetAmount -= toBuy;

                        //Update sales offer
                        saleOffers[i].tbl_Sales_BTCTargetAmount = saleOffers[i].tbl_Sales_BTCTargetAmount - toBuy;
                        saleOffers[i].tbl_Sales_BTCSold = toBuy;
                        context.Entry(saleOffers[i]).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();

                        //Update current buy entry
                        BTCTargetAmount = BTCTargetAmount - saleOffers[i].tbl_Sales_BTCTargetAmount >= 0 ? BTCTargetAmount - saleOffers[i].tbl_Sales_BTCTargetAmount : 0;
                        currentBuy.tbl_Buys_BTCBought += toBuy;
                        currentBuy.tbl_Buys_BTCTargetAmount -= toBuy;
                        currentBuy.tbl_Buys_DateLastModified = DateTime.Now;
                        context.Entry(currentBuy).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                }

                //TODO: call buy btc api through blockchain and update tbl_buys accordingly.

                return new CreateBuyResponse { Data = 0, Success = true, Error = new List<string>(),Warnings = new List<string>() };
            }
        }
        #endregion

        #region Modify Buy      
        public void UpdateBuyEntry(tbl_Buys Buy)
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                DateTime dateTimeNow = DateTime.Now;
                context.tbl_Buys.Single(x => x.pk_tbl_Buys == Buy.pk_tbl_Buys).fk_tbl_Wallet = Buy.fk_tbl_Wallet;
                context.tbl_Buys.Single(x => x.pk_tbl_Buys == Buy.pk_tbl_Buys).tbl_Buys_BTCTargetAmount = Buy.tbl_Buys_BTCTargetAmount;
                context.tbl_Buys.Single(x => x.pk_tbl_Buys == Buy.pk_tbl_Buys).tbl_Buys_BTCBought = Buy.tbl_Buys_BTCBought;
                context.tbl_Buys.Single(x => x.pk_tbl_Buys == Buy.pk_tbl_Buys).tbl_Buys_Status = Buy.tbl_Buys_Status;
                context.tbl_Buys.Single(x => x.pk_tbl_Buys == Buy.pk_tbl_Buys).tbl_Buys_ZARPrice = Buy.tbl_Buys_ZARPrice;
                context.tbl_Buys.Single(x => x.pk_tbl_Buys == Buy.pk_tbl_Buys).tbl_Buys_DateLastModified = dateTimeNow;
                context.tbl_Buys.Single(x => x.pk_tbl_Buys == Buy.pk_tbl_Buys).tbl_Buys_ZARTotal = Buy.tbl_Buys_ZARTotal;
                context.Entry(context.tbl_Buys.Single(x => x.pk_tbl_Buys == Buy.pk_tbl_Buys)).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        #endregion

        #region Get Buys
        public static List<tbl_Buys> GetAllBuysList()
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                var buysList = (from buy in context.tbl_Buys
                                orderby buy.tbl_Buys_DateLastModified
                                select buy).ToList();
                                
                return buysList;
            }
        }

        public IQueryable<tbl_Buys> GetAllBuysQueryable()
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                var buysList = (from buy in context.tbl_Buys
                                orderby buy.tbl_Buys_DateLastModified
                                select buy).AsQueryable();

                return buysList;
            }
        }

        public List<tbl_Buys> GetBuysListByWallet(Guid fkWallet)
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                var buysList = (from buy in context.tbl_Buys
                                where buy.fk_tbl_Wallet == fkWallet
                                orderby buy.tbl_Buys_DateLastModified
                                select buy).ToList();

                return buysList;
            }
        }

        public static List<tbl_Buys> GetBuysByStatus(string status)
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                var buysList = (from buys in context.tbl_Buys
                                 where buys.tbl_Buys_Status == status
                                 orderby buys.tbl_Buys_ZARPrice, buys.tbl_Buys_DateLastModified
                                 select buys).ToList();
                return buysList;
            }
        }

        public static GetAvailableBuyOffersResponse GetPendingBuyOffers()
        {
            GetAvailableBuyOffersResponse offersResponse = new GetAvailableBuyOffersResponse();
            offersResponse.Data = new List<BuyOffer>();
            try
            {
                List<tbl_Buys> availablebuysOffers = GetBuysByStatus(Enums.SaleStatus.Pending.ToString());

                foreach (tbl_Buys buy in availablebuysOffers)
                {
                    BuyOffer offer = new BuyOffer
                    {
                        BTCAmount = (buy.tbl_Buys_BTCTargetAmount - buy.tbl_Buys_BTCBought), // this is because you can sell only part of what you have offered.
                        Price = buy.tbl_Buys_ZARPrice,
                        Total = buy.tbl_Buys_ZARTotal
                    };
                    offersResponse.Data.Add(offer);
                }

                offersResponse.Success = true;
                return offersResponse;
            }
            catch (Exception ex)
            {
                offersResponse.Error.Add(ex.Message);
                offersResponse.Success = false;
                return offersResponse;
            }
        }
        #endregion

        #region Delete Buy        
        public bool DeleteBuy(Guid PrimaryKey)
        {
            try
            {
                using (FastCoinTraderContext context = new FastCoinTraderContext())
                {
                    var buyToDelete = (from buy in context.tbl_Buys
                                          where buy.pk_tbl_Buys == PrimaryKey
                                          select buy).FirstOrDefault();

                    if (buyToDelete != null)
                    {
                        context.tbl_Buys.Remove(buyToDelete);
                        context.SaveChanges();
                        return true;
                    }
                    //if there is no matching wallet to delete.
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }
        #endregion

    }
}
