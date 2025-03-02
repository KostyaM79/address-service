using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressService.Migrations
{
    public partial class indexesmodified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BuildingNumbers",
                table: "BuildingNumbers");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingNumbers",
                table: "BuildingNumbers",
                columns: new[] { "HouseNumberId", "BuildingNumber" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BuildingNumbers",
                table: "BuildingNumbers");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingNumbers",
                table: "BuildingNumbers",
                column: "HouseNumberId",
                unique: true);
        }
    }
}
