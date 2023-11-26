﻿// <auto-generated />
using System;
using Kujira.Backend.User.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Kujira.Backend.Migrations
{
    [DbContext(typeof(KujiraContext))]
    [Migration("20231110174925_NewInitialMigration")]
    partial class NewInitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Kujira.Backend.Company.Domain.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("AddressID")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("AddStreet");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("AddStreetNumber");

                    b.Property<Guid>("ZipId")
                        .HasColumnType("uuid")
                        .HasColumnName("AddZipID_FK");

                    b.HasKey("Id")
                        .HasName("PK_AddressID");

                    b.HasIndex("ZipId");

                    b.ToTable("Addresses", "public");
                });

            modelBuilder.Entity("Kujira.Backend.Company.Domain.Canton", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("CantonID")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uuid")
                        .HasColumnName("CanCountryID_FK");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("CanName");

                    b.HasKey("Id")
                        .HasName("PK_CantonID");

                    b.HasIndex("CountryId");

                    b.ToTable("Cantons", "public");
                });

            modelBuilder.Entity("Kujira.Backend.Company.Domain.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("CompanyID")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uuid")
                        .HasColumnName("ComAddressID");

                    b.Property<Guid>("CompanyTypeId")
                        .HasColumnType("uuid")
                        .HasColumnName("ComCompanyTypeID");

                    b.Property<string>("EMailAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ComEMail");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ComName");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ComPhoneNumber");

                    b.Property<string>("WebsiteAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ComWebsiteAddress");

                    b.HasKey("Id")
                        .HasName("PK_CompanyID");

                    b.HasIndex("AddressId");

                    b.HasIndex("CompanyTypeId");

                    b.ToTable("Companies", "public");
                });

            modelBuilder.Entity("Kujira.Backend.Company.Domain.CompanyType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("CompanyTypeID")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("CompType");

                    b.HasKey("Id")
                        .HasName("PK_CompanyTypeID");

                    b.ToTable("CompanyTypes", "public");
                });

            modelBuilder.Entity("Kujira.Backend.Company.Domain.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("CountryID")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("CouName");

                    b.HasKey("Id")
                        .HasName("PK_CountryID");

                    b.ToTable("Countries", "public");
                });

            modelBuilder.Entity("Kujira.Backend.Company.Domain.Zip", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ZipID")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid>("CantonId")
                        .HasColumnType("uuid")
                        .HasColumnName("ZipCantonID_FK");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ZipCity");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ZipCode");

                    b.HasKey("Id")
                        .HasName("PK_ZipID");

                    b.HasIndex("CantonId");

                    b.ToTable("Zips", "public");
                });

            modelBuilder.Entity("Kujira.Backend.Offer.Domain.Offer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("OfferID")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("AdditionalNote")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("OffAdditionalNote");

                    b.Property<int>("AvailablePlaces")
                        .HasColumnType("integer")
                        .HasColumnName("OffAvailablePlaces");

                    b.Property<int>("BiologicalChildren")
                        .HasColumnType("integer")
                        .HasColumnName("OffBiologicalChildren");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("OffCreatedAt");

                    b.Property<bool>("CrisisIntervention")
                        .HasColumnType("boolean")
                        .HasColumnName("OffCrisisIntervention");

                    b.Property<int>("CurrentlyPlacedFosterChildren")
                        .HasColumnType("integer")
                        .HasColumnName("OffCurrentlyPlacedFosterChildren");

                    b.Property<bool>("IsInactive")
                        .HasColumnType("boolean")
                        .HasColumnName("OffIsInactive");

                    b.Property<bool>("LongTermFamilyCare")
                        .HasColumnType("boolean")
                        .HasColumnName("OffLongTermFamilyCare");

                    b.Property<bool>("ReliefOffer")
                        .HasColumnType("boolean")
                        .HasColumnName("OffReliefOffer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ZipId")
                        .HasColumnType("uuid")
                        .HasColumnName("OffZipID_FK");

                    b.HasKey("Id")
                        .HasName("PK_OfferID");

                    b.HasIndex("UserId");

                    b.HasIndex("ZipId");

                    b.ToTable("Offers", "public");
                });

            modelBuilder.Entity("Kujira.Backend.Request.Domain.Request", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("RequestID")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("AdditionalNote")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ReqAdditionalNote");

                    b.Property<int>("BiologicalChildren")
                        .HasColumnType("integer")
                        .HasColumnName("ReqBiologicalChildren");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("ReqCreatedAt");

                    b.Property<bool>("CrisisIntervention")
                        .HasColumnType("boolean")
                        .HasColumnName("ReqCrisisIntervention");

                    b.Property<int>("CurrentlyPlacedFosterChildren")
                        .HasColumnType("integer")
                        .HasColumnName("ReqCurrentlyPlacedFosterChildren");

                    b.Property<bool>("IsInactive")
                        .HasColumnType("boolean")
                        .HasColumnName("ReqIsInactive");

                    b.Property<bool>("LongTermFamilyCare")
                        .HasColumnType("boolean")
                        .HasColumnName("ReqLongTermFamilyCare");

                    b.Property<int>("NeededPlaceAmount")
                        .HasColumnType("integer")
                        .HasColumnName("ReqNeededPlaces");

                    b.Property<bool>("ReliefOffer")
                        .HasColumnType("boolean")
                        .HasColumnName("ReqReliefOffer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ZipId")
                        .HasColumnType("uuid")
                        .HasColumnName("ReqZipID_FK");

                    b.HasKey("Id")
                        .HasName("PK_RequestID");

                    b.HasIndex("UserId");

                    b.HasIndex("ZipId");

                    b.ToTable("Requests", "public");
                });

            modelBuilder.Entity("Kujira.Backend.User.Domain.Login", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("LoginID")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying")
                        .HasColumnName("LogEmail");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("LogPassword");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("PK_LoginID");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Logins", "public");
                });

            modelBuilder.Entity("Kujira.Backend.User.Domain.PersonalInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("PersonalInformationID")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("PerInfDateOfBirth");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("PerInfPhoneNumber");

                    b.HasKey("Id")
                        .HasName("PK_PersonalInformationID");

                    b.ToTable("PersonalInformation", "public");
                });

            modelBuilder.Entity("Kujira.Backend.User.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("UserID")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("UseCreateDate")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying")
                        .HasColumnName("UseFirstName");

                    b.Property<bool>("IsInactive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasColumnName("UseIsInactive")
                        .HasDefaultValueSql("false");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying")
                        .HasColumnName("UseLastName");

                    b.Property<Guid>("PersonalInformationId")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("PK_UserID");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PersonalInformationId")
                        .IsUnique();

                    b.ToTable("Users", "public");
                });

            modelBuilder.Entity("Kujira.Backend.Company.Domain.Address", b =>
                {
                    b.HasOne("Kujira.Backend.Company.Domain.Zip", "Zip")
                        .WithMany()
                        .HasForeignKey("ZipId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Zip");
                });

            modelBuilder.Entity("Kujira.Backend.Company.Domain.Canton", b =>
                {
                    b.HasOne("Kujira.Backend.Company.Domain.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Kujira.Backend.Company.Domain.Company", b =>
                {
                    b.HasOne("Kujira.Backend.Company.Domain.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Kujira.Backend.Company.Domain.CompanyType", "CompanyType")
                        .WithMany()
                        .HasForeignKey("CompanyTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("CompanyType");
                });

            modelBuilder.Entity("Kujira.Backend.Company.Domain.Zip", b =>
                {
                    b.HasOne("Kujira.Backend.Company.Domain.Canton", "Canton")
                        .WithMany()
                        .HasForeignKey("CantonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Canton");
                });

            modelBuilder.Entity("Kujira.Backend.Offer.Domain.Offer", b =>
                {
                    b.HasOne("Kujira.Backend.User.Domain.User", "User")
                        .WithMany("Offers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Kujira.Backend.Company.Domain.Zip", "Zip")
                        .WithMany()
                        .HasForeignKey("ZipId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Zip");
                });

            modelBuilder.Entity("Kujira.Backend.Request.Domain.Request", b =>
                {
                    b.HasOne("Kujira.Backend.User.Domain.User", "User")
                        .WithMany("Requests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Kujira.Backend.Company.Domain.Zip", "Zip")
                        .WithMany()
                        .HasForeignKey("ZipId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Zip");
                });

            modelBuilder.Entity("Kujira.Backend.User.Domain.Login", b =>
                {
                    b.HasOne("Kujira.Backend.User.Domain.User", "User")
                        .WithOne()
                        .HasForeignKey("Kujira.Backend.User.Domain.Login", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Kujira.Backend.User.Domain.User", b =>
                {
                    b.HasOne("Kujira.Backend.Company.Domain.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kujira.Backend.User.Domain.PersonalInformation", "PersonalInformation")
                        .WithOne("User")
                        .HasForeignKey("Kujira.Backend.User.Domain.User", "PersonalInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("PersonalInformation");
                });

            modelBuilder.Entity("Kujira.Backend.Company.Domain.Company", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Kujira.Backend.User.Domain.PersonalInformation", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("Kujira.Backend.User.Domain.User", b =>
                {
                    b.Navigation("Offers");

                    b.Navigation("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}
