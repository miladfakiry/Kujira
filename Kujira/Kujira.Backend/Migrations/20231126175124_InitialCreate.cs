using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kujira.Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Addresses_ComAddressID",
                schema: "public",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_ComAddressID",
                schema: "public",
                table: "Companies");

            migrationBuilder.AlterColumn<string>(
                name: "UseLastName",
                schema: "public",
                table: "Users",
                type: "character varying",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "UseFirstName",
                schema: "public",
                table: "Users",
                type: "character varying",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldMaxLength: 255);

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "public",
                columns: table => new
                {
                    RoleID = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    RolName = table.Column<string>(type: "character varying", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleID", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "public",
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ComAddressID",
                schema: "public",
                table: "Companies",
                column: "ComAddressID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Addresses_ComAddressID",
                schema: "public",
                table: "Companies",
                column: "ComAddressID",
                principalSchema: "public",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Addresses_ComAddressID",
                schema: "public",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_Companies_ComAddressID",
                schema: "public",
                table: "Companies");

            migrationBuilder.AlterColumn<string>(
                name: "UseLastName",
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

            migrationBuilder.AlterColumn<string>(
                name: "UseFirstName",
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

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ComAddressID",
                schema: "public",
                table: "Companies",
                column: "ComAddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Addresses_ComAddressID",
                schema: "public",
                table: "Companies",
                column: "ComAddressID",
                principalSchema: "public",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
