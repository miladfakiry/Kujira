namespace Kujira.Backend.Models;

internal class Notification
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }
}