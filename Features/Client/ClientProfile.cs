using AutoMapper;
using Data.Entities;

namespace Features.Client
{
    public class ClientProfile : AutoMapper.Profile
    {
        public ClientProfile()
        {
            CreateMap<Customer, ClientDto>()
                .ReverseMap();
        }
    }
} 