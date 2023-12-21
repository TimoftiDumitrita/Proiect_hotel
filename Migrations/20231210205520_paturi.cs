using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_hotel.Migrations
{
    public partial class paturi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lungime = table.Column<double>(type: "float", nullable: false),
                    Latime = table.Column<double>(type: "float", nullable: false),
                    TipPat = table.Column<int>(type: "int", nullable: false),
                    CameraID = table.Column<int>(type: "int", nullable: true),
                    NumarCamera = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pat", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pat_Camera_CameraID",
                        column: x => x.CameraID,
                        principalTable: "Camera",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pat_CameraID",
                table: "Pat",
                column: "CameraID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pat");
        }
    }
}
