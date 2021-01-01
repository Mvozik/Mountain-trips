using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WycieczkiGórskie.Migrations
{
    public partial class tourPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TourPhoto",
                table: "Tours");

            migrationBuilder.CreateTable(
                name: "TourPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<byte[]>(nullable: true),
                    TourId = table.Column<int>(nullable: false),
                    TourId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourPhotos_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourPhotos_Tours_TourId1",
                        column: x => x.TourId1,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourPhotos_TourId",
                table: "TourPhotos",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_TourPhotos_TourId1",
                table: "TourPhotos",
                column: "TourId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourPhotos");

            migrationBuilder.AddColumn<byte[]>(
                name: "TourPhoto",
                table: "Tours",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
