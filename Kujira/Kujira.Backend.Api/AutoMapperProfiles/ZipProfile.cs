using AutoMapper;
using Kujira.Api.DTOs;
using Kujira.Backend.Company.Domain;

namespace Kujira.Api.AutoMapperProfiles
{
    public class ZipProfile : Profile
    {
        public ZipProfile()
        {
            CreateMap<Zip, ZipDto>()
                .ForMember(dest => dest.Canton, opt => opt.MapFrom(src => src.Canton.Name))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Canton.Country.Name));

            CreateMap<ZipDto, Zip>();
        }
    }
}
