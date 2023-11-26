using Kujira.Backend.Shared.Persistence;

namespace Kujira.Backend.Company.Domain;

public class Zip : DbItem
{
    public Zip(Guid id, string code, string city, Canton canton) : base(id)
    {
        Id = id;
        Code = code;
        City = city;
        Canton = canton;
        CantonId = canton.Id;
    }

    public Zip(Guid id, string code, string city, Guid cantonId) : base(id)
    {
        Id = id;
        Code = code;
        City = city;
        CantonId = cantonId;
    }


    public Guid Id { get; set; }
    public string Code { get; set; }
    public string City { get; set; }
    public Canton Canton { get; set; }
    public Guid CantonId { get; set; }
}