using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ticketing.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultRolesAndAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2026, 7, 7, 9, 35, 19, 142, DateTimeKind.Utc).AddTicks(7906), "SuperAdmin", new DateTime(2026, 7, 7, 9, 35, 19, 142, DateTimeKind.Utc).AddTicks(7911) },
                    { 2L, new DateTime(2026, 7, 7, 9, 35, 19, 142, DateTimeKind.Utc).AddTicks(8866), "EventOrganizer", new DateTime(2026, 7, 7, 9, 35, 19, 142, DateTimeKind.Utc).AddTicks(8867) },
                    { 3L, new DateTime(2026, 7, 7, 9, 35, 19, 142, DateTimeKind.Utc).AddTicks(8869), "Customer", new DateTime(2026, 7, 7, 9, 35, 19, 142, DateTimeKind.Utc).AddTicks(8870) }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Email", "IsActive", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[] { 1L, new DateTime(2026, 7, 7, 9, 35, 19, 354, DateTimeKind.Utc).AddTicks(9893), null, "superadmin@ticket.com", true, "Super Admin Utama", "$2a$11$KAq9H9Xv3UcftDQ4s5nnr.7wWPgchWZPB5PrixTifw1yFzdJEA2ui", "081111111111", new DateTime(2026, 7, 7, 9, 35, 19, 354, DateTimeKind.Utc).AddTicks(9897) });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1L, 1L });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
