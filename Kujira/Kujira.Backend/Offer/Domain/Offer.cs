namespace Kujira.Backend.Offer.Domain;

internal class Offer
{
    public Guid Id { get; set; }
    public Company.Domain.Company Company { get; set; }
    public Address.Domain.Address Address { get; set; }
    public int AvailablePlaces { get; set; }

    public bool LongTermFamilyCare { get; set; }
    public bool CrisisIntervention { get; set; }
    public bool ReliefOffer { get; set; }
    public string Residence { get; set; }
    public int CurrentlyPlacedFosterChildren { get; set; }
    public int BiologicalChildren { get; set; }
    public bool Availability { get; set; }
    public string AdditionalNote { get; set; }
}