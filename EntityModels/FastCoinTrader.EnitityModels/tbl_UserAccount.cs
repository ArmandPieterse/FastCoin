namespace FastCoinTrader.EnitityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_UserAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_UserAccount()
        {
            tbl_Wallet = new HashSet<tbl_Wallet>();
        }

        [Key]
        public Guid pk_tbl_UserAccount { get; set; }

        [Required]
        [StringLength(200)]
        public string tbl_UserAccount_EmailAddress { get; set; }

        [Required]
        [StringLength(200)]
        public string tbl_UserAccount_Firstname { get; set; }

        [Required]
        [StringLength(200)]
        public string tbl_UserAccount_Surname { get; set; }

        [Required]
        [StringLength(200)]
        public string tbl_UserAccount_PhysicalAddressLine1 { get; set; }

        [Required]
        [StringLength(200)]
        public string tbl_UserAccount_PhysicalAddressLine2 { get; set; }

        [Required]
        [StringLength(200)]
        public string tbl_UserAccount_PhysicalAddressLine3 { get; set; }

        [Required]
        [StringLength(10)]
        public string tbl_UserAccount_PostalCode { get; set; }

        [StringLength(13)]
        public string tbl_UserAccount_CellphoneNumber { get; set; }

        [Required]
        [StringLength(10)]
        public string tbl_UserAccount_UserRole { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Wallet> tbl_Wallet { get; set; }
    }
}
