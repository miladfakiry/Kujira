using AutoMapper;
using Kujira.Api.Controllers;
using Kujira.Api.DTOs;
using Kujira.Backend.Company.Domain;
using Kujira.Backend.Company.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Kujira.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ZipController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IZipRepository _zipRepository;

        public ZipController(IZipRepository zipRepository, IMapper mapper)
        {
            _zipRepository = zipRepository ?? throw new ArgumentException(nameof(_zipRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ZipDto>> GetAllZipsCantonsAndCountry()
        {
            var zips = _zipRepository.GetAll();
            var zipDtos = _mapper.Map<IEnumerable<ZipDto>>(zips);
            return Ok(zipDtos);
        }
    }
}


