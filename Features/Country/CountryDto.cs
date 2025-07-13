namespace Features.Country
{
    public class CountryDto
    {
        public decimal CountryId { get; set; }
        public string CountryIsoCode { get; set; }
        public string CountryName { get; set; }
        public string CountrySubregion { get; set; }
        public decimal? CountrySubregionId { get; set; }
        public string CountryRegion { get; set; }
        public decimal? CountryRegionId { get; set; }
        public string CountryTotal { get; set; }
        public decimal? CountryTotalId { get; set; }
    }
} 