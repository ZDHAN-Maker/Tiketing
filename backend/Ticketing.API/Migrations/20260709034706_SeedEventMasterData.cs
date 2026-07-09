using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketing.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedEventMasterData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "event_categories",
                columns: new[] { "Id", "CreatedAt", "Name", "Slug" },
                values: new object[] { 1L, new DateTime(2026, 7, 9, 3, 47, 4, 357, DateTimeKind.Utc).AddTicks(1502), "Konser Musik", "konser-musik" });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 3, 47, 4, 362, DateTimeKind.Utc).AddTicks(1671), new DateTime(2026, 7, 9, 3, 47, 4, 362, DateTimeKind.Utc).AddTicks(1672) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 3, 47, 4, 362, DateTimeKind.Utc).AddTicks(2441), new DateTime(2026, 7, 9, 3, 47, 4, 362, DateTimeKind.Utc).AddTicks(2441) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 3, 47, 4, 362, DateTimeKind.Utc).AddTicks(2444), new DateTime(2026, 7, 9, 3, 47, 4, 362, DateTimeKind.Utc).AddTicks(2444) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 3, 47, 4, 588, DateTimeKind.Utc).AddTicks(1608), new DateTime(2026, 7, 9, 3, 47, 4, 588, DateTimeKind.Utc).AddTicks(1612) });

            migrationBuilder.InsertData(
                table: "venues",
                columns: new[] { "Id", "Address", "Capacity", "City", "CreatedAt", "GoogleMapsUrl", "Name" },
                values: new object[] { 1L, "Jl. Sudirman No 1", 50000L, "Jakarta", new DateTime(2026, 7, 9, 3, 47, 4, 358, DateTimeKind.Utc).AddTicks(2487), null, "Stadion Utama" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "event_categories",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "venues",
                keyColumn: "Id",
                keyValue: 1L);

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
    }
}
