using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kujira.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddProfilePictureToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UseProfilePicturePath",
                schema: "public",
                table: "Users",
                type: "character varying",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UseProfilePicturePath",
                schema: "public",
                table: "Users");
        }
    }
}
