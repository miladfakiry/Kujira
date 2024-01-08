using AutoMapper;
using Kujira.Api.DTOs;
using Kujira.Backend.Models;

namespace Kujira.Api.AutoMapperProfiles;

public class ServiceRequestProfile : Profile
{
    public ServiceRequestProfile()
    {
        // Mapping from DTO to Model
        CreateMap<ServiceRequestDto, ServiceRequest>()
            .ForMember(sr => sr.RequestId, opt => opt.MapFrom(dto => dto.RequestId != Guid.Empty ? dto.RequestId : Guid.NewGuid()))
            .ForMember(sr => sr.OfferId, opt => opt.MapFrom(dto => dto.OfferId))
            .ForMember(sr => sr.FromUserId, opt => opt.MapFrom(dto => dto.FromUserId))
            .ForMember(sr => sr.FromUserEMail, opt => opt.MapFrom(dto => dto.RequesterEmail))
            .ForMember(sr => sr.ToUserId, opt => opt.MapFrom(dto => dto.ToUserId))
            .ForMember(sr => sr.Message, opt => opt.MapFrom(dto => dto.Message))
            .ForMember(sr => sr.ResponseMessage, opt => opt.MapFrom(dto => dto.ResponseMessage))
            .ForMember(sr => sr.RequestStatus, opt => opt.Ignore())
            .ForMember(sr => sr.CreatedAt, opt => opt.Ignore())    
            .ForMember(sr => sr.UpdatedAt, opt => opt.Ignore());    

        // Mapping from Model to DTO
        CreateMap<ServiceRequest, ServiceRequestDto>()
            .ForMember(dto => dto.RequestId, opt => opt.MapFrom(sr => sr.RequestId))
            .ForMember(dto => dto.OfferId, opt => opt.MapFrom(sr => sr.OfferId))
            .ForMember(dto => dto.FromUserId, opt => opt.MapFrom(sr => sr.FromUserId))
            .ForMember(dto => dto.ToUserId, opt => opt.MapFrom(sr => sr.ToUserId))
            .ForMember(dto => dto.Message, opt => opt.MapFrom(sr => sr.Message))
            .ForMember(dto => dto.ResponseMessage, opt => opt.MapFrom(sr => sr.ResponseMessage))
            .ForMember(dto => dto.RequesterFirstName, opt => opt.MapFrom(sr => sr.FromUser.FirstName))
            .ForMember(dto => dto.RequesterLastName, opt => opt.MapFrom(sr => sr.FromUser.LastName))
            .ForMember(dto => dto.RequesterPhoneNumber, opt => opt.MapFrom(sr => sr.FromUser.PersonalInformation.PhoneNumber))
            .ForMember(dto => dto.CreatedAt, opt => opt.MapFrom(sr => sr.CreatedAt))
            .ForMember(dto => dto.RequestStatus, opt => opt.MapFrom(sr => sr.RequestStatus));
    }
}