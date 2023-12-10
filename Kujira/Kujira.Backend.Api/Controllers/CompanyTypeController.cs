using AutoMapper;
using Kujira.Api.DTOs;
using Kujira.Backend.Company.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Kujira.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyTypeController : ControllerBase
{
    private readonly ICompanyTypeRepository _companyTypeRepository;
    private readonly IMapper _mapper;

    public CompanyTypeController(ICompanyTypeRepository companyTypeRepository, IMapper mapper)
    {
        _companyTypeRepository = companyTypeRepository ?? throw new ArgumentNullException(nameof(companyTypeRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public ActionResult<IEnumerable<CompanyTypeDto>> GetCompanyTypes()
    {
        var companyTypes =  _companyTypeRepository.GetAll();
        var companyTypeDtos = _mapper.Map<IEnumerable<CompanyTypeDto>>(companyTypes);
        return Ok(companyTypeDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CompanyTypeDto>> GetCompanyType(Guid id)
    {
        var companyType = _companyTypeRepository.Get(id);
        if (companyType == null)
        {
            return NotFound();
        }

        var companyTypeDto = _mapper.Map<CompanyTypeDto>(companyType);
        return Ok(companyTypeDto);
    }

    [HttpPost]
    public async Task<ActionResult<CompanyTypeDto>> CreateCompanyType(CompanyTypeDto companyTypeDto)
    {
        var companyType = _mapper.Map<CompanyType>(companyTypeDto);
        _companyTypeRepository.Create(companyType);
        return CreatedAtAction(nameof(GetCompanyType), new
        {
            id = companyType.Id
        }, companyTypeDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompanyType(Guid id, CompanyTypeDto companyTypeDto)
    {
        if (id != companyTypeDto.Id)
        {
            return BadRequest();
        }

        var companyType = _companyTypeRepository.Get(id);
        if (companyType == null)
        {
            return NotFound();
        }

        _mapper.Map(companyTypeDto, companyType);
        _companyTypeRepository.Update(companyType);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompanyType(Guid id)
    {
        var companyType = _companyTypeRepository.Get(id);
        if (companyType == null)
        {
            return NotFound();
        }

        _companyTypeRepository.Delete(id);
        return NoContent();
    }
}