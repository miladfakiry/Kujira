using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kujira.Backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangedCreatedAtAtOfferAndRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReqCreatedAt",
                schema: "public",
                table: "Requests",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OffCreatedAt",
                schema: "public",
                table: "Offers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReqCreatedAt",
                schema: "public",
                table: "Requests",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OffCreatedAt",
                schema: "public",
                table: "Offers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()");
        }
    }
}
