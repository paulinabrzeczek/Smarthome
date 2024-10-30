using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_smarthome.Migrations
{
    /// <inheritdoc />
    public partial class SEHCountryCodes_DML : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "Value" },
                values: new object[] { "AT", "Austria" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "Value" },
                values: new object[] { "BE", "Belgium" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "Value" },
                values: new object[] { "BG", "Bulgaria" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Code", "Value" },
                values: new object[] { "HR", "Croatia" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Code", "Value" },
                values: new object[] { "CY", "Cyprus" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Code", "Value" },
                values: new object[] { "CZ", "Czech Republic" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Code", "Value" },
                values: new object[] { "DK", "Denmark" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Code", "Value" },
                values: new object[] { "EE", "Estonia" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Code", "Value" },
                values: new object[] { "FI", "Finland" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Code", "Value" },
                values: new object[] { "FR", "France" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Code", "Value" },
                values: new object[] { "DE", "Germany" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Code", "Value" },
                values: new object[] { "GR", "Greece" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Code", "Value" },
                values: new object[] { "HU", "Hungary" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Code", "Value" },
                values: new object[] { "IE", "Ireland" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Code", "Value" },
                values: new object[] { "IT", "Italy" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Code", "Value" },
                values: new object[] { "LV", "Latvia" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Code", "Value" },
                values: new object[] { "LT", "Lithuania" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Code", "Value" },
                values: new object[] { "LU", "Luxembourg" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Code", "Value" },
                values: new object[] { "MT", "Malta" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Code", "Value" },
                values: new object[] { "NL", "Netherlands" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Code", "Value" },
                values: new object[] { "PL", "Poland" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Code", "Value" },
                values: new object[] { "PT", "Portugal" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Code", "Value" },
                values: new object[] { "RO", "Romania" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Code", "Value" },
                values: new object[] { "SK", "Slovakia" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Code", "Value" },
                values: new object[] { "SI", "Slovenia" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Code", "Value" },
                values: new object[] { "ES", "Spain" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Code", "Value" },
                values: new object[] { "SE", "Sweden" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "Value" },
                values: new object[] { "AUSTRIA", "AT" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "Value" },
                values: new object[] { "BELGIUM", "BE" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "Value" },
                values: new object[] { "BULGARIA", "BG" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Code", "Value" },
                values: new object[] { "CROATIA", "HR" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Code", "Value" },
                values: new object[] { "CYPRUS", "CY" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Code", "Value" },
                values: new object[] { "CZECH REPUBLIC", "CZ" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Code", "Value" },
                values: new object[] { "DENMARK", "DK" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Code", "Value" },
                values: new object[] { "ESTONIA", "EE" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Code", "Value" },
                values: new object[] { "FINLAND", "FI" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Code", "Value" },
                values: new object[] { "FRANCE", "FR" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Code", "Value" },
                values: new object[] { "GERMANY", "DE" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Code", "Value" },
                values: new object[] { "GREECE", "GR" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Code", "Value" },
                values: new object[] { "HUNGARY", "HU" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Code", "Value" },
                values: new object[] { "IRELAND", "IE" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Code", "Value" },
                values: new object[] { "ITALY", "IT" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Code", "Value" },
                values: new object[] { "LATVIA", "LV" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Code", "Value" },
                values: new object[] { "LITHUANIA", "LT" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Code", "Value" },
                values: new object[] { "LUXEMBOURG", "LU" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Code", "Value" },
                values: new object[] { "MALTA", "MT" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Code", "Value" },
                values: new object[] { "NETHERLANDS", "NL" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Code", "Value" },
                values: new object[] { "POLAND", "PL" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Code", "Value" },
                values: new object[] { "PORTUGAL", "PT" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Code", "Value" },
                values: new object[] { "ROMANIA", "RO" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Code", "Value" },
                values: new object[] { "SLOVAKIA", "SK" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Code", "Value" },
                values: new object[] { "SLOVENIA", "SI" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Code", "Value" },
                values: new object[] { "SPAIN", "ES" });

            migrationBuilder.UpdateData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Code", "Value" },
                values: new object[] { "SWEDEN", "SE" });
        }
    }
}
