using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Sale
    {
        [Key]
        [Column(Order = 0)]
        public decimal ProdId { get; set; }
        [Key]
        [Column(Order = 1)]
        public decimal CustId { get; set; }
        [Key]
        [Column(Order = 2)]
        public DateTime TimeId { get; set; }
        [Key]
        [Column(Order = 3)]
        public decimal ChannelId { get; set; }
        [Key]
        [Column(Order = 4)]
        public decimal PromoId { get; set; }
        public decimal? QuantitySold { get; set; }
        public decimal? AmountSold { get; set; }

        [ForeignKey("CustId")]
        public virtual Customer Customer { get; set; }
    }
} 