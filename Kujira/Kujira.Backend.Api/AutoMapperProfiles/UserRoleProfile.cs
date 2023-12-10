using AutoMapper;
using Kujira.Api.DTOs;
using Kujira.Backend.User.Domain;

namespace Kujira.Api.AutoMapperProfiles;

public class UserRoleProfile : Profile
{
    public UserRoleProfile()
    {
        CreateMap<UserRoleDto, UserRole>();
        CreateMap<UserRole, UserRoleDto>();
    }
}