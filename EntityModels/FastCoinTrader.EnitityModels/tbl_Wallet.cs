namespace FastCoinTrader.EnitityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Wallet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Wallet()
        {
            tbl_Sales = new HashSet<tbl_Sales>();
        }

        [Key]
        public Guid pk_tbl_Wallet { get; set; }

        public Guid fk_tbl_UserAccount { get; set; }

        public decimal tbl_Wallet_ZARBalance { get; set; }

        public decimal tbl_Wallet_BTCBalance { get; set; }

        [Required]
        [StringLength(64)]
        public string tbl_Wallet_BTCAddress { get; set; }

        [Required]
        [StringLength(20)]
        public string tbl_Wallet_BankAccNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string tbl_Wallet_BankName { get; set; }

        [Required]
        [StringLength(100)]
        public string tbl_Wallet_BankBranchName { get; set; }

        [Required]
        [StringLength(26)]
        public string tbl_Wallet_BankBranchNumber { get; set; }

        public DateTime tbl_Wallet_DateCreated { get; set; }

        public DateTime tbl_Wallet_DateLastModified { get; set; }

        public decimal tbl_Wallet_ZARPending { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Sales> tbl_Sales { get; set; }

        public virtual tbl_UserAccount tbl_UserAccount { get; set; }
    }
}
