using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCoinTrader.EnitityModels.API.Models
{
    public class GetAvailableBuyOffersResponse
    {
        public List<BuyOffer> Data { get; set; }
        public bool Success { get; set; }
        public List<string> Error { get; set; }
        public List<string> Warnings { get; set; }

    }

    public class BuyOffer
    {
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public decimal BTCAmount { get; set; }        
    }
}
