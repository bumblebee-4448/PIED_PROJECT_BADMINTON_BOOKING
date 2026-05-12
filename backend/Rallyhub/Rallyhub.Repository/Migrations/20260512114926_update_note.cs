using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rallyhub.Repository.Migrations
{
    /// <inheritdoc />
    public partial class update_note : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CourtId",
                table: "Notifications",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "BookingId",
                table: "Notifications",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "FeedbackId",
                table: "Notifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerRequestId",
                table: "Notifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReportId",
                table: "Notifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SystemReportId",
                table: "Notifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TransactionId",
                table: "Notifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "Campaigns",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_FeedbackId",
                table: "Notifications",
                column: "FeedbackId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_OwnerRequestId",
                table: "Notifications",
                column: "OwnerRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ReportId",
                table: "Notifications",
                column: "ReportId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_SystemReportId",
                table: "Notifications",
                column: "SystemReportId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TransactionId",
                table: "Notifications",
                column: "TransactionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Feedbacks_FeedbackId",
                table: "Notifications",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_OwnerRequests_OwnerRequestId",
                table: "Notifications",
                column: "OwnerRequestId",
                principalTable: "OwnerRequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Reports_ReportId",
                table: "Notifications",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_SystemReports_SystemReportId",
                table: "Notifications",
                column: "SystemReportId",
                principalTable: "SystemReports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Transactions_TransactionId",
                table: "Notifications",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Feedbacks_FeedbackId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_OwnerRequests_OwnerRequestId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Reports_ReportId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_SystemReports_SystemReportId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Transactions_TransactionId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_FeedbackId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_OwnerRequestId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_ReportId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_SystemReportId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_TransactionId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "FeedbackId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "OwnerRequestId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "SystemReportId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Notifications");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourtId",
                table: "Notifications",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BookingId",
                table: "Notifications",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "Campaigns",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);
        }
    }
}
