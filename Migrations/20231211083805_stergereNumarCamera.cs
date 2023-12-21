using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_hotel.Migrations
{
    public partial class stergereNumarCamera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumarCamera",
                table: "Pat");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumarCamera",
                table: "Pat",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
