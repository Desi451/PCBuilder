using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PSU : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RAMs_MemorySpeeds_MemorySpeedId",
                table: "RAMs");

            migrationBuilder.DropTable(
                name: "MemorySpeeds");

            migrationBuilder.CreateTable(
                name: "PSUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maxPower = table.Column<int>(type: "int", nullable: false),
                    Fans = table.Column<int>(type: "int", nullable: false),
                    HasPFC = table.Column<bool>(type: "bit", nullable: false),
                    MainConnPins = table.Column<int>(type: "int", nullable: false),
                    PCIExpressConn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasSLI = table.Column<bool>(type: "bit", nullable: false),
                    HasCrossFire = table.Column<bool>(type: "bit", nullable: false),
                    Voltage = table.Column<double>(type: "float", nullable: false),
                    Freq = table.Column<int>(type: "int", nullable: false),
                    Connectors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dimensions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    SeriesId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PSUs_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PSUs_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RamSpeeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Standard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Freq = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RamSpeeds", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PSUs_BrandId",
                table: "PSUs",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_PSUs_SeriesId",
                table: "PSUs",
                column: "SeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_RAMs_RamSpeeds_MemorySpeedId",
                table: "RAMs",
                column: "MemorySpeedId",
                principalTable: "RamSpeeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RAMs_RamSpeeds_MemorySpeedId",
                table: "RAMs");

            migrationBuilder.DropTable(
                name: "PSUs");

            migrationBuilder.DropTable(
                name: "RamSpeeds");

            migrationBuilder.CreateTable(
                name: "MemorySpeeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Freq = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    Standard = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorySpeeds", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RAMs_MemorySpeeds_MemorySpeedId",
                table: "RAMs",
                column: "MemorySpeedId",
                principalTable: "MemorySpeeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
