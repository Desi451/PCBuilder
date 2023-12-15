using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class gpuRefix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocketCPUs_Brands_BrandId",
                table: "SocketCPUs");

            migrationBuilder.RenameColumn(
                name: "CoresetId",
                table: "GPUs",
                newName: "CoresQuantity");

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
                name: "FK_SocketCPUs_Brands_BrandId",
                table: "SocketCPUs");

            migrationBuilder.RenameColumn(
                name: "CoresQuantity",
                table: "GPUs",
                newName: "CoresetId");

            migrationBuilder.AddForeignKey(
                name: "FK_SocketCPUs_Brands_BrandId",
                table: "SocketCPUs",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
