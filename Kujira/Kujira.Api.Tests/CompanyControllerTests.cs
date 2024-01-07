using AutoMapper;
using Kujira.Api.Controllers;
using Kujira.Api.DTOs;
using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Kujira.Api.Tests;

public class CompanyControllerTests
{
    private Mock<ICompanyRepository> _mockCompanyRepository;
    private Mock<IZipRepository> _mockZipRepository;
    private Mock<IMapper> _mockMapper;
    private CompanyController _controller;

    [SetUp]
    public void Setup()
    {
        _mockCompanyRepository = new Mock<ICompanyRepository>();
        _mockZipRepository = new Mock<IZipRepository>();
        _mockMapper = new Mock<IMapper>();
        _controller = new CompanyController(_mockCompanyRepository.Object, _mockMapper.Object, _mockZipRepository.Object);
    }

    [Test]
    public void GetCompanies_ReturnsAllCompanies()
    {
        // Arrange
        var companies = new List<Company>
        {
            new Company(Guid.NewGuid(), "TestCompany1", "email1@test.com", "123456789", "www.test1.com", Guid.NewGuid(), Guid.NewGuid()),
            new Company(Guid.NewGuid(), "TestCompany2", "email2@test.com", "987654321", "www.test2.com", Guid.NewGuid(), Guid.NewGuid())
        };

        var companyDtos = companies.Select(c => new CompanyDto
        {
            Id = c.Id,
            Name = c.Name,
            EMailAddress = c.EMailAddress,
            PhoneNumber = c.PhoneNumber,
            WebsiteAddress = c.WebsiteAddress,
            AddressId = c.AddressId,
            CompanyTypeId = c.CompanyTypeId
        });

        _mockCompanyRepository.Setup(repo => repo.GetAll()).Returns(companies);
        _mockMapper.Setup(m => m.Map<IEnumerable<CompanyDto>>(It.IsAny<IEnumerable<Company>>())).Returns(companyDtos);

        // Act
        var result = _controller.GetCompanies();

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result.Result);
        var okResult = result.Result as OkObjectResult;
        Assert.IsNotNull(okResult.Value);

    }

    [Test]
    public void GetCompany_ExistingId_ReturnsCompany()
    {
        // Arrange
        var company = new Company(Guid.NewGuid(), "TestCompany", "email@test.com", "123456789", "www.test.com", Guid.NewGuid(), Guid.NewGuid());
        var companyDto = new CompanyDto
        {

            Id = company.Id,
            Name = company.Name,
            EMailAddress = company.EMailAddress,

        };

        _mockCompanyRepository.Setup(repo => repo.Get(It.IsAny<Guid>())).Returns(company);
        _mockMapper.Setup(m => m.Map<CompanyDto>(It.IsAny<Company>())).Returns(companyDto);

        // Act
        var result = _controller.GetCompany(Guid.NewGuid());

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result.Result);
    }

    [Test]
    public void CreateCompany_ValidCompany_ReturnsCreatedAtActionResult()
    {
        // Arrange
        var companyDto = new CompanyDto
        {
            // Setzen Sie die Werte entsprechend
            Name = "Neue Firma",
            EMailAddress = "neuefirma@example.com",
            // weitere Eigenschaften
        };
        var company = new Company(Guid.NewGuid(), companyDto.Name, companyDto.EMailAddress, "...", "...", Guid.NewGuid(), Guid.NewGuid());

        var zip = new Zip(Guid.NewGuid(), "12345", "Teststadt", new Canton(Guid.NewGuid(), "Testkanton", new Country(Guid.NewGuid(), "Testland")));

        _mockMapper.Setup(m => m.Map<Company>(companyDto)).Returns(company);
        _mockZipRepository.Setup(r => r.GetByCodeWithCantonAndCountry(companyDto.ZipCode)).Returns(zip);
        _mockCompanyRepository.Setup(r => r.Create(company)).Verifiable();

        // Act
        var result = _controller.CreateCompany(companyDto);

        // Assert
        Assert.IsInstanceOf<CreatedAtActionResult>(result.Result);
        _mockCompanyRepository.Verify();
    }

    [Test]
    public void UpdateCompany_ValidCompany_ReturnsNoContentResult()
    {
        // Arrange
        var companyId = Guid.NewGuid();
        var companyDto = new CompanyDto
        {
            Id = companyId,
            Name = "Aktualisierte Firma",
        };

        var existingAddress = new Address(Guid.NewGuid(), "Teststrasse", "123", new Zip(Guid.NewGuid(), "12345", "Teststadt", new Canton(Guid.NewGuid(), "Testkanton", new Country(Guid.NewGuid(), "Testland"))));
        var existingCompany = new Company(companyId, "Vorheriger Name", "email@test.com", "123456789", "www.test.com", existingAddress, new CompanyType(Guid.NewGuid(), "Vorheriger Typ"))
        {
            Address = existingAddress
        };

        _mockCompanyRepository.Setup(r => r.Get(companyId)).Returns(existingCompany);
        _mockMapper.Setup(m => m.Map<CompanyDto, Company>(companyDto, existingCompany)).Verifiable();
        _mockCompanyRepository.Setup(r => r.Update(existingCompany)).Verifiable();

        // Act
        var result = _controller.UpdateCompany(companyId, companyDto);

        // Assert
        Assert.IsInstanceOf<NoContentResult>(result);
        _mockCompanyRepository.Verify();
        _mockMapper.Verify();
    }

    [Test]
    public void DeleteCompany_ExistingId_ReturnsNoContentResult()
    {
        // Arrange
        var companyId = Guid.NewGuid();
        var existingCompany = new Company(companyId, "TestFirma", "email@test.com", "123456789", "www.test.com", Guid.NewGuid(), Guid.NewGuid());

        _mockCompanyRepository.Setup(r => r.Get(companyId)).Returns(existingCompany);
        _mockCompanyRepository.Setup(r => r.Delete(companyId)).Verifiable();

        // Act
        var result = _controller.DeleteCompany(companyId);

        // Assert
        Assert.IsInstanceOf<NoContentResult>(result);
        _mockCompanyRepository.Verify();
    }
}