using AutoMapper;
using Features.Country;

namespace Features.Country
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Data.Entities.Country, CountryDto>().ReverseMap();
        }
    }
} 