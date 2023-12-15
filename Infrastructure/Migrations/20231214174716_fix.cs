using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocketCPUs_Brands_BrandId",
                table: "SocketCPUs");

            migrationBuilder.AddForeignKey(
                name: "FK_SocketCPUs_Brands_BrandId",
                table: "SocketCPUs",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocketCPUs_Brands_BrandId",
                table: "SocketCPUs");

            migrationBuilder.AddForeignKey(
                name: "FK_SocketCPUs_Brands_BrandId",
                table: "SocketCPUs",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");
        }
    }
}
