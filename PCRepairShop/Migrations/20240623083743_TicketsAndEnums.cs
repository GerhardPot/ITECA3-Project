using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pcrepairshop.Migrations
{
    /// <inheritdoc />
    public partial class TicketsAndEnums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_AspNetUsers_UserId",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Ticket",
                newName: "UserValueId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_UserId",
                table: "Ticket",
                newName: "IX_Ticket_UserValueId");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceDescription",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<int>(
                name: "InventoryTypeId",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "InitStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_InventoryTypeId",
                table: "Ticket",
                column: "InventoryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_AspNetUsers_UserValueId",
                table: "Ticket",
                column: "UserValueId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_InvType_InventoryTypeId",
                table: "Ticket",
                column: "InventoryTypeId",
                principalTable: "InvType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_AspNetUsers_UserValueId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_InvType_InventoryTypeId",
                table: "Ticket");

            migrationBuilder.DropTable(
                name: "InitStatus");

            migrationBuilder.DropTable(
                name: "InvType");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_InventoryTypeId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "InventoryTypeId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "UserValueId",
                table: "Ticket",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_UserValueId",
                table: "Ticket",
                newName: "IX_Ticket_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceDescription",
                table: "Ticket",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_AspNetUsers_UserId",
                table: "Ticket",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
