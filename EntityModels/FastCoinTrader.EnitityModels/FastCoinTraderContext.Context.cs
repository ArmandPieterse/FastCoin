﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FastCoinTraderContext : DbContext
    {
        public FastCoinTraderContext()
            : base("name=FastCoinTraderContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_Email> tbl_Email { get; set; }
        public virtual DbSet<tbl_Sales> tbl_Sales { get; set; }
        public virtual DbSet<tbl_UserAccount> tbl_UserAccount { get; set; }
        public virtual DbSet<tbl_Wallet> tbl_Wallet { get; set; }
        public virtual DbSet<tbl_Buys> tbl_Buys { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
