using System.Security.Claims;
using AutoMapper;
using Kujira.Api.DTOs;
using Kujira.Backend.Offer.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kujira.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OfferController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IOfferRepository _offerRepository;
    private readonly ILogger<OfferController> _logger;

    public OfferController(IOfferRepository offerRepository, IMapper mapper, ILogger<OfferController> logger)
    {
        _offerRepository = offerRepository;
        _mapper = mapper;
        _logger = logger;
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
        var offers = await _offerRepository.GetAllAsync();
        var offerDtos = offers.Select(o => new OfferDto
        {
            Id = o.Id,
            AvailablePlaces = o.AvailablePlaces,
            LongTermFamilyCare = o.LongTermFamilyCare,
            CrisisIntervention = o.CrisisIntervention,
            ReliefOffer = o.ReliefOffer,
            CurrentlyPlacedFosterChildren = o.CurrentlyPlacedFosterChildren,
            BiologicalChildren = o.BiologicalChildren,
            AdditionalNote = o.AdditionalNote,
            IsInactive = o.IsInactive,
            PhoneNumber = o.User?.Company?.PhoneNumber,
            EMailAddress = o.User?.Company?.EMailAddress,
            CompanyName = o.User?.Company?.Name,
            ZipCode = o.User?.Company?.Address?.Zip?.Code,
            City = o.User?.Company?.Address?.Zip?.City, 
            ZipId = o.ZipId,
            UserId = o.UserId,

            
        });

        return Ok(offerDtos);
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