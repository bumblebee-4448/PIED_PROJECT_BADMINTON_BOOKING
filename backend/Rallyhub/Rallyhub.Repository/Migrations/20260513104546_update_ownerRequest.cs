using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rallyhub.Repository.Migrations
{
    /// <inheritdoc />
    public partial class update_ownerRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Transactions_TransactionId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_OwnerRequests_TaxCode",
                table: "OwnerRequests");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_TransactionId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Notifications");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TransactionId",
                table: "Notifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OwnerRequests_TaxCode",
                table: "OwnerRequests",
                column: "TaxCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TransactionId",
                table: "Notifications",
                column: "TransactionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Transactions_TransactionId",
                table: "Notifications",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id");
        }
    }
}
