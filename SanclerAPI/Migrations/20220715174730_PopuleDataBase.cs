using Microsoft.EntityFrameworkCore.Migrations;

namespace SanclerAPI.Migrations
{
    public partial class PopuleDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adminIDsanclerAPI00213554856Pqwus",
                column: "ConcurrencyStamp",
                value: "2c61fd99-5491-46c1-a699-c7be73485993");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "regular123aosdm123bJASNd",
                column: "ConcurrencyStamp",
                value: "eb6a9f8e-3b55-470f-b6a8-11920513c85c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminIDsanclerAPI00213554856Pqwus",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64be1c29-9019-4d51-8e65-88e42f40a553", "AQAAAAEAACcQAAAAEIks53+rTIOqTKORXIYRNV0p+mSFoUHFF9lZuKQpZx9gAyyMS3GZSsDpt69c62/5GA==", "ecaa265a-5708-4eff-967a-d63240316f6f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adminIDsanclerAPI00213554856Pqwus",
                column: "ConcurrencyStamp",
                value: "b3e6e756-a869-424f-8a5d-30a9c053be52");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "regular123aosdm123bJASNd",
                column: "ConcurrencyStamp",
                value: "8935c5e8-7f61-43df-afd1-7ea3d9e9d598");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminIDsanclerAPI00213554856Pqwus",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cca8dc47-12d9-4b89-bf5e-573d38cf0444", "AQAAAAEAACcQAAAAEIxey7KDh2koXkMrpjQ97cWE59d50aNY8ghMj1q9RHhz5qlfvLX9VVbWQG4jC7Om2A==", "032e7ab4-bb1a-4382-a308-8c0776a8b50e" });
        }
    }
}
