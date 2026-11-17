using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataIntegrity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComputerHdds_Hdds_HddId",
                table: "ComputerHdds");

            migrationBuilder.DropForeignKey(
                name: "FK_ComputerSsds_Ssds_SsdId",
                table: "ComputerSsds");

            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_Series_SeriesId",
                table: "CPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_SocketCPUs_SocketCpuId",
                table: "CPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_GPUs_Series_SeriesId",
                table: "GPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_Hdds_Computers_ComputerId",
                table: "Hdds");

            migrationBuilder.DropForeignKey(
                name: "FK_Hdds_Series_SeriesId",
                table: "Hdds");

            migrationBuilder.DropForeignKey(
                name: "FK_Hdds_SlotInterfaces_SlotInterfaceId",
                table: "Hdds");

            migrationBuilder.DropForeignKey(
                name: "FK_MotherboardMemories_RamSpeeds_MemoryId",
                table: "MotherboardMemories");

            migrationBuilder.DropForeignKey(
                name: "FK_Motherboards_Series_SeriesId",
                table: "Motherboards");

            migrationBuilder.DropForeignKey(
                name: "FK_Motherboards_SocketCPUs_SocketCpuId",
                table: "Motherboards");

            migrationBuilder.DropForeignKey(
                name: "FK_PSUs_Series_SeriesId",
                table: "PSUs");

            migrationBuilder.DropForeignKey(
                name: "FK_RAMs_RamSpeeds_MemorySpeedId",
                table: "RAMs");

            migrationBuilder.DropForeignKey(
                name: "FK_RAMs_Series_SeriesId",
                table: "RAMs");

            migrationBuilder.DropForeignKey(
                name: "FK_SlotGpus_SlotInterfaces_SlotId",
                table: "SlotGpus");

            migrationBuilder.DropForeignKey(
                name: "FK_Ssds_Computers_ComputerId",
                table: "Ssds");

            migrationBuilder.DropForeignKey(
                name: "FK_Ssds_Series_SeriesId",
                table: "Ssds");

            migrationBuilder.DropForeignKey(
                name: "FK_Ssds_SlotInterfaces_SlotInterfaceId",
                table: "Ssds");

            migrationBuilder.DropIndex(
                name: "IX_Ssds_ComputerId",
                table: "Ssds");

            migrationBuilder.DropIndex(
                name: "IX_SlotGpus_SlotId",
                table: "SlotGpus");

            migrationBuilder.DropIndex(
                name: "IX_MotherboardMemories_MotherBoardId",
                table: "MotherboardMemories");

            migrationBuilder.DropIndex(
                name: "IX_Hdds_ComputerId",
                table: "Hdds");

            migrationBuilder.DropIndex(
                name: "IX_ComputerSsds_ComputerId",
                table: "ComputerSsds");

            migrationBuilder.DropIndex(
                name: "IX_ComputerHdds_ComputerId",
                table: "ComputerHdds");

            migrationBuilder.Sql("UPDATE [Cases] SET [CaseSize] = [CaseSizeId];");
            migrationBuilder.Sql("UPDATE [Motherboards] SET [CaseSize] = [CaseSizeId];");

            migrationBuilder.Sql("WITH d AS (SELECT ROW_NUMBER() OVER (PARTITION BY [ComputerId], [HddId] ORDER BY [Id]) AS rn FROM [ComputerHdds]) DELETE FROM d WHERE rn > 1;");
            migrationBuilder.Sql("WITH d AS (SELECT ROW_NUMBER() OVER (PARTITION BY [ComputerId], [SsdId] ORDER BY [Id]) AS rn FROM [ComputerSsds]) DELETE FROM d WHERE rn > 1;");
            migrationBuilder.Sql("WITH d AS (SELECT ROW_NUMBER() OVER (PARTITION BY [MotherBoardId], [MemoryId] ORDER BY [Id]) AS rn FROM [MotherboardMemories]) DELETE FROM d WHERE rn > 1;");
            migrationBuilder.Sql("WITH d AS (SELECT ROW_NUMBER() OVER (PARTITION BY [SlotId], [GpuId] ORDER BY [Id]) AS rn FROM [SlotGpus]) DELETE FROM d WHERE rn > 1;");

            migrationBuilder.DropColumn(
                name: "ComputerId",
                table: "Ssds");

            migrationBuilder.DropColumn(
                name: "CaseSizeId",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "ComputerId",
                table: "Hdds");

            migrationBuilder.DropColumn(
                name: "CaseSizeId",
                table: "Cases");

            migrationBuilder.AlterColumn<int>(
                name: "GpuId",
                table: "Computers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_SlotGpus_SlotId_GpuId",
                table: "SlotGpus",
                columns: new[] { "SlotId", "GpuId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MotherboardMemories_MotherBoardId_MemoryId",
                table: "MotherboardMemories",
                columns: new[] { "MotherBoardId", "MemoryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComputerSsds_ComputerId_SsdId",
                table: "ComputerSsds",
                columns: new[] { "ComputerId", "SsdId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComputerHdds_ComputerId_HddId",
                table: "ComputerHdds",
                columns: new[] { "ComputerId", "HddId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ComputerHdds_Hdds_HddId",
                table: "ComputerHdds",
                column: "HddId",
                principalTable: "Hdds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComputerSsds_Ssds_SsdId",
                table: "ComputerSsds",
                column: "SsdId",
                principalTable: "Ssds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CPUs_Series_SeriesId",
                table: "CPUs",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CPUs_SocketCPUs_SocketCpuId",
                table: "CPUs",
                column: "SocketCpuId",
                principalTable: "SocketCPUs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GPUs_Series_SeriesId",
                table: "GPUs",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hdds_Series_SeriesId",
                table: "Hdds",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hdds_SlotInterfaces_SlotInterfaceId",
                table: "Hdds",
                column: "SlotInterfaceId",
                principalTable: "SlotInterfaces",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MotherboardMemories_RamSpeeds_MemoryId",
                table: "MotherboardMemories",
                column: "MemoryId",
                principalTable: "RamSpeeds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Motherboards_Series_SeriesId",
                table: "Motherboards",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Motherboards_SocketCPUs_SocketCpuId",
                table: "Motherboards",
                column: "SocketCpuId",
                principalTable: "SocketCPUs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PSUs_Series_SeriesId",
                table: "PSUs",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RAMs_RamSpeeds_MemorySpeedId",
                table: "RAMs",
                column: "MemorySpeedId",
                principalTable: "RamSpeeds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RAMs_Series_SeriesId",
                table: "RAMs",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SlotGpus_SlotInterfaces_SlotId",
                table: "SlotGpus",
                column: "SlotId",
                principalTable: "SlotInterfaces",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ssds_Series_SeriesId",
                table: "Ssds",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ssds_SlotInterfaces_SlotInterfaceId",
                table: "Ssds",
                column: "SlotInterfaceId",
                principalTable: "SlotInterfaces",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComputerHdds_Hdds_HddId",
                table: "ComputerHdds");

            migrationBuilder.DropForeignKey(
                name: "FK_ComputerSsds_Ssds_SsdId",
                table: "ComputerSsds");

            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_Series_SeriesId",
                table: "CPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_SocketCPUs_SocketCpuId",
                table: "CPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_GPUs_Series_SeriesId",
                table: "GPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_Hdds_Series_SeriesId",
                table: "Hdds");

            migrationBuilder.DropForeignKey(
                name: "FK_Hdds_SlotInterfaces_SlotInterfaceId",
                table: "Hdds");

            migrationBuilder.DropForeignKey(
                name: "FK_MotherboardMemories_RamSpeeds_MemoryId",
                table: "MotherboardMemories");

            migrationBuilder.DropForeignKey(
                name: "FK_Motherboards_Series_SeriesId",
                table: "Motherboards");

            migrationBuilder.DropForeignKey(
                name: "FK_Motherboards_SocketCPUs_SocketCpuId",
                table: "Motherboards");

            migrationBuilder.DropForeignKey(
                name: "FK_PSUs_Series_SeriesId",
                table: "PSUs");

            migrationBuilder.DropForeignKey(
                name: "FK_RAMs_RamSpeeds_MemorySpeedId",
                table: "RAMs");

            migrationBuilder.DropForeignKey(
                name: "FK_RAMs_Series_SeriesId",
                table: "RAMs");

            migrationBuilder.DropForeignKey(
                name: "FK_SlotGpus_SlotInterfaces_SlotId",
                table: "SlotGpus");

            migrationBuilder.DropForeignKey(
                name: "FK_Ssds_Series_SeriesId",
                table: "Ssds");

            migrationBuilder.DropForeignKey(
                name: "FK_Ssds_SlotInterfaces_SlotInterfaceId",
                table: "Ssds");

            migrationBuilder.DropIndex(
                name: "IX_SlotGpus_SlotId_GpuId",
                table: "SlotGpus");

            migrationBuilder.DropIndex(
                name: "IX_MotherboardMemories_MotherBoardId_MemoryId",
                table: "MotherboardMemories");

            migrationBuilder.DropIndex(
                name: "IX_ComputerSsds_ComputerId_SsdId",
                table: "ComputerSsds");

            migrationBuilder.DropIndex(
                name: "IX_ComputerHdds_ComputerId_HddId",
                table: "ComputerHdds");

            migrationBuilder.AddColumn<int>(
                name: "ComputerId",
                table: "Ssds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CaseSizeId",
                table: "Motherboards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ComputerId",
                table: "Hdds",
                type: "int",
                nullable: true);

            migrationBuilder.Sql("DELETE FROM [Computers] WHERE [GpuId] IS NULL;");

            migrationBuilder.AlterColumn<int>(
                name: "GpuId",
                table: "Computers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CaseSizeId",
                table: "Cases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("UPDATE [Cases] SET [CaseSizeId] = [CaseSize];");
            migrationBuilder.Sql("UPDATE [Motherboards] SET [CaseSizeId] = [CaseSize];");

            migrationBuilder.CreateIndex(
                name: "IX_Ssds_ComputerId",
                table: "Ssds",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_SlotGpus_SlotId",
                table: "SlotGpus",
                column: "SlotId");

            migrationBuilder.CreateIndex(
                name: "IX_MotherboardMemories_MotherBoardId",
                table: "MotherboardMemories",
                column: "MotherBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Hdds_ComputerId",
                table: "Hdds",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerSsds_ComputerId",
                table: "ComputerSsds",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerHdds_ComputerId",
                table: "ComputerHdds",
                column: "ComputerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComputerHdds_Hdds_HddId",
                table: "ComputerHdds",
                column: "HddId",
                principalTable: "Hdds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComputerSsds_Ssds_SsdId",
                table: "ComputerSsds",
                column: "SsdId",
                principalTable: "Ssds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CPUs_Series_SeriesId",
                table: "CPUs",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CPUs_SocketCPUs_SocketCpuId",
                table: "CPUs",
                column: "SocketCpuId",
                principalTable: "SocketCPUs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GPUs_Series_SeriesId",
                table: "GPUs",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hdds_Computers_ComputerId",
                table: "Hdds",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hdds_Series_SeriesId",
                table: "Hdds",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hdds_SlotInterfaces_SlotInterfaceId",
                table: "Hdds",
                column: "SlotInterfaceId",
                principalTable: "SlotInterfaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MotherboardMemories_RamSpeeds_MemoryId",
                table: "MotherboardMemories",
                column: "MemoryId",
                principalTable: "RamSpeeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motherboards_Series_SeriesId",
                table: "Motherboards",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motherboards_SocketCPUs_SocketCpuId",
                table: "Motherboards",
                column: "SocketCpuId",
                principalTable: "SocketCPUs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PSUs_Series_SeriesId",
                table: "PSUs",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RAMs_RamSpeeds_MemorySpeedId",
                table: "RAMs",
                column: "MemorySpeedId",
                principalTable: "RamSpeeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RAMs_Series_SeriesId",
                table: "RAMs",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SlotGpus_SlotInterfaces_SlotId",
                table: "SlotGpus",
                column: "SlotId",
                principalTable: "SlotInterfaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ssds_Computers_ComputerId",
                table: "Ssds",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ssds_Series_SeriesId",
                table: "Ssds",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ssds_SlotInterfaces_SlotInterfaceId",
                table: "Ssds",
                column: "SlotInterfaceId",
                principalTable: "SlotInterfaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
