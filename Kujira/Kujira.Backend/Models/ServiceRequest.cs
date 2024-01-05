using Kujira.Backend.Enums;

namespace Kujira.Backend.Models;

public class ServiceRequest
{
    public Guid RequestId { get; set; }
    public Guid OfferId { get; set; }
    public Guid FromUserId { get; set; }
    public Guid ToUserId { get; set; }
    public string Message { get; set; }
    public string FromUserEMail { get; set; }
    public RequestStatus RequestStatus { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    // Navigation Properties
    public Offer Offer { get; set; }
    public User FromUser { get; set; }
    public User ToUser { get; set; }
}