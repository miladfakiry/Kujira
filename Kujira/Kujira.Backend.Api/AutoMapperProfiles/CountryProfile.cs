using AutoMapper;
using Kujira.Api.DTOs;
using Kujira.Backend.Models;

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
