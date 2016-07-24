using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCoinTrader.EnitityModels.EmailEntityHelper
{
    class WalletEntityHelper
    {
        #region Create Wallet
        public void CreateWalletEntry(Guid fkUserAccount,decimal ZARBalance,decimal ZARPending,decimal BTCBalance,string BTCAddress,
            string bankAccountNumber,string bankName,string branchName,string branchNumber)
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                DateTime dateTimeNow = DateTime.Now;
                context.tbl_Wallet.Add(
                    new tbl_Wallet
                    {
                        fk_tbl_UserAccount = fkUserAccount,
                        tbl_Wallet_ZARBalance = ZARBalance,
                        tbl_Wallet_ZARPending = ZARPending,
                        tbl_Wallet_BTCBalance = BTCBalance,
                        tbl_Wallet_BankAccNumber = bankAccountNumber,
                        tbl_Wallet_BankBranchName = branchName,
                        tbl_Wallet_BTCAddress = BTCAddress,
                        tbl_Wallet_BankBranchNumber = branchNumber,
                        tbl_Wallet_BankName = bankName,
                        tbl_Wallet_DateCreated = dateTimeNow,
                        tbl_Wallet_DateLastModified = dateTimeNow
                    }
                );
                context.SaveChanges();
            }
        }
        #endregion

        #region Modify Wallet
        public void UpdateEmailEntry(tbl_Wallet Wallet)
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                DateTime dateTimeNow = DateTime.Now;
                context.tbl_Wallet.Single(x => x.pk_tbl_Wallet == Wallet.pk_tbl_Wallet).fk_tbl_UserAccount = Wallet.fk_tbl_UserAccount;
                context.tbl_Wallet.Single(x => x.pk_tbl_Wallet == Wallet.pk_tbl_Wallet).tbl_Wallet_BankAccNumber = Wallet.tbl_Wallet_BankAccNumber;
                context.tbl_Wallet.Single(x => x.pk_tbl_Wallet == Wallet.pk_tbl_Wallet).tbl_Wallet_DateLastModified = dateTimeNow;
                context.tbl_Wallet.Single(x => x.pk_tbl_Wallet == Wallet.pk_tbl_Wallet).tbl_Wallet_BankBranchName = Wallet.tbl_Wallet_BankBranchName;
                context.tbl_Wallet.Single(x => x.pk_tbl_Wallet == Wallet.pk_tbl_Wallet).tbl_Wallet_BankBranchNumber = Wallet.tbl_Wallet_BankBranchNumber;
                context.tbl_Wallet.Single(x => x.pk_tbl_Wallet == Wallet.pk_tbl_Wallet).tbl_Wallet_BankName = Wallet.tbl_Wallet_BankName;
                context.tbl_Wallet.Single(x => x.pk_tbl_Wallet == Wallet.pk_tbl_Wallet).tbl_Wallet_BTCAddress = Wallet.tbl_Wallet_BTCAddress;
                context.tbl_Wallet.Single(x => x.pk_tbl_Wallet == Wallet.pk_tbl_Wallet).tbl_Wallet_BTCBalance = Wallet.tbl_Wallet_BTCBalance;
                context.tbl_Wallet.Single(x => x.pk_tbl_Wallet == Wallet.pk_tbl_Wallet).tbl_Wallet_ZARBalance = Wallet.tbl_Wallet_ZARBalance;
                context.tbl_Wallet.Single(x => x.pk_tbl_Wallet == Wallet.pk_tbl_Wallet).tbl_Wallet_ZARPending = Wallet.tbl_Wallet_ZARPending;
                context.Entry(context.tbl_Wallet.Single(x => x.pk_tbl_Wallet == Wallet.pk_tbl_Wallet)).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        #endregion

        #region Get Wallet
        public List<tbl_Wallet> GetAllWalletList()
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                var walletList = (from wallet in context.tbl_Wallet
                                  orderby wallet.tbl_Wallet_DateLastModified
                                  select wallet).ToList();

                return walletList; 
            }
        }

        public List<tbl_Wallet> GetWalletByUserAccount(Guid fk_UserAccount)
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                var walletList = (from wallet in context.tbl_Wallet
                                  where wallet.fk_tbl_UserAccount == fk_UserAccount
                                  orderby wallet.tbl_Wallet_DateLastModified
                                  select wallet).ToList();

                return walletList;
            }
        }

        public List<tbl_Wallet> GetAllWalletList()
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                var walletList = (from wallet in context.tbl_Wallet
                                  orderby wallet.tbl_Wallet_DateLastModified
                                  select wallet).ToList();

                return walletList;
            }
        }
        #endregion

        #region Delete Wallet        
        public bool DeleteWallet(Guid PrimaryKey)
        {
            try
            {
                using (FastCoinTraderContext context = new FastCoinTraderContext())
                {
                    var walletToDelete = (from wallet in context.tbl_Wallet
                                         where wallet.pk_tbl_Wallet == PrimaryKey
                                         select wallet).FirstOrDefault();

                    if (walletToDelete != null)
                    {
                        context.tbl_Wallet.Remove(walletToDelete);
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
