using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketing.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOfficerIdToFour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2L);

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

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Email", "IsActive", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[] { 4L, new DateTime(2026, 7, 9, 8, 56, 40, 239, DateTimeKind.Utc).AddTicks(2999), null, "officer.gordon@ticketapp.com", true, "Gate Officer", "$2a$11$abcdefghijklmnopqrstuuktGbqrT8QbkGjM98OkmV8Y.ltInGree", "081111111112", new DateTime(2026, 7, 9, 8, 56, 40, 239, DateTimeKind.Utc).AddTicks(3000) });

            migrationBuilder.UpdateData(
                table: "venues",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 9, 8, 56, 39, 902, DateTimeKind.Utc).AddTicks(1468));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.UpdateData(
                table: "event_categories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 9, 8, 52, 50, 2, DateTimeKind.Utc).AddTicks(3635));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 52, 50, 7, DateTimeKind.Utc).AddTicks(1095), new DateTime(2026, 7, 9, 8, 52, 50, 7, DateTimeKind.Utc).AddTicks(1096) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 52, 50, 7, DateTimeKind.Utc).AddTicks(1864), new DateTime(2026, 7, 9, 8, 52, 50, 7, DateTimeKind.Utc).AddTicks(1864) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 52, 50, 7, DateTimeKind.Utc).AddTicks(1866), new DateTime(2026, 7, 9, 8, 52, 50, 7, DateTimeKind.Utc).AddTicks(1866) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 52, 50, 7, DateTimeKind.Utc).AddTicks(1867), new DateTime(2026, 7, 9, 8, 52, 50, 7, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 52, 50, 347, DateTimeKind.Utc).AddTicks(4364), new DateTime(2026, 7, 9, 8, 52, 50, 347, DateTimeKind.Utc).AddTicks(4368) });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Email", "IsActive", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[] { 2L, new DateTime(2026, 7, 9, 8, 52, 50, 347, DateTimeKind.Utc).AddTicks(6505), null, "officer.gordon@ticketapp.com", true, "Gate Officer", "$2a$11$abcdefghijklmnopqrstuuktGbqrT8QbkGjM98OkmV8Y.ltInGree", "081111111112", new DateTime(2026, 7, 9, 8, 52, 50, 347, DateTimeKind.Utc).AddTicks(6506) });

            migrationBuilder.UpdateData(
                table: "venues",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 9, 8, 52, 50, 3, DateTimeKind.Utc).AddTicks(5345));
        }
    }
}
