namespace FastCoinTrader.EnitityModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FastCoinTraderContext : DbContext
    {
        public FastCoinTraderContext()
            : base("name=FastCoinTraderContext")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tbl_Email> tbl_Email { get; set; }
        public virtual DbSet<tbl_Sales> tbl_Sales { get; set; }
        public virtual DbSet<tbl_UserAccount> tbl_UserAccount { get; set; }
        public virtual DbSet<tbl_Wallet> tbl_Wallet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Sales>()
                .Property(e => e.tbl_BTCTargetAmount)
                .HasPrecision(14, 8);

            modelBuilder.Entity<tbl_Sales>()
                .Property(e => e.tbl_Sales_BTCSold)
                .HasPrecision(14, 8);

            modelBuilder.Entity<tbl_UserAccount>()
                .HasMany(e => e.tbl_Wallet)
                .WithRequired(e => e.tbl_UserAccount)
                .HasForeignKey(e => e.fk_tbl_UserAccount)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Wallet>()
                .Property(e => e.tbl_Wallet_BTCBalance)
                .HasPrecision(14, 8);

            modelBuilder.Entity<tbl_Wallet>()
                .Property(e => e.tbl_Wallet_BTCAddress)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Wallet>()
                .HasMany(e => e.tbl_Sales)
                .WithRequired(e => e.tbl_Wallet)
                .HasForeignKey(e => e.fk_tbl_Wallet)
                .WillCascadeOnDelete(false);
        }
    }
}
