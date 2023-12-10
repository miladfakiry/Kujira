using AutoMapper;
using Kujira.Api.DTOs;
using Kujira.Backend.Offer.Domain;

namespace Kujira.Api.AutoMapperProfiles;

public class OfferProfile : Profile
{
    public OfferProfile()
    {
        CreateMap<OfferDto, Offer>()
            .ConstructUsing(dto => new Offer(
                dto.Id != Guid.Empty ? dto.Id : Guid.NewGuid(),
                dto.AvailablePlaces,
                dto.LongTermFamilyCare,
                dto.CrisisIntervention,
                dto.ReliefOffer,
                dto.CurrentlyPlacedFosterChildren,
                dto.BiologicalChildren,
                dto.AdditionalNote,
                false,
                dto.ZipId,
                dto.UserId))
            .ForMember(o => o.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(o => o.ZipId, opt => opt.MapFrom(dto => dto.ZipId));

        CreateMap<Offer, OfferDto>()
            .ForMember(dto => dto.City, opt => opt.MapFrom(o => o.User.Company.Address.Zip.City))
            .ForMember(dto => dto.ZipCode, opt => opt.MapFrom(o => o.User.Company.Address.Zip.Code));
    }
}


