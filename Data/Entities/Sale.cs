using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("SALES")]
    public class Sale
    {
        [Key]
            [Column("PROD_ID")]
        public decimal ProdId { get; set; }
        [Key]
        [Column("CUST_ID")]
        public decimal CustId { get; set; }
        [Key]
        [Column("TIME_ID")]
        public DateTime TimeId { get; set; }
        [Key]
        [Column("CHANNEL_ID")]
        public decimal ChannelId { get; set; }
        [Key]
        [Column("PROMO_ID")]
        public decimal PromoId { get; set; }
        [Column("QUANTITY_SOLD")]
        public decimal? QuantitySold { get; set; }
        [Column("AMOUNT_SOLD")]
        public decimal? AmountSold { get; set; }

        [ForeignKey("CustId")]
        public virtual Customer Customer { get; set; }
    }
} 