using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("COUNTRIES")]
    public class Country
    {
        [Key]
        [Column("COUNTRY_ID")]
        public decimal CountryId { get; set; }
        [Column("COUNTRY_ISO_CODE")]
        public string CountryIsoCode { get; set; }
        [Column("COUNTRY_NAME")]
        public string CountryName { get; set; }
        [Column("COUNTRY_SUBREGION")]
        public string CountrySubregion { get; set; }
        [Column("COUNTRY_SUBREGION_ID")]
        public decimal? CountrySubregionId { get; set; }
        [Column("COUNTRY_REGION")]
        public string CountryRegion { get; set; }
        [Column("COUNTRY_REGION_ID")]
        public decimal? CountryRegionId { get; set; }
        [Column("COUNTRY_TOTAL")]
        public string CountryTotal { get; set; }
        [Column("COUNTRY_TOTAL_ID")]
        public decimal? CountryTotalId { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
} 