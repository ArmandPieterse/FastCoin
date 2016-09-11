using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastCoinTrader.EnitityModels.EntityHelper;
using FastCoinTrader.EnitityModels;

namespace FastCoinTrader.Controllers
{
    public class BuysController : Controller
    {
        // GET: Buys
        public ActionResult Index()
        {
            if (!String.IsNullOrEmpty(User.Identity.Name))
            {
                return View();
            }
            return RedirectToAction("../Account/Login");
        }

        [HttpPost]
        public ActionResult CreateBuy(string amount, string price, string total)
        {
            Guid fkWallet = WalletEntityHelper.GetWalletByUserAccount(UserAccountEntityHelper.GetUserAccountKeyByEmail(User.Identity.Name)).pk_tbl_Wallet;
            var msg = BuysEntityHelper.CreateBuyEntry(decimal.Parse(amount), decimal.Parse(price), decimal.Parse(total), 0, Enums.SaleStatus.Pending.ToString(), fkWallet);
            return Json(new { message = msg });
        }

        public ActionResult _SaleOffers()
        {
            return PartialView();
        }
    }
}