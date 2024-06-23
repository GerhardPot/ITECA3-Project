using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pcrepairshop.Migrations
{
    /// <inheritdoc />
    public partial class TicketFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_InvType_InventoryTypeId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_InventoryTypeId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "InventoryTypeId",
                table: "Ticket");

            migrationBuilder.AddColumn<int>(
                name: "InventoryType",
                table: "Ticket",
                type: "int",
                maxLength: 200,
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InventoryType",
                table: "Ticket");

            migrationBuilder.AddColumn<int>(
                name: "InventoryTypeId",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_InventoryTypeId",
                table: "Ticket",
                column: "InventoryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_InvType_InventoryTypeId",
                table: "Ticket",
                column: "InventoryTypeId",
                principalTable: "InvType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
