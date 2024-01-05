using AutoMapper;
using Kujira.Api.DTOs;
using Kujira.Backend.Models;
using Kujira.Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kujira.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OfferController : ControllerBase
{
    private readonly ILogger<OfferController> _logger;
    private readonly IMapper _mapper;
    private readonly IOfferRepository _offerRepository;
    private readonly IServiceRequestRepository _serviceRequestRepository;
    private readonly IZipRepository _zipRepository;

    public OfferController(IOfferRepository offerRepository, IZipRepository zipRepository, IMapper mapper, ILogger<OfferController> logger, IServiceRequestRepository serviceRequestRepository)
    {
        _offerRepository = offerRepository;
        _zipRepository = zipRepository;
        _mapper = mapper;
        _logger = logger;
        _serviceRequestRepository = serviceRequestRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOffer([FromBody] OfferDto offerDto)
    {
        try
        {
            var offer = _mapper.Map<Offer>(offerDto);
            offer.ZipId = offerDto.ZipId;

            await _offerRepository.AddAsync(offer);
            return Ok(offer.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error in CreateOffer: {ex.Message}");
            return StatusCode(500, ex.Message);
        }
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetOfferById(Guid id)
    {
        var offer = await _offerRepository.GetByIdAsync(id);
        if (offer == null)
        {
            return NotFound();
        }

        var offerDto = _mapper.Map<OfferDto>(offer);
        return Ok(offerDto);
    }

    [HttpGet("User/{userId}")]
    public async Task<IActionResult> GetUserOffers(Guid userId)
    {
        try
        {
            var offers = await _offerRepository.GetOffersByUserIdAsync(userId);
            var offerDtos = offers.Select(o => _mapper.Map<OfferDto>(o));
            return Ok(offerDtos);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error in GetUserOffers: {ex.Message}");
            return StatusCode(500, ex.Message);
        }
    }


    [HttpGet]
    public async Task<IActionResult> GetAllOffers()
    {
        try
        {
            var offers = await _offerRepository.GetAllAsync();

            var offerDtos = new List<OfferDto>();

            foreach (var offer in offers)
            {
                var zip = await _zipRepository.GetByIdAsync(offer.ZipId);

                var offerDto = new OfferDto
                {
                    Id = offer.Id,
                    AvailablePlaces = offer.AvailablePlaces,
                    LongTermFamilyCare = offer.LongTermFamilyCare,
                    CrisisIntervention = offer.CrisisIntervention,
                    ReliefOffer = offer.ReliefOffer,
                    CurrentlyPlacedFosterChildren = offer.CurrentlyPlacedFosterChildren,
                    BiologicalChildren = offer.BiologicalChildren,
                    AdditionalNote = offer.AdditionalNote,
                    IsInactive = offer.IsInactive,
                    PhoneNumber = offer.User?.Company?.PhoneNumber,
                    EMailAddress = offer.User?.Company?.EMailAddress,
                    CompanyName = offer.User?.Company?.Name,
                    ZipCode = zip?.Code,
                    City = zip?.City,
                    ZipId = offer.ZipId,
                    UserId = offer.UserId
                };

                offerDtos.Add(offerDto);
            }

            return Ok(offerDtos);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error in GetAllOffers: {ex.Message}");
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOffer(Guid id, [FromBody] OfferDto offerDto)
    {
        try
        {
            var offer = await _offerRepository.GetByIdAsync(id);
            if (offer == null)
            {
                return NotFound();
            }

            offer.AvailablePlaces = offerDto.AvailablePlaces;
            offer.LongTermFamilyCare = offerDto.LongTermFamilyCare;
            offer.CrisisIntervention = offerDto.CrisisIntervention;
            offer.ReliefOffer = offerDto.ReliefOffer;
            offer.CurrentlyPlacedFosterChildren = offerDto.CurrentlyPlacedFosterChildren;
            offer.BiologicalChildren = offerDto.BiologicalChildren;
            offer.AdditionalNote = offerDto.AdditionalNote;
            offer.IsInactive = offerDto.IsInactive;
            offer.ZipId = offerDto.ZipId;


            await _offerRepository.UpdateAsync(offer);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error in UpdateOffer: {ex.Message}");
            return StatusCode(500, ex.Message);
        }
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOffer(Guid id)
    {
        var offer = await _offerRepository.GetByIdAsync(id);
        if (offer == null)
        {
            return NotFound();
        }

        await _offerRepository.DeleteAsync(offer);
        return Ok();
    }
}