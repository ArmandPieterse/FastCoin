using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FastCoinTrader.Controllers
{
    public class WalletController : Controller
    {
        // GET: Wallet
        public ActionResult MyWallet()
        {
            return View();
        }
    }
}