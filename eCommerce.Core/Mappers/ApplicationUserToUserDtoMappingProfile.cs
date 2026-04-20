using AutoMapper;
using eCommerce.Core.DTOs;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers
{
    public class ApplicationUserToUserDtoMappingProfile : Profile
    {
        public ApplicationUserToUserDtoMappingProfile()
        {
            CreateMap<ApplicationUser, UserDto>()
              .ForMember(des => des.UserID, opt => opt.MapFrom(src => src.UserID))
              .ForMember(des => des.Email, opt => opt.MapFrom(src => src.Email))
              .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name))
              .ForMember(des => des.Gender, opt => opt.MapFrom(src => src.Gender));
        }
    }
}
