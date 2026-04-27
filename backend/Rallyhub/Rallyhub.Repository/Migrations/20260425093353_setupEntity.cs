using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rallyhub.Repository.Migrations
{
    /// <inheritdoc />
    public partial class setupEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampaignCourts_Courts_CourseId",
                table: "CampaignCourts");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCourts_Courts_CourseId",
                table: "SubCourts");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "SubCourts",
                newName: "CourtId");

            migrationBuilder.RenameIndex(
                name: "IX_SubCourts_CourseId",
                table: "SubCourts",
                newName: "IX_SubCourts_CourtId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CampaignCourts",
                newName: "CourtId");

            migrationBuilder.RenameIndex(
                name: "IX_CampaignCourts_CourseId",
                table: "CampaignCourts",
                newName: "IX_CampaignCourts_CourtId");

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignCourts_Courts_CourtId",
                table: "CampaignCourts",
                column: "CourtId",
                principalTable: "Courts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCourts_Courts_CourtId",
                table: "SubCourts",
                column: "CourtId",
                principalTable: "Courts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampaignCourts_Courts_CourtId",
                table: "CampaignCourts");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCourts_Courts_CourtId",
                table: "SubCourts");

            migrationBuilder.RenameColumn(
                name: "CourtId",
                table: "SubCourts",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_SubCourts_CourtId",
                table: "SubCourts",
                newName: "IX_SubCourts_CourseId");

            migrationBuilder.RenameColumn(
                name: "CourtId",
                table: "CampaignCourts",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CampaignCourts_CourtId",
                table: "CampaignCourts",
                newName: "IX_CampaignCourts_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignCourts_Courts_CourseId",
                table: "CampaignCourts",
                column: "CourseId",
                principalTable: "Courts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCourts_Courts_CourseId",
                table: "SubCourts",
                column: "CourseId",
                principalTable: "Courts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
