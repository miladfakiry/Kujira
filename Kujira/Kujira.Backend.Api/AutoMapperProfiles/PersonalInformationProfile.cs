using AutoMapper;
using Kujira.Backend.Api.DTOs;
using Kujira.Backend.Models;

namespace Kujira.Api.AutoMapperProfiles
{
    public class PersonalInformationProfile : Profile
    {
        public PersonalInformationProfile()
        {
            CreateMap<UserDto, PersonalInformation>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
        }
    }
}
