using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ramAndMoboFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "MotherboardMemories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MotherboardMemories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MotherboardMemories");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "MotherboardMemories");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "MotherboardMemories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "MotherboardMemories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "MotherboardMemories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MotherboardMemories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "MotherboardMemories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "MotherboardMemories",
                type: "int",
                nullable: true);
        }
    }
}
