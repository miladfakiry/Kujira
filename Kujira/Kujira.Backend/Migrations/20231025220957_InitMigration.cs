using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kujira.Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "users",
                schema: "public",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UseFirstName = table.Column<string>(type: "character varying", maxLength: 255, nullable: false),
                    UseLastName = table.Column<string>(type: "character varying", maxLength: 255, nullable: false),
                    UseDateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    UseEMail = table.Column<string>(type: "character varying", maxLength: 255, nullable: false),
                    UsePhoneNumber = table.Column<string>(type: "character varying", maxLength: 255, nullable: false),
                    UseIsInactive = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "false"),
                    UseCreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserId", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users",
                schema: "public");
        }
    }
}
