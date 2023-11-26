using Kujira.Backend.Company.Domain;
using Kujira.Backend.Shared.Persistence;

namespace Kujira.Backend.Offer.Domain;

public class Offer : DbItem
{
    public Offer(Guid id, int availablePlaces, bool longTermFamilyCare, bool crisisIntervention, bool reliefOffer, int currentlyPlacedFosterChildren, int biologicalChildren, string additionalNote,
        bool isInactive, DateTime createdAt, Zip zip, User.Domain.User user) : base(id)
    {
        Id = id;
        AvailablePlaces = availablePlaces;
        LongTermFamilyCare = longTermFamilyCare;
        CrisisIntervention = crisisIntervention;
        ReliefOffer = reliefOffer;
        CurrentlyPlacedFosterChildren = currentlyPlacedFosterChildren;
        BiologicalChildren = biologicalChildren;
        AdditionalNote = additionalNote;
        IsInactive = isInactive;
        CreatedAt = createdAt;
        Zip = zip;
        ZipId = zip.Id;
        User = user;
        UserId = user.Id;
    }

    public Offer(Guid id, int availablePlaces, bool longTermFamilyCare, bool crisisIntervention, bool reliefOffer, int currentlyPlacedFosterChildren, int biologicalChildren, string additionalNote,
        bool isInactive, DateTime createdAt, Guid zipId, Guid userId) : base(id)
    {
        Id = id;
        AvailablePlaces = availablePlaces;
        LongTermFamilyCare = longTermFamilyCare;
        CrisisIntervention = crisisIntervention;
        ReliefOffer = reliefOffer;
        CurrentlyPlacedFosterChildren = currentlyPlacedFosterChildren;
        BiologicalChildren = biologicalChildren;
        AdditionalNote = additionalNote;
        IsInactive = isInactive;
        CreatedAt = createdAt;
        ZipId = zipId;
        UserId = userId;
    }

    public Guid Id { get; set; }
    public int AvailablePlaces { get; set; }
    public bool LongTermFamilyCare { get; set; }
    public bool CrisisIntervention { get; set; }
    public bool ReliefOffer { get; set; }
    public int CurrentlyPlacedFosterChildren { get; set; }
    public int BiologicalChildren { get; set; }
    public string AdditionalNote { get; set; }
    public bool IsInactive { get; set; }
    public DateTime CreatedAt { get; set; }
    public Zip Zip { get; set; }
    public Guid ZipId { get; set; }

    public User.Domain.User User { get; set; }
    public Guid UserId { get; set; }
}