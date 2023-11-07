using AutoMapper;
using Kujira.Backend.Api.DTOs;

namespace Kujira.Backend.Api.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User.Domain.User, UserDto>().ReverseMap();
        }
    }
}
