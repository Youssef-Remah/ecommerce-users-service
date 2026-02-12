using AutoMapper;
using eCommerce.Core.DTOs;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers;

public class ApplicationUserMappingProfile : Profile
{
    public ApplicationUserMappingProfile()
    {
        CreateMap<ApplicationUser, AuthenticationResponse>()
            .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID));

        CreateMap<ApplicationUser, AuthenticationResponse>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

        CreateMap<ApplicationUser, AuthenticationResponse>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        CreateMap<ApplicationUser, AuthenticationResponse>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender));

        CreateMap<ApplicationUser, AuthenticationResponse>()
            .ForMember(dest => dest.Success, opt => opt.Ignore());

        CreateMap<ApplicationUser, AuthenticationResponse>()
            .ForMember(dest => dest.Token, opt => opt.Ignore());
    }
}
