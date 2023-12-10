namespace Kujira.Api.Requests;

public class UserRequest
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public string? PhoneNumber { get; set; }
    public bool IsInactive { get; set; }
    public DateTime CreateDate { get; set; }
    public Guid CompanyId { get; set; }

    public Guid RoleId { get; set; }

    public string Email { get; set; }
    public string Password { get; set; }
}