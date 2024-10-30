using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_smarthome.Migrations
{
    /// <inheritdoc />
    public partial class SEHDevicess_DDL_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devicess_Devices_DeviceId",
                table: "Devicess");

            migrationBuilder.DropForeignKey(
                name: "FK_Devicess_Users_UserId",
                table: "Devicess");

            migrationBuilder.DropForeignKey(
                name: "FK_Heads_Devicess_DevicesId",
                table: "Heads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Devicess",
                table: "Devicess");

            migrationBuilder.DropIndex(
                name: "IX_Devicess_DeviceId",
                table: "Devicess");

            migrationBuilder.RenameTable(
                name: "Devicess",
                newName: "devicess");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "devicess",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "SerialNumber",
                table: "devicess",
                newName: "serial_number");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "devicess",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DeviceId",
                table: "devicess",
                newName: "device_id");

            migrationBuilder.RenameIndex(
                name: "IX_Devicess_UserId",
                table: "devicess",
                newName: "IX_devicess_user_id");

            migrationBuilder.AlterColumn<string>(
                name: "serial_number",
                table: "devicess",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_devicess",
                table: "devicess",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_devicess_device_id",
                table: "devicess",
                column: "device_id",
                unique: true,
                filter: "[device_id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_devicess_Devices_device_id",
                table: "devicess",
                column: "device_id",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_devicess_Users_user_id",
                table: "devicess",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Heads_devicess_DevicesId",
                table: "Heads",
                column: "DevicesId",
                principalTable: "devicess",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_devicess_Devices_device_id",
                table: "devicess");

            migrationBuilder.DropForeignKey(
                name: "FK_devicess_Users_user_id",
                table: "devicess");

            migrationBuilder.DropForeignKey(
                name: "FK_Heads_devicess_DevicesId",
                table: "Heads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_devicess",
                table: "devicess");

            migrationBuilder.DropIndex(
                name: "IX_devicess_device_id",
                table: "devicess");

            migrationBuilder.RenameTable(
                name: "devicess",
                newName: "Devicess");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Devicess",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "serial_number",
                table: "Devicess",
                newName: "SerialNumber");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "Devicess",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "device_id",
                table: "Devicess",
                newName: "DeviceId");

            migrationBuilder.RenameIndex(
                name: "IX_devicess_user_id",
                table: "Devicess",
                newName: "IX_Devicess_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "SerialNumber",
                table: "Devicess",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Devicess",
                table: "Devicess",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Devicess_DeviceId",
                table: "Devicess",
                column: "DeviceId",
                unique: true,
                filter: "[DeviceId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Devicess_Devices_DeviceId",
                table: "Devicess",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Devicess_Users_UserId",
                table: "Devicess",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Heads_Devicess_DevicesId",
                table: "Heads",
                column: "DevicesId",
                principalTable: "Devicess",
                principalColumn: "Id");
        }
    }
}
