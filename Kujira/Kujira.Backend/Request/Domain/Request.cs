namespace Kujira.Backend.Request.Domain;

internal class Request
{
    public Guid Id { get; set; }
    public string Status { get; set; }
    public DateTime RequestDate { get; set; }
    public string NeededPlaceCriteria { get; set; }
}