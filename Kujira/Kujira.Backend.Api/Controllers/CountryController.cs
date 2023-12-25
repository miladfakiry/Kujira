using AutoMapper;
using Kujira.Api.DTOs;
using Kujira.Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kujira.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly IMapper _mapper;
    private ICountryRepository _countryRepository;


    public CountryController(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository ?? throw new ArgumentException(nameof(countryRepository));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }


    [HttpGet]
    public ActionResult<IEnumerable<CountryDto>> GetCountries()
    {
        var countries = _countryRepository.GetAll();
        var countryDtos = _mapper.Map<IEnumerable<CountryDto>>(countries);
        return Ok(countryDtos);
    }
}