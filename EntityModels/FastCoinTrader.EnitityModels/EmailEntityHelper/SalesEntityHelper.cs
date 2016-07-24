﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCoinTrader.EnitityModels.EmailEntityHelper
{
    public class SalesEntityHelper
    {
        #region Create Sale
        public void CreateSaleEntry(decimal BTCTargetAmount,decimal ZARPrice, decimal ZARTotal, decimal BTCSoldAmount,string status,Guid fkWallet)
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {

                DateTime dateTimeNow = DateTime.Now;
                context.tbl_Sales.Add(
                    new tbl_Sales {
                            fk_tbl_Wallet = fkWallet,
                            tbl_BTCTargetAmount = BTCTargetAmount,
                            tbl_Sales_BTCSold = BTCSoldAmount,
                            tbl_Sales_Status = status,
                            tbl_Sales_ZARPrice = ZARPrice,
                            tbl_Sales_DateCreated = dateTimeNow,
                            tbl_Sales_DateLastModified = dateTimeNow,
                            tbl_Sales_ZARTotal = ZARTotal
                        }
                    );
                context.SaveChanges();
            }
        }
        #endregion

        #region Modify Sale
        public void UpdateSaleEntry(tbl_Sales sale)
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                DateTime dateTimeNow = DateTime.Now;                
                context.tbl_Sales.Single(x => x.pk_tbl_Sales == sale.pk_tbl_Sales).fk_tbl_Wallet = sale.fk_tbl_Wallet;
                context.tbl_Sales.Single(x => x.pk_tbl_Sales == sale.pk_tbl_Sales).tbl_BTCTargetAmount = sale.tbl_BTCTargetAmount;
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

        public List<tbl_Sales> GetSalesByStatus(Guid fkWallet)
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