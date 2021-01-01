using Microsoft.EntityFrameworkCore.Migrations;

namespace WycieczkiGórskie.Migrations
{
    public partial class tourPhoto2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourPhotos_Tours_TourId1",
                table: "TourPhotos");

            migrationBuilder.DropIndex(
                name: "IX_TourPhotos_TourId1",
                table: "TourPhotos");

            migrationBuilder.DropColumn(
                name: "TourId1",
                table: "TourPhotos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TourId1",
                table: "TourPhotos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TourPhotos_TourId1",
                table: "TourPhotos",
                column: "TourId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TourPhotos_Tours_TourId1",
                table: "TourPhotos",
                column: "TourId1",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
