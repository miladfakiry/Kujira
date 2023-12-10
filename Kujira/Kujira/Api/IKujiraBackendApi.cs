using Kujira.Api.Requests;
using Kujira.Gui.Api.Requests;
using Kujira.Gui.Api.Response;
using RestEase;

namespace Kujira.Api;

public interface IKujiraBackendApi
{
    [Get("/api/User")]
    Task<IEnumerable<UserRequest>> GetUsers();

    [Get("/api/User/{id}")]
    Task<UserRequest> GetUser([Path] Guid id);

    [Post("/api/User")]
    Task CreateUser([Body] UserRequest userRequest);

    [Put("/api/User/{id}")]
    Task UpdateUser([Path] Guid id, [Body] UserRequest userRequest);

    [Delete("/api/User/{id}")]
    Task<IEnumerable<UserRequest>> DeleteUser([Path] Guid id);


    [Get("/api/Company")]
    Task<IEnumerable<CompanyRequest>> GetCompanies();

    [Get("/api/Company/{id}")]
    Task<CompanyRequest> GetCompany([Path] Guid id);

    [Put("/api/Company/{id}")]
    Task UpdateCompany([Path] Guid id, [Body] CompanyRequest companyRequest);

    [Post("/api/Company")]
    Task CreateCompany([Body] CompanyRequest companyRequest);

    [Delete("/api/Company/{id}")]
    Task<IEnumerable<CompanyRequest>> DeleteCompany([Path] Guid id);



    [Get("/api/CompanyType")]
    Task<IEnumerable<CompanyTypeRequest>> GetCompanyTypes();


    [Get("/api/Country")]
    Task<IEnumerable<CountryRequest>> GetCountries();


    [Get("/api/Zip")]
    Task<IEnumerable<ZipRequest>> GetZips();

    [Get("/api/Role")]
    Task<IEnumerable<RoleRequest>> GetRoles();


    [Post("/api/Auth/login")]
    Task<LoginResponse> Login([Body] LoginRequest loginRequest);


    [Get("/api/Offer")]
    Task<IEnumerable<OfferRequest>> GetOffers();

    [Get("/api/Offer/{id}")]
    Task<OfferRequest> GetOfferById([Path] Guid id);

    [Get("/api/Offer/User/{userId}")]
    Task<IEnumerable<OfferRequest>> GetOfferByUserId([Path] Guid userId);

    [Post("/api/Offer")]
    Task CreateOffer([Body] OfferRequest offerRequest);

    [Put("/api/Offer/{id}")]
    Task UpdateOffer([Path] Guid id, [Body] OfferRequest offerRequest);

    [Delete("/api/Offer/{id}")]
    Task DeleteOffer([Path] Guid id);
}