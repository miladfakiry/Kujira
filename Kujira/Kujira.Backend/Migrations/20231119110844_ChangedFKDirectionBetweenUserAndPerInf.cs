using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kujira.Backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangedFKDirectionBetweenUserAndPerInf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_PersonalInformation_PersonalInformationId",
                schema: "public",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PersonalInformationId",
                schema: "public",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PersonalInformationId",
                schema: "public",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "public",
                table: "PersonalInformation",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformation_UserId",
                schema: "public",
                table: "PersonalInformation",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInformation_Users_UserId",
                schema: "public",
                table: "PersonalInformation",
                column: "UserId",
                principalSchema: "public",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInformation_Users_UserId",
                schema: "public",
                table: "PersonalInformation");

            migrationBuilder.DropIndex(
                name: "IX_PersonalInformation_UserId",
                schema: "public",
                table: "PersonalInformation");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "public",
                table: "PersonalInformation");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonalInformationId",
                schema: "public",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonalInformationId",
                schema: "public",
                table: "Users",
                column: "PersonalInformationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_PersonalInformation_PersonalInformationId",
                schema: "public",
                table: "Users",
                column: "PersonalInformationId",
                principalSchema: "public",
                principalTable: "PersonalInformation",
                principalColumn: "PersonalInformationID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
