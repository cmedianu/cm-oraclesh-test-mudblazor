using AutoMapper;
using Data.Entities;

namespace Features.Client
{
    public class ClientProfile : AutoMapper.Profile
    {
        public ClientProfile()
        {
            CreateMap<Customer, ClientDto>()
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country != null ? src.Country.CountryName : null));
        }
    }
} 