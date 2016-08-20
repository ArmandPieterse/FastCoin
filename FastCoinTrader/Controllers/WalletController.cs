using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastCoinTrader.EnitityModels.EntityHelper;
using FastCoinTrader.EnitityModels;

namespace FastCoinTrader.Controllers
{
    public class WalletController : Controller
    {
        // GET: Wallet
        public ActionResult MyWallet()
        {
            if (!String.IsNullOrEmpty(User.Identity.Name))
            {
                tbl_Wallet wallet = WalletEntityHelper.GetWalletByUserAccount(UserAccountEntityHelper.GetUserAccountKeyByEmail(User.Identity.Name));
                return View(wallet);
            }
            return View();
        }
    }
}