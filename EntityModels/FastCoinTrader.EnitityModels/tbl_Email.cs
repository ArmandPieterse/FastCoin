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
    
    public partial class tbl_Email
    {
        public System.Guid pk_tbl_Email { get; set; }
        public string tbl_Email_Subject { get; set; }
        public string tbl_Email_Type { get; set; }
        public string tbl_Email_Body { get; set; }
        public string tbl_Email_From { get; set; }
        public string tbl_Email_To { get; set; }
        public System.DateTime tbl_Email_DateCreated { get; set; }
        public System.DateTime tbl_Email_DateLastModified { get; set; }
    }
}