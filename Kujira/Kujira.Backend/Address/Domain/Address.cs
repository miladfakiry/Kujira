namespace Kujira.Backend.Address.Domain;

public class Address
{
    public Guid Id { get; set; }
    public string Street { get; set; }
    public string StreetNumber { get; set; }
    public Zip Zip { get; set; }
}