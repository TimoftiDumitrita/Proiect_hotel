using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_hotel.Migrations
{
    public partial class clientID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Client_ClientId",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Review",
                newName: "ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_Review_ClientId",
                table: "Review",
                newName: "IX_Review_ClientID");

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Client_ClientID",
                table: "Review",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Client_ClientID",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "Review",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_ClientID",
                table: "Review",
                newName: "IX_Review_ClienID");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Review",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Client_ClientID",
                table: "Review",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID");
        }
    }
}
