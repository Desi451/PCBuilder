using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class caseFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_CaseSizes_CaseSizeId",
                table: "Cases");

            migrationBuilder.DropTable(
                name: "CaseSizes");

            migrationBuilder.DropIndex(
                name: "IX_Cases_CaseSizeId",
                table: "Cases");

            migrationBuilder.AddColumn<int>(
                name: "CaseSize",
                table: "Cases",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaseSize",
                table: "Cases");

            migrationBuilder.CreateTable(
                name: "CaseSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseSizes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CaseSizeId",
                table: "Cases",
                column: "CaseSizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_CaseSizes_CaseSizeId",
                table: "Cases",
                column: "CaseSizeId",
                principalTable: "CaseSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
