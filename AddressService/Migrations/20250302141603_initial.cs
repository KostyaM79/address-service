using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressService.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegionStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionStatusName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StreetTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetTypeName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreetTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    RegionStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Regions_RegionStatuses_RegionStatusId",
                        column: x => x.RegionStatusId,
                        principalTable: "RegionStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    DistrictName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TownStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TownStatusName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DistrictEntityId = table.Column<int>(type: "int", nullable: true),
                    TownStatusEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TownStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TownStatuses_Districts_DistrictEntityId",
                        column: x => x.DistrictEntityId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TownStatuses_TownStatuses_TownStatusEntityId",
                        column: x => x.TownStatusEntityId,
                        principalTable: "TownStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    TownName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TownStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Towns_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Towns_TownStatuses_TownStatusId",
                        column: x => x.TownStatusId,
                        principalTable: "TownStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TownId = table.Column<int>(type: "int", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    StreetTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Streets_StreetTypes_StreetTypeId",
                        column: x => x.StreetTypeId,
                        principalTable: "StreetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Streets_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetId = table.Column<int>(type: "int", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseNumbers_Streets_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Streets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuildingNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseNumberId = table.Column<int>(type: "int", nullable: false),
                    BuildingNumber = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingNumbers_HouseNumbers_HouseNumberId",
                        column: x => x.HouseNumberId,
                        principalTable: "HouseNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApartamentNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingNumberId = table.Column<int>(type: "int", nullable: false),
                    ApartamentNumber = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartamentNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApartamentNumbers_BuildingNumbers_BuildingNumberId",
                        column: x => x.BuildingNumberId,
                        principalTable: "BuildingNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApartamentNumbers",
                table: "ApartamentNumbers",
                columns: new[] { "BuildingNumberId", "ApartamentNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuildingNumbers",
                table: "BuildingNumbers",
                column: "HouseNumberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries",
                table: "Countries",
                column: "CountryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Districts",
                table: "Districts",
                columns: new[] { "RegionId", "DistrictName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HouseNumbers",
                table: "HouseNumbers",
                columns: new[] { "StreetId", "HouseNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions",
                table: "Regions",
                columns: new[] { "CountryId", "RegionName", "RegionStatusId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_RegionStatusId",
                table: "Regions",
                column: "RegionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionStatuses",
                table: "RegionStatuses",
                column: "RegionStatusName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Streets",
                table: "Streets",
                columns: new[] { "TownId", "StreetName", "StreetTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Streets_StreetTypeId",
                table: "Streets",
                column: "StreetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StreetTypes",
                table: "StreetTypes",
                column: "StreetTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Towns",
                table: "Towns",
                columns: new[] { "DistrictId", "TownName", "TownStatusId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Towns_TownStatusId",
                table: "Towns",
                column: "TownStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TownStatuses",
                table: "TownStatuses",
                column: "TownStatusName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TownStatuses_DistrictEntityId",
                table: "TownStatuses",
                column: "DistrictEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TownStatuses_TownStatusEntityId",
                table: "TownStatuses",
                column: "TownStatusEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartamentNumbers");

            migrationBuilder.DropTable(
                name: "BuildingNumbers");

            migrationBuilder.DropTable(
                name: "HouseNumbers");

            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropTable(
                name: "StreetTypes");

            migrationBuilder.DropTable(
                name: "Towns");

            migrationBuilder.DropTable(
                name: "TownStatuses");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "RegionStatuses");
        }
    }
}
