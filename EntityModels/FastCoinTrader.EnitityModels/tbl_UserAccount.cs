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
    
    public partial class tbl_UserAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_UserAccount()
        {
            this.tbl_Wallet = new HashSet<tbl_Wallet>();
        }
    
        public System.Guid pk_tbl_UserAccount { get; set; }
        public string tbl_UserAccount_EmailAddress { get; set; }
        public string tbl_UserAccount_Firstname { get; set; }
        public string tbl_UserAccount_Surname { get; set; }
        public string tbl_UserAccount_PhysicalAddressLine1 { get; set; }
        public string tbl_UserAccount_PhysicalAddressLine2 { get; set; }
        public string tbl_UserAccount_PhysicalAddressLine3 { get; set; }
        public string tbl_UserAccount_PostalCode { get; set; }
        public string tbl_UserAccount_CellphoneNumber { get; set; }
        public string tbl_UserAccount_UserRole { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Wallet> tbl_Wallet { get; set; }
    }
}