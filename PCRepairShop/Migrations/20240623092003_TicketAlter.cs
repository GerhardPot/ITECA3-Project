using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pcrepairshop.Migrations
{
    /// <inheritdoc />
    public partial class TicketAlter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_AspNetUsers_UserValueId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_UserValueId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "UserValueId",
                table: "Ticket");

            migrationBuilder.AlterColumn<string>(
                name: "User",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceDescription",
                table: "Ticket",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "User",
                table: "Ticket",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceDescription",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "UserValueId",
                table: "Ticket",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_UserValueId",
                table: "Ticket",
                column: "UserValueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_AspNetUsers_UserValueId",
                table: "Ticket",
                column: "UserValueId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
