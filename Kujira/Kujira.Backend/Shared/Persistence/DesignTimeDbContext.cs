using Kujira.Backend.User.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Kujira.Backend.Shared.Persistence;

public class DesignTimeDbContext : IDesignTimeDbContextFactory<KujiraContext>
{
    public KujiraContext CreateDbContext(string[] args)
    {
        var connectionString = "User ID=postgres;password=ku#123#jira#456#!;Host=localhost;Port=5432;Database=kujira";

        var builder = new DbContextOptionsBuilder<KujiraContext>();

        builder.UseNpgsql(connectionString);
        return new KujiraContext(builder.Options);
    }
}