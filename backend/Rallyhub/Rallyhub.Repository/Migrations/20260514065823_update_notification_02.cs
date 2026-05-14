using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rallyhub.Repository.Migrations
{
    /// <inheritdoc />
    public partial class update_notification_02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "FeedbackId1",
                table: "Notifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerRequestId1",
                table: "Notifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReportId1",
                table: "Notifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SystemReportId1",
                table: "Notifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WithdrawalId",
                table: "Notifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WithdrawalId1",
                table: "Notifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_FeedbackId",
                table: "Notifications",
                column: "FeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_FeedbackId1",
                table: "Notifications",
                column: "FeedbackId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_OwnerRequestId",
                table: "Notifications",
                column: "OwnerRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_OwnerRequestId1",
                table: "Notifications",
                column: "OwnerRequestId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ReportId",
                table: "Notifications",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ReportId1",
                table: "Notifications",
                column: "ReportId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_SystemReportId",
                table: "Notifications",
                column: "SystemReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_SystemReportId1",
                table: "Notifications",
                column: "SystemReportId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_WithdrawalId",
                table: "Notifications",
                column: "WithdrawalId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_WithdrawalId1",
                table: "Notifications",
                column: "WithdrawalId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Feedbacks_FeedbackId",
                table: "Notifications",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Feedbacks_FeedbackId1",
                table: "Notifications",
                column: "FeedbackId1",
                principalTable: "Feedbacks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_OwnerRequests_OwnerRequestId",
                table: "Notifications",
                column: "OwnerRequestId",
                principalTable: "OwnerRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_OwnerRequests_OwnerRequestId1",
                table: "Notifications",
                column: "OwnerRequestId1",
                principalTable: "OwnerRequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Reports_ReportId",
                table: "Notifications",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Reports_ReportId1",
                table: "Notifications",
                column: "ReportId1",
                principalTable: "Reports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_SystemReports_SystemReportId",
                table: "Notifications",
                column: "SystemReportId",
                principalTable: "SystemReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_SystemReports_SystemReportId1",
                table: "Notifications",
                column: "SystemReportId1",
                principalTable: "SystemReports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Withdrawals_WithdrawalId",
                table: "Notifications",
                column: "WithdrawalId",
                principalTable: "Withdrawals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Withdrawals_WithdrawalId1",
                table: "Notifications",
                column: "WithdrawalId1",
                principalTable: "Withdrawals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Feedbacks_FeedbackId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Feedbacks_FeedbackId1",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_OwnerRequests_OwnerRequestId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_OwnerRequests_OwnerRequestId1",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Reports_ReportId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Reports_ReportId1",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_SystemReports_SystemReportId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_SystemReports_SystemReportId1",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Withdrawals_WithdrawalId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Withdrawals_WithdrawalId1",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_FeedbackId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_FeedbackId1",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_OwnerRequestId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_OwnerRequestId1",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_ReportId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_ReportId1",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_SystemReportId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_SystemReportId1",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_WithdrawalId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_WithdrawalId1",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "FeedbackId1",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "OwnerRequestId1",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "ReportId1",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "SystemReportId1",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "WithdrawalId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "WithdrawalId1",
                table: "Notifications");

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
        }
    }
}
