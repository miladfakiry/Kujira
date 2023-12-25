using AutoMapper;
using Kujira.Backend.Api.DTOs;
using Kujira.Backend.Models;

namespace Kujira.Api.AutoMapperProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, User>()
            .ForMember(u => u.PersonalInformation, opt => opt.MapFrom((dto, user) =>
            {
                if (user.PersonalInformation == null)
                {
                    user.PersonalInformation = new PersonalInformation(Guid.NewGuid(), dto.DateOfBirth, user.Id);
                }

                user.PersonalInformation.PhoneNumber = dto.PhoneNumber;
                return user.PersonalInformation;
            }));

        CreateMap<UserDto, PersonalInformation>()
            .ConstructUsing(dto => new PersonalInformation(Guid.NewGuid(), dto.DateOfBirth, dto.Id)
            {
                PhoneNumber = dto.PhoneNumber
            });

        CreateMap<User, UserDto>()
            .ForMember(dto => dto.DateOfBirth, opt => opt.MapFrom(u => u.PersonalInformation.DateOfBirth))
            .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(u => u.PersonalInformation.PhoneNumber))
            .ForMember(dto => dto.RoleId, opt => opt.MapFrom(u => u.UserRoles.FirstOrDefault().RoleId));
    }
}