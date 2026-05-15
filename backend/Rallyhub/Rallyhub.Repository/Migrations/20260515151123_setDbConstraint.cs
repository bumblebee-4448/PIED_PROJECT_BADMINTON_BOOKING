using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rallyhub.Repository.Migrations
{
    /// <inheritdoc />
    public partial class setDbConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookingDetails_SubCourtId",
                table: "BookingDetails");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_SubCourtId_Date_StartTime_EndTime",
                table: "BookingDetails",
                columns: new[] { "SubCourtId", "Date", "StartTime", "EndTime" },
                unique: true,
                filter: "\"Status\" IN ('Pending', 'Banked')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookingDetails_SubCourtId_Date_StartTime_EndTime",
                table: "BookingDetails");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_SubCourtId",
                table: "BookingDetails",
                column: "SubCourtId");
        }
    }
}
