using AutoMapper;
using Kujira.Api.DTOs;
using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Kujira.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;
    private readonly IZipRepository _zipRepository;

    public CompanyController(ICompanyRepository companyRepository, IMapper mapper, IZipRepository zipRepository)
    {
        _companyRepository = companyRepository ?? throw new ArgumentException(nameof(companyRepository));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        _zipRepository = zipRepository ?? throw new ArgumentException(nameof(zipRepository));
    }

    [HttpGet]
    public ActionResult<IEnumerable<Company>> GetCompanies()
    {
        var companies = _companyRepository.GetAll();
        var companyDtos = _mapper.Map<IEnumerable<CompanyDto>>(companies);
        return Ok(companyDtos);
    }

    [HttpGet("{id}")]
    public ActionResult<Company> GetCompany(Guid id)
    {
        var company = _companyRepository.Get(id);
        if (company == null)
        {
            return NotFound();
        }

        var companyDto = _mapper.Map<CompanyDto>(company);
        return Ok(companyDto);
    }

    [HttpPost]
    public ActionResult<CompanyDto> CreateCompany(CompanyDto companyDto)
    {
        var company = _mapper.Map<Company>(companyDto);
        var zip = _zipRepository.GetByCodeWithCantonAndCountry(companyDto.ZipCode);
        if (zip == null)
        {
            return BadRequest("Zip-Code ist ungültig.");
        }

        var address = new Address(Guid.NewGuid(), companyDto.Street, companyDto.StreetNumber, zip);
        company.Address = address;
        _companyRepository.Create(company);

        return CreatedAtAction(nameof(GetCompany), new
        {
            id = company.Id
        }, _mapper.Map<Company>(company));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCompany(Guid id, CompanyDto companyDto)
    {
        Console.WriteLine($"Aktualisierung der Firma {id} mit den Daten: {JsonConvert.SerializeObject(companyDto)}");

        var company = _companyRepository.Get(id);
        if (company == null)
        {
            throw new KeyNotFoundException("Company not found");
        }

        var address = company.Address;
        if (address == null)
        {
            throw new KeyNotFoundException("Address not found");
        }

        address.Street = companyDto.Street;
        address.StreetNumber = companyDto.StreetNumber;
        address.Zip.Code = companyDto.ZipCode;
        address.Zip.City = companyDto.City;
        address.Zip.Canton.Name = companyDto.CantonName;

        _mapper.Map(companyDto, company);
        _companyRepository.Update(company);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCompany(Guid id)
    {
        var company = _companyRepository.Get(id);
        if (company == null)
        {
            return NotFound();
        }

        _companyRepository.Delete(id);
        return NoContent();
    }
}