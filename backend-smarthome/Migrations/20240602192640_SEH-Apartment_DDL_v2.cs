using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_smarthome.Migrations
{
    /// <inheritdoc />
    public partial class SEHApartment_DDL_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresss_Apartments_ApartmentId",
                table: "Addresss");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Users_UserId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Apartments_ApartmentId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Apartments_ApartmentId",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apartments",
                table: "Apartments");

            migrationBuilder.RenameTable(
                name: "Apartments",
                newName: "apartment");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "apartment",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "apartment",
                newName: "user_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Apartments_UserId",
                table: "apartment",
                newName: "IX_apartment_user_Id");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "apartment",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_apartment",
                table: "apartment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresss_apartment_ApartmentId",
                table: "Addresss",
                column: "ApartmentId",
                principalTable: "apartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_apartment_Users_user_Id",
                table: "apartment",
                column: "user_Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_apartment_ApartmentId",
                table: "Guests",
                column: "ApartmentId",
                principalTable: "apartment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_apartment_ApartmentId",
                table: "Rooms",
                column: "ApartmentId",
                principalTable: "apartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresss_apartment_ApartmentId",
                table: "Addresss");

            migrationBuilder.DropForeignKey(
                name: "FK_apartment_Users_user_Id",
                table: "apartment");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_apartment_ApartmentId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_apartment_ApartmentId",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_apartment",
                table: "apartment");

            migrationBuilder.RenameTable(
                name: "apartment",
                newName: "Apartments");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Apartments",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "user_Id",
                table: "Apartments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_apartment_user_Id",
                table: "Apartments",
                newName: "IX_Apartments_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apartments",
                table: "Apartments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresss_Apartments_ApartmentId",
                table: "Addresss",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Users_UserId",
                table: "Apartments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Apartments_ApartmentId",
                table: "Guests",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Apartments_ApartmentId",
                table: "Rooms",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
