using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketing.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialFreshDbWithAllRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "event_categories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 9, 9, 2, 24, 541, DateTimeKind.Utc).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 9, 2, 24, 545, DateTimeKind.Utc).AddTicks(979), new DateTime(2026, 7, 9, 9, 2, 24, 545, DateTimeKind.Utc).AddTicks(980) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 9, 2, 24, 545, DateTimeKind.Utc).AddTicks(1753), new DateTime(2026, 7, 9, 9, 2, 24, 545, DateTimeKind.Utc).AddTicks(1754) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 9, 2, 24, 545, DateTimeKind.Utc).AddTicks(1756), new DateTime(2026, 7, 9, 9, 2, 24, 545, DateTimeKind.Utc).AddTicks(1757) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 9, 2, 24, 545, DateTimeKind.Utc).AddTicks(1758), new DateTime(2026, 7, 9, 9, 2, 24, 545, DateTimeKind.Utc).AddTicks(1758) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 9, 2, 24, 778, DateTimeKind.Utc).AddTicks(5350), new DateTime(2026, 7, 9, 9, 2, 24, 778, DateTimeKind.Utc).AddTicks(5354) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 9, 2, 24, 778, DateTimeKind.Utc).AddTicks(7468), new DateTime(2026, 7, 9, 9, 2, 24, 778, DateTimeKind.Utc).AddTicks(7469) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 9, 2, 24, 778, DateTimeKind.Utc).AddTicks(7488), new DateTime(2026, 7, 9, 9, 2, 24, 778, DateTimeKind.Utc).AddTicks(7489) });

            migrationBuilder.UpdateData(
                table: "venues",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 9, 9, 2, 24, 542, DateTimeKind.Utc).AddTicks(872));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "event_categories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 9, 9, 1, 0, 498, DateTimeKind.Utc).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 9, 1, 0, 502, DateTimeKind.Utc).AddTicks(6824), new DateTime(2026, 7, 9, 9, 1, 0, 502, DateTimeKind.Utc).AddTicks(6825) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 9, 1, 0, 502, DateTimeKind.Utc).AddTicks(7599), new DateTime(2026, 7, 9, 9, 1, 0, 502, DateTimeKind.Utc).AddTicks(7600) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 9, 1, 0, 502, DateTimeKind.Utc).AddTicks(7602), new DateTime(2026, 7, 9, 9, 1, 0, 502, DateTimeKind.Utc).AddTicks(7602) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 9, 1, 0, 502, DateTimeKind.Utc).AddTicks(7604), new DateTime(2026, 7, 9, 9, 1, 0, 502, DateTimeKind.Utc).AddTicks(7604) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 9, 1, 0, 914, DateTimeKind.Utc).AddTicks(4430), new DateTime(2026, 7, 9, 9, 1, 0, 914, DateTimeKind.Utc).AddTicks(4434) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 9, 1, 0, 914, DateTimeKind.Utc).AddTicks(6732), new DateTime(2026, 7, 9, 9, 1, 0, 914, DateTimeKind.Utc).AddTicks(6733) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 9, 1, 0, 914, DateTimeKind.Utc).AddTicks(6736), new DateTime(2026, 7, 9, 9, 1, 0, 914, DateTimeKind.Utc).AddTicks(6737) });

            migrationBuilder.UpdateData(
                table: "venues",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 9, 9, 1, 0, 499, DateTimeKind.Utc).AddTicks(4203));
        }
    }
}
