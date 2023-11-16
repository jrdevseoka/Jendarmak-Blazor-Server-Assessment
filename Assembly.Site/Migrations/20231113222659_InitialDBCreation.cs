using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assembly.Site.Migrations
{
    /// <inheritdoc />
    public partial class InitialDBCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DEVICES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TYPE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEVICES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OPERATIONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PIORITY = table.Column<int>(type: "int", nullable: false),
                    IMAGE = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DeviceID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERATIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OPERATIONS_DEVICES_DeviceID",
                        column: x => x.DeviceID,
                        principalTable: "DEVICES",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OPERATIONS_DeviceID",
                table: "OPERATIONS",
                column: "DeviceID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OPERATIONS");

            migrationBuilder.DropTable(
                name: "DEVICES");
        }
    }
}
