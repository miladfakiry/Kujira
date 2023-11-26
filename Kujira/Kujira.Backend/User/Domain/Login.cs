using Kujira.Backend.Shared.Persistence;

namespace Kujira.Backend.User.Domain;

public class Login : DbItem
{

    public Login(Guid id, string email, string password) : base(id)
    {
        Id = id;
        Email = email;
        Password = password;
    }

    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public User User { get; set; }
    public Guid UserId { get; set; }

}