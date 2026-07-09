using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketing.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "CreatedAt", "Phone", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 9, 1, 0, 914, DateTimeKind.Utc).AddTicks(6732), "082222222222", new DateTime(2026, 7, 9, 9, 1, 0, 914, DateTimeKind.Utc).AddTicks(6733) });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Email", "IsActive", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[] { 5L, new DateTime(2026, 7, 9, 9, 1, 0, 914, DateTimeKind.Utc).AddTicks(6736), null, "budi.customer@gmail.com", true, "Budi Setiawan", "$2a$11$abcdefghijklmnopqrstuuktGbqrT8QbkGjM98OkmV8Y.ltInGree", "083333333333", new DateTime(2026, 7, 9, 9, 1, 0, 914, DateTimeKind.Utc).AddTicks(6737) });

            migrationBuilder.UpdateData(
                table: "venues",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 9, 9, 1, 0, 499, DateTimeKind.Utc).AddTicks(4203));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.UpdateData(
                table: "event_categories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 9, 8, 56, 39, 901, DateTimeKind.Utc).AddTicks(2533));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 56, 39, 905, DateTimeKind.Utc).AddTicks(2607), new DateTime(2026, 7, 9, 8, 56, 39, 905, DateTimeKind.Utc).AddTicks(2608) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 56, 39, 905, DateTimeKind.Utc).AddTicks(3376), new DateTime(2026, 7, 9, 8, 56, 39, 905, DateTimeKind.Utc).AddTicks(3377) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 56, 39, 905, DateTimeKind.Utc).AddTicks(3379), new DateTime(2026, 7, 9, 8, 56, 39, 905, DateTimeKind.Utc).AddTicks(3379) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 56, 39, 905, DateTimeKind.Utc).AddTicks(3380), new DateTime(2026, 7, 9, 8, 56, 39, 905, DateTimeKind.Utc).AddTicks(3381) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 56, 40, 239, DateTimeKind.Utc).AddTicks(807), new DateTime(2026, 7, 9, 8, 56, 40, 239, DateTimeKind.Utc).AddTicks(814) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "Phone", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 56, 40, 239, DateTimeKind.Utc).AddTicks(2999), "081111111112", new DateTime(2026, 7, 9, 8, 56, 40, 239, DateTimeKind.Utc).AddTicks(3000) });

            migrationBuilder.UpdateData(
                table: "venues",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 9, 8, 56, 39, 902, DateTimeKind.Utc).AddTicks(1468));
        }
    }
}
