using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCoinTrader.EnitityModels.EmailEntityHelper
{
    class WalletEntityHelper
    {
        #region CreateWallet
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

    }
}
