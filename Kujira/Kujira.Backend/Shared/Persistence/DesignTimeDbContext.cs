using Kujira.Backend.User.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Kujira.Backend.Shared.Persistence;

public class DesignTimeDbContext : IDesignTimeDbContextFactory<UserContext>
{
    public UserContext CreateDbContext(string[] args)
    {
        var connectionString = "User ID=postgres;password=ku#123#jira#456#!;Host=localhost;Port=5432;Database=kujira";

        var builder = new DbContextOptionsBuilder<UserContext>();

        builder.UseNpgsql(connectionString);
        return new UserContext(builder.Options);
    }
}