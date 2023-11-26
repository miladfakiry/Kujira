using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kujira.Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "CompanyTypes",
                schema: "public",
                columns: table => new
                {
                    CompanyTypeID = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    CompType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTypeID", x => x.CompanyTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "public",
                columns: table => new
                {
                    CountryID = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    CouName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryID", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInformation",
                schema: "public",
                columns: table => new
                {
                    PersonalInformationID = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    PerInfDateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    PerInfPhoneNumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInformationID", x => x.PersonalInformationID);
                });

            migrationBuilder.CreateTable(
                name: "Cantons",
                schema: "public",
                columns: table => new
                {
                    CantonID = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    CanName = table.Column<string>(type: "text", nullable: false),
                    CanCountryID_FK = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CantonID", x => x.CantonID);
                    table.ForeignKey(
                        name: "FK_Cantons_Countries_CanCountryID_FK",
                        column: x => x.CanCountryID_FK,
                        principalSchema: "public",
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zips",
                schema: "public",
                columns: table => new
                {
                    ZipID = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    ZipCode = table.Column<string>(type: "text", nullable: false),
                    ZipCity = table.Column<string>(type: "text", nullable: false),
                    ZipCantonID_FK = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipID", x => x.ZipID);
                    table.ForeignKey(
                        name: "FK_Zips_Cantons_ZipCantonID_FK",
                        column: x => x.ZipCantonID_FK,
                        principalSchema: "public",
                        principalTable: "Cantons",
                        principalColumn: "CantonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "public",
                columns: table => new
                {
                    AddressID = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    AddStreet = table.Column<string>(type: "text", nullable: false),
                    AddStreetNumber = table.Column<string>(type: "text", nullable: false),
                    AddZipID_FK = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressID", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Addresses_Zips_AddZipID_FK",
                        column: x => x.AddZipID_FK,
                        principalSchema: "public",
                        principalTable: "Zips",
                        principalColumn: "ZipID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "public",
                columns: table => new
                {
                    CompanyID = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    ComName = table.Column<string>(type: "text", nullable: false),
                    ComEMail = table.Column<string>(type: "text", nullable: false),
                    ComPhoneNumber = table.Column<string>(type: "text", nullable: false),
                    ComWebsiteAddress = table.Column<string>(type: "text", nullable: false),
                    ComAddressID = table.Column<Guid>(type: "uuid", nullable: false),
                    ComCompanyTypeID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyID", x => x.CompanyID);
                    table.ForeignKey(
                        name: "FK_Companies_Addresses_ComAddressID",
                        column: x => x.ComAddressID,
                        principalSchema: "public",
                        principalTable: "Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_CompanyTypes_ComCompanyTypeID",
                        column: x => x.ComCompanyTypeID,
                        principalSchema: "public",
                        principalTable: "CompanyTypes",
                        principalColumn: "CompanyTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "public",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    UseFirstName = table.Column<string>(type: "character varying", maxLength: 255, nullable: false),
                    UseLastName = table.Column<string>(type: "character varying", maxLength: 255, nullable: false),
                    UseIsInactive = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "false"),
                    UseCreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    LoginId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonalInformationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserID", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "public",
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_PersonalInformation_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalSchema: "public",
                        principalTable: "PersonalInformation",
                        principalColumn: "PersonalInformationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                schema: "public",
                columns: table => new
                {
                    LoginID = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    LogEmail = table.Column<string>(type: "character varying", maxLength: 255, nullable: false),
                    LogPassword = table.Column<string>(type: "character varying", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginID", x => x.LoginID);
                    table.ForeignKey(
                        name: "FK_Logins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                schema: "public",
                columns: table => new
                {
                    OfferID = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    OffAvailablePlaces = table.Column<int>(type: "integer", nullable: false),
                    OffLongTermFamilyCare = table.Column<bool>(type: "boolean", nullable: false),
                    OffCrisisIntervention = table.Column<bool>(type: "boolean", nullable: false),
                    OffReliefOffer = table.Column<bool>(type: "boolean", nullable: false),
                    OffCurrentlyPlacedFosterChildren = table.Column<int>(type: "integer", nullable: false),
                    OffBiologicalChildren = table.Column<int>(type: "integer", nullable: false),
                    OffAdditionalNote = table.Column<string>(type: "text", nullable: false),
                    OffIsInactive = table.Column<bool>(type: "boolean", nullable: false),
                    OffCreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    OffZipID_FK = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferID", x => x.OfferID);
                    table.ForeignKey(
                        name: "FK_Offers_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offers_Zips_OffZipID_FK",
                        column: x => x.OffZipID_FK,
                        principalSchema: "public",
                        principalTable: "Zips",
                        principalColumn: "ZipID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                schema: "public",
                columns: table => new
                {
                    RequestID = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    ReqNeededPlaces = table.Column<int>(type: "integer", nullable: false),
                    ReqLongTermFamilyCare = table.Column<bool>(type: "boolean", nullable: false),
                    ReqCrisisIntervention = table.Column<bool>(type: "boolean", nullable: false),
                    ReqReliefOffer = table.Column<bool>(type: "boolean", nullable: false),
                    ReqCurrentlyPlacedFosterChildren = table.Column<int>(type: "integer", nullable: false),
                    ReqBiologicalChildren = table.Column<int>(type: "integer", nullable: false),
                    ReqAdditionalNote = table.Column<string>(type: "text", nullable: false),
                    ReqIsInactive = table.Column<bool>(type: "boolean", nullable: false),
                    ReqCreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ReqZipID_FK = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestID", x => x.RequestID);
                    table.ForeignKey(
                        name: "FK_Requests_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Zips_ReqZipID_FK",
                        column: x => x.ReqZipID_FK,
                        principalSchema: "public",
                        principalTable: "Zips",
                        principalColumn: "ZipID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddZipID_FK",
                schema: "public",
                table: "Addresses",
                column: "AddZipID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Cantons_CanCountryID_FK",
                schema: "public",
                table: "Cantons",
                column: "CanCountryID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ComAddressID",
                schema: "public",
                table: "Companies",
                column: "ComAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ComCompanyTypeID",
                schema: "public",
                table: "Companies",
                column: "ComCompanyTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_UserId",
                schema: "public",
                table: "Logins",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_OffZipID_FK",
                schema: "public",
                table: "Offers",
                column: "OffZipID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_UserId",
                schema: "public",
                table: "Offers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ReqZipID_FK",
                schema: "public",
                table: "Requests",
                column: "ReqZipID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserId",
                schema: "public",
                table: "Requests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId",
                schema: "public",
                table: "Users",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonalInformationId",
                schema: "public",
                table: "Users",
                column: "PersonalInformationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zips_ZipCantonID_FK",
                schema: "public",
                table: "Zips",
                column: "ZipCantonID_FK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logins",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Offers",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Requests",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "public");

            migrationBuilder.DropTable(
                name: "PersonalInformation",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "public");

            migrationBuilder.DropTable(
                name: "CompanyTypes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Zips",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Cantons",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "public");
        }
    }
}
