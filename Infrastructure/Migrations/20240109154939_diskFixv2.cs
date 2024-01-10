using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class diskFixv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComputerId",
                table: "Ssds");

            migrationBuilder.DropColumn(
                name: "ComputerId",
                table: "Hdds");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
