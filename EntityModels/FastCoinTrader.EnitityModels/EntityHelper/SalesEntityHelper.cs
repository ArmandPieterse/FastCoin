using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastCoinTrader.EnitityModels.API.Models;

namespace FastCoinTrader.EnitityModels.EntityHelper
{
    public class SalesEntityHelper
    {
        #region Create Sale
        public static string CreateSaleEntry(decimal BTCTargetAmount,decimal ZARPrice, decimal ZARTotal, decimal BTCSoldAmount,string status,Guid fkWallet)
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                tbl_Wallet wallet = context.tbl_Wallet.Single(x => x.pk_tbl_Wallet == fkWallet);
                if (BTCTargetAmount > wallet.tbl_Wallet_BTCBalance)
                {
                    return String.Format("Error: You don't have {0} bitcoins in your wallet!",BTCTargetAmount);
                }
                else
                {
                    wallet.tbl_Wallet_BTCBalance -= BTCTargetAmount;
                    wallet.tbl_Wallet_ZARPending += ZARTotal;                  
                    DateTime dateTimeNow = DateTime.Now;
                    Guid pkKey = Guid.NewGuid();
                    context.tbl_Sales.Add(
                        new tbl_Sales
                        {
                            pk_tbl_Sales = pkKey,
                            fk_tbl_Wallet = fkWallet,
                            tbl_Sales_BTCTargetAmount = BTCTargetAmount,
                            tbl_Sales_BTCSold = BTCSoldAmount,
                            tbl_Sales_Status = status,
                            tbl_Sales_ZARPrice = ZARPrice,
                            tbl_Sales_DateCreated = dateTimeNow,
                            tbl_Sales_DateLastModified = dateTimeNow,
                            tbl_Sales_ZARTotal = ZARTotal
                        }
                        );
                    context.SaveChanges();

                    var buyOffers = (from buys in context.tbl_Buys
                                     where buys.tbl_Buys_ZARPrice == ZARPrice
                                     orderby buys.tbl_Buys_BTCTargetAmount descending
                                     select buys).ToList();

                    decimal toSell = 0, totalSold = 0;

                    tbl_Sales currentSale = context.tbl_Sales.Single(x => x.pk_tbl_Sales == pkKey);
                    if (buyOffers.Count > 0)
                    {
                        for (int i = 0; i < buyOffers.Count; i++)
                        {
                            if (BTCTargetAmount == 0) break;

                            //Get amount to buy after transaction and amount bought within this transaction
                            toSell = buyOffers[i].tbl_Buys_BTCTargetAmount >= BTCTargetAmount ? BTCTargetAmount : buyOffers[i].tbl_Buys_BTCTargetAmount;
                            BTCTargetAmount -= toSell;

                            //Update buy offer
                            buyOffers[i].tbl_Buys_BTCTargetAmount -= toSell;
                            if (buyOffers[i].tbl_Buys_BTCTargetAmount == 0) { buyOffers[i].tbl_Buys_Status = Enums.BuyStatus.Successful.ToString(); };
                            buyOffers[i].tbl_Buys_BTCBought += toSell;
                            Guid fkBuyerWallet = buyOffers[i].fk_tbl_Wallet;
                            tbl_Wallet buyerWallet = context.tbl_Wallet.Single(x => x.pk_tbl_Wallet == fkBuyerWallet);
                            buyerWallet.tbl_Wallet_ZARBalance -= (toSell * ZARPrice);
                            context.Entry(buyOffers[i]).State = System.Data.Entity.EntityState.Modified;                           
                            
                            context.SaveChanges();

                            //Update current sales entry                            
                            currentSale.tbl_Sales_BTCSold += toSell;
                            currentSale.tbl_Sales_BTCTargetAmount -= toSell;
                            if (currentSale.tbl_Sales_BTCTargetAmount == 0) { currentSale.tbl_Sales_Status = Enums.SaleStatus.Successful.ToString(); };
                            currentSale.tbl_Sales_DateLastModified = DateTime.Now;
                            context.Entry(currentSale).State = System.Data.Entity.EntityState.Modified;
                            context.SaveChanges();

                            //Update sellers wallet
                            {
                                wallet.tbl_Wallet_ZARBalance += (toSell * ZARPrice);
                                wallet.tbl_Wallet_ZARPending -= (toSell * ZARPrice);
                            }
                        }
                    }
                }
                
            }
            return String.Format("The sale offer has been placed successfully.");

           
        }
        #endregion

        #region Modify Sale
        public void UpdateSaleEntry(tbl_Sales sale)
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                DateTime dateTimeNow = DateTime.Now;                
                context.tbl_Sales.Single(x => x.pk_tbl_Sales == sale.pk_tbl_Sales).fk_tbl_Wallet = sale.fk_tbl_Wallet;
                context.tbl_Sales.Single(x => x.pk_tbl_Sales == sale.pk_tbl_Sales).tbl_Sales_BTCTargetAmount = sale.tbl_Sales_BTCTargetAmount;
                context.tbl_Sales.Single(x => x.pk_tbl_Sales == sale.pk_tbl_Sales).tbl_Sales_BTCSold = sale.tbl_Sales_BTCSold;
                context.tbl_Sales.Single(x => x.pk_tbl_Sales == sale.pk_tbl_Sales).tbl_Sales_Status = sale.tbl_Sales_Status;
                context.tbl_Sales.Single(x => x.pk_tbl_Sales == sale.pk_tbl_Sales).tbl_Sales_ZARPrice = sale.tbl_Sales_ZARPrice;                
                context.tbl_Sales.Single(x => x.pk_tbl_Sales == sale.pk_tbl_Sales).tbl_Sales_DateLastModified = dateTimeNow;
                context.tbl_Sales.Single(x => x.pk_tbl_Sales == sale.pk_tbl_Sales).tbl_Sales_ZARTotal = sale.tbl_Sales_ZARTotal;
                context.Entry(context.tbl_Sales.Single(x => x.pk_tbl_Sales == sale.pk_tbl_Sales)).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        #endregion

        #region Get Sales
        public List<tbl_Sales> GetAllSalesList()
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                var salesList = (from sales in context.tbl_Sales
                                 select sales).ToList();
                return salesList;
            }
        }
        public IQueryable<tbl_Sales> GetAllSalesQueryable()
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                var salesList = (from sales in context.tbl_Sales
                                 orderby sales.tbl_Sales_DateCreated
                                 select sales).AsQueryable();
                return salesList;
            }
        }

        public List<tbl_Sales> GetSalesByWalletId(Guid fkWallet)
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                var salesList = (from sales in context.tbl_Sales
                                 where sales.fk_tbl_Wallet == fkWallet
                                 orderby sales.tbl_Sales_DateCreated
                                 select sales).ToList();
                return salesList;
            }
        }

        public static List<tbl_Sales> GetSalesByStatus(string status,int? amount)
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                var salesList = (from sales in context.tbl_Sales
                                 where sales.tbl_Sales_Status == status
                                 orderby sales.tbl_Sales_ZARPrice, sales.tbl_Sales_DateCreated
                                 select sales).Take(amount.HasValue ? amount.Value : 1000).ToList();
                return salesList;
            }
        }


        public static GetAvailableSaleOffersResponse GetPendingSaleOffers()
        {

            GetAvailableSaleOffersResponse offersResponse = new GetAvailableSaleOffersResponse();
            offersResponse.Data = new List<SaleOffer>();
            try
            {
                List<tbl_Sales> availableSaleOffers = GetSalesByStatus(Enums.SaleStatus.Pending.ToString(),10);

                foreach (tbl_Sales sale in availableSaleOffers)
                {
                    SaleOffer offer = new SaleOffer
                    {
                        BTCAmount = (sale.tbl_Sales_BTCTargetAmount - sale.tbl_Sales_BTCSold), // this is because you can sell only part of what you have offered.
                        Price = sale.tbl_Sales_ZARPrice,
                        Total = sale.tbl_Sales_ZARTotal
                    };
                    offersResponse.Data.Add(offer);
                }

                offersResponse.Success = true;
                return offersResponse;
            }
            catch(Exception ex)
            {
                offersResponse.Error.Add(ex.Message);
                offersResponse.Success = false;                
                return offersResponse;
            }       

            

        }
        #endregion

        #region Delete Sale
        public bool DeleteSale(Guid PrimaryKey)
        {
            try
            {
                using (FastCoinTraderContext context = new FastCoinTraderContext())
                {
                    var saleToDelete = (from sale in context.tbl_Sales
                                         where sale.pk_tbl_Sales == PrimaryKey
                                         select sale).FirstOrDefault();

                    if (saleToDelete != null)
                    {
                        context.tbl_Sales.Remove(saleToDelete);
                        context.SaveChanges();
                        return true;
                    }
                    //if there is no matching sale to delete.
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
