using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kujira.Backend.Migrations
{
    /// <inheritdoc />
    public partial class RollbackRelationshipBetweenAddressAndCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Companies_ComAddressID",
                schema: "public",
                table: "Companies");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ComAddressID",
                schema: "public",
                table: "Companies",
                column: "ComAddressID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Companies_ComAddressID",
                schema: "public",
                table: "Companies");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ComAddressID",
                schema: "public",
                table: "Companies",
                column: "ComAddressID",
                unique: true);
        }
    }
}
