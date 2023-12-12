using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RamMemoryFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MotherboardMemories_RAMs_MemoryId",
                table: "MotherboardMemories");

            migrationBuilder.DropColumn(
                name: "RamMemoryId",
                table: "MotherboardMemories");

            migrationBuilder.AlterColumn<int>(
                name: "MemoryId",
                table: "MotherboardMemories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MotherboardMemories_RamSpeeds_MemoryId",
                table: "MotherboardMemories",
                column: "MemoryId",
                principalTable: "RamSpeeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MotherboardMemories_RamSpeeds_MemoryId",
                table: "MotherboardMemories");

            migrationBuilder.AlterColumn<int>(
                name: "MemoryId",
                table: "MotherboardMemories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RamMemoryId",
                table: "MotherboardMemories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_MotherboardMemories_RAMs_MemoryId",
                table: "MotherboardMemories",
                column: "MemoryId",
                principalTable: "RAMs",
                principalColumn: "Id");
        }
    }
}
