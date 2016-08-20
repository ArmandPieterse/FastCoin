using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCoinTrader.EnitityModels
{
    public class Enums 
    {
        public enum SaleStatus
        {
            Pending,
            Successful,            
            Failed,            
        };
        public enum BuyStatus
        {
            Pending,
            Successful,
            Failed,
        };
        public enum EmailType
        {
            System,
            Notification,
            Users,            
        }
    }
}
