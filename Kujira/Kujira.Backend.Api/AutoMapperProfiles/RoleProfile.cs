using AutoMapper;
using Kujira.Api.DTOs;
using Kujira.Backend.Models;

namespace Kujira.Api.AutoMapperProfiles;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<Role, RoleDto>();
        CreateMap<RoleDto, Role>();
    }
}