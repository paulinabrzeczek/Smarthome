using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_smarthome.Migrations
{
    /// <inheritdoc />
    public partial class SEHGuest_DDL_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_apartment_ApartmentId",
                table: "Guests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guests",
                table: "Guests");

            migrationBuilder.RenameTable(
                name: "Guests",
                newName: "guest");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "guest",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "guest",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "guest",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "ApartmentId",
                table: "guest",
                newName: "apartment_id");

            migrationBuilder.RenameIndex(
                name: "IX_Guests_ApartmentId",
                table: "guest",
                newName: "IX_guest_apartment_id");

            migrationBuilder.AlterColumn<string>(
                name: "lastname",
                table: "guest",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "firstname",
                table: "guest",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "guest",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_guest",
                table: "guest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_guest_apartment_apartment_id",
                table: "guest",
                column: "apartment_id",
                principalTable: "apartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_guest_apartment_apartment_id",
                table: "guest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_guest",
                table: "guest");

            migrationBuilder.RenameTable(
                name: "guest",
                newName: "Guests");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "Guests",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "Guests",
                newName: "Firstname");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Guests",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "apartment_id",
                table: "Guests",
                newName: "ApartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_guest_apartment_id",
                table: "Guests",
                newName: "IX_Guests_ApartmentId");

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guests",
                table: "Guests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_apartment_ApartmentId",
                table: "Guests",
                column: "ApartmentId",
                principalTable: "apartment",
                principalColumn: "Id");
        }
    }
}
