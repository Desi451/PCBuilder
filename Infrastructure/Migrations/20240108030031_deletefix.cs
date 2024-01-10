using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deletefix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Series_SeriesId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Series_Brands_BrandId",
                table: "Series");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Series_SeriesId",
                table: "Cases",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Brands_BrandId",
                table: "Series",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Series_SeriesId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Series_Brands_BrandId",
                table: "Series");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Series_SeriesId",
                table: "Cases",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Brands_BrandId",
                table: "Series",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
