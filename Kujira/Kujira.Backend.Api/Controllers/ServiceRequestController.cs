using AutoMapper;
using Kujira.Api.DTOs;
using Kujira.Backend.Enums;
using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kujira.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceRequestController : ControllerBase
{
    private readonly ILogger<ServiceRequestController> _logger;
    private readonly IMapper _mapper;
    private readonly IServiceRequestRepository _serviceRequestRepository;
    private readonly IUserRepository _userRepository;

    public ServiceRequestController(IServiceRequestRepository serviceRequestRepository, IUserRepository userRepository, IMapper mapper, ILogger<ServiceRequestController> logger)
    {
        _serviceRequestRepository = serviceRequestRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }

    // GET: api/ServiceRequest/User/{userId}
    [HttpGet("User/{userId}")]
    public async Task<IActionResult> GetServiceRequestsForUser(Guid userId)
    {
        try
        {
            var serviceRequests = await _serviceRequestRepository.GetServiceRequestsByUserIdAsync(userId);
            var serviceRequestDtos = new List<ServiceRequestDto>();

            foreach (var request in serviceRequests)
            {
                var fromUser = await _userRepository.GetByIdAsync(request.FromUserId);
                var dto = _mapper.Map<ServiceRequestDto>(request);
                dto.RequesterFirstName = fromUser.FirstName;
                dto.RequesterLastName = fromUser.LastName;
                dto.RequesterEmail = request.FromUserEMail;
                dto.RequesterPhoneNumber = fromUser.PersonalInformation.PhoneNumber;

                serviceRequestDtos.Add(dto);
            }

            return Ok(serviceRequestDtos);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error in GetServiceRequestsForUser: {ex.Message}");
            return StatusCode(500, ex.Message);
        }
    }

    // GET: api/ServiceRequest/Offer/{offerId}
    [HttpGet("Offer/{offerId}")]
    public async Task<IActionResult> GetServiceRequestsForOffer(Guid offerId)
    {
        try
        {
            var serviceRequests = await _serviceRequestRepository.GetServiceRequestsByOfferIdAsync(offerId);
            var serviceRequestDtos = new List<ServiceRequestDto>();

            foreach (var request in serviceRequests)
            {
                var fromUser = await _userRepository.GetByIdAsync(request.FromUserId);
                var dto = _mapper.Map<ServiceRequestDto>(request);
                dto.RequesterFirstName = fromUser.FirstName;
                dto.RequesterLastName = fromUser.LastName;
                dto.RequesterEmail = request.FromUserEMail;
                dto.RequesterPhoneNumber = fromUser.PersonalInformation.PhoneNumber;

                serviceRequestDtos.Add(dto);
            }

            return Ok(serviceRequestDtos);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error in GetServiceRequestsForOffer: {ex.Message}");
            return StatusCode(500, ex.Message);
        }
    }


    [HttpPost("SendRequest")]
    public async Task<IActionResult> SendRequest([FromBody] ServiceRequestDto requestDto)
    {
        try
        {
            var serviceRequest = new ServiceRequest
            {
                OfferId = requestDto.OfferId,
                FromUserId = requestDto.FromUserId,
                FromUserEMail = requestDto.RequesterEmail,
                ToUserId = requestDto.ToUserId,
                Message = requestDto.Message,
                RequestStatus = RequestStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            await _serviceRequestRepository.AddAsync(serviceRequest);

            return Ok(serviceRequest.RequestId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Fehler beim Verarbeiten der Anfrage: {Request}", requestDto);
            return StatusCode(500, "Interner Serverfehler");
        }
    }

    [HttpPost("AcceptRequest/{requestId}")]
    public async Task<IActionResult> AcceptRequest(Guid requestId)
    {
        var request = await _serviceRequestRepository.GetByIdAsync(requestId);
        if (request == null)
        {
            return NotFound();
        }

        request.RequestStatus = RequestStatus.Accepted;
        request.UpdatedAt = DateTime.UtcNow;

        await _serviceRequestRepository.UpdateAsync(request);

        return Ok();
    }

    [HttpPost("RejectRequest/{requestId}")]
    public async Task<IActionResult> RejectRequest(Guid requestId)
    {
        var request = await _serviceRequestRepository.GetByIdAsync(requestId);
        if (request == null)
        {
            return NotFound();
        }

        request.RequestStatus = RequestStatus.Rejected;
        request.UpdatedAt = DateTime.UtcNow;

        await _serviceRequestRepository.UpdateAsync(request);

        return Ok();
    }
}