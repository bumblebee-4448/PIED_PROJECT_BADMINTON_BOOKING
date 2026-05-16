using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rallyhub.Repository.Migrations
{
    /// <inheritdoc />
    public partial class seeddata_06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Courts",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "TimeRefundBefor", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("c0000000-0000-0000-0000-000000000011"), "Thủ Đức, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1346), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.8523m, 106.7589m, "https://maps.google.com", "Sân Cầu Lông Lan Anh Thủ Đức", new TimeOnly(5, 0, 0), new Guid("d9035646-41ac-4110-b9d1-d30b1c125ffe"), "https://example.com/td1.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1347), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000012"), "Thủ Đức, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1351), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.8645m, 106.7432m, "https://maps.google.com", "Sân Cầu Lông Tam Phú", new TimeOnly(6, 0, 0), new Guid("11bdc660-19e9-42cc-a7bb-448453c2852a"), "https://example.com/td2.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1352), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000013"), "Thủ Đức, HCM", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1356), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.8256m, 106.7234m, "https://maps.google.com", "Sân Cầu Lông Hiệp Bình Chánh", new TimeOnly(5, 0, 0), new Guid("d9035646-41ac-4110-b9d1-d30b1c125ffe"), "https://example.com/td3.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1357), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000014"), "Thủ Đức, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1362), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.8712m, 106.7789m, "https://maps.google.com", "Sân Cầu Lông Linh Trung", new TimeOnly(6, 0, 0), new Guid("11bdc660-19e9-42cc-a7bb-448453c2852a"), "https://example.com/td4.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1362), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000015"), "Thủ Đức, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1367), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.8234m, 106.7845m, "https://maps.google.com", "Sân Cầu Lông Phước Long B", new TimeOnly(5, 0, 0), new Guid("d9035646-41ac-4110-b9d1-d30b1c125ffe"), "https://example.com/td5.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1367), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000016"), "Thủ Đức, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1371), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.8345m, 106.7912m, "https://maps.google.com", "Sân Cầu Lông Tăng Nhơn Phú", new TimeOnly(6, 0, 0), new Guid("11bdc660-19e9-42cc-a7bb-448453c2852a"), "https://example.com/td6.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1371), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000017"), "Thủ Đức, HCM", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1376), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.8456m, 106.8234m, "https://maps.google.com", "Sân Cầu Lông Long Thạnh Mỹ", new TimeOnly(5, 0, 0), new Guid("d9035646-41ac-4110-b9d1-d30b1c125ffe"), "https://example.com/td7.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1376), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000018"), "Thủ Đức, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1380), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.8312m, 106.7654m, "https://maps.google.com", "Sân Cầu Lông Trường Thọ", new TimeOnly(6, 0, 0), new Guid("11bdc660-19e9-42cc-a7bb-448453c2852a"), "https://example.com/td8.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1380), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000019"), "Bình Chánh, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1384), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.7123m, 106.6789m, "https://maps.google.com", "Sân Cầu Lông Bình Hưng", new TimeOnly(5, 0, 0), new Guid("d9035646-41ac-4110-b9d1-d30b1c125ffe"), "https://example.com/bc1.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1384), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000020"), "Bình Chánh, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1388), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.6945m, 106.6634m, "https://maps.google.com", "Sân Cầu Lông Phong Phú", new TimeOnly(6, 0, 0), new Guid("11bdc660-19e9-42cc-a7bb-448453c2852a"), "https://example.com/bc2.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1388), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000021"), "Bình Chánh, HCM", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1437), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.6612m, 106.6856m, "https://maps.google.com", "Sân Cầu Lông Đa Phước", new TimeOnly(5, 0, 0), new Guid("d9035646-41ac-4110-b9d1-d30b1c125ffe"), "https://example.com/bc3.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1438), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000022"), "Bình Chánh, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1442), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.8034m, 106.5878m, "https://maps.google.com", "Sân Cầu Lông Vĩnh Lộc", new TimeOnly(6, 0, 0), new Guid("11bdc660-19e9-42cc-a7bb-448453c2852a"), "https://example.com/bc4.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1442), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000023"), "Bình Chánh, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1446), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.7545m, 106.5234m, "https://maps.google.com", "Sân Cầu Lông Lê Minh Xuân", new TimeOnly(5, 0, 0), new Guid("d9035646-41ac-4110-b9d1-d30b1c125ffe"), "https://example.com/bc5.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1446), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000024"), "Bình Chánh, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1450), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.7812m, 106.5123m, "https://maps.google.com", "Sân Cầu Lông Phạm Văn Hai", new TimeOnly(6, 0, 0), new Guid("11bdc660-19e9-42cc-a7bb-448453c2852a"), "https://example.com/bc6.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1450), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000025"), "Bình Chánh, HCM", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1454), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.6912m, 106.5845m, "https://maps.google.com", "Sân Cầu Lông Tân Túc", new TimeOnly(5, 0, 0), new Guid("d9035646-41ac-4110-b9d1-d30b1c125ffe"), "https://example.com/bc7.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1455), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000026"), "Thuận An, Bình Dương", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1458), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.9012m, 106.7034m, "https://maps.google.com", "Sân Cầu Lông Thuận An", new TimeOnly(5, 0, 0), new Guid("11bdc660-19e9-42cc-a7bb-448453c2852a"), "https://example.com/bd1.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1459), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000027"), "Dĩ An, Bình Dương", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1463), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.9123m, 106.7845m, "https://maps.google.com", "Sân Cầu Lông Dĩ An", new TimeOnly(6, 0, 0), new Guid("d9035646-41ac-4110-b9d1-d30b1c125ffe"), "https://example.com/bd2.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1464), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000028"), "Thủ Dầu Một, Bình Dương", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1468), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.9845m, 106.6534m, "https://maps.google.com", "Sân Cầu Lông Thủ Dầu Một", new TimeOnly(5, 0, 0), new Guid("11bdc660-19e9-42cc-a7bb-448453c2852a"), "https://example.com/bd3.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1468), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000029"), "Bến Cát, Bình Dương", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1473), new TimeSpan(0, 0, 0, 0, 0)), null, false, 11.1234m, 106.6012m, "https://maps.google.com", "Sân Cầu Lông Bến Cát", new TimeOnly(6, 0, 0), new Guid("d9035646-41ac-4110-b9d1-d30b1c125ffe"), "https://example.com/bd4.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1473), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000030"), "Tân Uyên, Bình Dương", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1478), new TimeSpan(0, 0, 0, 0, 0)), null, false, 11.0545m, 106.8234m, "https://maps.google.com", "Sân Cầu Lông Tân Uyên", new TimeOnly(5, 0, 0), new Guid("11bdc660-19e9-42cc-a7bb-448453c2852a"), "https://example.com/bd5.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1478), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000031"), "Thuận An, Bình Dương", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1483), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.8912m, 106.6912m, "https://maps.google.com", "Sân Cầu Lông Lái Thiêu", new TimeOnly(6, 0, 0), new Guid("d9035646-41ac-4110-b9d1-d30b1c125ffe"), "https://example.com/bd6.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1483), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000032"), "Dĩ An, Bình Dương", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1488), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.8945m, 106.7534m, "https://maps.google.com", "Sân Cầu Lông Sóng Thần", new TimeOnly(5, 0, 0), new Guid("11bdc660-19e9-42cc-a7bb-448453c2852a"), "https://example.com/bd7.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1488), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000033"), "Bến Cát, Bình Dương", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1494), new TimeSpan(0, 0, 0, 0, 0)), null, false, 11.1012m, 106.5845m, "https://maps.google.com", "Sân Cầu Lông Mỹ Phước", new TimeOnly(6, 0, 0), new Guid("d9035646-41ac-4110-b9d1-d30b1c125ffe"), "https://example.com/bd8.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1494), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000034"), "Vũng Tàu", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1498), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.3456m, 107.0789m, "https://maps.google.com", "Sân Cầu Lông Bãi Trước", new TimeOnly(5, 0, 0), new Guid("11bdc660-19e9-42cc-a7bb-448453c2852a"), "https://example.com/vt1.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1498), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000035"), "Vũng Tàu", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1502), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.3545m, 107.1012m, "https://maps.google.com", "Sân Cầu Lông Bãi Sau", new TimeOnly(6, 0, 0), new Guid("d9035646-41ac-4110-b9d1-d30b1c125ffe"), "https://example.com/vt2.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1502), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000036"), "Vũng Tàu", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1506), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.3812m, 107.1234m, "https://maps.google.com", "Sân Cầu Lông Chí Linh", new TimeOnly(5, 0, 0), new Guid("11bdc660-19e9-42cc-a7bb-448453c2852a"), "https://example.com/vt3.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1506), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000037"), "Vũng Tàu", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1510), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.4034m, 107.1123m, "https://maps.google.com", "Sân Cầu Lông Rạch Dừa", new TimeOnly(6, 0, 0), new Guid("d9035646-41ac-4110-b9d1-d30b1c125ffe"), "https://example.com/vt4.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1511), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000038"), "Vũng Tàu", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1514), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.3912m, 107.0945m, "https://maps.google.com", "Sân Cầu Lông Thắng Nhất", new TimeOnly(5, 0, 0), new Guid("11bdc660-19e9-42cc-a7bb-448453c2852a"), "https://example.com/vt5.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1515), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000039"), "Vũng Tàu", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1550), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.3645m, 107.0856m, "https://maps.google.com", "Sân Cầu Lông Phường 7", new TimeOnly(6, 0, 0), new Guid("d9035646-41ac-4110-b9d1-d30b1c125ffe"), "https://example.com/vt6.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1551), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0000000-0000-0000-0000-000000000040"), "Vũng Tàu", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1555), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.4512m, 107.0812m, "https://maps.google.com", "Sân Cầu Lông Long Sơn", new TimeOnly(5, 0, 0), new Guid("11bdc660-19e9-42cc-a7bb-448453c2852a"), "https://example.com/vt7.jpg", "Active", 120, new DateTimeOffset(new DateTime(2026, 5, 16, 9, 15, 25, 603, DateTimeKind.Unspecified).AddTicks(1555), new TimeSpan(0, 0, 0, 0, 0)) }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000021"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000022"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000023"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000024"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000025"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000026"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000027"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000028"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000029"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000030"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000031"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000032"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000033"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000034"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000035"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000036"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000037"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000038"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000039"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000040"));

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "Date", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 11, 9, 10, 37, 78, DateTimeKind.Unspecified).AddTicks(6247), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 11, 9, 10, 37, 78, DateTimeKind.Unspecified).AddTicks(6239), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 11, 9, 10, 37, 78, DateTimeKind.Unspecified).AddTicks(6247), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "Date", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 78, DateTimeKind.Unspecified).AddTicks(6252), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 78, DateTimeKind.Unspecified).AddTicks(6251), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 78, DateTimeKind.Unspecified).AddTicks(6253), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 11, 9, 10, 37, 78, DateTimeKind.Unspecified).AddTicks(2794), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 11, 9, 10, 37, 78, DateTimeKind.Unspecified).AddTicks(2800), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 78, DateTimeKind.Unspecified).AddTicks(2805), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 78, DateTimeKind.Unspecified).AddTicks(2805), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 4, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(3919), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(3925), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(3934), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(3935), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(3940), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(3941), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(3944), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(3945), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(3948), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(3949), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(3954), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(3954), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(3958), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(3958), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000007"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(3962), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(3962), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000008"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(3966), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(3967), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000009"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(3971), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(3971), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000010"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(3975), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(3975), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 4, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(4173), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(4175), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 4, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(4205), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 16, 9, 10, 37, 79, DateTimeKind.Unspecified).AddTicks(4206), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 4, 16, 9, 10, 37, 90, DateTimeKind.Unspecified).AddTicks(7624), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 16, 9, 10, 37, 90, DateTimeKind.Unspecified).AddTicks(7647), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 11, 9, 10, 37, 91, DateTimeKind.Unspecified).AddTicks(4560), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 11, 9, 10, 37, 91, DateTimeKind.Unspecified).AddTicks(4567), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 91, DateTimeKind.Unspecified).AddTicks(4577), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 16, 9, 10, 37, 91, DateTimeKind.Unspecified).AddTicks(4577), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 4, 16, 9, 10, 37, 77, DateTimeKind.Unspecified).AddTicks(9974), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 16, 9, 10, 37, 77, DateTimeKind.Unspecified).AddTicks(9998), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 4, 16, 9, 10, 37, 78, DateTimeKind.Unspecified).AddTicks(5), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 16, 9, 10, 37, 78, DateTimeKind.Unspecified).AddTicks(6), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 4, 16, 9, 10, 37, 91, DateTimeKind.Unspecified).AddTicks(6475), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 16, 9, 10, 37, 91, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 4, 16, 9, 10, 37, 91, DateTimeKind.Unspecified).AddTicks(6487), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 16, 9, 10, 37, 91, DateTimeKind.Unspecified).AddTicks(6488), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
