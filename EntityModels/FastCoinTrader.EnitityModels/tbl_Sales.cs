namespace FastCoinTrader.EnitityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Sales
    {
        [Key]
        public Guid pk_tbl_Sales { get; set; }

        public Guid fk_tbl_Wallet { get; set; }

        public decimal tbl_BTCTargetAmount { get; set; }

        public decimal tbl_Sales_ZARPrice { get; set; }

        public decimal tbl_Sales_BTCSold { get; set; }

        [Required]
        [StringLength(20)]
        public string tbl_Sales_Status { get; set; }

        public DateTime tbl_Sales_DateCreated { get; set; }

        public DateTime tbl_Sales_DateLastModified { get; set; }

        public virtual tbl_Wallet tbl_Wallet { get; set; }
    }
}
