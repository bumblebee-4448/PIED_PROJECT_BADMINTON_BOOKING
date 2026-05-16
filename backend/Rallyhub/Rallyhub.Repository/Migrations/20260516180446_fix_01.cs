using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rallyhub.Repository.Migrations
{
    /// <inheritdoc />
    public partial class fix_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Courts",
                type: "numeric(18,10)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,10)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Courts",
                type: "numeric(18,10)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,10)");

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "Date", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 11, 18, 4, 45, 599, DateTimeKind.Unspecified).AddTicks(5340), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 11, 18, 4, 45, 599, DateTimeKind.Unspecified).AddTicks(5331), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 11, 18, 4, 45, 599, DateTimeKind.Unspecified).AddTicks(5341), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "Date", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 599, DateTimeKind.Unspecified).AddTicks(5345), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 599, DateTimeKind.Unspecified).AddTicks(5344), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 599, DateTimeKind.Unspecified).AddTicks(5345), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 11, 18, 4, 45, 599, DateTimeKind.Unspecified).AddTicks(2071), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 11, 18, 4, 45, 599, DateTimeKind.Unspecified).AddTicks(2078), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 599, DateTimeKind.Unspecified).AddTicks(2083), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 599, DateTimeKind.Unspecified).AddTicks(2084), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 4, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2043), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2048), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2058), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2058), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2063), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2063), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2122), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2123), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2127), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2127), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2133), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2133), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2138), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2138), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000007"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2142), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2142), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000008"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2146), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2146), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000009"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2152), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2152), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000010"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2156), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2156), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000011"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2161), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2161), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000012"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2166), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2166), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000013"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2172), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2172), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000014"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2177), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2177), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000015"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2182), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2182), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000016"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2187), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2187), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000017"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2191), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2192), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000018"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2195), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2196), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000019"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2233), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2233), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000020"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2238), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2238), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000021"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2242), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2242), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000022"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2246), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2246), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000023"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2250), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2250), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000024"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2254), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2254), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000025"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2258), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2258), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000026"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2261), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2262), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000027"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2265), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2266), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000028"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2269), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2270), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000029"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2273), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2274), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000030"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2277), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2278), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000031"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2281), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000032"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2285), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2285), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000033"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2291), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2291), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000034"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2295), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2295), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000035"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2298), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2299), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000036"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2326), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2326), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000037"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2330), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2331), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000038"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2334), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2335), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000039"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2338), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2339), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000040"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2342), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2343), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 4, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2568), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2572), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 4, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2576), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 16, 18, 4, 45, 600, DateTimeKind.Unspecified).AddTicks(2577), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 4, 16, 18, 4, 45, 610, DateTimeKind.Unspecified).AddTicks(630), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 16, 18, 4, 45, 610, DateTimeKind.Unspecified).AddTicks(654), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 11, 18, 4, 45, 610, DateTimeKind.Unspecified).AddTicks(5890), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 11, 18, 4, 45, 610, DateTimeKind.Unspecified).AddTicks(5900), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 610, DateTimeKind.Unspecified).AddTicks(5905), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 18, 4, 45, 610, DateTimeKind.Unspecified).AddTicks(5906), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 4, 16, 18, 4, 45, 598, DateTimeKind.Unspecified).AddTicks(9307), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 16, 18, 4, 45, 598, DateTimeKind.Unspecified).AddTicks(9332), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 4, 16, 18, 4, 45, 598, DateTimeKind.Unspecified).AddTicks(9338), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 16, 18, 4, 45, 598, DateTimeKind.Unspecified).AddTicks(9339), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 4, 16, 18, 4, 45, 610, DateTimeKind.Unspecified).AddTicks(7513), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 16, 18, 4, 45, 610, DateTimeKind.Unspecified).AddTicks(7519), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 4, 16, 18, 4, 45, 610, DateTimeKind.Unspecified).AddTicks(7524), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 16, 18, 4, 45, 610, DateTimeKind.Unspecified).AddTicks(7525), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Courts",
                type: "numeric(18,10)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Courts",
                type: "numeric(18,10)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,10)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "Date", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 11, 9, 15, 25, 601, DateTimeKind.Unspecified).AddTicks(6637), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 11, 9, 15, 25, 601, DateTimeKind.Unspecified).AddTicks(6628), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 11, 9, 15, 25, 601, DateTimeKind.Unspecified).AddTicks(6638), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "Date", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 601, DateTimeKind.Unspecified).AddTicks(6643), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 601, DateTimeKind.Unspecified).AddTicks(6642), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 601, DateTimeKind.Unspecified).AddTicks(6643), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 11, 9, 15, 25, 601, DateTimeKind.Unspecified).AddTicks(3253), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 11, 9, 15, 25, 601, DateTimeKind.Unspecified).AddTicks(3268), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 601, DateTimeKind.Unspecified).AddTicks(3277), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 601, DateTimeKind.Unspecified).AddTicks(3278), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 4, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1214), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1220), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1234), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1235), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1242), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1243), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1249), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1250), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1299), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1300), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1309), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1309), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1314), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1315), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000007"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1322), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1323), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000008"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1328), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1329), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000009"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1336), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1336), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000010"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1341), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1341), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000011"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1346), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1347), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000012"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1351), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1352), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000013"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1356), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1357), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000014"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1362), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1362), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000015"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1367), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1367), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000016"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1371), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1371), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000017"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1376), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1376), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000018"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1380), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1380), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000019"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1384), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1384), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000020"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1388), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1388), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000021"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1437), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1438), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000022"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1442), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1442), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000023"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1446), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1446), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000024"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1450), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1450), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000025"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1454), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1455), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000026"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1458), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1459), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000027"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1463), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1464), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000028"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1468), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1468), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000029"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1473), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1473), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000030"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1478), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1478), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000031"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1483), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1483), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000032"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1488), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1488), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000033"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1494), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1494), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000034"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1498), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1498), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000035"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1502), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1502), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000036"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1506), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1506), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000037"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1510), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1511), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000038"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1514), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1515), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000039"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1550), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1551), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000040"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1555), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1555), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 4, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1853), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1857), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 4, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1861), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1862), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 4, 16, 9, 15, 25, 615, DateTimeKind.Unspecified).AddTicks(5413), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 16, 9, 15, 25, 615, DateTimeKind.Unspecified).AddTicks(5440), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 11, 9, 15, 25, 616, DateTimeKind.Unspecified).AddTicks(2687), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 11, 9, 15, 25, 616, DateTimeKind.Unspecified).AddTicks(2697), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 616, DateTimeKind.Unspecified).AddTicks(2704), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 616, DateTimeKind.Unspecified).AddTicks(2705), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 4, 16, 9, 15, 25, 601, DateTimeKind.Unspecified).AddTicks(370), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 16, 9, 15, 25, 601, DateTimeKind.Unspecified).AddTicks(392), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 4, 16, 9, 15, 25, 601, DateTimeKind.Unspecified).AddTicks(398), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 16, 9, 15, 25, 601, DateTimeKind.Unspecified).AddTicks(399), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 4, 16, 9, 15, 25, 616, DateTimeKind.Unspecified).AddTicks(4676), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 16, 9, 15, 25, 616, DateTimeKind.Unspecified).AddTicks(4685), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 4, 16, 9, 15, 25, 616, DateTimeKind.Unspecified).AddTicks(4691), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 16, 9, 15, 25, 616, DateTimeKind.Unspecified).AddTicks(4692), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
