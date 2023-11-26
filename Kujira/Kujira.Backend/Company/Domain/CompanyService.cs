namespace Kujira.Backend.Company.Domain;

public class CompanyService
{
    private readonly IAddressRepository _addressRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly ICompanyTypeRepository _companyTypeRepository;

    public CompanyService(ICompanyRepository companyRepository, ICompanyTypeRepository companyTypeRepository, IAddressRepository addressRepository)
    {
        _companyRepository = companyRepository;
        _companyTypeRepository = companyTypeRepository;
        _addressRepository = addressRepository;
    }

    //public async Task<Company> CreateCompanyWithAddressAsync(string name, string email, string phoneNumber, string? websiteAddress, Address address, Guid companyTypeId)
    //{
    //    await _addressRepository.CreateAsync(address);

    //    var companyType = await _companyTypeRepository.GetAsync(companyTypeId) ?? throw new Exception("CompanyType not found.");

    //    var company = new Company
    //    {
    //        Name = name,
    //        EMailAddress = email,
    //        PhoneNumber = phoneNumber,
    //        WebsiteAddress = websiteAddress,
    //        Address = address,
    //        CompanyType = companyType
    //    };

    //    await _companyRepository.CreateAsync(company);

    //    return company;
    //}
}