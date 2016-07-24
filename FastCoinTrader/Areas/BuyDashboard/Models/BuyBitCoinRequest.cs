using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastCoinTrader.Areas.BuyDashboard.Models
{
    public class BuyBitCoinRequest
    {
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
        public decimal Total { get; set; }
    }
}