using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class gpuFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GPUs_Brands_ProcessorBrandId",
                table: "GPUs");

            migrationBuilder.RenameColumn(
                name: "ProcessorBrandId",
                table: "GPUs",
                newName: "ChipsetSeriesId");

            migrationBuilder.RenameIndex(
                name: "IX_GPUs_ProcessorBrandId",
                table: "GPUs",
                newName: "IX_GPUs_ChipsetSeriesId");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "GPUs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GPUs_BrandId",
                table: "GPUs",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_GPUs_Brands_BrandId",
                table: "GPUs",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GPUs_Series_ChipsetSeriesId",
                table: "GPUs",
                column: "ChipsetSeriesId",
                principalTable: "Series",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GPUs_Brands_BrandId",
                table: "GPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_GPUs_Series_ChipsetSeriesId",
                table: "GPUs");

            migrationBuilder.DropIndex(
                name: "IX_GPUs_BrandId",
                table: "GPUs");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "GPUs");

            migrationBuilder.RenameColumn(
                name: "ChipsetSeriesId",
                table: "GPUs",
                newName: "ProcessorBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_GPUs_ChipsetSeriesId",
                table: "GPUs",
                newName: "IX_GPUs_ProcessorBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_GPUs_Brands_ProcessorBrandId",
                table: "GPUs",
                column: "ProcessorBrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
