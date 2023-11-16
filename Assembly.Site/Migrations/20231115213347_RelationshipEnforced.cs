using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assembly.Site.Migrations
{
    /// <inheritdoc />
    public partial class RelationshipEnforced : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OPERATIONS_DEVICES_DeviceID",
                table: "OPERATIONS");

            migrationBuilder.RenameColumn(
                name: "DeviceID",
                table: "OPERATIONS",
                newName: "DEVICEID");

            migrationBuilder.RenameIndex(
                name: "IX_OPERATIONS_DeviceID",
                table: "OPERATIONS",
                newName: "IX_OPERATIONS_DEVICEID");

            migrationBuilder.AlterColumn<int>(
                name: "DEVICEID",
                table: "OPERATIONS",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OPERATIONS_DEVICES_DEVICEID",
                table: "OPERATIONS",
                column: "DEVICEID",
                principalTable: "DEVICES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OPERATIONS_DEVICES_DEVICEID",
                table: "OPERATIONS");

            migrationBuilder.RenameColumn(
                name: "DEVICEID",
                table: "OPERATIONS",
                newName: "DeviceID");

            migrationBuilder.RenameIndex(
                name: "IX_OPERATIONS_DEVICEID",
                table: "OPERATIONS",
                newName: "IX_OPERATIONS_DeviceID");

            migrationBuilder.AlterColumn<int>(
                name: "DeviceID",
                table: "OPERATIONS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OPERATIONS_DEVICES_DeviceID",
                table: "OPERATIONS",
                column: "DeviceID",
                principalTable: "DEVICES",
                principalColumn: "ID");
        }
    }
}
