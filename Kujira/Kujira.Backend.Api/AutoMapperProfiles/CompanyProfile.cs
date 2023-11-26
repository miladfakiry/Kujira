using AutoMapper;
using Kujira.Api.DTOs;
using Kujira.Backend.Company.Domain;

namespace Kujira.Api.AutoMapperProfiles;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        // Mapping von CompanyDto zu Company
        CreateMap<CompanyDto, Company>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.EMailAddress, opt => opt.MapFrom(src => src.EMailAddress))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.WebsiteAddress, opt => opt.MapFrom(src => src.WebsiteAddress))
            .ForMember(dest => dest.Address, opt => opt.MapFrom((src, dest) => CreateOrUpdateAddress(src, dest)))
            .ForMember(dest => dest.CompanyType, opt => opt.Ignore());

        // Mapping von Company zu CompanyDto
        CreateMap<Company, CompanyDto>()
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
            .ForMember(dest => dest.StreetNumber, opt => opt.MapFrom(src => src.Address.StreetNumber))
            .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Address.Zip.Code))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.Zip.City))
            .ForMember(dest => dest.CantonName, opt => opt.MapFrom(src => src.Address.Zip.Canton.Name))
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Address.Zip.Canton.Country.Name))
            .ForMember(dest => dest.CompanyType, opt => opt.MapFrom(src => src.CompanyType.Type));

        CreateMap<CompanyDto, Address>()
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
            .ForMember(dest => dest.StreetNumber, opt => opt.MapFrom(src => src.StreetNumber));
            //.ForMember(dest => dest.ZipId, opt => opt.MapFrom(src => /* Logik zur Umwandlung von ZipCode in ZipId */));

        // Mapping von Address zu CompanyDto
        CreateMap<Address, CompanyDto>()
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
            .ForMember(dest => dest.StreetNumber, opt => opt.MapFrom(src => src.StreetNumber))
            .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Zip.Code))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Zip.City))
            .ForMember(dest => dest.CantonName, opt => opt.MapFrom(src => src.Zip.Canton.Name))
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Zip.Canton.Country.Name));
    }



    private Address CreateOrUpdateAddress(CompanyDto src, Company dest)
    {
        // Logik für das Erstellen oder Aktualisieren der Adresse
        if (src.AddressId == Guid.Empty)
        {
            // Erstellung einer neuen Adresse
            var newZip = new Zip(Guid.NewGuid(), src.ZipCode, src.City, Guid.NewGuid()); // Annahme: Neue Zip-Instanz
            var newAddress = new Address(Guid.NewGuid(), src.Street, src.StreetNumber, newZip);
            return newAddress;
        }
        else
        {
            // Aktualisierung einer bestehenden Adresse
            if (dest.Address != null)
            {
                dest.Address.Street = src.Street;
                dest.Address.StreetNumber = src.StreetNumber;
                // Aktualisieren Sie weitere Eigenschaften der Adresse, falls erforderlich
            }
            return dest.Address;
        }
    }

}
