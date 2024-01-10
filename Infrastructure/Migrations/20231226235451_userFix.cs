using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class userFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_SocketCPUs_SocketCPUId",
                table: "CPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_SlotInterfaces_GPUs_GPUId",
                table: "SlotInterfaces");

            migrationBuilder.DropIndex(
                name: "IX_SlotInterfaces_GPUId",
                table: "SlotInterfaces");

            migrationBuilder.DropColumn(
                name: "SlotName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GPUId",
                table: "SlotInterfaces");

            migrationBuilder.RenameColumn(
                name: "SocketCPUId",
                table: "CPUs",
                newName: "SocketCpuId");

            migrationBuilder.RenameIndex(
                name: "IX_CPUs_SocketCPUId",
                table: "CPUs",
                newName: "IX_CPUs_SocketCpuId");

            migrationBuilder.AddForeignKey(
                name: "FK_CPUs_SocketCPUs_SocketCpuId",
                table: "CPUs",
                column: "SocketCpuId",
                principalTable: "SocketCPUs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_SocketCPUs_SocketCpuId",
                table: "CPUs");

            migrationBuilder.RenameColumn(
                name: "SocketCpuId",
                table: "CPUs",
                newName: "SocketCPUId");

            migrationBuilder.RenameIndex(
                name: "IX_CPUs_SocketCpuId",
                table: "CPUs",
                newName: "IX_CPUs_SocketCPUId");

            migrationBuilder.AddColumn<string>(
                name: "SlotName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GPUId",
                table: "SlotInterfaces",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SlotInterfaces_GPUId",
                table: "SlotInterfaces",
                column: "GPUId");

            migrationBuilder.AddForeignKey(
                name: "FK_CPUs_SocketCPUs_SocketCPUId",
                table: "CPUs",
                column: "SocketCPUId",
                principalTable: "SocketCPUs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SlotInterfaces_GPUs_GPUId",
                table: "SlotInterfaces",
                column: "GPUId",
                principalTable: "GPUs",
                principalColumn: "Id");
        }
    }
}
