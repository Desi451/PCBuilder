using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ramFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeriesId",
                table: "RAMs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RAMs_SeriesId",
                table: "RAMs",
                column: "SeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_RAMs_Series_SeriesId",
                table: "RAMs",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RAMs_Series_SeriesId",
                table: "RAMs");

            migrationBuilder.DropIndex(
                name: "IX_RAMs_SeriesId",
                table: "RAMs");

            migrationBuilder.DropColumn(
                name: "SeriesId",
                table: "RAMs");
        }
    }
}
