using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketing.API.Migrations
{
    /// <inheritdoc />
    public partial class FixAdminSeedAndRolesKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 7, 9, 50, 53, 419, DateTimeKind.Utc).AddTicks(4472), new DateTime(2026, 7, 7, 9, 50, 53, 419, DateTimeKind.Utc).AddTicks(4475) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 7, 9, 50, 53, 419, DateTimeKind.Utc).AddTicks(5264), new DateTime(2026, 7, 7, 9, 50, 53, 419, DateTimeKind.Utc).AddTicks(5265) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 7, 9, 50, 53, 419, DateTimeKind.Utc).AddTicks(5267), new DateTime(2026, 7, 7, 9, 50, 53, 419, DateTimeKind.Utc).AddTicks(5268) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 7, 9, 50, 53, 632, DateTimeKind.Utc).AddTicks(8890), new DateTime(2026, 7, 7, 9, 50, 53, 632, DateTimeKind.Utc).AddTicks(8894) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 7, 9, 48, 53, 634, DateTimeKind.Utc).AddTicks(5550), new DateTime(2026, 7, 7, 9, 48, 53, 634, DateTimeKind.Utc).AddTicks(5554) });
        }
    }
}
