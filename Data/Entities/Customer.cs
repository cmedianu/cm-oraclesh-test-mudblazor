using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Customer
    {
        [Key]
        public decimal CustId { get; set; }
        public string CustFirstName { get; set; }
        public string CustLastName { get; set; }
        public string CustGender { get; set; }
        public decimal? CustYearOfBirth { get; set; }
        public string CustMaritalStatus { get; set; }
        public string CustStreetAddress { get; set; }
        public string CustPostalCode { get; set; }
        public string CustCity { get; set; }
        public decimal? CustCityId { get; set; }
        public string CustStateProvince { get; set; }
        public decimal? CustStateProvinceId { get; set; }
        [ForeignKey("Country")]
        public decimal? CountryId { get; set; }
        public string CustMainPhoneNumber { get; set; }
        public string CustIncomeLevel { get; set; }
        public decimal? CustCreditLimit { get; set; }
        public string CustEmail { get; set; }
        public string CustTotal { get; set; }
        public decimal? CustTotalId { get; set; }
        public decimal? CustSrcId { get; set; }
        public DateTime? CustEffFrom { get; set; }
        public DateTime? CustEffTo { get; set; }
        public string CustValid { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
} 