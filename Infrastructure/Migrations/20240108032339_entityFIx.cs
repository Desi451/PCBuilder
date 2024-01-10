using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class entityFIx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Ssds");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Ssds");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SocketCPUs");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "SocketCPUs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SlotInterfaces");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "SlotInterfaces");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RamSpeeds");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "RamSpeeds");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RAMs");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "RAMs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PSUs");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "PSUs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Hdds");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Hdds");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GPUs");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "GPUs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CPUs");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "CPUs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Brands");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Ssds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "Ssds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "SocketCPUs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "SocketCPUs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "SlotInterfaces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "SlotInterfaces",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Series",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "Series",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "RamSpeeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "RamSpeeds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "RAMs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "RAMs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "PSUs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "PSUs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Motherboards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "Motherboards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Hdds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "Hdds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "GPUs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "GPUs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "CPUs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "CPUs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Computers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "Computers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Cases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "Cases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "Brands",
                type: "int",
                nullable: true);
        }
    }
}
