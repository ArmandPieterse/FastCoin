//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FastCoinTrader.EnitityModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Buys
    {
        public System.Guid pk_tbl_Buys { get; set; }
        public System.Guid fk_tbl_Wallet { get; set; }
        public decimal tbl_Buys_BTCTargetAmount { get; set; }
        public decimal tbl_Buys_ZARPrice { get; set; }
        public decimal tbl_Buys_BTCBought { get; set; }
        public string tbl_Buys_Status { get; set; }
        public System.DateTime tbl_Buys_DateCreated { get; set; }
        public System.DateTime tbl_Buys_DateLastModified { get; set; }
        public decimal tbl_Buys_ZARTotal { get; set; }
    
        public virtual tbl_Wallet tbl_Wallet { get; set; }
    }
}
