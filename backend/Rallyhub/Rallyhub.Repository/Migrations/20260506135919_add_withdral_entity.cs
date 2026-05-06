using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rallyhub.Repository.Migrations
{
    /// <inheritdoc />
    public partial class add_withdral_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("51c3959c-92f3-4b6c-b3df-6d58fe8c319d"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("662c41ad-62f3-476c-8d3b-75b610238405"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("945f02a2-ff01-430c-8efd-18e98415bdfb"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("aa4208d1-d142-424f-924d-49bde2bac358"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("b0fa1be1-2db5-4ca9-a1a0-5bd9eea9e937"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("35cfadac-2b78-4a63-8a15-752d793d0eee"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("3f69a509-fbc4-4c87-b5dc-f0a29e596433"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("59038745-991f-4dd7-aa0b-ed855addacb5"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("9bb58627-e78b-4789-aa66-0b1846a18f18"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("0214d825-eaf6-43ce-b644-e875ca0046ef"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("c1471456-2bde-4907-b5b5-6dc5e5be83ce"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("cdd32eda-51db-46b4-b922-d3832c0dc986"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("ef5bcba0-912d-4843-a4df-9f6e523f0702"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("03eb02d8-bfe0-49c6-ade9-667d68f6930f"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("218322eb-c883-41c1-8ddb-ca8c879d474f"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("28feac41-54fb-4b7a-a26e-2b4a68e9c0a6"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("323ee50b-229a-4a77-88e1-4e8fbd31f908"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("3c86f9d8-cde8-47b2-8af6-575644d304ca"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("3ccc9d5c-cd54-4698-8a8b-c52c7370a708"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("473ff037-9720-46bf-a142-2a7e59844ac9"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("4b306746-1567-41de-8bc2-1cd0cc19f092"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("68a55d25-6a5e-4101-b405-e5b8018a68ad"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("6c8a49a4-197f-46ce-8680-e1986a03a475"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("6ca30b2e-7d1d-4d63-8966-d353a534b219"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("75d15a39-ea1b-471d-be39-8c02acf0deb3"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("767fc39c-997c-41f1-a198-6d01e6fb2e36"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("7ea94242-88d9-4044-8186-7e8d420f44f7"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("7fdc0dd5-9118-425d-88fd-850352d1531a"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("8302a28a-36f4-49c7-b066-31c644f162af"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("98fe8b99-0f61-4cc6-bc83-49990146b60e"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("b0782300-27f2-4959-bbda-fe86b2eccea1"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("bc07794c-5202-403f-81a3-730cb0e5bd39"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("bc8b3ac4-8a7d-4bcf-9786-4c1187da8d24"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("c434a684-3888-4079-ad7a-5ffcdbeddc8d"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("c986caa9-3a53-4236-94f7-4e234b615aee"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("cb5c2760-82cc-4a98-bb58-c9949c3dfa68"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("ce8805e6-48ea-4580-b900-21c6ab0b9bcd"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("d641c519-e384-4c41-8a97-0ccebfb3bcd1"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("e165c3b9-e3f6-4ae8-85c8-c56400275899"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("ec11aabd-b698-479e-a24b-099699e48b1a"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("ef9e0583-0016-433b-8820-40853b11b25a"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("f2323ffd-3126-486c-919e-199dc3bb1878"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("f3d46d00-1c7b-496a-bbd0-ca6928a1dd35"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("f9d03486-69e7-4bc6-bf84-94c67301b8e5"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("fed61a78-3d7e-4138-b66f-9ddeeecb5a44"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("40820c57-8c25-4a5a-af15-180b87147c8d"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("81cfc89d-826d-4db2-b0f7-259b385ab863"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("b3810711-9c39-4a00-92af-30b005a09467"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("e5d4843c-1a57-407c-83f1-403c25e8c129"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("569de319-bc3f-42fd-a419-f42c90ecee62"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("8c18e063-82d0-4b77-b3b7-7868eb6fbc29"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("cb9aa5a8-460c-4d48-960b-2200da589c99"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("d8e77c76-6b80-4e51-941d-4ccaa9a0a779"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("e9f4bfc2-fe5e-4f62-ba07-feaa9a614f2d"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("00eb32ef-eded-4bfc-8253-6499035f147f"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("2a3c1a6a-1e89-4243-8646-8001e7b8d2fb"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("7936ce11-9c96-4a66-816b-5f6dd69df872"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("7cbded7f-9a42-43a2-84fc-2fb0067db97c"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("b827dba9-595f-4a51-a173-6b65f3fae29b"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("020b12e2-fb74-46f6-b514-b2514da2e5ec"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("4de4c052-100f-4e9b-977a-1039a124db6b"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("914ae69b-02a0-433a-9395-fb8bfcd19b70"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("bf68428e-a20f-4a17-91a2-710a2120c287"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("d4751e45-18a8-4fc4-a6f4-d62936a46606"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("3f5126dd-c686-460a-8a51-a2b9fc573721"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("6b5019c9-67d4-418f-9517-ea59c95dfcbc"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("87e633ab-13b1-4020-85dd-031520b8014e"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("e700d83c-12fe-44da-80cb-5a1c915c6034"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("ed2ecd9c-f888-4bd1-97b9-814001272a6e"));

            migrationBuilder.DeleteData(
                table: "OwnerRequests",
                keyColumn: "Id",
                keyValue: new Guid("59b58851-f62a-4716-acb2-a4c9ba335ca2"));

            migrationBuilder.DeleteData(
                table: "OwnerRequests",
                keyColumn: "Id",
                keyValue: new Guid("bf932aa5-778a-488a-9169-a5d92cdd0b3d"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("04249951-b9f7-4c09-acbe-1d5cbd1e8345"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("ac850560-435c-4388-a69e-b27394ef0ca0"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("d14ee340-a311-4894-8044-8ada326c748f"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("d67307fa-c4ce-4696-8ca3-ccd95286fd2b"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("e257ec2c-2021-4f03-a07c-317b5c83ea49"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("ec91fc42-ad45-4774-9e2a-46e1c3925313"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("2319b478-7a18-4b30-8be8-f1e612b4e4ff"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("b7f84386-122e-4881-a3d9-0c45ae3e1276"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("f7ab225b-bd3d-4010-86de-77b649b04e93"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("0a7705e5-9670-48e7-8ca7-d36eea0a8639"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("32c78ac5-79e0-4e7b-8b30-0bb1db872de2"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("acc844e1-6fbe-4f61-9aea-8edb2752814c"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("ebcf525d-e0db-4ffe-8ce5-023ced369c35"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("ecece6d0-7b25-4e94-813c-96e071143b3a"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("49e037b5-2e7d-4305-95ae-1a2c5a573478"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("7032046b-bc9d-4be6-ad5d-dfc0a559fa72"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("d841cf90-48fc-4fe3-b7f5-2e113fdbb88d"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("e5d30b3a-2758-4fc7-b5da-f4d3b8e5244e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9080409c-e410-4b6a-b122-901ca60b6f63"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("44e693bf-845b-4d2f-8ec3-8fd03d172e82"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("71d611f2-b6c2-4247-a997-2c449db0ae8d"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("cc21bc39-2981-4191-97ed-c9231f162bd8"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("d162064b-3d28-4123-b865-6412948ee11b"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("d526112d-9e53-4226-9a32-1a9d7e733de5"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("1f5f8c88-1933-45a3-a473-3d9450abde7c"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("41962963-d917-4cd8-b2c8-1b087eedff1b"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("5184e9e0-0993-4d90-9ce3-021a420cb7d9"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("c5342658-6a2f-4e33-8ce5-a06fc097c8d9"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("ea7fd095-0f37-475f-b0e9-5f2ff556d4d5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0193e73d-f14d-4e93-8658-84e2e4300d4c"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("30912fe6-4ed1-4385-81fb-d52d2415cc79"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("ac13382f-e8b1-4349-a0f7-9824b4392e6c"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("c751b7a1-b5b8-4cf4-85c1-3a221696e9ee"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("ee9e431a-65b2-4238-86a3-d10e6633c6a9"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("16e26c5a-66ec-481c-ade4-90591cddecb1"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("261c666c-5102-4766-969c-3f2fa79f8c65"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("4161053e-81c1-41bf-a784-f534a1612284"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("438dec81-8dd4-42e6-b076-0fe082bb5655"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("642a7ba5-85fd-4df3-adb6-767abd966b13"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("7dbdf2ed-dc26-465d-b33c-0f4ab2ca8970"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("8e10a7ca-551d-43d4-883d-6a421bc90dd6"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("ce2e1dda-b9fa-465e-9b0e-4c60806b1888"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("5fa623f3-da33-43c0-8c60-64d02cc5b47a"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("f0e867d8-cff2-4084-b205-5ebee6622a9f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3b828f7e-6f81-40de-a298-3088d70ceef5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f05c8746-9aec-486f-bf48-f38d442b22a0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4da822d4-aae4-4d5c-9188-cb1f7bf60d4a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("52d4f5ca-ca4b-4d17-b4b3-765f272727f0"));

            migrationBuilder.AlterColumn<string>(
                name: "BankName",
                table: "Wallets",
                type: "character varying(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAccountName",
                table: "Wallets",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Withdrawals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    BankName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    BankAccountNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BankAccountName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "Pending"),
                    RejectionReason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    AdminNote = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ProcessedByAdminId = table.Column<Guid>(type: "uuid", nullable: true),
                    WalletId = table.Column<Guid>(type: "uuid", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Withdrawals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Withdrawals_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Withdrawals_Users_ProcessedByAdminId",
                        column: x => x.ProcessedByAdminId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Withdrawals_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3136c868-c1f0-47ac-8230-783f5a98c169"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner2@rallyhub.vn", "Hải", false, "Đăng", "hashed_pw_3", "0900000003", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5299cd30-b534-4a1f-a796-ad9840fca7b2"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner1@rallyhub.vn", "Minh", false, "Tuấn", "hashed_pw_2", "0900000002", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6616d5d0-fb91-4d20-b49e-3e671230e96b"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner3@rallyhub.vn", "Trần", false, "Phú", "hashed_pw_6", "0900000006", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7753611c-1c7e-4679-900b-f7fb651eaf8b"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "admin@rallyhub.vn", "Quản", false, "Trị", "hashed_pw_1", "0900000001", "Admin", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("97e106c4-e178-43f2-8084-572daa1d2225"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer1@gmail.com", "Lan", false, "Phương", "hashed_pw_4", "0900000004", "Customer", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fcfcb615-a19b-4783-aa80-0a04d66a87ae"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer2@gmail.com", "Bảo", false, "Châu", "hashed_pw_5", "0900000005", "Customer", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("2e912811-7901-47b1-b0ae-43da7e4ece3e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("97e106c4-e178-43f2-8084-572daa1d2225") },
                    { new Guid("f984e2d3-2abb-4755-b9f3-b02e54b2e58c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("fcfcb615-a19b-4783-aa80-0a04d66a87ae") }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("1e37c80a-e4ce-439f-894e-596206930672"), "456 Lê Lợi, Q3, HCM", null, "Trung Tâm Thể Thao Hải Đăng", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, false, "9876543210", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3136c868-c1f0-47ac-8230-783f5a98c169") },
                    { new Guid("208c7a59-41ab-44b2-88a2-2700e2243a1b"), "123 Nguyễn Huệ, Q1, HCM", null, "Sân Cầu Lông Minh Tuấn", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, false, "0123456789", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5299cd30-b534-4a1f-a796-ad9840fca7b2") },
                    { new Guid("dda5df2a-3f58-49f3-a99c-d6bed04dc05c"), "Tôn Đức Thắng, HCM", null, "Sân Cầu Lông Trần Phú", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, false, "98765434219", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("6616d5d0-fb91-4d20-b49e-3e671230e96b") }
                });

            migrationBuilder.InsertData(
                table: "SystemReports",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("32f0adb6-cf83-467f-95e5-9eab7e6324e9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Crash khi mở trang tìm kiếm sân.", "Pending", "App bị crash", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("97e106c4-e178-43f2-8084-572daa1d2225") },
                    { new Guid("5d1c24d9-7ce7-43c8-80b8-89d66a81b5c5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Số dư hiển thị không khớp lịch sử.", "Resolved", "Sai số dư sau giao dịch", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("fcfcb615-a19b-4783-aa80-0a04d66a87ae") },
                    { new Guid("a1cf722e-5ddf-4ca2-b6f2-045725aa5b62"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "OTP không gửi đến số điện thoại.", "Pending", "Không nhận được OTP", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("97e106c4-e178-43f2-8084-572daa1d2225") },
                    { new Guid("c308b2af-8e9b-4287-9b90-8fd10ab22577"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Không thể thanh toán qua ví.", "Pending", "Lỗi thanh toán", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5299cd30-b534-4a1f-a796-ad9840fca7b2") },
                    { new Guid("f30ba6e5-2bfe-4780-9006-725b9402fbe7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Bản đồ không load được trên iOS.", "Resolved", "Lỗi hiển thị bản đồ", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3136c868-c1f0-47ac-8230-783f5a98c169") }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Balance", "BankAccount", "BankAccountName", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version" },
                values: new object[,]
                {
                    { new Guid("201552fd-befe-42bd-8da7-cfdc9881514b"), 2000000m, "4567890123", null, "MB Bank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("97e106c4-e178-43f2-8084-572daa1d2225"), 0 },
                    { new Guid("33c1be7c-8a9a-416f-99fb-367a50e88749"), 3500000m, "5678901234", null, "VPBank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("fcfcb615-a19b-4783-aa80-0a04d66a87ae"), 0 },
                    { new Guid("631066aa-35ff-432f-afea-87fe650fc533"), 12000000m, "2345678901", null, "Techcombank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5299cd30-b534-4a1f-a796-ad9840fca7b2"), 0 },
                    { new Guid("daa3f04d-6411-49f2-9d81-54a09145affc"), 8500000m, "3456789012", null, "BIDV", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3136c868-c1f0-47ac-8230-783f5a98c169"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount" },
                values: new object[,]
                {
                    { new Guid("041fce41-0cb2-4b16-a0b5-25c20cc009ee"), "LOYAL5", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 30000m, 100000m, new Guid("1e37c80a-e4ce-439f-894e-596206930672"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 500, 87 },
                    { new Guid("1fed8503-0f6d-4abd-b158-a37a2a4bdffc"), "FLASH50", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 50m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 200000m, 500000m, new Guid("208c7a59-41ab-44b2-88a2-2700e2243a1b"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10, 10 },
                    { new Guid("2bc19b16-15b2-495b-9802-fb810b02f018"), "SUMMER25", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 50000m, 200000m, new Guid("208c7a59-41ab-44b2-88a2-2700e2243a1b"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 100, 12 },
                    { new Guid("52f43241-48a3-472b-8298-8895214e0bbb"), "WEEKEND10", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 15m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 75000m, 250000m, new Guid("1e37c80a-e4ce-439f-894e-596206930672"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 200, 30 },
                    { new Guid("9f9ca4cb-6bea-47bd-8bff-c3ed17013155"), "YEUTH", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 30000m, 100000m, new Guid("208c7a59-41ab-44b2-88a2-2700e2243a1b"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 500, 87 },
                    { new Guid("bbe1a647-b5b9-4671-a710-4c46dfc132a2"), "NEWUSER", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 20m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 100000m, 300000m, new Guid("1e37c80a-e4ce-439f-894e-596206930672"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 50, 5 }
                });

            migrationBuilder.InsertData(
                table: "Courts",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "TimeRefundBefor", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("856e3049-40ee-445d-909c-a0947306ff03"), "123 Nguyễn Huệ, Q1, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.77m, 106.70m, "https://maps.google.com/?q=10.77,106.70", "Sân A - Minh Tuấn", new TimeOnly(6, 0, 0), new Guid("208c7a59-41ab-44b2-88a2-2700e2243a1b"), "https://images.example.com/courts/go-vap.jpg", "Active", 120, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("bbcb493a-89d1-446d-ae35-a1f1e4458a61"), "456 Lê Lợi, Q3, HCM", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.78m, 106.69m, "https://maps.google.com/?q=10.78,106.69", "Sân C - Hải Đăng", new TimeOnly(5, 30, 0), new Guid("1e37c80a-e4ce-439f-894e-596206930672"), "https://images.example.com/courts/go-vap.jpg", "Active", 120, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d87b695c-4788-4aea-b051-74ace689b295"), "456 Lê Lợi, Q3, HCM", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.78m, 106.69m, "https://maps.google.com/?q=10.78,106.69", "Sân D - Hải Đăng", new TimeOnly(5, 30, 0), new Guid("1e37c80a-e4ce-439f-894e-596206930672"), "https://images.example.com/courts/go-vap.jpg", "Active", 120, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ef67c863-c3ec-45d7-be2b-e88e9cafcb0d"), "123 Nguyễn Huệ, Q1, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.77m, 106.70m, "https://maps.google.com/?q=10.77,106.70", "Sân B - Minh Tuấn", new TimeOnly(6, 0, 0), new Guid("208c7a59-41ab-44b2-88a2-2700e2243a1b"), "https://images.example.com/courts/go-vap.jpg", "Active", 120, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "OwnerRequests",
                columns: new[] { "Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "CustomerId", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "OwnerId", "RejectionReason", "Status", "TaxCode", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("8907daa3-e8aa-4529-ad30-455ff49622c3"), "456 Lê Lợi, Q3, HCM", "https://cdn.rallyhub.vn/license/2.jpg", "Trung Tâm Thể Thao Hải Đăng", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f984e2d3-2abb-4755-b9f3-b02e54b2e58c"), "https://cdn.rallyhub.vn/cccd/2_back.jpg", "https://cdn.rallyhub.vn/cccd/2_front.jpg", "079200054321", false, new Guid("1e37c80a-e4ce-439f-894e-596206930672"), null, "Approved", "9876543210", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("faa28c5e-e852-4646-8b6e-b32c60b93081"), "123 Nguyễn Huệ, Q1, HCM", "https://cdn.rallyhub.vn/license/1.jpg", "Sân Cầu Lông Minh Tuấn", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2e912811-7901-47b1-b0ae-43da7e4ece3e"), "https://cdn.rallyhub.vn/cccd/1_back.jpg", "https://cdn.rallyhub.vn/cccd/1_front.jpg", "079200012345", false, new Guid("208c7a59-41ab-44b2-88a2-2700e2243a1b"), null, "Approved", "0123456789", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "ExpiresAt", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("572fae3c-b25a-499f-a093-d3df38bacdfc"), new Guid("bbe1a647-b5b9-4671-a710-4c46dfc132a2"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f984e2d3-2abb-4755-b9f3-b02e54b2e58c"), 0m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 150000m, false, "Complete", 150000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("599a6aad-21e2-48a2-a4b8-99c65e386075"), new Guid("2bc19b16-15b2-495b-9802-fb810b02f018"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2e912811-7901-47b1-b0ae-43da7e4ece3e"), 20000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 180000m, false, "Complete", 200000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("88aae08a-c704-4bd7-91ef-740e3031b36c"), new Guid("bbe1a647-b5b9-4671-a710-4c46dfc132a2"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f984e2d3-2abb-4755-b9f3-b02e54b2e58c"), 40000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 360000m, false, "Banked", 400000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("df562fec-c2a2-4808-bf44-ebd1e95301be"), new Guid("bbe1a647-b5b9-4671-a710-4c46dfc132a2"), "Khách huỷ", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f984e2d3-2abb-4755-b9f3-b02e54b2e58c"), 50000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 200000m, false, "Cancel", 250000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ef6d76af-b894-4348-9eac-2fd183e0eafa"), new Guid("2bc19b16-15b2-495b-9802-fb810b02f018"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2e912811-7901-47b1-b0ae-43da7e4ece3e"), 30000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 270000m, false, "Banked", 300000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "CampaignCourts",
                columns: new[] { "Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("06d2d79f-2ac8-4e39-86ab-6a45dd43ba6b"), new Guid("bbe1a647-b5b9-4671-a710-4c46dfc132a2"), new Guid("ef67c863-c3ec-45d7-be2b-e88e9cafcb0d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2a97ce55-51b3-4436-b561-95b581d9b5d6"), new Guid("2bc19b16-15b2-495b-9802-fb810b02f018"), new Guid("d87b695c-4788-4aea-b051-74ace689b295"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("830caadc-4e31-4a4c-8b24-23a841af2ebb"), new Guid("bbe1a647-b5b9-4671-a710-4c46dfc132a2"), new Guid("856e3049-40ee-445d-909c-a0947306ff03"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b55dadbd-2cf6-40c8-b08e-c9fcdd55758a"), new Guid("2bc19b16-15b2-495b-9802-fb810b02f018"), new Guid("bbcb493a-89d1-446d-ae35-a1f1e4458a61"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "LikeListDetails",
                columns: new[] { "Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("154e15b5-508c-4b68-b8eb-36d2e6ad2526"), new Guid("856e3049-40ee-445d-909c-a0947306ff03"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f984e2d3-2abb-4755-b9f3-b02e54b2e58c"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6a9dd293-6ced-42ae-abce-d1889eedaf31"), new Guid("ef67c863-c3ec-45d7-be2b-e88e9cafcb0d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2e912811-7901-47b1-b0ae-43da7e4ece3e"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("774dbd0f-07f7-4efa-a743-c0a2bd6b956f"), new Guid("d87b695c-4788-4aea-b051-74ace689b295"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f984e2d3-2abb-4755-b9f3-b02e54b2e58c"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ef7c398b-5ff4-4e09-a3a1-5a2d4a6fe308"), new Guid("bbcb493a-89d1-446d-ae35-a1f1e4458a61"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f984e2d3-2abb-4755-b9f3-b02e54b2e58c"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fcf31731-245d-4673-9993-164c04fbefb2"), new Guid("856e3049-40ee-445d-909c-a0947306ff03"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2e912811-7901-47b1-b0ae-43da7e4ece3e"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "SubCourts",
                columns: new[] { "Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0205402b-752f-45f5-acc2-99e2cedbe4c4"), new Guid("d87b695c-4788-4aea-b051-74ace689b295"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ D1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3d5620e3-de98-47f3-b4bb-c14cb61784c4"), new Guid("bbcb493a-89d1-446d-ae35-a1f1e4458a61"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ C2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("463ded10-6fb0-4f1e-949e-953204a0a1ff"), new Guid("bbcb493a-89d1-446d-ae35-a1f1e4458a61"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ C1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("55de8dc6-63e4-484c-82e3-bba4939e6a77"), new Guid("856e3049-40ee-445d-909c-a0947306ff03"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ A1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5dbde2a4-88da-41bd-b794-42a1051148b9"), new Guid("856e3049-40ee-445d-909c-a0947306ff03"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ A2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5f1f6ad8-6870-4d81-b859-c68ea5c7fcfc"), new Guid("ef67c863-c3ec-45d7-be2b-e88e9cafcb0d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ B2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("76095461-b26d-4eac-92fa-633a6bfed72b"), new Guid("d87b695c-4788-4aea-b051-74ace689b295"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ D2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e8b8cc80-a3e0-47d3-a2b3-7b3e7642adbc"), new Guid("ef67c863-c3ec-45d7-be2b-e88e9cafcb0d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ B1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "BookingDetails",
                columns: new[] { "Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "Status", "SubCourtId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("131aa886-f0ff-4392-b989-89659c6a4bcb"), new Guid("599a6aad-21e2-48a2-a4b8-99c65e386075"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 1, 20, 59, 18, 321, DateTimeKind.Unspecified).AddTicks(8753), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 100000m, new TimeOnly(8, 0, 0), "Banked", new Guid("55de8dc6-63e4-484c-82e3-bba4939e6a77"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("161e86a8-d8a8-4314-82c2-af5a7a43c1e8"), new Guid("572fae3c-b25a-499f-a093-d3df38bacdfc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 3, 20, 59, 18, 321, DateTimeKind.Unspecified).AddTicks(8821), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 150000m, new TimeOnly(7, 0, 0), "Banked", new Guid("463ded10-6fb0-4f1e-949e-953204a0a1ff"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("349270a5-7938-4c89-be81-22ae347d430b"), new Guid("88aae08a-c704-4bd7-91ef-740e3031b36c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 7, 20, 59, 18, 321, DateTimeKind.Unspecified).AddTicks(8831), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 150000m, new TimeOnly(9, 0, 0), "Banked", new Guid("5dbde2a4-88da-41bd-b794-42a1051148b9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("360e8022-514a-4273-b58d-4d71c69986d4"), new Guid("df562fec-c2a2-4808-bf44-ebd1e95301be"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 3, 20, 59, 18, 321, DateTimeKind.Unspecified).AddTicks(8826), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 150000m, new TimeOnly(6, 0, 0), "Cancel", new Guid("0205402b-752f-45f5-acc2-99e2cedbe4c4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("795e2e50-8ceb-4b7b-9dc5-e10d155abc92"), new Guid("ef6d76af-b894-4348-9eac-2fd183e0eafa"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 1, 20, 59, 18, 321, DateTimeKind.Unspecified).AddTicks(8815), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 100000m, new TimeOnly(6, 0, 0), "Banked", new Guid("e8b8cc80-a3e0-47d3-a2b3-7b3e7642adbc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ConfigSlots",
                columns: new[] { "Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("064b1602-5474-474c-a85b-de837c7cf4e2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 100000m, new TimeOnly(8, 30, 0), new Guid("0205402b-752f-45f5-acc2-99e2cedbe4c4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("08fa07e8-20e2-4b07-b919-0d94482309a9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 50000m, new TimeOnly(8, 30, 0), new Guid("55de8dc6-63e4-484c-82e3-bba4939e6a77"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("09aec336-0913-4f0a-859c-bff98179450e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 50000m, new TimeOnly(6, 30, 0), new Guid("55de8dc6-63e4-484c-82e3-bba4939e6a77"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("18af6fb3-d595-41dc-94f5-a2a6a800a7c2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 35000m, new TimeOnly(9, 30, 0), new Guid("463ded10-6fb0-4f1e-949e-953204a0a1ff"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("1b11dfab-46fb-4396-8f84-8fc3b5cb6dd1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 35000m, new TimeOnly(8, 0, 0), new Guid("463ded10-6fb0-4f1e-949e-953204a0a1ff"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("1bb6695b-fd72-4849-80e8-6c831089248d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 70000m, new TimeOnly(6, 30, 0), new Guid("e8b8cc80-a3e0-47d3-a2b3-7b3e7642adbc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("25e87ad8-ef2b-4092-8ddb-7036b513d6ce"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 100000m, new TimeOnly(6, 0, 0), new Guid("0205402b-752f-45f5-acc2-99e2cedbe4c4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2c0aff2a-dae2-4047-a645-5ffe33432a18"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 70000m, new TimeOnly(9, 0, 0), new Guid("e8b8cc80-a3e0-47d3-a2b3-7b3e7642adbc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3588bb11-ef7e-4cfa-9bd4-35aa57d37c76"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 100000m, new TimeOnly(7, 0, 0), new Guid("0205402b-752f-45f5-acc2-99e2cedbe4c4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("493243fb-8c02-46e2-93b9-85ae64e29fc1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 100000m, new TimeOnly(7, 30, 0), new Guid("0205402b-752f-45f5-acc2-99e2cedbe4c4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4cbd7c2e-2f1c-4596-b6b8-cb492ff30df9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 100000m, new TimeOnly(9, 30, 0), new Guid("0205402b-752f-45f5-acc2-99e2cedbe4c4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4f88313d-e381-4461-b3ca-280e587118c7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 70000m, new TimeOnly(6, 0, 0), new Guid("e8b8cc80-a3e0-47d3-a2b3-7b3e7642adbc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("564d8026-9da3-465e-9d3c-3aa4b41c09e4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 100000m, new TimeOnly(9, 0, 0), new Guid("0205402b-752f-45f5-acc2-99e2cedbe4c4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("585116f1-da09-4d44-9dbc-475e5466f74e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 50000m, new TimeOnly(9, 30, 0), new Guid("55de8dc6-63e4-484c-82e3-bba4939e6a77"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5b2fd5a0-764b-4729-b236-093927575d36"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 35000m, new TimeOnly(6, 30, 0), new Guid("463ded10-6fb0-4f1e-949e-953204a0a1ff"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5ef84413-2858-41bf-8c06-e6024dcf773e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 70000m, new TimeOnly(8, 30, 0), new Guid("e8b8cc80-a3e0-47d3-a2b3-7b3e7642adbc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("667b9386-e762-47a5-9662-f51caa20f09b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 35000m, new TimeOnly(7, 0, 0), new Guid("463ded10-6fb0-4f1e-949e-953204a0a1ff"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6c90cbd3-fd1f-4696-8109-a574523dd032"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 70000m, new TimeOnly(9, 30, 0), new Guid("e8b8cc80-a3e0-47d3-a2b3-7b3e7642adbc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7ec95092-2de5-4819-a568-4f033979a696"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 35000m, new TimeOnly(6, 0, 0), new Guid("463ded10-6fb0-4f1e-949e-953204a0a1ff"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8b976f63-af7f-4818-b9d2-66d139228a30"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 70000m, new TimeOnly(8, 0, 0), new Guid("e8b8cc80-a3e0-47d3-a2b3-7b3e7642adbc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8f528c76-5b84-402c-87d9-372e7a8f3042"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 35000m, new TimeOnly(9, 0, 0), new Guid("463ded10-6fb0-4f1e-949e-953204a0a1ff"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9af19edb-47a8-48ac-8891-e8ef0db45bf4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 70000m, new TimeOnly(7, 30, 0), new Guid("e8b8cc80-a3e0-47d3-a2b3-7b3e7642adbc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a53058ba-13c6-4ed8-8a86-d280e1109c13"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 50000m, new TimeOnly(6, 0, 0), new Guid("55de8dc6-63e4-484c-82e3-bba4939e6a77"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a98ed0e6-9040-4c77-a1b7-89d7054f9057"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 35000m, new TimeOnly(8, 30, 0), new Guid("463ded10-6fb0-4f1e-949e-953204a0a1ff"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b42fe174-d5a5-4266-b7dd-e9141fde12b6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 50000m, new TimeOnly(9, 0, 0), new Guid("55de8dc6-63e4-484c-82e3-bba4939e6a77"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("bb5ebb09-5fd8-4702-997b-5efe2dd810d6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 50000m, new TimeOnly(7, 30, 0), new Guid("55de8dc6-63e4-484c-82e3-bba4939e6a77"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c2d33113-7d8f-494c-8ae9-ed1f0a9b3232"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 100000m, new TimeOnly(8, 0, 0), new Guid("0205402b-752f-45f5-acc2-99e2cedbe4c4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cfde6411-9dc2-4af7-a014-7a3ffe2e5b80"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 35000m, new TimeOnly(7, 30, 0), new Guid("463ded10-6fb0-4f1e-949e-953204a0a1ff"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("daa093c3-a476-4c0d-b823-9eee08e4cb80"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 100000m, new TimeOnly(6, 30, 0), new Guid("0205402b-752f-45f5-acc2-99e2cedbe4c4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("dffe9ad0-bc07-40fc-a33e-ede5a710b41b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 70000m, new TimeOnly(7, 0, 0), new Guid("e8b8cc80-a3e0-47d3-a2b3-7b3e7642adbc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e97b8574-5c2c-41a3-8349-fbe1b237f8db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 50000m, new TimeOnly(7, 0, 0), new Guid("55de8dc6-63e4-484c-82e3-bba4939e6a77"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ebd92f71-3dcb-4992-b03b-63b1a476b643"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 50000m, new TimeOnly(8, 0, 0), new Guid("55de8dc6-63e4-484c-82e3-bba4939e6a77"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Exceptions",
                columns: new[] { "Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0c91a4a8-5472-4b91-a036-5e4633739203"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Tổ chức sự kiện nội bộ", new TimeOnly(12, 0, 0), new Guid("0205402b-752f-45f5-acc2-99e2cedbe4c4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("10e64fab-7d0c-4078-ab0f-31de15c99a66"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Bảo trì định kỳ", new TimeOnly(12, 0, 0), new Guid("55de8dc6-63e4-484c-82e3-bba4939e6a77"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5e013b2e-ab8b-421d-80a4-c9e2b61b32b0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Hỏng đèn chiếu sáng", new TimeOnly(12, 0, 0), new Guid("463ded10-6fb0-4f1e-949e-953204a0a1ff"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ca29908b-2afb-4757-84eb-4b1b8572d065"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Sơn lại mặt sân", new TimeOnly(12, 0, 0), new Guid("e8b8cc80-a3e0-47d3-a2b3-7b3e7642adbc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1702f5d5-b5b1-4760-ab17-dbbd90e7539b"), new Guid("88aae08a-c704-4bd7-91ef-740e3031b36c"), "Đèn chiếu sáng yếu vào ban đêm.", new Guid("856e3049-40ee-445d-909c-a0947306ff03"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f984e2d3-2abb-4755-b9f3-b02e54b2e58c"), false, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("668737ea-9e2b-4331-b7f1-fb7afeba532c"), new Guid("599a6aad-21e2-48a2-a4b8-99c65e386075"), "Sân rất tốt, sẽ quay lại!", new Guid("856e3049-40ee-445d-909c-a0947306ff03"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f984e2d3-2abb-4755-b9f3-b02e54b2e58c"), false, 5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6a06199b-f45c-4949-93be-c9f591a79ed1"), new Guid("ef6d76af-b894-4348-9eac-2fd183e0eafa"), "Dịch vụ ổn, giá hợp lý.", new Guid("ef67c863-c3ec-45d7-be2b-e88e9cafcb0d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f984e2d3-2abb-4755-b9f3-b02e54b2e58c"), false, 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a955bb80-62b7-4e1e-873d-d1502959edc1"), new Guid("df562fec-c2a2-4808-bf44-ebd1e95301be"), "Nhân viên thân thiện, sân sạch.", new Guid("ef67c863-c3ec-45d7-be2b-e88e9cafcb0d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2e912811-7901-47b1-b0ae-43da7e4ece3e"), false, 5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d4d7dcfa-8d9f-4fd3-8526-0df71b0c9914"), new Guid("572fae3c-b25a-499f-a093-d3df38bacdfc"), "Bình thường, sân hơi cũ.", new Guid("bbcb493a-89d1-446d-ae35-a1f1e4458a61"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2e912811-7901-47b1-b0ae-43da7e4ece3e"), false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("24b4465f-86fd-4c96-bff8-40da02a19f60"), new Guid("ef6d76af-b894-4348-9eac-2fd183e0eafa"), "Booking #2 đã được xác nhận.", new Guid("ef67c863-c3ec-45d7-be2b-e88e9cafcb0d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Đặt sân thành công", "Booking", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3136c868-c1f0-47ac-8230-783f5a98c169") },
                    { new Guid("a3c8ba51-fa7a-4e7b-bf2d-fb7b9a69c552"), new Guid("88aae08a-c704-4bd7-91ef-740e3031b36c"), "Đã hoàn 360,000đ vào ví của bạn.", new Guid("856e3049-40ee-445d-909c-a0947306ff03"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Hoàn tiền", "Refund", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5299cd30-b534-4a1f-a796-ad9840fca7b2") },
                    { new Guid("b4c06ab1-f0e5-46c9-8ebc-3415bcdb6b95"), new Guid("572fae3c-b25a-499f-a093-d3df38bacdfc"), "Bạn có lịch chơi vào ngày mai.", new Guid("bbcb493a-89d1-446d-ae35-a1f1e4458a61"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Nhắc nhở lịch chơi", "Remind", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("97e106c4-e178-43f2-8084-572daa1d2225") }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("cd943140-c946-490a-9c59-2eebf96fc66e"), new Guid("599a6aad-21e2-48a2-a4b8-99c65e386075"), "Booking #1 đã được xác nhận.", new Guid("856e3049-40ee-445d-909c-a0947306ff03"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Đặt sân thành công", "Booking", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5299cd30-b534-4a1f-a796-ad9840fca7b2") },
                    { new Guid("e80d5c27-1587-47a7-92a0-49a4cc2d1c86"), new Guid("df562fec-c2a2-4808-bf44-ebd1e95301be"), "Booking #4 đã bị huỷ. Tiền sẽ hoàn.", new Guid("d87b695c-4788-4aea-b051-74ace689b295"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Huỷ booking", "Cancel", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("fcfcb615-a19b-4783-aa80-0a04d66a87ae") }
                });

            migrationBuilder.InsertData(
                table: "OverideSlots",
                columns: new[] { "Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("007497b5-ee64-4a29-b87c-ef9b35ede725"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 220500m, new TimeOnly(12, 0, 0), new Guid("e8b8cc80-a3e0-47d3-a2b3-7b3e7642adbc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0348370-fd09-463a-b0a0-7fb1e47dd248"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 2054000m, new TimeOnly(12, 0, 0), new Guid("463ded10-6fb0-4f1e-949e-953204a0a1ff"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "OverideSlots",
                columns: new[] { "Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "IsRecurring", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[] { new Guid("c4320760-bcbc-476e-b1dc-877ca3dab6b7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(1, 1, 1), 1, new TimeOnly(20, 0, 0), false, true, 200000m, new TimeOnly(18, 0, 0), new Guid("5dbde2a4-88da-41bd-b794-42a1051148b9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "OverideSlots",
                columns: new[] { "Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("cb7f16cd-d285-401c-911a-61da5e5b8be4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 208400m, new TimeOnly(12, 0, 0), new Guid("55de8dc6-63e4-484c-82e3-bba4939e6a77"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d7b5cf82-4362-4e2b-81b2-d5d326716e75"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 220800m, new TimeOnly(12, 0, 0), new Guid("0205402b-752f-45f5-acc2-99e2cedbe4c4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("02050119-995c-40e3-8b18-c2b6abd0f4a4"), new Guid("ef6d76af-b894-4348-9eac-2fd183e0eafa"), new Guid("856e3049-40ee-445d-909c-a0947306ff03"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2e912811-7901-47b1-b0ae-43da7e4ece3e"), false, "Chủ sân thái độ không tốt.", "Resolved", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("192aeeb9-f2c6-4fb2-9d69-0b3d6c6432a4"), new Guid("88aae08a-c704-4bd7-91ef-740e3031b36c"), new Guid("d87b695c-4788-4aea-b051-74ace689b295"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f984e2d3-2abb-4755-b9f3-b02e54b2e58c"), false, "Thông tin giờ mở cửa sai.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9625988c-a650-4957-b648-a08f67e2a4c4"), new Guid("df562fec-c2a2-4808-bf44-ebd1e95301be"), new Guid("bbcb493a-89d1-446d-ae35-a1f1e4458a61"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f984e2d3-2abb-4755-b9f3-b02e54b2e58c"), false, "Không hoàn tiền khi huỷ đúng hạn.", "Rejected", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c61f6616-f05a-4a08-a4af-49e7b712b0ab"), new Guid("572fae3c-b25a-499f-a093-d3df38bacdfc"), new Guid("ef67c863-c3ec-45d7-be2b-e88e9cafcb0d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f984e2d3-2abb-4755-b9f3-b02e54b2e58c"), false, "Cơ sở vật chất xuống cấp.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e60a8aeb-abfb-45d8-9245-5f553e6e7c1e"), new Guid("599a6aad-21e2-48a2-a4b8-99c65e386075"), new Guid("bbcb493a-89d1-446d-ae35-a1f1e4458a61"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2e912811-7901-47b1-b0ae-43da7e4ece3e"), false, "Sân không đúng mô tả.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId" },
                values: new object[,]
                {
                    { new Guid("1724d421-bdb7-438d-8c4f-48f92f094065"), "ACT001", 180000m, 2000000m, 2180000m, "2345678901", "REF001", new Guid("599a6aad-21e2-48a2-a4b8-99c65e386075"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP001", "SIG001", "Success", "Thanh toán booking #1", "Payment", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("631066aa-35ff-432f-afea-87fe650fc533") },
                    { new Guid("42183f63-29c2-4bdc-88dd-e95afe4de17f"), "ACT004", 500000m, 2000000m, 1500000m, "5678901234", "REF004", new Guid("88aae08a-c704-4bd7-91ef-740e3031b36c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP004", "SIG004", "Success", "Nạp tiền vào ví", "Deposit", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("33c1be7c-8a9a-416f-99fb-367a50e88749") },
                    { new Guid("921d5671-0962-43e4-9ffd-b5094a5e8f0c"), "ACT002", 270000m, 3500000m, 3770000m, "3456789012", "REF002", new Guid("ef6d76af-b894-4348-9eac-2fd183e0eafa"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP002", "SIG002", "Success", "Thanh toán booking #2", "Payment", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("daa3f04d-6411-49f2-9d81-54a09145affc") },
                    { new Guid("c4d80465-fda0-41b8-981d-c1dc1479d156"), "ACT003", 200000m, 2200000m, 2000000m, "4567890123", "REF003", new Guid("572fae3c-b25a-499f-a093-d3df38bacdfc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP003", "SIG003", "Success", "Hoàn tiền booking #4", "Refund", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("201552fd-befe-42bd-8da7-cfdc9881514b") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Withdrawals_ProcessedByAdminId",
                table: "Withdrawals",
                column: "ProcessedByAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Withdrawals_TransactionId",
                table: "Withdrawals",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Withdrawals_WalletId",
                table: "Withdrawals",
                column: "WalletId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Withdrawals");

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("131aa886-f0ff-4392-b989-89659c6a4bcb"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("161e86a8-d8a8-4314-82c2-af5a7a43c1e8"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("349270a5-7938-4c89-be81-22ae347d430b"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("360e8022-514a-4273-b58d-4d71c69986d4"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("795e2e50-8ceb-4b7b-9dc5-e10d155abc92"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("06d2d79f-2ac8-4e39-86ab-6a45dd43ba6b"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("2a97ce55-51b3-4436-b561-95b581d9b5d6"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("830caadc-4e31-4a4c-8b24-23a841af2ebb"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("b55dadbd-2cf6-40c8-b08e-c9fcdd55758a"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("041fce41-0cb2-4b16-a0b5-25c20cc009ee"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("1fed8503-0f6d-4abd-b158-a37a2a4bdffc"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("52f43241-48a3-472b-8298-8895214e0bbb"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("9f9ca4cb-6bea-47bd-8bff-c3ed17013155"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("064b1602-5474-474c-a85b-de837c7cf4e2"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("08fa07e8-20e2-4b07-b919-0d94482309a9"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("09aec336-0913-4f0a-859c-bff98179450e"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("18af6fb3-d595-41dc-94f5-a2a6a800a7c2"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("1b11dfab-46fb-4396-8f84-8fc3b5cb6dd1"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("1bb6695b-fd72-4849-80e8-6c831089248d"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("25e87ad8-ef2b-4092-8ddb-7036b513d6ce"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("2c0aff2a-dae2-4047-a645-5ffe33432a18"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("3588bb11-ef7e-4cfa-9bd4-35aa57d37c76"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("493243fb-8c02-46e2-93b9-85ae64e29fc1"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("4cbd7c2e-2f1c-4596-b6b8-cb492ff30df9"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("4f88313d-e381-4461-b3ca-280e587118c7"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("564d8026-9da3-465e-9d3c-3aa4b41c09e4"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("585116f1-da09-4d44-9dbc-475e5466f74e"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("5b2fd5a0-764b-4729-b236-093927575d36"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("5ef84413-2858-41bf-8c06-e6024dcf773e"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("667b9386-e762-47a5-9662-f51caa20f09b"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("6c90cbd3-fd1f-4696-8109-a574523dd032"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("7ec95092-2de5-4819-a568-4f033979a696"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("8b976f63-af7f-4818-b9d2-66d139228a30"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("8f528c76-5b84-402c-87d9-372e7a8f3042"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("9af19edb-47a8-48ac-8891-e8ef0db45bf4"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("a53058ba-13c6-4ed8-8a86-d280e1109c13"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("a98ed0e6-9040-4c77-a1b7-89d7054f9057"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("b42fe174-d5a5-4266-b7dd-e9141fde12b6"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("bb5ebb09-5fd8-4702-997b-5efe2dd810d6"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("c2d33113-7d8f-494c-8ae9-ed1f0a9b3232"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("cfde6411-9dc2-4af7-a014-7a3ffe2e5b80"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("daa093c3-a476-4c0d-b823-9eee08e4cb80"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("dffe9ad0-bc07-40fc-a33e-ede5a710b41b"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("e97b8574-5c2c-41a3-8349-fbe1b237f8db"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("ebd92f71-3dcb-4992-b03b-63b1a476b643"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("0c91a4a8-5472-4b91-a036-5e4633739203"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("10e64fab-7d0c-4078-ab0f-31de15c99a66"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("5e013b2e-ab8b-421d-80a4-c9e2b61b32b0"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("ca29908b-2afb-4757-84eb-4b1b8572d065"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("1702f5d5-b5b1-4760-ab17-dbbd90e7539b"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("668737ea-9e2b-4331-b7f1-fb7afeba532c"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("6a06199b-f45c-4949-93be-c9f591a79ed1"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("a955bb80-62b7-4e1e-873d-d1502959edc1"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("d4d7dcfa-8d9f-4fd3-8526-0df71b0c9914"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("154e15b5-508c-4b68-b8eb-36d2e6ad2526"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("6a9dd293-6ced-42ae-abce-d1889eedaf31"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("774dbd0f-07f7-4efa-a743-c0a2bd6b956f"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("ef7c398b-5ff4-4e09-a3a1-5a2d4a6fe308"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("fcf31731-245d-4673-9993-164c04fbefb2"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("24b4465f-86fd-4c96-bff8-40da02a19f60"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("a3c8ba51-fa7a-4e7b-bf2d-fb7b9a69c552"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("b4c06ab1-f0e5-46c9-8ebc-3415bcdb6b95"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("cd943140-c946-490a-9c59-2eebf96fc66e"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("e80d5c27-1587-47a7-92a0-49a4cc2d1c86"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("007497b5-ee64-4a29-b87c-ef9b35ede725"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("c0348370-fd09-463a-b0a0-7fb1e47dd248"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("c4320760-bcbc-476e-b1dc-877ca3dab6b7"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("cb7f16cd-d285-401c-911a-61da5e5b8be4"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("d7b5cf82-4362-4e2b-81b2-d5d326716e75"));

            migrationBuilder.DeleteData(
                table: "OwnerRequests",
                keyColumn: "Id",
                keyValue: new Guid("8907daa3-e8aa-4529-ad30-455ff49622c3"));

            migrationBuilder.DeleteData(
                table: "OwnerRequests",
                keyColumn: "Id",
                keyValue: new Guid("faa28c5e-e852-4646-8b6e-b32c60b93081"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("dda5df2a-3f58-49f3-a99c-d6bed04dc05c"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("02050119-995c-40e3-8b18-c2b6abd0f4a4"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("192aeeb9-f2c6-4fb2-9d69-0b3d6c6432a4"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("9625988c-a650-4957-b648-a08f67e2a4c4"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("c61f6616-f05a-4a08-a4af-49e7b712b0ab"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("e60a8aeb-abfb-45d8-9245-5f553e6e7c1e"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("3d5620e3-de98-47f3-b4bb-c14cb61784c4"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("5f1f6ad8-6870-4d81-b859-c68ea5c7fcfc"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("76095461-b26d-4eac-92fa-633a6bfed72b"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("32f0adb6-cf83-467f-95e5-9eab7e6324e9"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("5d1c24d9-7ce7-43c8-80b8-89d66a81b5c5"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("a1cf722e-5ddf-4ca2-b6f2-045725aa5b62"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("c308b2af-8e9b-4287-9b90-8fd10ab22577"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("f30ba6e5-2bfe-4780-9006-725b9402fbe7"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("1724d421-bdb7-438d-8c4f-48f92f094065"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("42183f63-29c2-4bdc-88dd-e95afe4de17f"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("921d5671-0962-43e4-9ffd-b5094a5e8f0c"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("c4d80465-fda0-41b8-981d-c1dc1479d156"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7753611c-1c7e-4679-900b-f7fb651eaf8b"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("572fae3c-b25a-499f-a093-d3df38bacdfc"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("599a6aad-21e2-48a2-a4b8-99c65e386075"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("88aae08a-c704-4bd7-91ef-740e3031b36c"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("df562fec-c2a2-4808-bf44-ebd1e95301be"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("ef6d76af-b894-4348-9eac-2fd183e0eafa"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("0205402b-752f-45f5-acc2-99e2cedbe4c4"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("463ded10-6fb0-4f1e-949e-953204a0a1ff"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("55de8dc6-63e4-484c-82e3-bba4939e6a77"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("5dbde2a4-88da-41bd-b794-42a1051148b9"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("e8b8cc80-a3e0-47d3-a2b3-7b3e7642adbc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6616d5d0-fb91-4d20-b49e-3e671230e96b"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("201552fd-befe-42bd-8da7-cfdc9881514b"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("33c1be7c-8a9a-416f-99fb-367a50e88749"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("631066aa-35ff-432f-afea-87fe650fc533"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("daa3f04d-6411-49f2-9d81-54a09145affc"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("2bc19b16-15b2-495b-9802-fb810b02f018"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("bbe1a647-b5b9-4671-a710-4c46dfc132a2"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("856e3049-40ee-445d-909c-a0947306ff03"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("bbcb493a-89d1-446d-ae35-a1f1e4458a61"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("d87b695c-4788-4aea-b051-74ace689b295"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("ef67c863-c3ec-45d7-be2b-e88e9cafcb0d"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("2e912811-7901-47b1-b0ae-43da7e4ece3e"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("f984e2d3-2abb-4755-b9f3-b02e54b2e58c"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("1e37c80a-e4ce-439f-894e-596206930672"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("208c7a59-41ab-44b2-88a2-2700e2243a1b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("97e106c4-e178-43f2-8084-572daa1d2225"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fcfcb615-a19b-4783-aa80-0a04d66a87ae"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3136c868-c1f0-47ac-8230-783f5a98c169"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5299cd30-b534-4a1f-a796-ad9840fca7b2"));

            migrationBuilder.DropColumn(
                name: "BankAccountName",
                table: "Wallets");

            migrationBuilder.AlterColumn<string>(
                name: "BankName",
                table: "Wallets",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0193e73d-f14d-4e93-8658-84e2e4300d4c"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner3@rallyhub.vn", "Trần", false, "Phú", "hashed_pw_6", "0900000006", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3b828f7e-6f81-40de-a298-3088d70ceef5"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer2@gmail.com", "Bảo", false, "Châu", "hashed_pw_5", "0900000005", "Customer", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4da822d4-aae4-4d5c-9188-cb1f7bf60d4a"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner1@rallyhub.vn", "Minh", false, "Tuấn", "hashed_pw_2", "0900000002", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("52d4f5ca-ca4b-4d17-b4b3-765f272727f0"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner2@rallyhub.vn", "Hải", false, "Đăng", "hashed_pw_3", "0900000003", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9080409c-e410-4b6a-b122-901ca60b6f63"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "admin@rallyhub.vn", "Quản", false, "Trị", "hashed_pw_1", "0900000001", "Admin", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f05c8746-9aec-486f-bf48-f38d442b22a0"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer1@gmail.com", "Lan", false, "Phương", "hashed_pw_4", "0900000004", "Customer", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("8e10a7ca-551d-43d4-883d-6a421bc90dd6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3b828f7e-6f81-40de-a298-3088d70ceef5") },
                    { new Guid("ce2e1dda-b9fa-465e-9b0e-4c60806b1888"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f05c8746-9aec-486f-bf48-f38d442b22a0") }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("04249951-b9f7-4c09-acbe-1d5cbd1e8345"), "Tôn Đức Thắng, HCM", null, "Sân Cầu Lông Trần Phú", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, false, "98765434219", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("0193e73d-f14d-4e93-8658-84e2e4300d4c") },
                    { new Guid("5fa623f3-da33-43c0-8c60-64d02cc5b47a"), "456 Lê Lợi, Q3, HCM", null, "Trung Tâm Thể Thao Hải Đăng", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, false, "9876543210", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("52d4f5ca-ca4b-4d17-b4b3-765f272727f0") },
                    { new Guid("f0e867d8-cff2-4084-b205-5ebee6622a9f"), "123 Nguyễn Huệ, Q1, HCM", null, "Sân Cầu Lông Minh Tuấn", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, false, "0123456789", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4da822d4-aae4-4d5c-9188-cb1f7bf60d4a") }
                });

            migrationBuilder.InsertData(
                table: "SystemReports",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("0a7705e5-9670-48e7-8ca7-d36eea0a8639"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Không thể thanh toán qua ví.", "Pending", "Lỗi thanh toán", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4da822d4-aae4-4d5c-9188-cb1f7bf60d4a") },
                    { new Guid("32c78ac5-79e0-4e7b-8b30-0bb1db872de2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Bản đồ không load được trên iOS.", "Resolved", "Lỗi hiển thị bản đồ", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("52d4f5ca-ca4b-4d17-b4b3-765f272727f0") },
                    { new Guid("acc844e1-6fbe-4f61-9aea-8edb2752814c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Số dư hiển thị không khớp lịch sử.", "Resolved", "Sai số dư sau giao dịch", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3b828f7e-6f81-40de-a298-3088d70ceef5") },
                    { new Guid("ebcf525d-e0db-4ffe-8ce5-023ced369c35"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Crash khi mở trang tìm kiếm sân.", "Pending", "App bị crash", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f05c8746-9aec-486f-bf48-f38d442b22a0") },
                    { new Guid("ecece6d0-7b25-4e94-813c-96e071143b3a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "OTP không gửi đến số điện thoại.", "Pending", "Không nhận được OTP", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f05c8746-9aec-486f-bf48-f38d442b22a0") }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version" },
                values: new object[,]
                {
                    { new Guid("30912fe6-4ed1-4385-81fb-d52d2415cc79"), 12000000m, "2345678901", "Techcombank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4da822d4-aae4-4d5c-9188-cb1f7bf60d4a"), 0 },
                    { new Guid("ac13382f-e8b1-4349-a0f7-9824b4392e6c"), 2000000m, "4567890123", "MB Bank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f05c8746-9aec-486f-bf48-f38d442b22a0"), 0 },
                    { new Guid("c751b7a1-b5b8-4cf4-85c1-3a221696e9ee"), 3500000m, "5678901234", "VPBank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3b828f7e-6f81-40de-a298-3088d70ceef5"), 0 },
                    { new Guid("ee9e431a-65b2-4238-86a3-d10e6633c6a9"), 8500000m, "3456789012", "BIDV", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("52d4f5ca-ca4b-4d17-b4b3-765f272727f0"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount" },
                values: new object[,]
                {
                    { new Guid("0214d825-eaf6-43ce-b644-e875ca0046ef"), "FLASH50", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 50m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 200000m, 500000m, new Guid("f0e867d8-cff2-4084-b205-5ebee6622a9f"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10, 10 },
                    { new Guid("16e26c5a-66ec-481c-ade4-90591cddecb1"), "NEWUSER", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 20m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 100000m, 300000m, new Guid("5fa623f3-da33-43c0-8c60-64d02cc5b47a"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 50, 5 },
                    { new Guid("261c666c-5102-4766-969c-3f2fa79f8c65"), "SUMMER25", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 50000m, 200000m, new Guid("f0e867d8-cff2-4084-b205-5ebee6622a9f"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 100, 12 },
                    { new Guid("c1471456-2bde-4907-b5b5-6dc5e5be83ce"), "LOYAL5", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 30000m, 100000m, new Guid("5fa623f3-da33-43c0-8c60-64d02cc5b47a"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 500, 87 },
                    { new Guid("cdd32eda-51db-46b4-b922-d3832c0dc986"), "WEEKEND10", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 15m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 75000m, 250000m, new Guid("5fa623f3-da33-43c0-8c60-64d02cc5b47a"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 200, 30 },
                    { new Guid("ef5bcba0-912d-4843-a4df-9f6e523f0702"), "YEUTH", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 30000m, 100000m, new Guid("f0e867d8-cff2-4084-b205-5ebee6622a9f"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 500, 87 }
                });

            migrationBuilder.InsertData(
                table: "Courts",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "TimeRefundBefor", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("4161053e-81c1-41bf-a784-f534a1612284"), "456 Lê Lợi, Q3, HCM", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.78m, 106.69m, "https://maps.google.com/?q=10.78,106.69", "Sân D - Hải Đăng", new TimeOnly(5, 30, 0), new Guid("5fa623f3-da33-43c0-8c60-64d02cc5b47a"), "https://images.example.com/courts/go-vap.jpg", "Active", 120, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("438dec81-8dd4-42e6-b076-0fe082bb5655"), "456 Lê Lợi, Q3, HCM", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.78m, 106.69m, "https://maps.google.com/?q=10.78,106.69", "Sân C - Hải Đăng", new TimeOnly(5, 30, 0), new Guid("5fa623f3-da33-43c0-8c60-64d02cc5b47a"), "https://images.example.com/courts/go-vap.jpg", "Active", 120, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("642a7ba5-85fd-4df3-adb6-767abd966b13"), "123 Nguyễn Huệ, Q1, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.77m, 106.70m, "https://maps.google.com/?q=10.77,106.70", "Sân A - Minh Tuấn", new TimeOnly(6, 0, 0), new Guid("f0e867d8-cff2-4084-b205-5ebee6622a9f"), "https://images.example.com/courts/go-vap.jpg", "Active", 120, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7dbdf2ed-dc26-465d-b33c-0f4ab2ca8970"), "123 Nguyễn Huệ, Q1, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.77m, 106.70m, "https://maps.google.com/?q=10.77,106.70", "Sân B - Minh Tuấn", new TimeOnly(6, 0, 0), new Guid("f0e867d8-cff2-4084-b205-5ebee6622a9f"), "https://images.example.com/courts/go-vap.jpg", "Active", 120, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "OwnerRequests",
                columns: new[] { "Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "CustomerId", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "OwnerId", "RejectionReason", "Status", "TaxCode", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("59b58851-f62a-4716-acb2-a4c9ba335ca2"), "456 Lê Lợi, Q3, HCM", "https://cdn.rallyhub.vn/license/2.jpg", "Trung Tâm Thể Thao Hải Đăng", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8e10a7ca-551d-43d4-883d-6a421bc90dd6"), "https://cdn.rallyhub.vn/cccd/2_back.jpg", "https://cdn.rallyhub.vn/cccd/2_front.jpg", "079200054321", false, new Guid("5fa623f3-da33-43c0-8c60-64d02cc5b47a"), null, "Approved", "9876543210", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("bf932aa5-778a-488a-9169-a5d92cdd0b3d"), "123 Nguyễn Huệ, Q1, HCM", "https://cdn.rallyhub.vn/license/1.jpg", "Sân Cầu Lông Minh Tuấn", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ce2e1dda-b9fa-465e-9b0e-4c60806b1888"), "https://cdn.rallyhub.vn/cccd/1_back.jpg", "https://cdn.rallyhub.vn/cccd/1_front.jpg", "079200012345", false, new Guid("f0e867d8-cff2-4084-b205-5ebee6622a9f"), null, "Approved", "0123456789", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "ExpiresAt", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("44e693bf-845b-4d2f-8ec3-8fd03d172e82"), new Guid("261c666c-5102-4766-969c-3f2fa79f8c65"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ce2e1dda-b9fa-465e-9b0e-4c60806b1888"), 30000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 270000m, false, "Banked", 300000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("71d611f2-b6c2-4247-a997-2c449db0ae8d"), new Guid("16e26c5a-66ec-481c-ade4-90591cddecb1"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8e10a7ca-551d-43d4-883d-6a421bc90dd6"), 0m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 150000m, false, "Complete", 150000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cc21bc39-2981-4191-97ed-c9231f162bd8"), new Guid("261c666c-5102-4766-969c-3f2fa79f8c65"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ce2e1dda-b9fa-465e-9b0e-4c60806b1888"), 20000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 180000m, false, "Complete", 200000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d162064b-3d28-4123-b865-6412948ee11b"), new Guid("16e26c5a-66ec-481c-ade4-90591cddecb1"), "Khách huỷ", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8e10a7ca-551d-43d4-883d-6a421bc90dd6"), 50000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 200000m, false, "Cancel", 250000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d526112d-9e53-4226-9a32-1a9d7e733de5"), new Guid("16e26c5a-66ec-481c-ade4-90591cddecb1"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8e10a7ca-551d-43d4-883d-6a421bc90dd6"), 40000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 360000m, false, "Banked", 400000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "CampaignCourts",
                columns: new[] { "Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("35cfadac-2b78-4a63-8a15-752d793d0eee"), new Guid("261c666c-5102-4766-969c-3f2fa79f8c65"), new Guid("438dec81-8dd4-42e6-b076-0fe082bb5655"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3f69a509-fbc4-4c87-b5dc-f0a29e596433"), new Guid("261c666c-5102-4766-969c-3f2fa79f8c65"), new Guid("4161053e-81c1-41bf-a784-f534a1612284"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("59038745-991f-4dd7-aa0b-ed855addacb5"), new Guid("16e26c5a-66ec-481c-ade4-90591cddecb1"), new Guid("642a7ba5-85fd-4df3-adb6-767abd966b13"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9bb58627-e78b-4789-aa66-0b1846a18f18"), new Guid("16e26c5a-66ec-481c-ade4-90591cddecb1"), new Guid("7dbdf2ed-dc26-465d-b33c-0f4ab2ca8970"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "LikeListDetails",
                columns: new[] { "Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00eb32ef-eded-4bfc-8253-6499035f147f"), new Guid("642a7ba5-85fd-4df3-adb6-767abd966b13"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ce2e1dda-b9fa-465e-9b0e-4c60806b1888"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2a3c1a6a-1e89-4243-8646-8001e7b8d2fb"), new Guid("7dbdf2ed-dc26-465d-b33c-0f4ab2ca8970"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ce2e1dda-b9fa-465e-9b0e-4c60806b1888"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7936ce11-9c96-4a66-816b-5f6dd69df872"), new Guid("4161053e-81c1-41bf-a784-f534a1612284"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8e10a7ca-551d-43d4-883d-6a421bc90dd6"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7cbded7f-9a42-43a2-84fc-2fb0067db97c"), new Guid("642a7ba5-85fd-4df3-adb6-767abd966b13"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8e10a7ca-551d-43d4-883d-6a421bc90dd6"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b827dba9-595f-4a51-a173-6b65f3fae29b"), new Guid("438dec81-8dd4-42e6-b076-0fe082bb5655"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8e10a7ca-551d-43d4-883d-6a421bc90dd6"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "SubCourts",
                columns: new[] { "Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1f5f8c88-1933-45a3-a473-3d9450abde7c"), new Guid("4161053e-81c1-41bf-a784-f534a1612284"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ D1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2319b478-7a18-4b30-8be8-f1e612b4e4ff"), new Guid("7dbdf2ed-dc26-465d-b33c-0f4ab2ca8970"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ B2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("41962963-d917-4cd8-b2c8-1b087eedff1b"), new Guid("642a7ba5-85fd-4df3-adb6-767abd966b13"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ A2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5184e9e0-0993-4d90-9ce3-021a420cb7d9"), new Guid("7dbdf2ed-dc26-465d-b33c-0f4ab2ca8970"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ B1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b7f84386-122e-4881-a3d9-0c45ae3e1276"), new Guid("4161053e-81c1-41bf-a784-f534a1612284"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ D2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c5342658-6a2f-4e33-8ce5-a06fc097c8d9"), new Guid("642a7ba5-85fd-4df3-adb6-767abd966b13"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ A1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ea7fd095-0f37-475f-b0e9-5f2ff556d4d5"), new Guid("438dec81-8dd4-42e6-b076-0fe082bb5655"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ C1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f7ab225b-bd3d-4010-86de-77b649b04e93"), new Guid("438dec81-8dd4-42e6-b076-0fe082bb5655"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ C2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "BookingDetails",
                columns: new[] { "Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "Status", "SubCourtId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("51c3959c-92f3-4b6c-b3df-6d58fe8c319d"), new Guid("44e693bf-845b-4d2f-8ec3-8fd03d172e82"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 1, 17, 52, 30, 939, DateTimeKind.Unspecified).AddTicks(6543), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 100000m, new TimeOnly(6, 0, 0), "Banked", new Guid("5184e9e0-0993-4d90-9ce3-021a420cb7d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("662c41ad-62f3-476c-8d3b-75b610238405"), new Guid("cc21bc39-2981-4191-97ed-c9231f162bd8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 1, 17, 52, 30, 939, DateTimeKind.Unspecified).AddTicks(6430), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 100000m, new TimeOnly(8, 0, 0), "Banked", new Guid("c5342658-6a2f-4e33-8ce5-a06fc097c8d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("945f02a2-ff01-430c-8efd-18e98415bdfb"), new Guid("d162064b-3d28-4123-b865-6412948ee11b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 3, 17, 52, 30, 939, DateTimeKind.Unspecified).AddTicks(6552), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 150000m, new TimeOnly(6, 0, 0), "Cancel", new Guid("1f5f8c88-1933-45a3-a473-3d9450abde7c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("aa4208d1-d142-424f-924d-49bde2bac358"), new Guid("d526112d-9e53-4226-9a32-1a9d7e733de5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 7, 17, 52, 30, 939, DateTimeKind.Unspecified).AddTicks(6556), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 150000m, new TimeOnly(9, 0, 0), "Banked", new Guid("41962963-d917-4cd8-b2c8-1b087eedff1b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b0fa1be1-2db5-4ca9-a1a0-5bd9eea9e937"), new Guid("71d611f2-b6c2-4247-a997-2c449db0ae8d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 3, 17, 52, 30, 939, DateTimeKind.Unspecified).AddTicks(6548), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 150000m, new TimeOnly(7, 0, 0), "Banked", new Guid("ea7fd095-0f37-475f-b0e9-5f2ff556d4d5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ConfigSlots",
                columns: new[] { "Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("03eb02d8-bfe0-49c6-ade9-667d68f6930f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 50000m, new TimeOnly(8, 30, 0), new Guid("c5342658-6a2f-4e33-8ce5-a06fc097c8d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("218322eb-c883-41c1-8ddb-ca8c879d474f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 50000m, new TimeOnly(7, 0, 0), new Guid("c5342658-6a2f-4e33-8ce5-a06fc097c8d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("28feac41-54fb-4b7a-a26e-2b4a68e9c0a6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 70000m, new TimeOnly(8, 30, 0), new Guid("5184e9e0-0993-4d90-9ce3-021a420cb7d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("323ee50b-229a-4a77-88e1-4e8fbd31f908"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 35000m, new TimeOnly(7, 0, 0), new Guid("ea7fd095-0f37-475f-b0e9-5f2ff556d4d5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3c86f9d8-cde8-47b2-8af6-575644d304ca"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 50000m, new TimeOnly(9, 30, 0), new Guid("c5342658-6a2f-4e33-8ce5-a06fc097c8d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3ccc9d5c-cd54-4698-8a8b-c52c7370a708"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 100000m, new TimeOnly(7, 30, 0), new Guid("1f5f8c88-1933-45a3-a473-3d9450abde7c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("473ff037-9720-46bf-a142-2a7e59844ac9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 50000m, new TimeOnly(9, 0, 0), new Guid("c5342658-6a2f-4e33-8ce5-a06fc097c8d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4b306746-1567-41de-8bc2-1cd0cc19f092"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 35000m, new TimeOnly(6, 30, 0), new Guid("ea7fd095-0f37-475f-b0e9-5f2ff556d4d5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("68a55d25-6a5e-4101-b405-e5b8018a68ad"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 70000m, new TimeOnly(7, 30, 0), new Guid("5184e9e0-0993-4d90-9ce3-021a420cb7d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6c8a49a4-197f-46ce-8680-e1986a03a475"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 70000m, new TimeOnly(9, 0, 0), new Guid("5184e9e0-0993-4d90-9ce3-021a420cb7d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6ca30b2e-7d1d-4d63-8966-d353a534b219"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 50000m, new TimeOnly(6, 0, 0), new Guid("c5342658-6a2f-4e33-8ce5-a06fc097c8d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("75d15a39-ea1b-471d-be39-8c02acf0deb3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 70000m, new TimeOnly(8, 0, 0), new Guid("5184e9e0-0993-4d90-9ce3-021a420cb7d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("767fc39c-997c-41f1-a198-6d01e6fb2e36"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 35000m, new TimeOnly(7, 30, 0), new Guid("ea7fd095-0f37-475f-b0e9-5f2ff556d4d5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7ea94242-88d9-4044-8186-7e8d420f44f7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 70000m, new TimeOnly(6, 30, 0), new Guid("5184e9e0-0993-4d90-9ce3-021a420cb7d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7fdc0dd5-9118-425d-88fd-850352d1531a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 100000m, new TimeOnly(7, 0, 0), new Guid("1f5f8c88-1933-45a3-a473-3d9450abde7c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8302a28a-36f4-49c7-b066-31c644f162af"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 35000m, new TimeOnly(6, 0, 0), new Guid("ea7fd095-0f37-475f-b0e9-5f2ff556d4d5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("98fe8b99-0f61-4cc6-bc83-49990146b60e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 50000m, new TimeOnly(6, 30, 0), new Guid("c5342658-6a2f-4e33-8ce5-a06fc097c8d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b0782300-27f2-4959-bbda-fe86b2eccea1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 100000m, new TimeOnly(8, 30, 0), new Guid("1f5f8c88-1933-45a3-a473-3d9450abde7c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("bc07794c-5202-403f-81a3-730cb0e5bd39"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 100000m, new TimeOnly(6, 0, 0), new Guid("1f5f8c88-1933-45a3-a473-3d9450abde7c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("bc8b3ac4-8a7d-4bcf-9786-4c1187da8d24"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 50000m, new TimeOnly(7, 30, 0), new Guid("c5342658-6a2f-4e33-8ce5-a06fc097c8d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c434a684-3888-4079-ad7a-5ffcdbeddc8d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 100000m, new TimeOnly(6, 30, 0), new Guid("1f5f8c88-1933-45a3-a473-3d9450abde7c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c986caa9-3a53-4236-94f7-4e234b615aee"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 70000m, new TimeOnly(9, 30, 0), new Guid("5184e9e0-0993-4d90-9ce3-021a420cb7d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cb5c2760-82cc-4a98-bb58-c9949c3dfa68"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 35000m, new TimeOnly(8, 0, 0), new Guid("ea7fd095-0f37-475f-b0e9-5f2ff556d4d5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ce8805e6-48ea-4580-b900-21c6ab0b9bcd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 100000m, new TimeOnly(9, 0, 0), new Guid("1f5f8c88-1933-45a3-a473-3d9450abde7c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d641c519-e384-4c41-8a97-0ccebfb3bcd1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 70000m, new TimeOnly(7, 0, 0), new Guid("5184e9e0-0993-4d90-9ce3-021a420cb7d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e165c3b9-e3f6-4ae8-85c8-c56400275899"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 35000m, new TimeOnly(9, 0, 0), new Guid("ea7fd095-0f37-475f-b0e9-5f2ff556d4d5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ec11aabd-b698-479e-a24b-099699e48b1a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 50000m, new TimeOnly(8, 0, 0), new Guid("c5342658-6a2f-4e33-8ce5-a06fc097c8d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ef9e0583-0016-433b-8820-40853b11b25a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 100000m, new TimeOnly(9, 30, 0), new Guid("1f5f8c88-1933-45a3-a473-3d9450abde7c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f2323ffd-3126-486c-919e-199dc3bb1878"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 35000m, new TimeOnly(8, 30, 0), new Guid("ea7fd095-0f37-475f-b0e9-5f2ff556d4d5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f3d46d00-1c7b-496a-bbd0-ca6928a1dd35"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 100000m, new TimeOnly(8, 0, 0), new Guid("1f5f8c88-1933-45a3-a473-3d9450abde7c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f9d03486-69e7-4bc6-bf84-94c67301b8e5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 35000m, new TimeOnly(9, 30, 0), new Guid("ea7fd095-0f37-475f-b0e9-5f2ff556d4d5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fed61a78-3d7e-4138-b66f-9ddeeecb5a44"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 70000m, new TimeOnly(6, 0, 0), new Guid("5184e9e0-0993-4d90-9ce3-021a420cb7d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Exceptions",
                columns: new[] { "Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("40820c57-8c25-4a5a-af15-180b87147c8d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Hỏng đèn chiếu sáng", new TimeOnly(12, 0, 0), new Guid("ea7fd095-0f37-475f-b0e9-5f2ff556d4d5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("81cfc89d-826d-4db2-b0f7-259b385ab863"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Tổ chức sự kiện nội bộ", new TimeOnly(12, 0, 0), new Guid("1f5f8c88-1933-45a3-a473-3d9450abde7c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b3810711-9c39-4a00-92af-30b005a09467"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Bảo trì định kỳ", new TimeOnly(12, 0, 0), new Guid("c5342658-6a2f-4e33-8ce5-a06fc097c8d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e5d4843c-1a57-407c-83f1-403c25e8c129"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Sơn lại mặt sân", new TimeOnly(12, 0, 0), new Guid("5184e9e0-0993-4d90-9ce3-021a420cb7d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("569de319-bc3f-42fd-a419-f42c90ecee62"), new Guid("cc21bc39-2981-4191-97ed-c9231f162bd8"), "Sân rất tốt, sẽ quay lại!", new Guid("642a7ba5-85fd-4df3-adb6-767abd966b13"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8e10a7ca-551d-43d4-883d-6a421bc90dd6"), false, 5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8c18e063-82d0-4b77-b3b7-7868eb6fbc29"), new Guid("d162064b-3d28-4123-b865-6412948ee11b"), "Nhân viên thân thiện, sân sạch.", new Guid("7dbdf2ed-dc26-465d-b33c-0f4ab2ca8970"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ce2e1dda-b9fa-465e-9b0e-4c60806b1888"), false, 5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cb9aa5a8-460c-4d48-960b-2200da589c99"), new Guid("d526112d-9e53-4226-9a32-1a9d7e733de5"), "Đèn chiếu sáng yếu vào ban đêm.", new Guid("642a7ba5-85fd-4df3-adb6-767abd966b13"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8e10a7ca-551d-43d4-883d-6a421bc90dd6"), false, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d8e77c76-6b80-4e51-941d-4ccaa9a0a779"), new Guid("44e693bf-845b-4d2f-8ec3-8fd03d172e82"), "Dịch vụ ổn, giá hợp lý.", new Guid("7dbdf2ed-dc26-465d-b33c-0f4ab2ca8970"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8e10a7ca-551d-43d4-883d-6a421bc90dd6"), false, 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e9f4bfc2-fe5e-4f62-ba07-feaa9a614f2d"), new Guid("71d611f2-b6c2-4247-a997-2c449db0ae8d"), "Bình thường, sân hơi cũ.", new Guid("438dec81-8dd4-42e6-b076-0fe082bb5655"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ce2e1dda-b9fa-465e-9b0e-4c60806b1888"), false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("020b12e2-fb74-46f6-b514-b2514da2e5ec"), new Guid("d162064b-3d28-4123-b865-6412948ee11b"), "Booking #4 đã bị huỷ. Tiền sẽ hoàn.", new Guid("4161053e-81c1-41bf-a784-f534a1612284"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Huỷ booking", "Cancel", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3b828f7e-6f81-40de-a298-3088d70ceef5") });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("4de4c052-100f-4e9b-977a-1039a124db6b"), new Guid("d526112d-9e53-4226-9a32-1a9d7e733de5"), "Đã hoàn 360,000đ vào ví của bạn.", new Guid("642a7ba5-85fd-4df3-adb6-767abd966b13"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Hoàn tiền", "Refund", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4da822d4-aae4-4d5c-9188-cb1f7bf60d4a") },
                    { new Guid("914ae69b-02a0-433a-9395-fb8bfcd19b70"), new Guid("71d611f2-b6c2-4247-a997-2c449db0ae8d"), "Bạn có lịch chơi vào ngày mai.", new Guid("438dec81-8dd4-42e6-b076-0fe082bb5655"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Nhắc nhở lịch chơi", "Remind", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f05c8746-9aec-486f-bf48-f38d442b22a0") }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("bf68428e-a20f-4a17-91a2-710a2120c287"), new Guid("cc21bc39-2981-4191-97ed-c9231f162bd8"), "Booking #1 đã được xác nhận.", new Guid("642a7ba5-85fd-4df3-adb6-767abd966b13"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Đặt sân thành công", "Booking", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4da822d4-aae4-4d5c-9188-cb1f7bf60d4a") });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("d4751e45-18a8-4fc4-a6f4-d62936a46606"), new Guid("44e693bf-845b-4d2f-8ec3-8fd03d172e82"), "Booking #2 đã được xác nhận.", new Guid("7dbdf2ed-dc26-465d-b33c-0f4ab2ca8970"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Đặt sân thành công", "Booking", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("52d4f5ca-ca4b-4d17-b4b3-765f272727f0") });

            migrationBuilder.InsertData(
                table: "OverideSlots",
                columns: new[] { "Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3f5126dd-c686-460a-8a51-a2b9fc573721"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 220800m, new TimeOnly(12, 0, 0), new Guid("1f5f8c88-1933-45a3-a473-3d9450abde7c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6b5019c9-67d4-418f-9517-ea59c95dfcbc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 220500m, new TimeOnly(12, 0, 0), new Guid("5184e9e0-0993-4d90-9ce3-021a420cb7d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("87e633ab-13b1-4020-85dd-031520b8014e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 2054000m, new TimeOnly(12, 0, 0), new Guid("ea7fd095-0f37-475f-b0e9-5f2ff556d4d5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e700d83c-12fe-44da-80cb-5a1c915c6034"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 208400m, new TimeOnly(12, 0, 0), new Guid("c5342658-6a2f-4e33-8ce5-a06fc097c8d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "OverideSlots",
                columns: new[] { "Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "IsRecurring", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[] { new Guid("ed2ecd9c-f888-4bd1-97b9-814001272a6e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(1, 1, 1), 1, new TimeOnly(20, 0, 0), false, true, 200000m, new TimeOnly(18, 0, 0), new Guid("41962963-d917-4cd8-b2c8-1b087eedff1b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("ac850560-435c-4388-a69e-b27394ef0ca0"), new Guid("d162064b-3d28-4123-b865-6412948ee11b"), new Guid("438dec81-8dd4-42e6-b076-0fe082bb5655"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8e10a7ca-551d-43d4-883d-6a421bc90dd6"), false, "Không hoàn tiền khi huỷ đúng hạn.", "Rejected", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d14ee340-a311-4894-8044-8ada326c748f"), new Guid("cc21bc39-2981-4191-97ed-c9231f162bd8"), new Guid("438dec81-8dd4-42e6-b076-0fe082bb5655"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ce2e1dda-b9fa-465e-9b0e-4c60806b1888"), false, "Sân không đúng mô tả.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d67307fa-c4ce-4696-8ca3-ccd95286fd2b"), new Guid("71d611f2-b6c2-4247-a997-2c449db0ae8d"), new Guid("7dbdf2ed-dc26-465d-b33c-0f4ab2ca8970"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8e10a7ca-551d-43d4-883d-6a421bc90dd6"), false, "Cơ sở vật chất xuống cấp.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e257ec2c-2021-4f03-a07c-317b5c83ea49"), new Guid("44e693bf-845b-4d2f-8ec3-8fd03d172e82"), new Guid("642a7ba5-85fd-4df3-adb6-767abd966b13"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ce2e1dda-b9fa-465e-9b0e-4c60806b1888"), false, "Chủ sân thái độ không tốt.", "Resolved", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ec91fc42-ad45-4774-9e2a-46e1c3925313"), new Guid("d526112d-9e53-4226-9a32-1a9d7e733de5"), new Guid("4161053e-81c1-41bf-a784-f534a1612284"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8e10a7ca-551d-43d4-883d-6a421bc90dd6"), false, "Thông tin giờ mở cửa sai.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId" },
                values: new object[,]
                {
                    { new Guid("49e037b5-2e7d-4305-95ae-1a2c5a573478"), "ACT003", 200000m, 2200000m, 2000000m, "4567890123", "REF003", new Guid("71d611f2-b6c2-4247-a997-2c449db0ae8d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP003", "SIG003", "Success", "Hoàn tiền booking #4", "Refund", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ac13382f-e8b1-4349-a0f7-9824b4392e6c") },
                    { new Guid("7032046b-bc9d-4be6-ad5d-dfc0a559fa72"), "ACT004", 500000m, 2000000m, 1500000m, "5678901234", "REF004", new Guid("d526112d-9e53-4226-9a32-1a9d7e733de5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP004", "SIG004", "Success", "Nạp tiền vào ví", "Deposit", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c751b7a1-b5b8-4cf4-85c1-3a221696e9ee") },
                    { new Guid("d841cf90-48fc-4fe3-b7f5-2e113fdbb88d"), "ACT002", 270000m, 3500000m, 3770000m, "3456789012", "REF002", new Guid("44e693bf-845b-4d2f-8ec3-8fd03d172e82"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP002", "SIG002", "Success", "Thanh toán booking #2", "Payment", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ee9e431a-65b2-4238-86a3-d10e6633c6a9") },
                    { new Guid("e5d30b3a-2758-4fc7-b5da-f4d3b8e5244e"), "ACT001", 180000m, 2000000m, 2180000m, "2345678901", "REF001", new Guid("cc21bc39-2981-4191-97ed-c9231f162bd8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP001", "SIG001", "Success", "Thanh toán booking #1", "Payment", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("30912fe6-4ed1-4385-81fb-d52d2415cc79") }
                });
        }
    }
}
