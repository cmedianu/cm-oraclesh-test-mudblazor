using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("CUSTOMERS")]
    public class Customer
    {
        [Key]
        [Column("CUST_ID")]
        public decimal CustId { get; set; }
        [Column("CUST_FIRST_NAME")]
        public string CustFirstName { get; set; }
        [Column("CUST_LAST_NAME")]
        public string CustLastName { get; set; }
        [Column("CUST_GENDER")]
        public string CustGender { get; set; }
        [Column("CUST_YEAR_OF_BIRTH")]
        public decimal? CustYearOfBirth { get; set; }
        [Column("CUST_MARITAL_STATUS")]
        public string CustMaritalStatus { get; set; }
        [Column("CUST_STREET_ADDRESS")]
        public string CustStreetAddress { get; set; }
        [Column("CUST_POSTAL_CODE")]
        public string CustPostalCode { get; set; }
        [Column("CUST_CITY")]
        public string CustCity { get; set; }
        [Column("CUST_CITY_ID")]
        public decimal? CustCityId { get; set; }
        [Column("CUST_STATE_PROVINCE")]
        public string CustStateProvince { get; set; }
        [Column("CUST_STATE_PROVINCE_ID")]
        public decimal? CustStateProvinceId { get; set; }
        [ForeignKey("Country")]
        [Column("COUNTRY_ID")]
        public decimal? CountryId { get; set; }
        [Column("CUST_MAIN_PHONE_NUMBER")]
        public string CustMainPhoneNumber { get; set; }
        [Column("CUST_INCOME_LEVEL")]
        public string CustIncomeLevel { get; set; }
        [Column("CUST_CREDIT_LIMIT")]
        public decimal? CustCreditLimit { get; set; }
        [Column("CUST_EMAIL")]
        public string CustEmail { get; set; }
        [Column("CUST_TOTAL")]
        public string CustTotal { get; set; }
        [Column("CUST_TOTAL_ID")]
        public decimal? CustTotalId { get; set; }
        [Column("CUST_SRC_ID")]
        public decimal? CustSrcId { get; set; }
        [Column("CUST_EFF_FROM")]
        public DateTime? CustEffFrom { get; set; }
        [Column("CUST_EFF_TO")]
        public DateTime? CustEffTo { get; set; }
        [Column("CUST_VALID")]
        public string CustValid { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
} 