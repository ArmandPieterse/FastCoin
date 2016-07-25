using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCoinTrader.EnitityModels.API.Models
{
    public class CreateBuyResponse
    {
        public bool Success { get; set; }
        public List<string> Error { get; set; }
        public List<string> Warnings { get; set; }
        public int Data { get; set; }
    }
}
