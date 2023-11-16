using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assembly.Site.Migrations
{
    /// <inheritdoc />
    public partial class UniqueIndexOnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "OPERATIONS",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "DEVICES",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_OPERATIONS_NAME",
                table: "OPERATIONS",
                column: "NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DEVICES_NAME",
                table: "DEVICES",
                column: "NAME",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OPERATIONS_NAME",
                table: "OPERATIONS");

            migrationBuilder.DropIndex(
                name: "IX_DEVICES_NAME",
                table: "DEVICES");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "OPERATIONS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "DEVICES",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
