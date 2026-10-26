using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace isaacmagazine.Migrations
{
    /// <inheritdoc />
    public partial class ResetAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "{318295C6-0B4F-4D2D-A81B-76A375B69CF5}", "{C57B1666-4A5E-4461-B6CE-FCD850D12844}" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "{318295C6-0B4F-4D2D-A81B-76A375B69CF5}");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "{C57B1666-4A5E-4461-B6CE-FCD850D12844}");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "{50E3664F-A4B5-4D25-9DE8-ABBD1D99501E}", "8d858fb2-d988-4a26-bd81-ad65f06985a1", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "{6166694F-5F3B-4737-8DDA-6025E9D57B41}", 0, "f42a9cd8-d974-437b-ba66-3654519c6b21", "admin@gameStore.com", true, false, null, "ADMIN@GAMESTORE.COM", "ADMIN", "AQAAAAIAAYagAAAAELisG0rIwfaIk7FxAx0xj4ZYpZbF9j9/4xiKTlke9NKi07MyAy0r37XykjVT54jG8Q==", null, true, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "{50E3664F-A4B5-4D25-9DE8-ABBD1D99501E}", "{6166694F-5F3B-4737-8DDA-6025E9D57B41}" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "{50E3664F-A4B5-4D25-9DE8-ABBD1D99501E}", "{6166694F-5F3B-4737-8DDA-6025E9D57B41}" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "{50E3664F-A4B5-4D25-9DE8-ABBD1D99501E}");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "{6166694F-5F3B-4737-8DDA-6025E9D57B41}");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "{318295C6-0B4F-4D2D-A81B-76A375B69CF5}", "7080b862-3e6d-45b8-a820-f0883bb0f74a", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "{C57B1666-4A5E-4461-B6CE-FCD850D12844}", 0, "69e41ae1-b425-4502-97a2-5165a59fb6c5", "admin@gameStore.com", true, false, null, "ADMIN@GAMESTORE.COM", "ADMIN", "AQAAAAIAAYagAAAAEA/12U3UasR0py23K92bj06qSRIPu4znwUUDIlkXXVZUwyhQaYzyrsjSaH6KjmKVcA==", null, true, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "{318295C6-0B4F-4D2D-A81B-76A375B69CF5}", "{C57B1666-4A5E-4461-B6CE-FCD850D12844}" });
        }
    }
}
