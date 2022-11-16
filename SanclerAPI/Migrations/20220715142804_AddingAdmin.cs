using Microsoft.EntityFrameworkCore.Migrations;

namespace SanclerAPI.Migrations
{
    public partial class AddingAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "adminIDsanclerAPI00213554856Pqwus", "d7b0db3c-b2b7-40ed-8391-5615e56c02e9", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "adminIDsanclerAPI00213554856Pqwus", 0, "a2308618-9f59-45d3-8e38-ebce1bb69c26", "admin@sancler.com", true, false, null, "ADMIN@SANCLER.COM", "ADMIN@SANCLER.COM", "AQAAAAEAACcQAAAAEF6nAo9BDzz549dPg8YK6Fitzbdx5myLfFvRwSrA9kdKVkCfSsiFt10ia9kTE4ro/w==", null, false, "ae6b471f-1c42-4388-aad2-a180959bf86c", false, "admin@sancler.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "adminIDsanclerAPI00213554856Pqwus", "adminIDsanclerAPI00213554856Pqwus" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "adminIDsanclerAPI00213554856Pqwus", "adminIDsanclerAPI00213554856Pqwus" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adminIDsanclerAPI00213554856Pqwus");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminIDsanclerAPI00213554856Pqwus");
        }
    }
}
