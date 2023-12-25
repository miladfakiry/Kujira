using AutoMapper;
using Kujira.Api.DTOs;
using Kujira.Backend.Models;

namespace Kujira.Api.AutoMapperProfiles;

public class CompanyTypeProfile : Profile
{
    public CompanyTypeProfile()
    {
        CreateMap<CompanyType, CompanyTypeDto>();
        CreateMap<CompanyTypeDto, CompanyType>();
    }

}