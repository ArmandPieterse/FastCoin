namespace FastCoinTrader.EnitityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Email
    {
        [Key]
        public Guid pk_tbl_Email { get; set; }

        [Required]
        [StringLength(250)]
        public string tbl_Email_Subject { get; set; }

        [Required]
        [StringLength(50)]
        public string tbl_Email_Type { get; set; }

        [Required]
        public byte[] tbl_Email_Body { get; set; }

        [Required]
        [StringLength(200)]
        public string tbl_Email_From { get; set; }

        [Required]
        [StringLength(200)]
        public string tbl_Email_To { get; set; }

        public DateTime tbl_Email_DateCreated { get; set; }

        public DateTime tbl_Email_DateLastModified { get; set; }
    }
}
