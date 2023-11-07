namespace Kujira.Backend.Company.Domain;

public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Address.Domain.Address Address { get; set; }
    public CompanyType CompanyType { get; set; }
}