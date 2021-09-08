using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class AddedFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WeathersAndCities_CityId",
                table: "WeathersAndCities",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_WeathersAndCities_WeatherId",
                table: "WeathersAndCities",
                column: "WeatherId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeathersAndCities_Cities_CityId",
                table: "WeathersAndCities",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeathersAndCities_WeatherForecasts_WeatherId",
                table: "WeathersAndCities",
                column: "WeatherId",
                principalTable: "WeatherForecasts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeathersAndCities_Cities_CityId",
                table: "WeathersAndCities");

            migrationBuilder.DropForeignKey(
                name: "FK_WeathersAndCities_WeatherForecasts_WeatherId",
                table: "WeathersAndCities");

            migrationBuilder.DropIndex(
                name: "IX_WeathersAndCities_CityId",
                table: "WeathersAndCities");

            migrationBuilder.DropIndex(
                name: "IX_WeathersAndCities_WeatherId",
                table: "WeathersAndCities");
        }
    }
}
