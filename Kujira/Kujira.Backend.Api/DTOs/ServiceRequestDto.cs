using Kujira.Backend.Enums;

namespace Kujira.Api.DTOs
{
    public class ServiceRequestDto
    {
        public Guid RequestId { get; set; }
        public Guid OfferId { get; set; }
        public Guid FromUserId { get; set; }
        public Guid ToUserId { get; set; }
        public string? Message { get; set; }
        public string? ResponseMessage { get; set; }

        public string RequesterFirstName { get; set; }
        public string RequesterLastName { get; set; }
        public string RequesterEmail { get; set; }
        public string? RequesterPhoneNumber { get; set; }

        public DateTime CreatedAt { get; set; }
        public RequestStatus RequestStatus { get; set; }
    }
}
