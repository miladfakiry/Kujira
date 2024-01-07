using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Moq;

namespace Kujira.Backend.Tests;

[TestFixture]
public class CompanyRepositoryTests
{
    private Mock<ICompanyRepository> _companyRepositoryMock;

    [SetUp]
    public void Setup()
    {
        _companyRepositoryMock = new Mock<ICompanyRepository>();
    }

    private Country CreateTestCountry()
    {
        return new Country(Guid.NewGuid(), "Test Country");
    }

    private Canton CreateTestCanton()
    {
        var country = CreateTestCountry();
        return new Canton(Guid.NewGuid(), "Test Canton", country);
    }

    private Zip CreateTestZip()
    {
        var canton = CreateTestCanton();
        return new Zip(Guid.NewGuid(), "12345", "Test City", canton);
    }

    private Address CreateTestAddress()
    {
        var zip = CreateTestZip();
        return new Address(Guid.NewGuid(), "Test Street", "123", zip);
    }

    private CompanyType CreateTestCompanyType()
    {
        return new CompanyType(Guid.NewGuid(), "Test Company Type");
    }

    private Company CreateTestCompany()
    {
        var address = CreateTestAddress();
        var companyType = CreateTestCompanyType();
        return new Company(Guid.NewGuid(), "Test Company", "test@example.com", "1234567890", "https://test.com", address, companyType);
    }

    [Test]
    public void GetAll_WhenCalled_ReturnsAllCompanies()
    {
        var companies = new List<Company> { CreateTestCompany(), CreateTestCompany() };
        _companyRepositoryMock.Setup(repo => repo.GetAll()).Returns(companies);

        var result = _companyRepositoryMock.Object.GetAll();

        Assert.That(result, Is.EquivalentTo(companies));
        _companyRepositoryMock.Verify(repo => repo.GetAll(), Times.Once);
    }

    [Test]
    public void Get_WhenCalledWithId_ReturnsCompany()
    {
        var company = CreateTestCompany();
        _companyRepositoryMock.Setup(repo => repo.Get(company.Id)).Returns(company);

        var result = _companyRepositoryMock.Object.Get(company.Id);

        Assert.That(result, Is.EqualTo(company));
        _companyRepositoryMock.Verify(repo => repo.Get(company.Id), Times.Once);
    }

    [Test]
    public void Create_WhenCalledWithCompany_AddsCompany()
    {
        var company = CreateTestCompany();
        _companyRepositoryMock.Object.Create(company);

        _companyRepositoryMock.Verify(repo => repo.Create(It.Is<Company>(c => c.Id == company.Id)), Times.Once);
    }

    [Test]
    public void Update_WhenCalledWithCompany_UpdatesCompany()
    {
        var company = CreateTestCompany();
        _companyRepositoryMock.Object.Update(company);

        _companyRepositoryMock.Verify(repo => repo.Update(It.Is<Company>(c => c.Id == company.Id)), Times.Once);
    }

    [Test]
    public void Delete_WhenCalledWithId_DeletesCompany()
    {
        var companyId = Guid.NewGuid();
        _companyRepositoryMock.Object.Delete(companyId);

        _companyRepositoryMock.Verify(repo => repo.Delete(companyId), Times.Once);
    }
}