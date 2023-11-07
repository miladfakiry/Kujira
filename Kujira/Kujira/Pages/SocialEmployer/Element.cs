namespace Kujira.Pages.SocialEmployer;

public class Element
{
    public int Id { get; set; }
    public string Association { get; set; }
    public int AvailablePlaces { get; set; }
    public string PhoneNumber { get; set; }
    public string EMailAddresse { get; set; }

    public bool LongTermFamilyCare { get; set; }
    public bool CrisisIntervention { get; set; }
    public bool ReliefOffer { get; set; }

    public string Residence { get; set; }
    public int CurrentlyPlacedFosterChildren { get; set; }
    public int BiologicalChildren { get; set; }
}