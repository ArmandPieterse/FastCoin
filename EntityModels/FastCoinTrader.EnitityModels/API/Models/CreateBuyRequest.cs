using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCoinTrader.EnitityModels.API.Models
{
    
    public class CreateBuyRequest
    {
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
        public decimal Total { get; set; }
    }

}
