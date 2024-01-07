using Kujira.Api.Requests;
using Kujira.Gui.Api.Requests;
using Kujira.Gui.Api.Response;
using RestEase;

namespace Kujira.Gui.Api;

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

    [Post("/api/Company")]
    Task CreateCompany([Body] CompanyRequest companyRequest);

    [Put("/api/Company/{id}")]
    Task UpdateCompany([Path] Guid id, [Body] CompanyRequest companyRequest);

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

    [Get("/api/ServiceRequest/{id}")]
    Task<ServiceRequestRequest> GetServiceRequestById([Path] Guid id);

    [Get("/api/ServiceRequest/User/{userId}")]
    Task<IEnumerable<ServiceRequestRequest>> GetServiceRequestsForUser([Path] Guid userId);

    [Get("/api/ServiceRequest/Offer/{offerId}")]
    Task<IEnumerable<ServiceRequestRequest>> GetServiceRequestsForOffer([Path] Guid offerId);

    [Get("/api/ServiceRequest/Exists/{userId}/{offerId}")]
    Task<bool> CheckIfRequestExists([Path] Guid userId, [Path] Guid offerId);

    [Post("/api/ServiceRequest/SendRequest")]
    Task SendRequest([Body] ServiceRequestRequest serviceRequestRequest);

    [Post("/api/ServiceRequest/SendResponse/{requestId}")]
    Task SendResponseToRequest([Path] Guid requestId, [Body] ServiceRequestRequest response);

    [Post("/api/ServiceRequest/AcceptRequest/{requestId}")]
    Task AcceptRequest([Path] Guid requestId);

    [Post("/api/ServiceRequest/RejectRequest/{requestId}")]
    Task RejectRequest([Path] Guid requestId);

}