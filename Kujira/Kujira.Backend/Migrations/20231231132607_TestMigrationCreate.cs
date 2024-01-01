using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kujira.Backend.Migrations
{
    /// <inheritdoc />
    public partial class TestMigrationCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UseProfilePicturePath",
                schema: "public",
                table: "Users",
                type: "character varying",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldMaxLength: 255);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UseProfilePicturePath",
                schema: "public",
                table: "Users",
                type: "character varying",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying",
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}
