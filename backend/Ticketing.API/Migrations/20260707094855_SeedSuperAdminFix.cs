using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketing.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedSuperAdminFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 7, 9, 48, 53, 422, DateTimeKind.Utc).AddTicks(797), new DateTime(2026, 7, 7, 9, 48, 53, 422, DateTimeKind.Utc).AddTicks(801) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 7, 9, 48, 53, 422, DateTimeKind.Utc).AddTicks(1565), new DateTime(2026, 7, 7, 9, 48, 53, 422, DateTimeKind.Utc).AddTicks(1566) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 7, 9, 48, 53, 422, DateTimeKind.Utc).AddTicks(1569), new DateTime(2026, 7, 7, 9, 48, 53, 422, DateTimeKind.Utc).AddTicks(1569) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 7, 9, 48, 53, 634, DateTimeKind.Utc).AddTicks(5550), "$2a$11$abcdefghijklmnopqrstuuktGbqrT8QbkGjM98OkmV8Y.ltInGree", new DateTime(2026, 7, 7, 9, 48, 53, 634, DateTimeKind.Utc).AddTicks(5554) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 7, 9, 35, 19, 142, DateTimeKind.Utc).AddTicks(7906), new DateTime(2026, 7, 7, 9, 35, 19, 142, DateTimeKind.Utc).AddTicks(7911) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 7, 9, 35, 19, 142, DateTimeKind.Utc).AddTicks(8866), new DateTime(2026, 7, 7, 9, 35, 19, 142, DateTimeKind.Utc).AddTicks(8867) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 7, 9, 35, 19, 142, DateTimeKind.Utc).AddTicks(8869), new DateTime(2026, 7, 7, 9, 35, 19, 142, DateTimeKind.Utc).AddTicks(8870) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 7, 9, 35, 19, 354, DateTimeKind.Utc).AddTicks(9893), "$2a$11$KAq9H9Xv3UcftDQ4s5nnr.7wWPgchWZPB5PrixTifw1yFzdJEA2ui", new DateTime(2026, 7, 7, 9, 35, 19, 354, DateTimeKind.Utc).AddTicks(9897) });
        }
    }
}
