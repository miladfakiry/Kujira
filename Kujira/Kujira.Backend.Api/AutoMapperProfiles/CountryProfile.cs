using AutoMapper;
using Kujira.Api.DTOs;
using Kujira.Backend.Company.Domain;

namespace Kujira.Api.AutoMapperProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();
        }
    }
}
