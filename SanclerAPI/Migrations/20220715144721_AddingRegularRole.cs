using Microsoft.EntityFrameworkCore.Migrations;

namespace SanclerAPI.Migrations
{
    public partial class AddingRegularRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adminIDsanclerAPI00213554856Pqwus",
                column: "ConcurrencyStamp",
                value: "b3e6e756-a869-424f-8a5d-30a9c053be52");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "regular123aosdm123bJASNd", "8935c5e8-7f61-43df-afd1-7ea3d9e9d598", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminIDsanclerAPI00213554856Pqwus",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cca8dc47-12d9-4b89-bf5e-573d38cf0444", "AQAAAAEAACcQAAAAEIxey7KDh2koXkMrpjQ97cWE59d50aNY8ghMj1q9RHhz5qlfvLX9VVbWQG4jC7Om2A==", "032e7ab4-bb1a-4382-a308-8c0776a8b50e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "regular123aosdm123bJASNd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adminIDsanclerAPI00213554856Pqwus",
                column: "ConcurrencyStamp",
                value: "d7b0db3c-b2b7-40ed-8391-5615e56c02e9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminIDsanclerAPI00213554856Pqwus",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2308618-9f59-45d3-8e38-ebce1bb69c26", "AQAAAAEAACcQAAAAEF6nAo9BDzz549dPg8YK6Fitzbdx5myLfFvRwSrA9kdKVkCfSsiFt10ia9kTE4ro/w==", "ae6b471f-1c42-4388-aad2-a180959bf86c" });
        }
    }
}
