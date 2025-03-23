using AutoMapper;
using SalesSystem.Application.Users.DTOs;
using SalesSystem.Domain.Users;
using SalesSystem.Domain.Users.ValueObjects;

namespace SalesSystem.Application.Users.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));

            CreateMap<Name, NameDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<Geolocation, GeolocationDto>();
        }
    }
}
