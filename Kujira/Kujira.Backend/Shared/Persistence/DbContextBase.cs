using Microsoft.EntityFrameworkCore;

namespace Kujira.Backend.Shared.Persistence;

public class DbContextBase<T> : DbContext where T : DbItem
{
    public DbSet<T>? DbSet { get; set; }

    public DbContextBase(DbContextOptions options) : base(options)
    {
    }
}
