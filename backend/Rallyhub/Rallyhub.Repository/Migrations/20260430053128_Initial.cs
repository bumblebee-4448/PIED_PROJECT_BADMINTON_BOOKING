using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rallyhub.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "Customer"),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "Active"),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    TaxCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    BusinessAddress = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    BusinessLicenseUrl = table.Column<string>(type: "text", nullable: true),
                    IdentityNumber = table.Column<string>(type: "text", nullable: true),
                    IdentityCardFrontUrl = table.Column<string>(type: "text", nullable: true),
                    IdentityCardBackUrl = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Owners_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SystemReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Reason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false, defaultValue: "Pending"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemReports_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BankName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    BankAccount = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Balance = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsGlobal = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DiscountPercent = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    MaxDiscountAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    MinBookingAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    UsageLimit = table.Column<int>(type: "integer", nullable: false),
                    UsedCount = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaigns_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    OpenTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    CloseTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "Active"),
                    Latitude = table.Column<decimal>(type: "numeric(10,8)", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(11,8)", nullable: false),
                    MapUrl = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    PictureUrl = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courts_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OwnerRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    TaxCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    BusinessAddress = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    BusinessLicenseUrl = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IdentityNumber = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    IdentityCardFrontUrl = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IdentityCardBackUrl = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Status = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false, defaultValue: "Pending"),
                    RejectionReason = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnerRequests_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnerRequests_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    FinalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, defaultValue: "Pending"),
                    CancellationReason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampaignCourts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CourtId = table.Column<Guid>(type: "uuid", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignCourts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignCourts_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignCourts_Courts_CourtId",
                        column: x => x.CourtId,
                        principalTable: "Courts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LikeListDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CourtId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeListDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LikeListDetails_Courts_CourtId",
                        column: x => x.CourtId,
                        principalTable: "Courts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikeListDetails_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCourts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CourtId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCourts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCourts_Courts_CourtId",
                        column: x => x.CourtId,
                        principalTable: "Courts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CourtId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    BookingId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Courts_CourtId",
                        column: x => x.CourtId,
                        principalTable: "Courts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookingId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Content = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Type = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CourtId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Courts_CourtId",
                        column: x => x.CourtId,
                        principalTable: "Courts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Reason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false, defaultValue: "Pending"),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourtId = table.Column<Guid>(type: "uuid", nullable: false),
                    BookingId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Courts_CourtId",
                        column: x => x.CourtId,
                        principalTable: "Courts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    BalanceBefore = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    BalanceAfter = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    SePayId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    BankRefCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    BankAccountNumber = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    TransferContent = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ActionCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Signature = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false, defaultValue: "Success"),
                    BookingId = table.Column<Guid>(type: "uuid", nullable: false),
                    WalletId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookingDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubCourtId = table.Column<Guid>(type: "uuid", nullable: false),
                    BookingId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingDetails_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingDetails_SubCourts_SubCourtId",
                        column: x => x.SubCourtId,
                        principalTable: "SubCourts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConfigSlots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubCourtDetailId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfigSlots_SubCourts_SubCourtDetailId",
                        column: x => x.SubCourtDetailId,
                        principalTable: "SubCourts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exceptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubCourtDetailId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    Reason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exceptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exceptions_SubCourts_SubCourtDetailId",
                        column: x => x.SubCourtDetailId,
                        principalTable: "SubCourts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OverideSlots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubCourtDetailId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsRecurring = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DayOfWeek = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverideSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OverideSlots_SubCourts_SubCourtDetailId",
                        column: x => x.SubCourtDetailId,
                        principalTable: "SubCourts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2bb8cc43-6ceb-4e86-b085-528679bca6b3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner2@rallyhub.vn", "Hải", false, "Đăng", "hashed_pw_3", "0900000003", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("83b95f86-62d5-40fc-bd68-f6fd9c05ba4e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "admin@rallyhub.vn", "Quản", false, "Trị", "hashed_pw_1", "0900000001", "Admin", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8a3b27fa-dd6d-49b7-83b8-3e1712cc19db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner1@rallyhub.vn", "Minh", false, "Tuấn", "hashed_pw_2", "0900000002", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a6f0c3fe-2085-4f76-bf29-7c690f0b1d6f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner3@rallyhub.vn", "Trần", false, "Phú", "hashed_pw_6", "0900000006", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ab66bf11-307a-437d-8825-69d620e05638"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer1@gmail.com", "Lan", false, "Phương", "hashed_pw_4", "0900000004", "Customer", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e381df1d-6157-4c3c-84e2-871b67db78a6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer2@gmail.com", "Bảo", false, "Châu", "hashed_pw_5", "0900000005", "Customer", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("2c854d5c-e88b-48dd-befd-271a5713ce50"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ab66bf11-307a-437d-8825-69d620e05638") },
                    { new Guid("4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("e381df1d-6157-4c3c-84e2-871b67db78a6") }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("2c37b4dc-93c5-45ec-a159-1652e0be4166"), "123 Nguyễn Huệ, Q1, HCM", null, "Sân Cầu Lông Minh Tuấn", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, false, "0123456789", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8a3b27fa-dd6d-49b7-83b8-3e1712cc19db") },
                    { new Guid("b6d05ded-a3dc-4f1f-8820-f926f2c32434"), "Tôn Đức Thắng, HCM", null, "Sân Cầu Lông Trần Phú", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, false, "98765434219", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a6f0c3fe-2085-4f76-bf29-7c690f0b1d6f") },
                    { new Guid("fbfa9163-b847-4d0f-b7b6-239dcbd9086d"), "456 Lê Lợi, Q3, HCM", null, "Trung Tâm Thể Thao Hải Đăng", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, false, "9876543210", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2bb8cc43-6ceb-4e86-b085-528679bca6b3") }
                });

            migrationBuilder.InsertData(
                table: "SystemReports",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("0ee9863b-3d52-4fda-b2e7-93c329665b36"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Không thể thanh toán qua ví.", "Pending", "Lỗi thanh toán", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8a3b27fa-dd6d-49b7-83b8-3e1712cc19db") },
                    { new Guid("2b040261-a690-4cd9-9701-7721fa2e4808"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "OTP không gửi đến số điện thoại.", "Pending", "Không nhận được OTP", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ab66bf11-307a-437d-8825-69d620e05638") },
                    { new Guid("b3668f9c-274b-4007-a4cc-608c57448a8f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Số dư hiển thị không khớp lịch sử.", "Resolved", "Sai số dư sau giao dịch", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("e381df1d-6157-4c3c-84e2-871b67db78a6") },
                    { new Guid("e6c2c9ff-2c19-47e3-802c-2072cda49268"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Crash khi mở trang tìm kiếm sân.", "Pending", "App bị crash", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ab66bf11-307a-437d-8825-69d620e05638") },
                    { new Guid("f68c1408-dbf3-4254-aae3-dd87bfa87f1c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Bản đồ không load được trên iOS.", "Resolved", "Lỗi hiển thị bản đồ", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2bb8cc43-6ceb-4e86-b085-528679bca6b3") }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version" },
                values: new object[,]
                {
                    { new Guid("16afe692-bf8d-43ae-a28f-375a7b2fe854"), 12000000m, "2345678901", "Techcombank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8a3b27fa-dd6d-49b7-83b8-3e1712cc19db"), 0 },
                    { new Guid("c6170538-b504-4ee1-af8f-ab27d415b225"), 8500000m, "3456789012", "BIDV", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2bb8cc43-6ceb-4e86-b085-528679bca6b3"), 0 },
                    { new Guid("f17c0bc4-4b94-4f9e-bcb3-46878e4f9f6a"), 3500000m, "5678901234", "VPBank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("e381df1d-6157-4c3c-84e2-871b67db78a6"), 0 },
                    { new Guid("fa434c49-dad2-48e0-a3ba-aeb4c0094623"), 2000000m, "4567890123", "MB Bank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ab66bf11-307a-437d-8825-69d620e05638"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount" },
                values: new object[,]
                {
                    { new Guid("0465f92a-28a2-4e65-a117-4d2740b4d7bf"), "LOYAL5", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 30000m, 100000m, new Guid("fbfa9163-b847-4d0f-b7b6-239dcbd9086d"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 500, 87 },
                    { new Guid("31378b0d-5851-4cb3-8283-897863472854"), "WEEKEND10", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 15m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 75000m, 250000m, new Guid("fbfa9163-b847-4d0f-b7b6-239dcbd9086d"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 200, 30 },
                    { new Guid("b11ab76c-48a0-406c-b2fd-bdaa412ab515"), "SUMMER25", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 50000m, 200000m, new Guid("2c37b4dc-93c5-45ec-a159-1652e0be4166"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 100, 12 },
                    { new Guid("c54e7607-18ed-4b18-8e78-83d472fcf4be"), "NEWUSER", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 20m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 100000m, 300000m, new Guid("fbfa9163-b847-4d0f-b7b6-239dcbd9086d"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 50, 5 },
                    { new Guid("c7f10bf4-3255-4934-a5cd-86ef3cea2a26"), "YEUTH", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 30000m, 100000m, new Guid("2c37b4dc-93c5-45ec-a159-1652e0be4166"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 500, 87 },
                    { new Guid("f2238419-bc05-4e24-a529-ad4fa031deab"), "FLASH50", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 50m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 200000m, 500000m, new Guid("2c37b4dc-93c5-45ec-a159-1652e0be4166"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "Courts",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3091f52d-4ec1-4084-b29d-fe44239b41c4"), "456 Lê Lợi, Q3, HCM", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.78m, 106.69m, "https://maps.google.com/?q=10.78,106.69", "Sân C - Hải Đăng", new TimeOnly(5, 30, 0), new Guid("fbfa9163-b847-4d0f-b7b6-239dcbd9086d"), "https://images.example.com/courts/go-vap.jpg", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6c727fa5-a22e-48eb-b839-7be005527b6f"), "123 Nguyễn Huệ, Q1, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.77m, 106.70m, "https://maps.google.com/?q=10.77,106.70", "Sân A - Minh Tuấn", new TimeOnly(6, 0, 0), new Guid("2c37b4dc-93c5-45ec-a159-1652e0be4166"), "https://images.example.com/courts/go-vap.jpg", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a6ced920-265d-4b14-bc0f-ef8124f4577b"), "456 Lê Lợi, Q3, HCM", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.78m, 106.69m, "https://maps.google.com/?q=10.78,106.69", "Sân D - Hải Đăng", new TimeOnly(5, 30, 0), new Guid("fbfa9163-b847-4d0f-b7b6-239dcbd9086d"), "https://images.example.com/courts/go-vap.jpg", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e94ededf-b3a9-4c6c-9d19-1754ac62f6f9"), "123 Nguyễn Huệ, Q1, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.77m, 106.70m, "https://maps.google.com/?q=10.77,106.70", "Sân B - Minh Tuấn", new TimeOnly(6, 0, 0), new Guid("2c37b4dc-93c5-45ec-a159-1652e0be4166"), "https://images.example.com/courts/go-vap.jpg", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "OwnerRequests",
                columns: new[] { "Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "CustomerId", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "OwnerId", "RejectionReason", "Status", "TaxCode", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("94349f48-3bc4-46b2-bab2-2dfc971df84f"), "123 Nguyễn Huệ, Q1, HCM", "https://cdn.rallyhub.vn/license/1.jpg", "Sân Cầu Lông Minh Tuấn", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2c854d5c-e88b-48dd-befd-271a5713ce50"), "https://cdn.rallyhub.vn/cccd/1_back.jpg", "https://cdn.rallyhub.vn/cccd/1_front.jpg", "079200012345", false, new Guid("2c37b4dc-93c5-45ec-a159-1652e0be4166"), null, "Approved", "0123456789", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ae72f2c0-a1d5-4639-add1-21aa257d927c"), "456 Lê Lợi, Q3, HCM", "https://cdn.rallyhub.vn/license/2.jpg", "Trung Tâm Thể Thao Hải Đăng", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3"), "https://cdn.rallyhub.vn/cccd/2_back.jpg", "https://cdn.rallyhub.vn/cccd/2_front.jpg", "079200054321", false, new Guid("fbfa9163-b847-4d0f-b7b6-239dcbd9086d"), null, "Approved", "9876543210", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0c4873a0-c8ca-46b0-876a-af8ef7e7111f"), new Guid("b11ab76c-48a0-406c-b2fd-bdaa412ab515"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2c854d5c-e88b-48dd-befd-271a5713ce50"), 30000m, 270000m, false, "Banked", 300000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3bdcb9d0-ef7b-4eea-a34d-b0c1aa469376"), new Guid("b11ab76c-48a0-406c-b2fd-bdaa412ab515"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2c854d5c-e88b-48dd-befd-271a5713ce50"), 20000m, 180000m, false, "Complete", 200000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5189db6e-2a50-4c4c-b0b6-de4c1501ce56"), new Guid("c54e7607-18ed-4b18-8e78-83d472fcf4be"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3"), 40000m, 360000m, false, "Banked", 400000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("71aeab11-b0d7-4d5e-bcb5-5d761015597e"), new Guid("c54e7607-18ed-4b18-8e78-83d472fcf4be"), "Khách huỷ", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3"), 50000m, 200000m, false, "Cancel", 250000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8901485b-9898-4112-8237-4463df23ba59"), new Guid("c54e7607-18ed-4b18-8e78-83d472fcf4be"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3"), 0m, 150000m, false, "Complete", 150000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "CampaignCourts",
                columns: new[] { "Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2bb5078f-4302-4864-a934-2915f096e727"), new Guid("c54e7607-18ed-4b18-8e78-83d472fcf4be"), new Guid("6c727fa5-a22e-48eb-b839-7be005527b6f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3b88c1a9-fa41-4a6a-82d4-a75ad40d1485"), new Guid("c54e7607-18ed-4b18-8e78-83d472fcf4be"), new Guid("e94ededf-b3a9-4c6c-9d19-1754ac62f6f9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9551358b-f4f0-4cda-85a0-fe1859ee356e"), new Guid("b11ab76c-48a0-406c-b2fd-bdaa412ab515"), new Guid("3091f52d-4ec1-4084-b29d-fe44239b41c4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f8299f7b-d82c-423b-883e-a86d7d1d124b"), new Guid("b11ab76c-48a0-406c-b2fd-bdaa412ab515"), new Guid("a6ced920-265d-4b14-bc0f-ef8124f4577b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "LikeListDetails",
                columns: new[] { "Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("075f0057-b21c-4fa8-9070-4351b1427c7a"), new Guid("e94ededf-b3a9-4c6c-9d19-1754ac62f6f9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2c854d5c-e88b-48dd-befd-271a5713ce50"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4ab5c1f0-0e73-4763-acce-a6b55ed36c24"), new Guid("6c727fa5-a22e-48eb-b839-7be005527b6f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5afc1587-4103-427b-b9aa-a3f8f29921af"), new Guid("3091f52d-4ec1-4084-b29d-fe44239b41c4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("608346c8-ece0-48cd-b26c-3a2e042a3fc6"), new Guid("a6ced920-265d-4b14-bc0f-ef8124f4577b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("78a604ea-af15-4ef5-b35a-714714e56c66"), new Guid("6c727fa5-a22e-48eb-b839-7be005527b6f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2c854d5c-e88b-48dd-befd-271a5713ce50"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "SubCourts",
                columns: new[] { "Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("5bd4c722-5700-48a6-b962-717b68af8d4d"), new Guid("a6ced920-265d-4b14-bc0f-ef8124f4577b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ D1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("62c8dcc8-d051-445c-870a-41b8afa226c0"), new Guid("3091f52d-4ec1-4084-b29d-fe44239b41c4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ C1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7226ea0b-efbc-4c58-b003-f5122480e7df"), new Guid("a6ced920-265d-4b14-bc0f-ef8124f4577b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ D2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("800676e0-f4d8-4bf9-bbbe-4b020f781fda"), new Guid("e94ededf-b3a9-4c6c-9d19-1754ac62f6f9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ B1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("900ac525-eb92-4e29-8f97-d46222389e1d"), new Guid("6c727fa5-a22e-48eb-b839-7be005527b6f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ A1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e0843b76-e683-44bd-8c6a-12f091ff3fa2"), new Guid("e94ededf-b3a9-4c6c-9d19-1754ac62f6f9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ B2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e6ebdb58-afe4-490b-bb52-9d787fbf9cb9"), new Guid("6c727fa5-a22e-48eb-b839-7be005527b6f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ A2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("faaf79f6-9f7e-40dc-99c5-378edbc57ebb"), new Guid("3091f52d-4ec1-4084-b29d-fe44239b41c4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ C2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "BookingDetails",
                columns: new[] { "Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("4dcd68d1-0650-4453-867e-7f1a94f4e3aa"), new Guid("3bdcb9d0-ef7b-4eea-a34d-b0c1aa469376"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 25, 12, 31, 28, 312, DateTimeKind.Unspecified).AddTicks(9720), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 100000m, new TimeOnly(8, 0, 0), new Guid("900ac525-eb92-4e29-8f97-d46222389e1d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5bbb6a15-ab4e-42f1-914f-efb2e66a2355"), new Guid("71aeab11-b0d7-4d5e-bcb5-5d761015597e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 27, 12, 31, 28, 312, DateTimeKind.Unspecified).AddTicks(9807), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 150000m, new TimeOnly(6, 0, 0), new Guid("5bd4c722-5700-48a6-b962-717b68af8d4d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6d01bcae-4e90-4ed8-aa6a-9d9c8eaf4d29"), new Guid("5189db6e-2a50-4c4c-b0b6-de4c1501ce56"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 1, 12, 31, 28, 312, DateTimeKind.Unspecified).AddTicks(9816), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 150000m, new TimeOnly(9, 0, 0), new Guid("e6ebdb58-afe4-490b-bb52-9d787fbf9cb9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8f753b07-6141-4404-8028-49dec223541b"), new Guid("8901485b-9898-4112-8237-4463df23ba59"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 27, 12, 31, 28, 312, DateTimeKind.Unspecified).AddTicks(9801), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 150000m, new TimeOnly(7, 0, 0), new Guid("62c8dcc8-d051-445c-870a-41b8afa226c0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e683f292-9f36-4130-a403-e33fccf54bc5"), new Guid("0c4873a0-c8ca-46b0-876a-af8ef7e7111f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 25, 12, 31, 28, 312, DateTimeKind.Unspecified).AddTicks(9793), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 100000m, new TimeOnly(6, 0, 0), new Guid("800676e0-f4d8-4bf9-bbbe-4b020f781fda"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ConfigSlots",
                columns: new[] { "Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("079c3582-f347-4933-bccb-4b840c262b0b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 50000m, new TimeOnly(9, 0, 0), new Guid("900ac525-eb92-4e29-8f97-d46222389e1d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("0bfadfa2-3691-4274-b3bb-1a6dbb1bf811"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 35000m, new TimeOnly(6, 0, 0), new Guid("62c8dcc8-d051-445c-870a-41b8afa226c0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("140db18c-adc6-417f-a515-4310641c7ea7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 100000m, new TimeOnly(7, 0, 0), new Guid("5bd4c722-5700-48a6-b962-717b68af8d4d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("20efc2a5-b1ef-43c1-8730-0c7a287a5749"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 50000m, new TimeOnly(8, 30, 0), new Guid("900ac525-eb92-4e29-8f97-d46222389e1d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4e860d98-39a0-4128-aa92-52d7b243be87"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 70000m, new TimeOnly(6, 30, 0), new Guid("800676e0-f4d8-4bf9-bbbe-4b020f781fda"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4f1eecfd-a06e-4a4c-825b-9a901f06645d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 35000m, new TimeOnly(6, 30, 0), new Guid("62c8dcc8-d051-445c-870a-41b8afa226c0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("501d59cb-bddf-44c5-ae9e-746594d4da91"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 35000m, new TimeOnly(7, 0, 0), new Guid("62c8dcc8-d051-445c-870a-41b8afa226c0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5081c69a-a459-41b5-adfa-caa7456ac905"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 50000m, new TimeOnly(7, 0, 0), new Guid("900ac525-eb92-4e29-8f97-d46222389e1d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("58c9834a-c6ea-4b6f-8530-2e1182a9a80c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 70000m, new TimeOnly(7, 30, 0), new Guid("800676e0-f4d8-4bf9-bbbe-4b020f781fda"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5ce3f5ae-1ad0-441f-9dbb-e497ef670d26"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 100000m, new TimeOnly(8, 30, 0), new Guid("5bd4c722-5700-48a6-b962-717b68af8d4d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5eb9cbc1-931c-4d57-a866-b0278ec11d2b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 35000m, new TimeOnly(8, 30, 0), new Guid("62c8dcc8-d051-445c-870a-41b8afa226c0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("683a564c-7fc9-4dd4-8a9f-72eabcd5ac57"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 100000m, new TimeOnly(9, 30, 0), new Guid("5bd4c722-5700-48a6-b962-717b68af8d4d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6ce48bc5-dad2-45a7-8afe-fe29fc7b839b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 50000m, new TimeOnly(8, 0, 0), new Guid("900ac525-eb92-4e29-8f97-d46222389e1d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("73e980c2-24eb-4259-bf38-b57d0aaa43c5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 70000m, new TimeOnly(6, 0, 0), new Guid("800676e0-f4d8-4bf9-bbbe-4b020f781fda"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("78ba0aa9-d45a-422f-9171-dbff845dcb5e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 100000m, new TimeOnly(9, 0, 0), new Guid("5bd4c722-5700-48a6-b962-717b68af8d4d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("864af20b-ac6e-4633-84b5-f573dd3190bd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 100000m, new TimeOnly(8, 0, 0), new Guid("5bd4c722-5700-48a6-b962-717b68af8d4d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("96a2123b-f3b6-4f99-9d5b-f0153497fb42"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 35000m, new TimeOnly(9, 0, 0), new Guid("62c8dcc8-d051-445c-870a-41b8afa226c0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a1ee54f8-ecf2-4222-abf6-dbbfcf3d810d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 100000m, new TimeOnly(7, 30, 0), new Guid("5bd4c722-5700-48a6-b962-717b68af8d4d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b64ef4b4-afb4-4917-9914-5995ecc1a11a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 35000m, new TimeOnly(8, 0, 0), new Guid("62c8dcc8-d051-445c-870a-41b8afa226c0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("be433d76-2d4a-4c8c-83e1-8daed8f8e4ef"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 50000m, new TimeOnly(6, 0, 0), new Guid("900ac525-eb92-4e29-8f97-d46222389e1d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c31af39a-6d40-47a8-9ff4-3a8026fb5daf"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 50000m, new TimeOnly(7, 30, 0), new Guid("900ac525-eb92-4e29-8f97-d46222389e1d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cae78988-ad24-40af-9b52-a44b37f7ea27"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 35000m, new TimeOnly(7, 30, 0), new Guid("62c8dcc8-d051-445c-870a-41b8afa226c0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d116561a-c113-44f2-9cc2-f6623f62ed0e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 100000m, new TimeOnly(6, 0, 0), new Guid("5bd4c722-5700-48a6-b962-717b68af8d4d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d185045e-4c91-4cc4-b667-94c897b5e3a1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 70000m, new TimeOnly(8, 30, 0), new Guid("800676e0-f4d8-4bf9-bbbe-4b020f781fda"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d44fc0eb-03e5-43b9-a1e0-6635c3d6a1ed"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 70000m, new TimeOnly(8, 0, 0), new Guid("800676e0-f4d8-4bf9-bbbe-4b020f781fda"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("df965cf4-e067-4aa9-b1dd-b55d59bc6821"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 50000m, new TimeOnly(6, 30, 0), new Guid("900ac525-eb92-4e29-8f97-d46222389e1d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f5af813e-1e91-49aa-9f0b-ac4cd79487f1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 70000m, new TimeOnly(7, 0, 0), new Guid("800676e0-f4d8-4bf9-bbbe-4b020f781fda"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fa1989ed-e4d3-4831-b611-602a265b2fe8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 50000m, new TimeOnly(9, 30, 0), new Guid("900ac525-eb92-4e29-8f97-d46222389e1d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fb108f81-339c-4c1a-90cd-2a0dde4a5d83"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 70000m, new TimeOnly(9, 30, 0), new Guid("800676e0-f4d8-4bf9-bbbe-4b020f781fda"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fb1cc836-a0fd-41ba-b24d-341797442267"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 35000m, new TimeOnly(9, 30, 0), new Guid("62c8dcc8-d051-445c-870a-41b8afa226c0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fdc53d38-6cf3-44a4-b5c1-e3968a11033f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 70000m, new TimeOnly(9, 0, 0), new Guid("800676e0-f4d8-4bf9-bbbe-4b020f781fda"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ff544347-ef71-493c-aa5e-fb607e8208ce"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 100000m, new TimeOnly(6, 30, 0), new Guid("5bd4c722-5700-48a6-b962-717b68af8d4d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Exceptions",
                columns: new[] { "Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2d183184-15fe-4a20-aba5-83ea2fc9702f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Tổ chức sự kiện nội bộ", new TimeOnly(12, 0, 0), new Guid("5bd4c722-5700-48a6-b962-717b68af8d4d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("47cf10b5-55ef-4585-b4ba-3129d4247370"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Bảo trì định kỳ", new TimeOnly(12, 0, 0), new Guid("900ac525-eb92-4e29-8f97-d46222389e1d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d810b00d-215c-43d7-9344-db37271072c8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Hỏng đèn chiếu sáng", new TimeOnly(12, 0, 0), new Guid("62c8dcc8-d051-445c-870a-41b8afa226c0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f0cc07be-0a34-48fe-a63e-36236aeed12a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Sơn lại mặt sân", new TimeOnly(12, 0, 0), new Guid("800676e0-f4d8-4bf9-bbbe-4b020f781fda"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("15f70445-277b-459c-b2da-c6094a9ee8fd"), new Guid("71aeab11-b0d7-4d5e-bcb5-5d761015597e"), "Nhân viên thân thiện, sân sạch.", new Guid("e94ededf-b3a9-4c6c-9d19-1754ac62f6f9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2c854d5c-e88b-48dd-befd-271a5713ce50"), false, 5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("52e9a8bf-9c61-47b0-baa1-508fe10d0720"), new Guid("8901485b-9898-4112-8237-4463df23ba59"), "Bình thường, sân hơi cũ.", new Guid("3091f52d-4ec1-4084-b29d-fe44239b41c4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2c854d5c-e88b-48dd-befd-271a5713ce50"), false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6490d792-e7a0-454e-97bb-e625e806025f"), new Guid("5189db6e-2a50-4c4c-b0b6-de4c1501ce56"), "Đèn chiếu sáng yếu vào ban đêm.", new Guid("6c727fa5-a22e-48eb-b839-7be005527b6f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3"), false, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("bf8194fa-9b82-48a0-9e0f-c073785be537"), new Guid("0c4873a0-c8ca-46b0-876a-af8ef7e7111f"), "Dịch vụ ổn, giá hợp lý.", new Guid("e94ededf-b3a9-4c6c-9d19-1754ac62f6f9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3"), false, 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cb905bcd-795f-4718-b7ef-de821e35086b"), new Guid("3bdcb9d0-ef7b-4eea-a34d-b0c1aa469376"), "Sân rất tốt, sẽ quay lại!", new Guid("6c727fa5-a22e-48eb-b839-7be005527b6f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3"), false, 5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("0e55c478-5709-45ef-966b-799cd256e965"), new Guid("0c4873a0-c8ca-46b0-876a-af8ef7e7111f"), "Booking #2 đã được xác nhận.", new Guid("e94ededf-b3a9-4c6c-9d19-1754ac62f6f9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Đặt sân thành công", "Booking", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2bb8cc43-6ceb-4e86-b085-528679bca6b3") });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("7df76c4e-d3ea-47b4-94dc-18cef99f5e94"), new Guid("71aeab11-b0d7-4d5e-bcb5-5d761015597e"), "Booking #4 đã bị huỷ. Tiền sẽ hoàn.", new Guid("a6ced920-265d-4b14-bc0f-ef8124f4577b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Huỷ booking", "Cancel", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("e381df1d-6157-4c3c-84e2-871b67db78a6") });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("83fe89b6-86ac-40a6-80e1-0c1737c0c458"), new Guid("5189db6e-2a50-4c4c-b0b6-de4c1501ce56"), "Đã hoàn 360,000đ vào ví của bạn.", new Guid("6c727fa5-a22e-48eb-b839-7be005527b6f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Hoàn tiền", "Refund", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8a3b27fa-dd6d-49b7-83b8-3e1712cc19db") });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("8d485a07-2f0a-4a43-9653-70516d909fb1"), new Guid("3bdcb9d0-ef7b-4eea-a34d-b0c1aa469376"), "Booking #1 đã được xác nhận.", new Guid("6c727fa5-a22e-48eb-b839-7be005527b6f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Đặt sân thành công", "Booking", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8a3b27fa-dd6d-49b7-83b8-3e1712cc19db") });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("99a3b29c-412e-49ce-98c3-f9627b8499bd"), new Guid("8901485b-9898-4112-8237-4463df23ba59"), "Bạn có lịch chơi vào ngày mai.", new Guid("3091f52d-4ec1-4084-b29d-fe44239b41c4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Nhắc nhở lịch chơi", "Remind", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ab66bf11-307a-437d-8825-69d620e05638") });

            migrationBuilder.InsertData(
                table: "OverideSlots",
                columns: new[] { "Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[] { new Guid("4b5540c6-0970-4a1e-b939-3b8649f7837c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 208400m, new TimeOnly(12, 0, 0), new Guid("900ac525-eb92-4e29-8f97-d46222389e1d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "OverideSlots",
                columns: new[] { "Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "IsRecurring", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[] { new Guid("75bf9b63-5f2b-439b-91dd-35291c7bab48"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(1, 1, 1), 1, new TimeOnly(20, 0, 0), false, true, 200000m, new TimeOnly(18, 0, 0), new Guid("e6ebdb58-afe4-490b-bb52-9d787fbf9cb9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "OverideSlots",
                columns: new[] { "Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("8db0e48e-8cec-471f-b7f4-9f629a6cd54d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 220500m, new TimeOnly(12, 0, 0), new Guid("800676e0-f4d8-4bf9-bbbe-4b020f781fda"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("99aedf0e-9433-4187-8d91-4addb3e7d048"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 2054000m, new TimeOnly(12, 0, 0), new Guid("62c8dcc8-d051-445c-870a-41b8afa226c0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e67ef3c8-4f24-4e8d-ba3f-41ccb138b2a6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 220800m, new TimeOnly(12, 0, 0), new Guid("5bd4c722-5700-48a6-b962-717b68af8d4d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("194b20ee-077d-4dc6-89c8-76c01384f9c8"), new Guid("0c4873a0-c8ca-46b0-876a-af8ef7e7111f"), new Guid("6c727fa5-a22e-48eb-b839-7be005527b6f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2c854d5c-e88b-48dd-befd-271a5713ce50"), false, "Chủ sân thái độ không tốt.", "Resolved", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d7675c76-7cc3-454b-bcd8-6938a6fac8c1"), new Guid("5189db6e-2a50-4c4c-b0b6-de4c1501ce56"), new Guid("a6ced920-265d-4b14-bc0f-ef8124f4577b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3"), false, "Thông tin giờ mở cửa sai.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d93821dc-2855-4222-851a-6739b02075d4"), new Guid("71aeab11-b0d7-4d5e-bcb5-5d761015597e"), new Guid("3091f52d-4ec1-4084-b29d-fe44239b41c4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3"), false, "Không hoàn tiền khi huỷ đúng hạn.", "Rejected", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f339352f-b6e8-473b-88b7-c7213ae2d510"), new Guid("8901485b-9898-4112-8237-4463df23ba59"), new Guid("e94ededf-b3a9-4c6c-9d19-1754ac62f6f9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3"), false, "Cơ sở vật chất xuống cấp.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fe9aef0c-5a6d-48f7-a7e1-8b7fa525975a"), new Guid("3bdcb9d0-ef7b-4eea-a34d-b0c1aa469376"), new Guid("3091f52d-4ec1-4084-b29d-fe44239b41c4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2c854d5c-e88b-48dd-befd-271a5713ce50"), false, "Sân không đúng mô tả.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId" },
                values: new object[,]
                {
                    { new Guid("39dcedba-942d-4981-a914-02db1de86c8e"), "ACT004", 500000m, 2000000m, 1500000m, "5678901234", "REF004", new Guid("5189db6e-2a50-4c4c-b0b6-de4c1501ce56"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP004", "SIG004", "Success", "Nạp tiền vào ví", "Deposit", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f17c0bc4-4b94-4f9e-bcb3-46878e4f9f6a") },
                    { new Guid("3a3a9e0a-c23a-467f-9783-259b22b1c29d"), "ACT001", 180000m, 2000000m, 2180000m, "2345678901", "REF001", new Guid("3bdcb9d0-ef7b-4eea-a34d-b0c1aa469376"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP001", "SIG001", "Success", "Thanh toán booking #1", "Payment", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("16afe692-bf8d-43ae-a28f-375a7b2fe854") },
                    { new Guid("ca9feb60-5224-4cf3-a274-665ef221f127"), "ACT003", 200000m, 2200000m, 2000000m, "4567890123", "REF003", new Guid("8901485b-9898-4112-8237-4463df23ba59"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP003", "SIG003", "Success", "Hoàn tiền booking #4", "Refund", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("fa434c49-dad2-48e0-a3ba-aeb4c0094623") },
                    { new Guid("ff0efc83-838b-4ab5-9306-5ab6abca452e"), "ACT002", 270000m, 3500000m, 3770000m, "3456789012", "REF002", new Guid("0c4873a0-c8ca-46b0-876a-af8ef7e7111f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP002", "SIG002", "Success", "Thanh toán booking #2", "Payment", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c6170538-b504-4ee1-af8f-ab27d415b225") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_BookingId",
                table: "BookingDetails",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_SubCourtId",
                table: "BookingDetails",
                column: "SubCourtId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CampaignId",
                table: "Bookings",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignCourts_CampaignId",
                table: "CampaignCourts",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignCourts_CourtId",
                table: "CampaignCourts",
                column: "CourtId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_Code",
                table: "Campaigns",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_OwnerId",
                table: "Campaigns",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigSlots_SubCourtDetailId",
                table: "ConfigSlots",
                column: "SubCourtDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Courts_Name",
                table: "Courts",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courts_OwnerId",
                table: "Courts",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exceptions_SubCourtDetailId",
                table: "Exceptions",
                column: "SubCourtDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_BookingId",
                table: "Feedbacks",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CourtId",
                table: "Feedbacks",
                column: "CourtId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CustomerId",
                table: "Feedbacks",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeListDetails_CourtId",
                table: "LikeListDetails",
                column: "CourtId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeListDetails_CustomerId",
                table: "LikeListDetails",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_BookingId",
                table: "Notifications",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CourtId",
                table: "Notifications",
                column: "CourtId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OverideSlots_SubCourtDetailId",
                table: "OverideSlots",
                column: "SubCourtDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerRequests_CustomerId",
                table: "OwnerRequests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerRequests_OwnerId",
                table: "OwnerRequests",
                column: "OwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OwnerRequests_TaxCode",
                table: "OwnerRequests",
                column: "TaxCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owners_TaxCode",
                table: "Owners",
                column: "TaxCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owners_UserId",
                table: "Owners",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_BookingId",
                table: "Reports",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_CourtId",
                table: "Reports",
                column: "CourtId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_CustomerId",
                table: "Reports",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCourts_CourtId",
                table: "SubCourts",
                column: "CourtId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemReports_UserId",
                table: "SystemReports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ActionCode",
                table: "Transactions",
                column: "ActionCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BankRefCode",
                table: "Transactions",
                column: "BankRefCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BookingId",
                table: "Transactions",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SePayId",
                table: "Transactions",
                column: "SePayId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_WalletId",
                table: "Transactions",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDetails");

            migrationBuilder.DropTable(
                name: "CampaignCourts");

            migrationBuilder.DropTable(
                name: "ConfigSlots");

            migrationBuilder.DropTable(
                name: "Exceptions");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "LikeListDetails");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "OverideSlots");

            migrationBuilder.DropTable(
                name: "OwnerRequests");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "SystemReports");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "SubCourts");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Courts");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
