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
    
    public partial class tbl_News
    {
        public System.Guid pk_tbl_News { get; set; }
        public string tbl_News_Title { get; set; }
        public string tbl_News_Paragraph { get; set; }
        public string tbl_News_VideoLink { get; set; }
        public System.DateTime tbl_News_DateCreated { get; set; }
    }
}