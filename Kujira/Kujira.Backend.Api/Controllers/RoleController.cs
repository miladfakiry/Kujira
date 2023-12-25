using AutoMapper;
using Kujira.Api.DTOs;
using Kujira.Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kujira.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository ?? throw new ArgumentException(nameof(_roleRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoleDto>> GetAllRoles()
        {
            var roles = _roleRepository.GetAll();
            var roleDtos = _mapper.Map<IEnumerable<RoleDto>>(roles);
            return Ok(roles);
        }
    }
}
