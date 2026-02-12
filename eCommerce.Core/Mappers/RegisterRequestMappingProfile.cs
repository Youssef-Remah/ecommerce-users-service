using AutoMapper;
using eCommerce.Core.DTOs;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers;

public class RegisterRequestMappingProfile : Profile
{
    public RegisterRequestMappingProfile()
    {
        CreateMap<RegisterRequest, ApplicationUser>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

        CreateMap<RegisterRequest, ApplicationUser>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        CreateMap<RegisterRequest, ApplicationUser>()
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

        CreateMap<RegisterRequest, ApplicationUser>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender));

        CreateMap<RegisterRequest, ApplicationUser>()
            .ForMember(dest => dest.UserID, opt => opt.Ignore());
    }
}
