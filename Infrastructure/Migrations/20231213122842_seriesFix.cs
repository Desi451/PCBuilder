using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seriesFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Brands_BrandId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_Brands_BrandId",
                table: "CPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_GPUs_Brands_BrandId",
                table: "GPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_GPUs_Brands_ChipsetBrandId",
                table: "GPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_Motherboards_Brands_BrandId",
                table: "Motherboards");

            migrationBuilder.DropForeignKey(
                name: "FK_PSUs_Brands_BrandId",
                table: "PSUs");

            migrationBuilder.DropForeignKey(
                name: "FK_RAMs_Brands_BrandId",
                table: "RAMs");

            migrationBuilder.DropIndex(
                name: "IX_RAMs_BrandId",
                table: "RAMs");

            migrationBuilder.DropIndex(
                name: "IX_PSUs_BrandId",
                table: "PSUs");

            migrationBuilder.DropIndex(
                name: "IX_Motherboards_BrandId",
                table: "Motherboards");

            migrationBuilder.DropIndex(
                name: "IX_GPUs_BrandId",
                table: "GPUs");

            migrationBuilder.DropIndex(
                name: "IX_GPUs_ChipsetBrandId",
                table: "GPUs");

            migrationBuilder.DropIndex(
                name: "IX_CPUs_BrandId",
                table: "CPUs");

            migrationBuilder.DropIndex(
                name: "IX_Cases_BrandId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "RAMs");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "PSUs");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "GPUs");

            migrationBuilder.DropColumn(
                name: "ChipsetBrandId",
                table: "GPUs");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "CPUs");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Cases");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "SocketCPUs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Series",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SocketCPUs_BrandId",
                table: "SocketCPUs",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_BrandId",
                table: "Series",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Brands_BrandId",
                table: "Series",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SocketCPUs_Brands_BrandId",
                table: "SocketCPUs",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Series_Brands_BrandId",
                table: "Series");

            migrationBuilder.DropForeignKey(
                name: "FK_SocketCPUs_Brands_BrandId",
                table: "SocketCPUs");

            migrationBuilder.DropIndex(
                name: "IX_SocketCPUs_BrandId",
                table: "SocketCPUs");

            migrationBuilder.DropIndex(
                name: "IX_Series_BrandId",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "SocketCPUs");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Series");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "RAMs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "PSUs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Motherboards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "GPUs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChipsetBrandId",
                table: "GPUs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "CPUs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Cases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RAMs_BrandId",
                table: "RAMs",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_PSUs_BrandId",
                table: "PSUs",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_BrandId",
                table: "Motherboards",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_GPUs_BrandId",
                table: "GPUs",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_GPUs_ChipsetBrandId",
                table: "GPUs",
                column: "ChipsetBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_BrandId",
                table: "CPUs",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_BrandId",
                table: "Cases",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Brands_BrandId",
                table: "Cases",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CPUs_Brands_BrandId",
                table: "CPUs",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GPUs_Brands_BrandId",
                table: "GPUs",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GPUs_Brands_ChipsetBrandId",
                table: "GPUs",
                column: "ChipsetBrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Motherboards_Brands_BrandId",
                table: "Motherboards",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PSUs_Brands_BrandId",
                table: "PSUs",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RAMs_Brands_BrandId",
                table: "RAMs",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
