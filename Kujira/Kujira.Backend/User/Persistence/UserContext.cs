using Kujira.Backend.Shared.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Kujira.Backend.User.Persistence;

public class UserContext : DbContextBase<Domain.User>
{
    public UserContext(DbContextOptions options) : base(options)
    {
    }


    public virtual DbSet<Domain.User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.User>(entity =>
        {
            entity.ToTable("users", "public");
            entity.HasKey(i => i.Id).HasName("PK_UserId");
            entity.Property(i => i.Id).HasColumnName("UserId").HasColumnType("uuid").IsRequired();
            entity.Property(i => i.FirstName).HasColumnName("UseFirstName").HasColumnType("character varying").HasMaxLength(255);
            entity.Property(i => i.LastName).HasColumnName("UseLastName").HasColumnType("character varying").HasMaxLength(255);
            entity.Property(i => i.DateOfBirth).HasColumnName("UseDateOfBirth").HasColumnType("date");
            entity.Property(i => i.EMail).HasColumnName("UseEMail").HasColumnType("character varying").HasMaxLength(255);
            entity.Property(i => i.PhoneNumber).HasColumnName("UsePhoneNumber").HasColumnType("character varying").HasMaxLength(255).IsRequired(false);
            entity.Property(i => i.CreateDate).HasColumnName("UseCreateDate").HasColumnType("timestamp without time zone").HasDefaultValueSql("NOW()");
            entity.Property(i => i.IsInactive).HasColumnName("UseIsInactive").HasColumnType("boolean").HasDefaultValueSql("false");
        });
    }
}