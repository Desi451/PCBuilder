using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class computer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motherboards_SocketCPUs_SocketCPUId",
                table: "Motherboards");

            migrationBuilder.RenameColumn(
                name: "SocketCPUId",
                table: "Motherboards",
                newName: "SocketCpuId");

            migrationBuilder.RenameIndex(
                name: "IX_Motherboards_SocketCPUId",
                table: "Motherboards",
                newName: "IX_Motherboards_SocketCpuId");

            migrationBuilder.AddColumn<string>(
                name: "PsswordSalt",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ComputerId",
                table: "Ssds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComputerId",
                table: "Hdds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    CpuId = table.Column<int>(type: "int", nullable: false),
                    MotherboardId = table.Column<int>(type: "int", nullable: false),
                    RamMemoryId = table.Column<int>(type: "int", nullable: false),
                    PsuId = table.Column<int>(type: "int", nullable: false),
                    GpuId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Computers_CPUs_CpuId",
                        column: x => x.CpuId,
                        principalTable: "CPUs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Computers_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Computers_GPUs_GpuId",
                        column: x => x.GpuId,
                        principalTable: "GPUs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Computers_Motherboards_MotherboardId",
                        column: x => x.MotherboardId,
                        principalTable: "Motherboards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Computers_PSUs_PsuId",
                        column: x => x.PsuId,
                        principalTable: "PSUs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Computers_RAMs_RamMemoryId",
                        column: x => x.RamMemoryId,
                        principalTable: "RAMs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComputerHdds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HddId = table.Column<int>(type: "int", nullable: false),
                    ComputerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerHdds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComputerHdds_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComputerHdds_Hdds_HddId",
                        column: x => x.HddId,
                        principalTable: "Hdds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComputerSsds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SsdId = table.Column<int>(type: "int", nullable: false),
                    ComputerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerSsds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComputerSsds_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComputerSsds_Ssds_SsdId",
                        column: x => x.SsdId,
                        principalTable: "Ssds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ssds_ComputerId",
                table: "Ssds",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_Hdds_ComputerId",
                table: "Hdds",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerHdds_ComputerId",
                table: "ComputerHdds",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerHdds_HddId",
                table: "ComputerHdds",
                column: "HddId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_CaseId",
                table: "Computers",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_CpuId",
                table: "Computers",
                column: "CpuId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_GpuId",
                table: "Computers",
                column: "GpuId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_MotherboardId",
                table: "Computers",
                column: "MotherboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_PsuId",
                table: "Computers",
                column: "PsuId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_RamMemoryId",
                table: "Computers",
                column: "RamMemoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerSsds_ComputerId",
                table: "ComputerSsds",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerSsds_SsdId",
                table: "ComputerSsds",
                column: "SsdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hdds_Computers_ComputerId",
                table: "Hdds",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Motherboards_SocketCPUs_SocketCpuId",
                table: "Motherboards",
                column: "SocketCpuId",
                principalTable: "SocketCPUs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ssds_Computers_ComputerId",
                table: "Ssds",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hdds_Computers_ComputerId",
                table: "Hdds");

            migrationBuilder.DropForeignKey(
                name: "FK_Motherboards_SocketCPUs_SocketCpuId",
                table: "Motherboards");

            migrationBuilder.DropForeignKey(
                name: "FK_Ssds_Computers_ComputerId",
                table: "Ssds");

            migrationBuilder.DropTable(
                name: "ComputerHdds");

            migrationBuilder.DropTable(
                name: "ComputerSsds");

            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Ssds_ComputerId",
                table: "Ssds");

            migrationBuilder.DropIndex(
                name: "IX_Hdds_ComputerId",
                table: "Hdds");

            migrationBuilder.DropColumn(
                name: "PsswordSalt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ComputerId",
                table: "Ssds");

            migrationBuilder.DropColumn(
                name: "ComputerId",
                table: "Hdds");

            migrationBuilder.RenameColumn(
                name: "SocketCpuId",
                table: "Motherboards",
                newName: "SocketCPUId");

            migrationBuilder.RenameIndex(
                name: "IX_Motherboards_SocketCpuId",
                table: "Motherboards",
                newName: "IX_Motherboards_SocketCPUId");

            migrationBuilder.AddForeignKey(
                name: "FK_Motherboards_SocketCPUs_SocketCPUId",
                table: "Motherboards",
                column: "SocketCPUId",
                principalTable: "SocketCPUs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
