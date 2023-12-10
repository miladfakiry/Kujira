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
}