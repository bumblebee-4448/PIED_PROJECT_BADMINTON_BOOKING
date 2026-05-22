using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rallyhub.Repository.Migrations
{
    /// <inheritdoc />
    public partial class add_admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt" },
                values: new object[] { new Guid("96ea8dc4-130e-429b-8cb8-4f97c8a7463d"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(2026, 5, 22, 13, 4, 29, 125, DateTimeKind.Unspecified).AddTicks(3042), new TimeSpan(0, 0, 0, 0, 0)), "phamquochoang356@gmail.com", "Phạm", false, "Hoàng", "$2a$11$hCiq6OBnPcq3WY.MRk4b8OLrjpydlG0snuczH367YwIY.wSie6iwi", "0123456781", "Admin", "Active", new DateTimeOffset(new DateTime(2026, 5, 22, 13, 4, 29, 125, DateTimeKind.Unspecified).AddTicks(3047), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96ea8dc4-130e-429b-8cb8-4f97c8a7463d"));
        }
    }
}
