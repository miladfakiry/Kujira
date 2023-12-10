using Kujira.Backend.Company.Domain;
using Kujira.Backend.User.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kujira.Backend.User.Persistence;

public class KujiraContext : DbContext
{
    public KujiraContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<Domain.User?> Users { get; set; }
    public virtual DbSet<PersonalInformation> PersonalInformation { get; set; }
    public virtual DbSet<Address> Addresses { get; set; }
    public virtual DbSet<Zip> Zips { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<Canton> Cantons { get; set; }
    public virtual DbSet<Company.Domain.Company?> Companies { get; set; }
    public virtual DbSet<CompanyType> CompanyTypes { get; set; }
    public virtual DbSet<Offer.Domain.Offer> Offers { get; set; }
    public virtual DbSet<Request.Domain.Request> Requests { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<UserRole> UserRoles { get; set; }
    public virtual DbSet<Login> Logins { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Login>(loginEntity =>
        {
            loginEntity.ToTable("Logins", "public");
            loginEntity.HasKey(l => l.Id).HasName("PK_LoginID");
            loginEntity.Property(l => l.Id).HasColumnName("LoginID").HasColumnType("uuid").IsRequired().HasDefaultValueSql("gen_random_uuid()");
            loginEntity.Property(l => l.Email).HasColumnName("LogEmail").HasColumnType("character varying").HasMaxLength(255).IsRequired();
            loginEntity.Property(l => l.Password).HasColumnName("LogPassword").HasColumnType("character varying").IsRequired();

            loginEntity.HasOne(login => login.User).WithOne().HasForeignKey<Login>(login => login.UserId);
        });

        modelBuilder.Entity<Domain.User>(userEntity =>
        {
            userEntity.ToTable("Users", "public");
            userEntity.HasKey(i => i.Id).HasName("PK_UserID");
            userEntity.Property(i => i.Id).HasColumnName("UserID").HasColumnType("uuid").IsRequired().HasDefaultValueSql("gen_random_uuid()");
            userEntity.Property(i => i.FirstName).HasColumnName("UseFirstName").HasColumnType("character varying").HasMaxLength(255);
            userEntity.Property(i => i.LastName).HasColumnName("UseLastName").HasColumnType("character varying").HasMaxLength(255);
            userEntity.Property(i => i.CreateDate).HasColumnName("UseCreateDate").HasColumnType("timestamp without time zone").HasDefaultValueSql("NOW()");
            userEntity.Property(i => i.IsInactive).HasColumnName("UseIsInactive").HasColumnType("boolean").HasDefaultValueSql("false");

            userEntity.HasOne(d => d.Company).WithMany(p => p.Users).HasForeignKey(d => d.CompanyId);

            userEntity.HasOne(u => u.PersonalInformation)
                      .WithOne(p => p.User)
                      .HasForeignKey<PersonalInformation>(pi => pi.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

            userEntity.HasMany(u => u.Offers).WithOne(o => o.User).HasForeignKey(o => o.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

            userEntity.HasMany(d => d.Requests).WithOne(p => p.User).HasForeignKey(d => d.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<PersonalInformation>(personalInformationEntity =>
        {
            personalInformationEntity.ToTable("PersonalInformation", "public");
            personalInformationEntity.HasKey(pi => pi.Id).HasName("PK_PersonalInformationID");
            personalInformationEntity.Property(pi => pi.Id).HasColumnName("PersonalInformationID").HasColumnType("uuid").IsRequired().HasDefaultValueSql("gen_random_uuid()");
            personalInformationEntity.Property(pi => pi.DateOfBirth).HasColumnName("PerInfDateOfBirth").HasColumnType("date").IsRequired();
            personalInformationEntity.Property(pi => pi.PhoneNumber).HasColumnName("PerInfPhoneNumber").HasMaxLength(255);

        });

        modelBuilder.Entity<Role>(roleEntity =>
        {
            roleEntity.ToTable("Roles", "public");
            roleEntity.HasKey(ro => ro.Id).HasName("PK_RoleID");
            roleEntity.Property(ro => ro.Id).HasColumnName("RoleID").HasColumnType("uuid").IsRequired().HasDefaultValueSql("gen_random_uuid()");
            roleEntity.Property(ro => ro.Name).HasColumnName("RolName").HasColumnType("character varying").HasMaxLength(255);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(ur => new { ur.UserId, ur.RoleId });

            entity.HasOne(ur => ur.User)
                  .WithMany(u => u.UserRoles)
                  .HasForeignKey(ur => ur.UserId);

            entity.HasOne(ur => ur.Role)
                  .WithMany(r => r.UserRoles)
                  .HasForeignKey(ur => ur.RoleId);
        });

        modelBuilder.Entity<Offer.Domain.Offer>(offerEntity =>
        {
            offerEntity.ToTable("Offers", "public");
            offerEntity.HasKey(o => o.Id).HasName("PK_OfferID");
            offerEntity.Property(o => o.Id).HasColumnName("OfferID").HasColumnType("uuid").IsRequired().HasDefaultValueSql("gen_random_uuid()");
            offerEntity.Property(o => o.AvailablePlaces).HasColumnName("OffAvailablePlaces");
            offerEntity.Property(o => o.LongTermFamilyCare).HasColumnName("OffLongTermFamilyCare");
            offerEntity.Property(o => o.CrisisIntervention).HasColumnName("OffCrisisIntervention");
            offerEntity.Property(o => o.ReliefOffer).HasColumnName("OffReliefOffer");
            offerEntity.Property(o => o.CurrentlyPlacedFosterChildren).HasColumnName("OffCurrentlyPlacedFosterChildren");
            offerEntity.Property(o => o.BiologicalChildren).HasColumnName("OffBiologicalChildren");
            offerEntity.Property(o => o.AdditionalNote).HasColumnName("OffAdditionalNote").HasColumnType("text");
            offerEntity.Property(o => o.IsInactive).HasColumnName("OffIsInactive");
            offerEntity.Property(o => o.CreatedAt).HasColumnName("OffCreatedAt").HasColumnType("timestamp with time zone").HasDefaultValueSql("NOW()");
            offerEntity.Property(o => o.ZipId).HasColumnName("OffZipID_FK");

            offerEntity.HasOne(o => o.Zip).WithMany().HasForeignKey(o => o.ZipId).OnDelete(DeleteBehavior.Restrict);

            offerEntity.HasOne(o => o.User).WithMany(u => u.Offers).HasForeignKey(o => o.UserId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Request.Domain.Request>(requestEntity =>
        {
            requestEntity.ToTable("Requests", "public");
            requestEntity.HasKey(r => r.Id).HasName("PK_RequestID");
            requestEntity.Property(r => r.Id).HasColumnName("RequestID").HasColumnType("uuid").IsRequired().HasDefaultValueSql("gen_random_uuid()");
            requestEntity.Property(r => r.NeededPlaceAmount).HasColumnName("ReqNeededPlaces");
            requestEntity.Property(r => r.LongTermFamilyCare).HasColumnName("ReqLongTermFamilyCare");
            requestEntity.Property(r => r.CrisisIntervention).HasColumnName("ReqCrisisIntervention");
            requestEntity.Property(r => r.ReliefOffer).HasColumnName("ReqReliefOffer");
            requestEntity.Property(r => r.CurrentlyPlacedFosterChildren).HasColumnName("ReqCurrentlyPlacedFosterChildren");
            requestEntity.Property(r => r.BiologicalChildren).HasColumnName("ReqBiologicalChildren");
            requestEntity.Property(r => r.AdditionalNote).HasColumnName("ReqAdditionalNote").HasColumnType("text");
            requestEntity.Property(r => r.IsInactive).HasColumnName("ReqIsInactive");
            requestEntity.Property(r => r.CreatedAt).HasColumnName("ReqCreatedAt").HasColumnType("timestamp with time zone").HasDefaultValueSql("NOW()");
            requestEntity.Property(r => r.ZipId).HasColumnName("ReqZipID_FK");

            requestEntity.HasOne(o => o.Zip).WithMany().HasForeignKey(o => o.ZipId).OnDelete(DeleteBehavior.Restrict);
            requestEntity.HasOne(r => r.User).WithMany(u => u.Requests).HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Restrict);
        });

        // Address configuration
        modelBuilder.Entity<Address>(addressEntity =>
        {
            addressEntity.ToTable("Addresses", "public");
            addressEntity.HasKey(a => a.Id).HasName("PK_AddressID");
            addressEntity.Property(a => a.Id).HasColumnName("AddressID").HasColumnType("uuid").IsRequired().HasDefaultValueSql("gen_random_uuid()");
            addressEntity.Property(a => a.Street).HasColumnName("AddStreet").IsRequired();
            addressEntity.Property(a => a.StreetNumber).HasColumnName("AddStreetNumber").IsRequired();
            addressEntity.Property(a => a.ZipId).HasColumnName("AddZipID_FK");

            addressEntity.HasOne(a => a.Zip).WithMany().HasForeignKey(a => a.ZipId).OnDelete(DeleteBehavior.Restrict);
        });

        // Zip configuration
        modelBuilder.Entity<Zip>(zipEntity =>
        {
            zipEntity.ToTable("Zips", "public");
            zipEntity.HasKey(z => z.Id).HasName("PK_ZipID");
            zipEntity.Property(z => z.Id).HasColumnName("ZipID").HasColumnType("uuid").IsRequired().HasDefaultValueSql("gen_random_uuid()");
            zipEntity.Property(z => z.Code).HasColumnName("ZipCode").IsRequired();
            zipEntity.Property(z => z.City).HasColumnName("ZipCity").IsRequired();
            zipEntity.Property(z => z.CantonId).HasColumnName("ZipCantonID_FK");

            zipEntity.HasOne(z => z.Canton).WithMany().HasForeignKey(z => z.CantonId).OnDelete(DeleteBehavior.Restrict);
        });

        // Canton configuration
        modelBuilder.Entity<Canton>(cantonEntity =>
        {
            cantonEntity.ToTable("Cantons", "public");
            cantonEntity.HasKey(c => c.Id).HasName("PK_CantonID");
            cantonEntity.Property(c => c.Id).HasColumnName("CantonID").HasColumnType("uuid").IsRequired().HasDefaultValueSql("gen_random_uuid()");
            cantonEntity.Property(c => c.Name).HasColumnName("CanName").IsRequired();
            cantonEntity.Property(c => c.CountryId).HasColumnName("CanCountryID_FK");

            cantonEntity.HasOne(c => c.Country).WithMany().HasForeignKey(c => c.CountryId).OnDelete(DeleteBehavior.Restrict);
        });

        // Country configuration
        modelBuilder.Entity<Country>(countryEntity =>
        {
            countryEntity.ToTable("Countries", "public");
            countryEntity.HasKey(co => co.Id).HasName("PK_CountryID");
            countryEntity.Property(co => co.Id).HasColumnName("CountryID").HasColumnType("uuid").IsRequired().HasDefaultValueSql("gen_random_uuid()");
            countryEntity.Property(co => co.Name).HasColumnName("CouName").IsRequired();
        });

        modelBuilder.Entity<Company.Domain.Company>(companyEntity =>
        {
            companyEntity.ToTable("Companies", "public");
            companyEntity.HasKey(c => c.Id).HasName("PK_CompanyID");
            companyEntity.Property(c => c.Id).HasColumnName("CompanyID").HasColumnType("uuid").IsRequired().HasDefaultValueSql("gen_random_uuid()");
            companyEntity.Property(c => c.Name).HasColumnName("ComName").IsRequired();
            companyEntity.Property(c => c.EMailAddress).HasColumnName("ComEMail").IsRequired();
            companyEntity.Property(c => c.PhoneNumber).HasColumnName("ComPhoneNumber").IsRequired();
            companyEntity.Property(c => c.WebsiteAddress).HasColumnName("ComWebsiteAddress");
            companyEntity.Property(c => c.AddressId).HasColumnName("ComAddressID");
            companyEntity.Property(c => c.CompanyTypeId).HasColumnName("ComCompanyTypeID");

            companyEntity.HasOne(c => c.Address).WithMany().HasForeignKey(c => c.AddressId).OnDelete(DeleteBehavior.Cascade);

            companyEntity.HasOne(c => c.CompanyType).WithMany().HasForeignKey(c => c.CompanyTypeId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<CompanyType>(companyTypeEntity =>
        {
            companyTypeEntity.ToTable("CompanyTypes", "public");
            companyTypeEntity.HasKey(ct => ct.Id).HasName("PK_CompanyTypeID");
            companyTypeEntity.Property(ct => ct.Id).HasColumnName("CompanyTypeID").HasColumnType("uuid").IsRequired().HasDefaultValueSql("gen_random_uuid()");
            companyTypeEntity.Property(ct => ct.Type).HasColumnName("CompType").IsRequired();
        });
    }
}