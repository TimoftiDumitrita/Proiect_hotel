using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_hotel.Migrations
{
    public partial class preturi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pret",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartValidity = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndValidity = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price_value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    Nr_persoane = table.Column<int>(type: "int", nullable: false),
                    CameraID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pret", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pret_Camera_CameraID",
                        column: x => x.CameraID,
                        principalTable: "Camera",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pret_CameraID",
                table: "Pret",
                column: "CameraID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pret");
        }
    }
}
