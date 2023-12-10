namespace Kujira.Api.Requests;

public class OfferRequest
{
    public Guid Id { get; set; }
    public int AvailablePlaces { get; set; }
    public bool LongTermFamilyCare { get; set; }
    public bool CrisisIntervention { get; set; }
    public bool ReliefOffer { get; set; }
    public int CurrentlyPlacedFosterChildren { get; set; }
    public int BiologicalChildren { get; set; }
    public string AdditionalNote { get; set; }
    public Guid ZipId { get; set; }
    public Guid UserId { get; set; }
    public string PhoneNumber { get; set; }
    public string EMailAddress { get; set; }
    public string ZipCode { get; set; }
    public string CompanyName { get; set; }
    public string City { get; set; }

}