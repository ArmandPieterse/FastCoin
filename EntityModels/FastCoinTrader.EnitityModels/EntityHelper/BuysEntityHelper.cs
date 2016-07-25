using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCoinTrader.EnitityModels.EntityHelper
{
    public class BuysEntityHelper
    {
        #region Create Buy Entry
        public static void CreateBuyEntry(decimal BTCTargetAmount, decimal ZARPrice, decimal ZARTotal, decimal BTCBoughtAmount, string status, Guid fkWallet)
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                DateTime dateTimeNow = DateTime.Now;
                context.tbl_Buys.Add(
                    new tbl_Buys
                    {
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
        public List<tbl_Buys> GetAllBuysList()
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
