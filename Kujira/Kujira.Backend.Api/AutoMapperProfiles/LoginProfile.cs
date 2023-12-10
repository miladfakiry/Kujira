using AutoMapper;
using Kujira.Api.DTOs;
using Kujira.Backend.User.Domain;

namespace Kujira.Api.AutoMapperProfiles
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<Login, LoginDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        }
    }
}
