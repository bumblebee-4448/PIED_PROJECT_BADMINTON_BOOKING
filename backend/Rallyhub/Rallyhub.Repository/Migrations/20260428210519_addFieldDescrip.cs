using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rallyhub.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addFieldDescrip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("29f12e5a-246d-4e2d-bde9-44a2bf284306"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("5165a283-6157-4ec2-b5e2-61eb6084eecd"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("cb78c72c-92d3-4661-9d0e-0b323db1867d"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("e62c2e55-fc3e-479f-9fdf-db75cef973c7"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("fd18202d-f55f-4878-884f-ab0e86aab669"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("11e6bf97-464c-4cd0-85e4-e15d340b315e"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("60d00289-a73c-43fc-b30a-732dd384cd69"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("ad91d0f2-b407-4664-8859-70b31be8c15b"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("c93ea608-925c-45b7-a176-62dff7e22e9b"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("0f883e67-870f-49ae-95b4-893bf6bcfae2"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("11c13a04-a257-4f52-a342-30dfb5742b57"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("1655ead5-51e7-4a47-9fc3-2e28c1e02104"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("8ed789ce-9ddd-4ba3-8a08-cae5d9027f6c"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("0caf2978-155a-457d-9303-3bf115ff98bd"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("2994152b-8c98-4457-992e-0e033967945c"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("2e580617-d8f2-451e-9400-7ad3b6bd7554"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("2ec30f02-fc05-441b-81e9-c708bcc01969"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("39a58272-f26d-4a59-9374-c9a98ff2849b"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("4096c517-9d76-49f4-b242-20b843b9350d"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("41c73983-341b-4f15-84c7-8dfb77b68d81"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("44a9a89f-01c7-4844-824f-c978d77230e0"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("49f11e18-28e3-4101-94ea-124a82a1b370"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("4f3765b3-55b0-47f0-a824-6ae868e216f7"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("53dd2155-1e94-45bc-ab95-585408158bc6"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("54109344-c661-482d-90d1-7f03e80d1a08"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("57fd6c6c-c527-4b02-9164-b9ae32e513cd"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("5d04e1dc-5c76-4bd9-8620-65cebac30b12"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("5ed2cce2-42da-4a46-b18b-99482b7a15ca"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("6ea18f7a-44fa-4b7c-84b1-637907a92e54"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("71749fce-2688-45c8-83ed-419328394e45"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("753148e6-ebab-49aa-993d-78aa36d9bf9b"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("7b03eaa5-8e32-411e-9d1a-98f402b2d6d5"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("7ec75482-c1d9-4f6e-87f4-bdfe88b50616"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("8589a2cf-f008-4867-b3b4-f95c136f2528"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("88d00cf6-01eb-4d49-b8e1-7f4b107f64dd"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("8c794115-77c9-47c3-a5af-4cd098bb10f7"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("8f217125-e62a-434d-bba1-8d3180ca4434"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("941e0d1b-0e2b-4e9c-b40b-7ca5173cfe71"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("b2c3b50d-e4c6-4d8c-9271-5c3a725c14d8"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("c0d0dd2f-bbee-4cc4-9c4a-7be63ed1272b"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("d82b1ebd-397e-4c6f-9257-349a4af4e436"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("e5adf1a6-c930-4976-9c79-291260237ab1"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("e63694f9-3082-49d9-8512-e37567276989"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("ebf9b4aa-a020-4a0e-af92-799653be1f32"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("ff19c793-0ead-4597-89f9-42ad0af05328"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("3a857115-955c-48bc-8669-4de782fea31b"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("9912566d-0aae-44e3-9dfd-d7a7c53896a5"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("ca54fbdd-7e3b-4fe2-bd99-30abcb18cdb2"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("d618c9de-4342-4b04-b561-7ebef97f5b33"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("08a2c7ab-e377-4adf-a1a1-89a6dc7b8a0f"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("51ec04ca-3dc6-4aaa-89aa-8b82d499d18b"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("8e661fbd-1891-4811-8350-f3506491716e"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("c318eeb0-b342-4355-aa5d-f7071bd9cdb4"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("ff01459a-1a9d-4a0c-ac65-0c7ff79444fa"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("54ef6cf3-6090-4ac8-8d27-d285f6b81e17"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("67dbe6f4-92b4-4dfd-b419-82fff69bcec4"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("9c58c8a9-c869-42f5-98dd-5ccd7b11102d"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("a7beef89-0293-4950-bed0-f65613800dff"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("ef400467-28c0-4de2-9d9c-34b61df7a550"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("1002c3eb-b805-4f7e-b6ac-4e331f0e409a"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("1b63eac4-5ad2-49a3-b30e-c99295de4652"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("63d629e1-a714-4c05-b803-60b04c962ae8"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("c2020b7b-616e-438b-b7d1-7ff9ed49947b"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("feaa4fef-42cc-420c-af41-692dece7fea2"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("0e7378c9-8373-4c3e-be47-600e2540693a"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("412bc2c4-72ff-469a-8bb6-d0b874e76b74"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("68dff6be-76f9-4b85-a465-28f5a3c86b63"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("8fbcc466-b0ae-40d4-932d-4db01a9dbd15"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("c97a037f-9a69-49da-94d7-1bf07a3328c1"));

            migrationBuilder.DeleteData(
                table: "OwnerRequests",
                keyColumn: "Id",
                keyValue: new Guid("440ebf4f-eb62-4573-804c-8454eb073968"));

            migrationBuilder.DeleteData(
                table: "OwnerRequests",
                keyColumn: "Id",
                keyValue: new Guid("e25499a6-cbe6-4b5f-8666-78ea761cb38f"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("c2835b11-eaa9-4d88-a5be-ff725d1e194e"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("3047c975-7e88-422d-86f7-1fc7fc4f7160"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("51ebae51-8a83-4aad-843f-d88dbb64a9e8"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("8e8f2aec-5ba7-4dd4-b8ce-944aa9cd6487"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("c22e3ed7-0be6-4cda-b5fa-68a10e1bda49"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("cce592f8-1fab-4164-93bc-27a75fc56736"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("059c9a6c-894d-4ff5-bd70-ec44968c7826"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("0e660f29-dce9-41bd-a146-df93ac448d3f"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("27f0acb0-d4d7-4001-b986-dea2a38ff8de"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("5a93c22a-98b6-427b-8339-6d592ea75fd1"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("89b5820b-e5d5-4cd2-8efe-7c05c483fccf"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("8c304c37-c3c0-4bee-9e3c-117abeb1fe7d"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("9327d64a-f3b7-4397-ba23-14c01eba531f"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("f00cbf07-3940-410d-a16b-bed7f595f275"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("06be7fe3-c41a-4a18-9a21-16ae58813d74"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("106252f7-dbfa-4ee6-8280-b0382a91fc2d"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("892fad2c-51cb-435f-9a30-69e898422510"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("dffd45fa-eba1-443a-ada5-f18b76056c5a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f7efd419-8f8d-44d1-b9df-82e8f2af2fe0"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("02fc39d8-ffa9-4476-b4c5-8c2ae36399bb"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("9b36f130-a2fd-48d8-a4f3-11a724e4becc"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("fa066cd1-0cdb-4ddc-9c23-b22c68645cfe"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("fe26ff4c-f9b9-4153-b076-f16e9299eff4"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("ffe055c7-1f22-432e-8984-93d6f2cd06fd"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("2f5bfdf9-c571-4889-8b12-469b22b11d57"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("71e027ae-6640-42c6-8f08-cb1876cf56f0"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("74ef5057-2ba8-420f-aa61-8664c4f01117"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("7af7d729-b258-4eaa-b883-1839ee46c255"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("9c26b298-fa03-496a-9369-35b762a387a6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e4fd8233-9462-4dcf-94c7-b294bc9def3d"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("1c74707f-750e-49a9-bf51-1330daeda7c1"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("2b54fc20-ca34-4bd7-88cf-a5c966d35aa2"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("3b688c7a-2db8-4afa-9fcf-0d511a31354f"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("ddb961c7-bb36-400d-a937-256565d9feeb"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("b6dc9962-d5fe-46b1-9c6a-5c7dc9117341"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("e79b6ceb-87ec-4f06-b63e-71db4fef8134"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("9abde540-77ae-4bf0-a328-a6a6d4b8b750"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("c33a17da-ed59-4fad-b64c-d2cf0d669d55"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("f849e99b-ffc7-40df-812d-cda13afc034b"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("fdbe16c6-9e23-4da7-bbfc-15bf1de5e04a"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("2019b663-5d37-4c6c-9ed3-1c00477850ea"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("593bb9fc-5ee9-4edb-80f9-eba5de78203f"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("16aa0a59-39d0-4e9f-b70d-8bab5ece1334"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("8aa78cda-8186-431e-aaaa-dc03e6668d03"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8116b849-43c6-46cd-91cb-cd19d5e011b0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d6787d36-1da7-49ff-88a9-22d5f611f857"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a1dc565f-f059-46e4-8c98-1fda4fb4056b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d366d816-58b8-4bdc-a811-c179653a5058"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Courts",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1fcf0cd9-8c44-492d-ba50-b72a2d220129"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner2@rallyhub.vn", "Hải", false, "Đăng", "hashed_pw_3", "0900000003", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2a0eccac-2318-407e-a14e-82004acfaba0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "admin@rallyhub.vn", "Quản", false, "Trị", "hashed_pw_1", "0900000001", "Admin", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("45393781-ebc5-4562-94b6-8985051e45d5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer2@gmail.com", "Bảo", false, "Châu", "hashed_pw_5", "0900000005", "Customer", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a0822d77-f49d-4ac0-b903-06e4ed2f58fd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner1@rallyhub.vn", "Minh", false, "Tuấn", "hashed_pw_2", "0900000002", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c6279eb4-8409-4464-a109-129af5567147"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer1@gmail.com", "Lan", false, "Phương", "hashed_pw_4", "0900000004", "Customer", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e89e6bee-839f-4e1b-b4f5-8e85576a00ed"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner3@rallyhub.vn", "Trần", false, "Phú", "hashed_pw_6", "0900000006", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("79c8771a-ea27-4d84-9984-6c80ae878944"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c6279eb4-8409-4464-a109-129af5567147") },
                    { new Guid("c9660380-b151-408d-b23e-5f86d1ecea1c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("45393781-ebc5-4562-94b6-8985051e45d5") }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "BusinessAddress", "BusinessName", "CreatedAt", "IsDeleted", "TaxCode", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("63d19069-0af2-4ece-a374-aececbb667fc"), "123 Nguyễn Huệ, Q1, HCM", "Sân Cầu Lông Minh Tuấn", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "0123456789", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a0822d77-f49d-4ac0-b903-06e4ed2f58fd") },
                    { new Guid("6741cd99-8133-4d29-91ff-cef70c7c90af"), "Tôn Đức Thắng, HCM", "Sân Cầu Lông Trần Phú", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "98765434219", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("e89e6bee-839f-4e1b-b4f5-8e85576a00ed") },
                    { new Guid("e8b8c3d7-cc4c-495f-b99e-94a87eefaaff"), "456 Lê Lợi, Q3, HCM", "Trung Tâm Thể Thao Hải Đăng", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "9876543210", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("1fcf0cd9-8c44-492d-ba50-b72a2d220129") }
                });

            migrationBuilder.InsertData(
                table: "SystemReports",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("09421a63-54db-4552-b699-36ce3cbda5f8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Số dư hiển thị không khớp lịch sử.", "Resolved", "Sai số dư sau giao dịch", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("45393781-ebc5-4562-94b6-8985051e45d5") },
                    { new Guid("6daab022-c092-4a6e-acb3-035e3f039cff"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Bản đồ không load được trên iOS.", "Resolved", "Lỗi hiển thị bản đồ", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("1fcf0cd9-8c44-492d-ba50-b72a2d220129") },
                    { new Guid("901c61dc-d537-4dea-bd8d-6648e3ca1359"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "OTP không gửi đến số điện thoại.", "Pending", "Không nhận được OTP", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c6279eb4-8409-4464-a109-129af5567147") },
                    { new Guid("9c35cf4e-74d7-4518-9838-978f5579de2e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Không thể thanh toán qua ví.", "Pending", "Lỗi thanh toán", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a0822d77-f49d-4ac0-b903-06e4ed2f58fd") },
                    { new Guid("b5bbf7dd-0d5e-46fa-9593-b2e037cebb85"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Crash khi mở trang tìm kiếm sân.", "Pending", "App bị crash", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c6279eb4-8409-4464-a109-129af5567147") }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version" },
                values: new object[,]
                {
                    { new Guid("93ed7e60-18cf-4293-9898-1de62bb13415"), 2000000m, "4567890123", "MB Bank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c6279eb4-8409-4464-a109-129af5567147"), 0 },
                    { new Guid("9ed1d2e1-aa1c-499d-8363-9b2552c541f6"), 3500000m, "5678901234", "VPBank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("45393781-ebc5-4562-94b6-8985051e45d5"), 0 },
                    { new Guid("a0b1dccc-7140-4c8b-b00b-cbc89b4b853e"), 8500000m, "3456789012", "BIDV", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("1fcf0cd9-8c44-492d-ba50-b72a2d220129"), 0 },
                    { new Guid("a9191fee-49b6-4ab5-b5d8-98a532256c4f"), 12000000m, "2345678901", "Techcombank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a0822d77-f49d-4ac0-b903-06e4ed2f58fd"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount" },
                values: new object[,]
                {
                    { new Guid("053abadc-5b87-424e-b458-aca2c61b9676"), "SUMMER25", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 50000m, 200000m, new Guid("63d19069-0af2-4ece-a374-aececbb667fc"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 100, 12 },
                    { new Guid("215770f6-d92b-44d7-aecd-4328c2178452"), "NEWUSER", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 20m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 100000m, 300000m, new Guid("e8b8c3d7-cc4c-495f-b99e-94a87eefaaff"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 50, 5 },
                    { new Guid("492b8505-fa7b-49be-9254-fc784814cf72"), "LOYAL5", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 30000m, 100000m, new Guid("e8b8c3d7-cc4c-495f-b99e-94a87eefaaff"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 500, 87 },
                    { new Guid("7646c08d-4c67-4cf5-b152-7ac783a592ad"), "YEUTH", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 30000m, 100000m, new Guid("63d19069-0af2-4ece-a374-aececbb667fc"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 500, 87 },
                    { new Guid("7d69417d-2c5b-4daa-81be-37febe85ec36"), "FLASH50", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 50m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 200000m, 500000m, new Guid("63d19069-0af2-4ece-a374-aececbb667fc"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10, 10 },
                    { new Guid("e4f0746c-f409-44b7-bc02-33c3db3ab630"), "WEEKEND10", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 15m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 75000m, 250000m, new Guid("e8b8c3d7-cc4c-495f-b99e-94a87eefaaff"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 200, 30 }
                });

            migrationBuilder.InsertData(
                table: "Courts",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1356f3c4-5208-4e30-8bd2-c8bdfb1b005e"), "456 Lê Lợi, Q3, HCM", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.78m, 106.69m, "https://maps.google.com/?q=10.78,106.69", "Sân D - Hải Đăng", new TimeOnly(5, 30, 0), new Guid("e8b8c3d7-cc4c-495f-b99e-94a87eefaaff"), "https://images.example.com/courts/go-vap.jpg", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6a5fce7d-b44c-429a-b881-f5d567fc0eb7"), "123 Nguyễn Huệ, Q1, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.77m, 106.70m, "https://maps.google.com/?q=10.77,106.70", "Sân A - Minh Tuấn", new TimeOnly(6, 0, 0), new Guid("63d19069-0af2-4ece-a374-aececbb667fc"), "https://images.example.com/courts/go-vap.jpg", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("999c4940-69bc-45e8-b36f-d49ed46928f0"), "123 Nguyễn Huệ, Q1, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.77m, 106.70m, "https://maps.google.com/?q=10.77,106.70", "Sân B - Minh Tuấn", new TimeOnly(6, 0, 0), new Guid("63d19069-0af2-4ece-a374-aececbb667fc"), "https://images.example.com/courts/go-vap.jpg", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ad914a6b-3925-41d6-8bea-8dc48de76710"), "456 Lê Lợi, Q3, HCM", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.78m, 106.69m, "https://maps.google.com/?q=10.78,106.69", "Sân C - Hải Đăng", new TimeOnly(5, 30, 0), new Guid("e8b8c3d7-cc4c-495f-b99e-94a87eefaaff"), "https://images.example.com/courts/go-vap.jpg", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "OwnerRequests",
                columns: new[] { "Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "CustomerId", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "OwnerId", "RejectionReason", "Status", "TaxCode", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1015d707-b485-4559-b4a6-f6844d99b0ee"), "123 Nguyễn Huệ, Q1, HCM", "https://cdn.rallyhub.vn/license/1.jpg", "Sân Cầu Lông Minh Tuấn", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("79c8771a-ea27-4d84-9984-6c80ae878944"), "https://cdn.rallyhub.vn/cccd/1_back.jpg", "https://cdn.rallyhub.vn/cccd/1_front.jpg", "079200012345", false, new Guid("63d19069-0af2-4ece-a374-aececbb667fc"), null, "Approved", "0123456789", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("548849aa-2700-403a-849f-a83625c58b47"), "456 Lê Lợi, Q3, HCM", "https://cdn.rallyhub.vn/license/2.jpg", "Trung Tâm Thể Thao Hải Đăng", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c9660380-b151-408d-b23e-5f86d1ecea1c"), "https://cdn.rallyhub.vn/cccd/2_back.jpg", "https://cdn.rallyhub.vn/cccd/2_front.jpg", "079200054321", false, new Guid("e8b8c3d7-cc4c-495f-b99e-94a87eefaaff"), null, "Approved", "9876543210", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("4bfab9d0-69ed-414b-8187-bab32780e86f"), new Guid("215770f6-d92b-44d7-aecd-4328c2178452"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c9660380-b151-408d-b23e-5f86d1ecea1c"), 40000m, 360000m, false, "Banked", 400000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("96151d51-7b56-4f3a-868b-590c717d3845"), new Guid("053abadc-5b87-424e-b458-aca2c61b9676"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("79c8771a-ea27-4d84-9984-6c80ae878944"), 30000m, 270000m, false, "Banked", 300000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e074af72-a681-47c4-a8e8-03e984193be5"), new Guid("053abadc-5b87-424e-b458-aca2c61b9676"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("79c8771a-ea27-4d84-9984-6c80ae878944"), 20000m, 180000m, false, "Complete", 200000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e69b1862-bc12-45c6-aa8a-2b91447de621"), new Guid("215770f6-d92b-44d7-aecd-4328c2178452"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c9660380-b151-408d-b23e-5f86d1ecea1c"), 0m, 150000m, false, "Complete", 150000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f4b21417-5dc9-4d08-911d-65bad8a307a2"), new Guid("215770f6-d92b-44d7-aecd-4328c2178452"), "Khách huỷ", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c9660380-b151-408d-b23e-5f86d1ecea1c"), 50000m, 200000m, false, "Cancel", 250000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "CampaignCourts",
                columns: new[] { "Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("09682681-a76e-4709-a16a-dcc0fd671ebc"), new Guid("053abadc-5b87-424e-b458-aca2c61b9676"), new Guid("ad914a6b-3925-41d6-8bea-8dc48de76710"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("25053802-0466-45e0-a79d-546750055264"), new Guid("215770f6-d92b-44d7-aecd-4328c2178452"), new Guid("6a5fce7d-b44c-429a-b881-f5d567fc0eb7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cefc93fe-02e7-4f88-9ed8-e01b28fbdaab"), new Guid("053abadc-5b87-424e-b458-aca2c61b9676"), new Guid("1356f3c4-5208-4e30-8bd2-c8bdfb1b005e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("dea54feb-8de6-4da6-9739-041738cec093"), new Guid("215770f6-d92b-44d7-aecd-4328c2178452"), new Guid("999c4940-69bc-45e8-b36f-d49ed46928f0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "LikeListDetails",
                columns: new[] { "Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("39a690df-91b3-42b7-b63c-d6aeca5211ce"), new Guid("ad914a6b-3925-41d6-8bea-8dc48de76710"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c9660380-b151-408d-b23e-5f86d1ecea1c"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("944973f5-6915-4f8c-b434-d008cabb0d77"), new Guid("6a5fce7d-b44c-429a-b881-f5d567fc0eb7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c9660380-b151-408d-b23e-5f86d1ecea1c"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a3216fa8-36ee-4e93-b144-45e6cca50f0b"), new Guid("999c4940-69bc-45e8-b36f-d49ed46928f0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("79c8771a-ea27-4d84-9984-6c80ae878944"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ac6660a8-db41-4e5e-bd68-e236ca82aa70"), new Guid("6a5fce7d-b44c-429a-b881-f5d567fc0eb7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("79c8771a-ea27-4d84-9984-6c80ae878944"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c28064a4-1ec0-4072-ba72-ca19375c7f7e"), new Guid("1356f3c4-5208-4e30-8bd2-c8bdfb1b005e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c9660380-b151-408d-b23e-5f86d1ecea1c"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "SubCourts",
                columns: new[] { "Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1cdc4b02-2d72-415d-b345-2782935fb634"), new Guid("999c4940-69bc-45e8-b36f-d49ed46928f0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ B1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2f10a9e2-dd33-4d7e-bf06-fc579360ccce"), new Guid("ad914a6b-3925-41d6-8bea-8dc48de76710"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ C2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("60e390bd-4d1f-4692-93f5-fed84de23758"), new Guid("6a5fce7d-b44c-429a-b881-f5d567fc0eb7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ A1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("68cd12a3-e6ee-4e54-ae0c-af6045d9a9fb"), new Guid("ad914a6b-3925-41d6-8bea-8dc48de76710"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ C1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("76c4c1a8-c5a5-4589-ba76-30d5d5b2ccbd"), new Guid("1356f3c4-5208-4e30-8bd2-c8bdfb1b005e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ D1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9789164c-6170-4ad5-9ca4-a36cbf93fee2"), new Guid("999c4940-69bc-45e8-b36f-d49ed46928f0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ B2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b65ebd1e-4599-4879-b372-20c90841351d"), new Guid("1356f3c4-5208-4e30-8bd2-c8bdfb1b005e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ D2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e46308bb-3358-468e-80b7-fe9ad51f9de2"), new Guid("6a5fce7d-b44c-429a-b881-f5d567fc0eb7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ A2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "BookingDetails",
                columns: new[] { "Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1c868ea0-ae00-4044-a01c-93dbfc52fb95"), new Guid("e074af72-a681-47c4-a8e8-03e984193be5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 24, 4, 5, 16, 742, DateTimeKind.Unspecified).AddTicks(3997), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 100000m, new TimeOnly(8, 0, 0), new Guid("60e390bd-4d1f-4692-93f5-fed84de23758"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7f8ae21c-bce5-4f8b-a2db-56650d6ed326"), new Guid("4bfab9d0-69ed-414b-8187-bab32780e86f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 30, 4, 5, 16, 742, DateTimeKind.Unspecified).AddTicks(4068), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 150000m, new TimeOnly(9, 0, 0), new Guid("e46308bb-3358-468e-80b7-fe9ad51f9de2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("89b18977-c219-40b5-9544-f9a35f5bbe38"), new Guid("f4b21417-5dc9-4d08-911d-65bad8a307a2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 26, 4, 5, 16, 742, DateTimeKind.Unspecified).AddTicks(4057), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 150000m, new TimeOnly(6, 0, 0), new Guid("76c4c1a8-c5a5-4589-ba76-30d5d5b2ccbd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9cda316a-df56-468b-86b8-7d6c23612ccb"), new Guid("96151d51-7b56-4f3a-868b-590c717d3845"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 24, 4, 5, 16, 742, DateTimeKind.Unspecified).AddTicks(4051), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 100000m, new TimeOnly(6, 0, 0), new Guid("1cdc4b02-2d72-415d-b345-2782935fb634"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("edfc4f50-3f1b-4463-aa58-98d7dbddd998"), new Guid("e69b1862-bc12-45c6-aa8a-2b91447de621"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 26, 4, 5, 16, 742, DateTimeKind.Unspecified).AddTicks(4054), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 150000m, new TimeOnly(7, 0, 0), new Guid("68cd12a3-e6ee-4e54-ae0c-af6045d9a9fb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ConfigSlots",
                columns: new[] { "Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("04650c91-bc5b-47aa-9fdb-74d1c71dbc5a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 100000m, new TimeOnly(7, 30, 0), new Guid("76c4c1a8-c5a5-4589-ba76-30d5d5b2ccbd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("0c3de906-009e-4236-a92f-53ae0cb04d92"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 100000m, new TimeOnly(6, 30, 0), new Guid("76c4c1a8-c5a5-4589-ba76-30d5d5b2ccbd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("18b46f67-6691-4075-ad70-9b0c331c32b2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 70000m, new TimeOnly(7, 0, 0), new Guid("1cdc4b02-2d72-415d-b345-2782935fb634"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("1ab438ab-c714-464d-8c5f-da5dfca6f1dd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 100000m, new TimeOnly(7, 0, 0), new Guid("76c4c1a8-c5a5-4589-ba76-30d5d5b2ccbd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("24b5391b-db21-4fb1-9851-dca933130197"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 100000m, new TimeOnly(8, 30, 0), new Guid("76c4c1a8-c5a5-4589-ba76-30d5d5b2ccbd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2c8f9d83-6d42-4a34-a101-a6509bea7d26"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 100000m, new TimeOnly(9, 30, 0), new Guid("76c4c1a8-c5a5-4589-ba76-30d5d5b2ccbd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("338150e9-b8d9-4414-9b92-8203756a22c6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 100000m, new TimeOnly(6, 0, 0), new Guid("76c4c1a8-c5a5-4589-ba76-30d5d5b2ccbd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("46a8f750-9ff4-49d3-8d6f-b6c787a8275b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 100000m, new TimeOnly(9, 0, 0), new Guid("76c4c1a8-c5a5-4589-ba76-30d5d5b2ccbd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("49cda32c-8ffd-426f-b201-f864547290bb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 70000m, new TimeOnly(8, 0, 0), new Guid("1cdc4b02-2d72-415d-b345-2782935fb634"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("57de552b-10bb-4235-a186-ab8f6ecabbd6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 50000m, new TimeOnly(6, 0, 0), new Guid("60e390bd-4d1f-4692-93f5-fed84de23758"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("582101ca-b2de-4c78-a359-56723d75c254"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 50000m, new TimeOnly(9, 30, 0), new Guid("60e390bd-4d1f-4692-93f5-fed84de23758"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5830b1d1-5f4a-4ada-bae3-cecb3a5a8ae7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 70000m, new TimeOnly(8, 30, 0), new Guid("1cdc4b02-2d72-415d-b345-2782935fb634"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5893fcda-c92b-42b0-9a49-aae27271e9c5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 50000m, new TimeOnly(8, 30, 0), new Guid("60e390bd-4d1f-4692-93f5-fed84de23758"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("67169797-1619-4364-bbab-b8f204fbded7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 50000m, new TimeOnly(9, 0, 0), new Guid("60e390bd-4d1f-4692-93f5-fed84de23758"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("84747583-93c0-4ab2-adc9-a8baad98d567"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 35000m, new TimeOnly(7, 30, 0), new Guid("68cd12a3-e6ee-4e54-ae0c-af6045d9a9fb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("878512dc-f748-4013-be23-62b25c93b4ab"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 35000m, new TimeOnly(9, 0, 0), new Guid("68cd12a3-e6ee-4e54-ae0c-af6045d9a9fb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8b613ebd-666c-4995-a801-ca2b9a012b40"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 35000m, new TimeOnly(6, 30, 0), new Guid("68cd12a3-e6ee-4e54-ae0c-af6045d9a9fb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8f7e9a5a-c1fb-4c83-b721-854144731d62"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 50000m, new TimeOnly(8, 0, 0), new Guid("60e390bd-4d1f-4692-93f5-fed84de23758"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a2b8633a-24c6-465b-a7ea-5a4546874776"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 35000m, new TimeOnly(9, 30, 0), new Guid("68cd12a3-e6ee-4e54-ae0c-af6045d9a9fb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a87bf8e5-5ac0-4589-968b-eabf6e8294dc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 70000m, new TimeOnly(7, 30, 0), new Guid("1cdc4b02-2d72-415d-b345-2782935fb634"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ad015690-fff0-48fa-a4bf-0150d59ae167"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 50000m, new TimeOnly(7, 30, 0), new Guid("60e390bd-4d1f-4692-93f5-fed84de23758"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0f8b024-87c7-4b2e-b885-83e70340d650"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 70000m, new TimeOnly(6, 30, 0), new Guid("1cdc4b02-2d72-415d-b345-2782935fb634"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c992ef9b-9b8e-4e27-9ed8-ef42c7727a5a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 35000m, new TimeOnly(8, 0, 0), new Guid("68cd12a3-e6ee-4e54-ae0c-af6045d9a9fb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d23b961a-eaab-4ec7-9b58-cab1246de519"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 50000m, new TimeOnly(6, 30, 0), new Guid("60e390bd-4d1f-4692-93f5-fed84de23758"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("db74733a-dfe7-4587-b1c3-24f9ce634d38"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 70000m, new TimeOnly(9, 30, 0), new Guid("1cdc4b02-2d72-415d-b345-2782935fb634"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("de06a214-0d01-4abc-ae29-8fba8e81e1d5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 35000m, new TimeOnly(6, 0, 0), new Guid("68cd12a3-e6ee-4e54-ae0c-af6045d9a9fb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("de07c264-2ba7-42c1-a7bb-4b4a199c9b2c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 35000m, new TimeOnly(8, 30, 0), new Guid("68cd12a3-e6ee-4e54-ae0c-af6045d9a9fb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e40059d1-8547-466b-a195-3556d62994b5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 50000m, new TimeOnly(7, 0, 0), new Guid("60e390bd-4d1f-4692-93f5-fed84de23758"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e5d4cdae-3112-4ed8-a38e-0ba75683f04e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 70000m, new TimeOnly(9, 0, 0), new Guid("1cdc4b02-2d72-415d-b345-2782935fb634"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ee0621f8-c49d-4e9f-9f5e-4d13ff8dd01b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 70000m, new TimeOnly(6, 0, 0), new Guid("1cdc4b02-2d72-415d-b345-2782935fb634"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f522ab3b-123f-477c-8547-2f4b932113dc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 100000m, new TimeOnly(8, 0, 0), new Guid("76c4c1a8-c5a5-4589-ba76-30d5d5b2ccbd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ff2e39a7-160e-4104-8546-a5ea7febfcfd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 35000m, new TimeOnly(7, 0, 0), new Guid("68cd12a3-e6ee-4e54-ae0c-af6045d9a9fb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Exceptions",
                columns: new[] { "Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("010a158a-89c9-4a3d-85c0-792f66b12a47"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Sơn lại mặt sân", new TimeOnly(12, 0, 0), new Guid("1cdc4b02-2d72-415d-b345-2782935fb634"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("1d06dc16-487a-4012-982e-204de6dea845"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Tổ chức sự kiện nội bộ", new TimeOnly(12, 0, 0), new Guid("76c4c1a8-c5a5-4589-ba76-30d5d5b2ccbd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a88becab-95c1-4ccb-9674-c470b5e20707"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Bảo trì định kỳ", new TimeOnly(12, 0, 0), new Guid("60e390bd-4d1f-4692-93f5-fed84de23758"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f911674c-d0c4-49f2-9b22-f4df1f8d7716"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Hỏng đèn chiếu sáng", new TimeOnly(12, 0, 0), new Guid("68cd12a3-e6ee-4e54-ae0c-af6045d9a9fb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("25ca5ea1-664d-42df-a7d2-68c1028fda45"), new Guid("e074af72-a681-47c4-a8e8-03e984193be5"), "Sân rất tốt, sẽ quay lại!", new Guid("6a5fce7d-b44c-429a-b881-f5d567fc0eb7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c9660380-b151-408d-b23e-5f86d1ecea1c"), false, 5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8995439e-822d-440d-85cb-44f72fec48bb"), new Guid("96151d51-7b56-4f3a-868b-590c717d3845"), "Dịch vụ ổn, giá hợp lý.", new Guid("999c4940-69bc-45e8-b36f-d49ed46928f0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c9660380-b151-408d-b23e-5f86d1ecea1c"), false, 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9883d76a-7fb2-4a7b-ab45-d2f29014bf6a"), new Guid("f4b21417-5dc9-4d08-911d-65bad8a307a2"), "Nhân viên thân thiện, sân sạch.", new Guid("999c4940-69bc-45e8-b36f-d49ed46928f0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("79c8771a-ea27-4d84-9984-6c80ae878944"), false, 5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a0b1fea3-f825-4df2-9f50-365f644b2b64"), new Guid("e69b1862-bc12-45c6-aa8a-2b91447de621"), "Bình thường, sân hơi cũ.", new Guid("ad914a6b-3925-41d6-8bea-8dc48de76710"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("79c8771a-ea27-4d84-9984-6c80ae878944"), false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("bd2b90d2-5c5d-4c77-99b7-212140a91785"), new Guid("4bfab9d0-69ed-414b-8187-bab32780e86f"), "Đèn chiếu sáng yếu vào ban đêm.", new Guid("6a5fce7d-b44c-429a-b881-f5d567fc0eb7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c9660380-b151-408d-b23e-5f86d1ecea1c"), false, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("73c9092e-8436-4f4e-bcb9-ba659f9ceeab"), new Guid("e074af72-a681-47c4-a8e8-03e984193be5"), "Booking #1 đã được xác nhận.", new Guid("6a5fce7d-b44c-429a-b881-f5d567fc0eb7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Đặt sân thành công", "Booking", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a0822d77-f49d-4ac0-b903-06e4ed2f58fd") });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("7c845fcf-b017-47ff-a27c-6f7fbdac9246"), new Guid("4bfab9d0-69ed-414b-8187-bab32780e86f"), "Đã hoàn 360,000đ vào ví của bạn.", new Guid("6a5fce7d-b44c-429a-b881-f5d567fc0eb7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Hoàn tiền", "Refund", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a0822d77-f49d-4ac0-b903-06e4ed2f58fd") },
                    { new Guid("b1d555ea-7893-430a-9b6e-e83c7c9f091b"), new Guid("96151d51-7b56-4f3a-868b-590c717d3845"), "Booking #2 đã được xác nhận.", new Guid("999c4940-69bc-45e8-b36f-d49ed46928f0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Đặt sân thành công", "Booking", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("1fcf0cd9-8c44-492d-ba50-b72a2d220129") },
                    { new Guid("bf31a30b-ae6a-4691-9710-6029cf010291"), new Guid("e69b1862-bc12-45c6-aa8a-2b91447de621"), "Bạn có lịch chơi vào ngày mai.", new Guid("ad914a6b-3925-41d6-8bea-8dc48de76710"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Nhắc nhở lịch chơi", "Remind", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c6279eb4-8409-4464-a109-129af5567147") }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("d4759fe3-9e7f-41c6-b78e-5a49b1cc0e7a"), new Guid("f4b21417-5dc9-4d08-911d-65bad8a307a2"), "Booking #4 đã bị huỷ. Tiền sẽ hoàn.", new Guid("1356f3c4-5208-4e30-8bd2-c8bdfb1b005e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Huỷ booking", "Cancel", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("45393781-ebc5-4562-94b6-8985051e45d5") });

            migrationBuilder.InsertData(
                table: "OverideSlots",
                columns: new[] { "Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("4acf1c1e-89c9-44f3-9638-a9dae0a26947"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 2054000m, new TimeOnly(12, 0, 0), new Guid("68cd12a3-e6ee-4e54-ae0c-af6045d9a9fb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("84cf4655-42bd-4d1d-9c92-e4dd50d44da9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 220800m, new TimeOnly(12, 0, 0), new Guid("76c4c1a8-c5a5-4589-ba76-30d5d5b2ccbd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9a54a008-77d5-4d53-8729-43dc77779864"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 220500m, new TimeOnly(12, 0, 0), new Guid("1cdc4b02-2d72-415d-b345-2782935fb634"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "OverideSlots",
                columns: new[] { "Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "IsRecurring", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[] { new Guid("be37c1bb-c816-4d71-8bad-c5b67f7bfe2d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(1, 1, 1), 1, new TimeOnly(20, 0, 0), false, true, 200000m, new TimeOnly(18, 0, 0), new Guid("e46308bb-3358-468e-80b7-fe9ad51f9de2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "OverideSlots",
                columns: new[] { "Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[] { new Guid("e149d9ff-99f9-4dea-983e-af2c4b02c94f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 208400m, new TimeOnly(12, 0, 0), new Guid("60e390bd-4d1f-4692-93f5-fed84de23758"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("49657f14-6653-45e3-9a54-b6c06c02d48f"), new Guid("4bfab9d0-69ed-414b-8187-bab32780e86f"), new Guid("1356f3c4-5208-4e30-8bd2-c8bdfb1b005e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c9660380-b151-408d-b23e-5f86d1ecea1c"), false, "Thông tin giờ mở cửa sai.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("927f04ba-4590-4b41-adb5-fa6d26188072"), new Guid("e074af72-a681-47c4-a8e8-03e984193be5"), new Guid("ad914a6b-3925-41d6-8bea-8dc48de76710"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("79c8771a-ea27-4d84-9984-6c80ae878944"), false, "Sân không đúng mô tả.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9b7ff839-9543-4b84-b0a5-8ea285449b37"), new Guid("f4b21417-5dc9-4d08-911d-65bad8a307a2"), new Guid("ad914a6b-3925-41d6-8bea-8dc48de76710"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c9660380-b151-408d-b23e-5f86d1ecea1c"), false, "Không hoàn tiền khi huỷ đúng hạn.", "Rejected", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b0521184-7569-4428-a2a8-7c9dee60a8d7"), new Guid("e69b1862-bc12-45c6-aa8a-2b91447de621"), new Guid("999c4940-69bc-45e8-b36f-d49ed46928f0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c9660380-b151-408d-b23e-5f86d1ecea1c"), false, "Cơ sở vật chất xuống cấp.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cf371754-1b35-49d8-9b16-8c4bdeecc309"), new Guid("96151d51-7b56-4f3a-868b-590c717d3845"), new Guid("6a5fce7d-b44c-429a-b881-f5d567fc0eb7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("79c8771a-ea27-4d84-9984-6c80ae878944"), false, "Chủ sân thái độ không tốt.", "Resolved", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId" },
                values: new object[,]
                {
                    { new Guid("14ccd85a-bda1-4846-8feb-8bb8fea43908"), "ACT002", 270000m, 3500000m, 3770000m, "3456789012", "REF002", new Guid("96151d51-7b56-4f3a-868b-590c717d3845"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP002", "SIG002", "Success", "Thanh toán booking #2", "Payment", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a0b1dccc-7140-4c8b-b00b-cbc89b4b853e") },
                    { new Guid("503d5477-2557-4831-8329-a9907c684270"), "ACT003", 200000m, 2200000m, 2000000m, "4567890123", "REF003", new Guid("e69b1862-bc12-45c6-aa8a-2b91447de621"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP003", "SIG003", "Success", "Hoàn tiền booking #4", "Refund", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("93ed7e60-18cf-4293-9898-1de62bb13415") },
                    { new Guid("cd8e586d-0abc-4eab-a29c-72ee5bd77773"), "ACT004", 500000m, 2000000m, 1500000m, "5678901234", "REF004", new Guid("4bfab9d0-69ed-414b-8187-bab32780e86f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP004", "SIG004", "Success", "Nạp tiền vào ví", "Deposit", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("9ed1d2e1-aa1c-499d-8363-9b2552c541f6") },
                    { new Guid("e9fdf279-37f5-4bbc-b8ac-585a7e2f3f3c"), "ACT001", 180000m, 2000000m, 2180000m, "2345678901", "REF001", new Guid("e074af72-a681-47c4-a8e8-03e984193be5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP001", "SIG001", "Success", "Thanh toán booking #1", "Payment", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a9191fee-49b6-4ab5-b5d8-98a532256c4f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courts_Name",
                table: "Courts",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Courts_Name",
                table: "Courts");

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("1c868ea0-ae00-4044-a01c-93dbfc52fb95"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("7f8ae21c-bce5-4f8b-a2db-56650d6ed326"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("89b18977-c219-40b5-9544-f9a35f5bbe38"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("9cda316a-df56-468b-86b8-7d6c23612ccb"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("edfc4f50-3f1b-4463-aa58-98d7dbddd998"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("09682681-a76e-4709-a16a-dcc0fd671ebc"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("25053802-0466-45e0-a79d-546750055264"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("cefc93fe-02e7-4f88-9ed8-e01b28fbdaab"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("dea54feb-8de6-4da6-9739-041738cec093"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("492b8505-fa7b-49be-9254-fc784814cf72"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("7646c08d-4c67-4cf5-b152-7ac783a592ad"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("7d69417d-2c5b-4daa-81be-37febe85ec36"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("e4f0746c-f409-44b7-bc02-33c3db3ab630"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("04650c91-bc5b-47aa-9fdb-74d1c71dbc5a"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("0c3de906-009e-4236-a92f-53ae0cb04d92"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("18b46f67-6691-4075-ad70-9b0c331c32b2"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("1ab438ab-c714-464d-8c5f-da5dfca6f1dd"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("24b5391b-db21-4fb1-9851-dca933130197"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("2c8f9d83-6d42-4a34-a101-a6509bea7d26"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("338150e9-b8d9-4414-9b92-8203756a22c6"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("46a8f750-9ff4-49d3-8d6f-b6c787a8275b"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("49cda32c-8ffd-426f-b201-f864547290bb"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("57de552b-10bb-4235-a186-ab8f6ecabbd6"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("582101ca-b2de-4c78-a359-56723d75c254"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("5830b1d1-5f4a-4ada-bae3-cecb3a5a8ae7"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("5893fcda-c92b-42b0-9a49-aae27271e9c5"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("67169797-1619-4364-bbab-b8f204fbded7"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("84747583-93c0-4ab2-adc9-a8baad98d567"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("878512dc-f748-4013-be23-62b25c93b4ab"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("8b613ebd-666c-4995-a801-ca2b9a012b40"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("8f7e9a5a-c1fb-4c83-b721-854144731d62"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("a2b8633a-24c6-465b-a7ea-5a4546874776"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("a87bf8e5-5ac0-4589-968b-eabf6e8294dc"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("ad015690-fff0-48fa-a4bf-0150d59ae167"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("c0f8b024-87c7-4b2e-b885-83e70340d650"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("c992ef9b-9b8e-4e27-9ed8-ef42c7727a5a"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("d23b961a-eaab-4ec7-9b58-cab1246de519"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("db74733a-dfe7-4587-b1c3-24f9ce634d38"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("de06a214-0d01-4abc-ae29-8fba8e81e1d5"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("de07c264-2ba7-42c1-a7bb-4b4a199c9b2c"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("e40059d1-8547-466b-a195-3556d62994b5"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("e5d4cdae-3112-4ed8-a38e-0ba75683f04e"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("ee0621f8-c49d-4e9f-9f5e-4d13ff8dd01b"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("f522ab3b-123f-477c-8547-2f4b932113dc"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("ff2e39a7-160e-4104-8546-a5ea7febfcfd"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("010a158a-89c9-4a3d-85c0-792f66b12a47"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("1d06dc16-487a-4012-982e-204de6dea845"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("a88becab-95c1-4ccb-9674-c470b5e20707"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("f911674c-d0c4-49f2-9b22-f4df1f8d7716"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("25ca5ea1-664d-42df-a7d2-68c1028fda45"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("8995439e-822d-440d-85cb-44f72fec48bb"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("9883d76a-7fb2-4a7b-ab45-d2f29014bf6a"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("a0b1fea3-f825-4df2-9f50-365f644b2b64"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("bd2b90d2-5c5d-4c77-99b7-212140a91785"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("39a690df-91b3-42b7-b63c-d6aeca5211ce"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("944973f5-6915-4f8c-b434-d008cabb0d77"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("a3216fa8-36ee-4e93-b144-45e6cca50f0b"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("ac6660a8-db41-4e5e-bd68-e236ca82aa70"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("c28064a4-1ec0-4072-ba72-ca19375c7f7e"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("73c9092e-8436-4f4e-bcb9-ba659f9ceeab"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("7c845fcf-b017-47ff-a27c-6f7fbdac9246"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("b1d555ea-7893-430a-9b6e-e83c7c9f091b"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("bf31a30b-ae6a-4691-9710-6029cf010291"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("d4759fe3-9e7f-41c6-b78e-5a49b1cc0e7a"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("4acf1c1e-89c9-44f3-9638-a9dae0a26947"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("84cf4655-42bd-4d1d-9c92-e4dd50d44da9"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("9a54a008-77d5-4d53-8729-43dc77779864"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("be37c1bb-c816-4d71-8bad-c5b67f7bfe2d"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("e149d9ff-99f9-4dea-983e-af2c4b02c94f"));

            migrationBuilder.DeleteData(
                table: "OwnerRequests",
                keyColumn: "Id",
                keyValue: new Guid("1015d707-b485-4559-b4a6-f6844d99b0ee"));

            migrationBuilder.DeleteData(
                table: "OwnerRequests",
                keyColumn: "Id",
                keyValue: new Guid("548849aa-2700-403a-849f-a83625c58b47"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("6741cd99-8133-4d29-91ff-cef70c7c90af"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("49657f14-6653-45e3-9a54-b6c06c02d48f"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("927f04ba-4590-4b41-adb5-fa6d26188072"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("9b7ff839-9543-4b84-b0a5-8ea285449b37"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("b0521184-7569-4428-a2a8-7c9dee60a8d7"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("cf371754-1b35-49d8-9b16-8c4bdeecc309"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("2f10a9e2-dd33-4d7e-bf06-fc579360ccce"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("9789164c-6170-4ad5-9ca4-a36cbf93fee2"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("b65ebd1e-4599-4879-b372-20c90841351d"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("09421a63-54db-4552-b699-36ce3cbda5f8"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("6daab022-c092-4a6e-acb3-035e3f039cff"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("901c61dc-d537-4dea-bd8d-6648e3ca1359"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("9c35cf4e-74d7-4518-9838-978f5579de2e"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("b5bbf7dd-0d5e-46fa-9593-b2e037cebb85"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("14ccd85a-bda1-4846-8feb-8bb8fea43908"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("503d5477-2557-4831-8329-a9907c684270"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("cd8e586d-0abc-4eab-a29c-72ee5bd77773"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("e9fdf279-37f5-4bbc-b8ac-585a7e2f3f3c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2a0eccac-2318-407e-a14e-82004acfaba0"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("4bfab9d0-69ed-414b-8187-bab32780e86f"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("96151d51-7b56-4f3a-868b-590c717d3845"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("e074af72-a681-47c4-a8e8-03e984193be5"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("e69b1862-bc12-45c6-aa8a-2b91447de621"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("f4b21417-5dc9-4d08-911d-65bad8a307a2"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("1cdc4b02-2d72-415d-b345-2782935fb634"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("60e390bd-4d1f-4692-93f5-fed84de23758"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("68cd12a3-e6ee-4e54-ae0c-af6045d9a9fb"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("76c4c1a8-c5a5-4589-ba76-30d5d5b2ccbd"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("e46308bb-3358-468e-80b7-fe9ad51f9de2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e89e6bee-839f-4e1b-b4f5-8e85576a00ed"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("93ed7e60-18cf-4293-9898-1de62bb13415"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("9ed1d2e1-aa1c-499d-8363-9b2552c541f6"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("a0b1dccc-7140-4c8b-b00b-cbc89b4b853e"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("a9191fee-49b6-4ab5-b5d8-98a532256c4f"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("053abadc-5b87-424e-b458-aca2c61b9676"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("215770f6-d92b-44d7-aecd-4328c2178452"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("1356f3c4-5208-4e30-8bd2-c8bdfb1b005e"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("6a5fce7d-b44c-429a-b881-f5d567fc0eb7"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("999c4940-69bc-45e8-b36f-d49ed46928f0"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("ad914a6b-3925-41d6-8bea-8dc48de76710"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("79c8771a-ea27-4d84-9984-6c80ae878944"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("c9660380-b151-408d-b23e-5f86d1ecea1c"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("63d19069-0af2-4ece-a374-aececbb667fc"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("e8b8c3d7-cc4c-495f-b99e-94a87eefaaff"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("45393781-ebc5-4562-94b6-8985051e45d5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c6279eb4-8409-4464-a109-129af5567147"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fcf0cd9-8c44-492d-ba50-b72a2d220129"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a0822d77-f49d-4ac0-b903-06e4ed2f58fd"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Courts");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("8116b849-43c6-46cd-91cb-cd19d5e011b0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer2@gmail.com", "Bảo", false, "Châu", "hashed_pw_5", "0900000005", "Customer", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a1dc565f-f059-46e4-8c98-1fda4fb4056b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner1@rallyhub.vn", "Minh", false, "Tuấn", "hashed_pw_2", "0900000002", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d366d816-58b8-4bdc-a811-c179653a5058"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner2@rallyhub.vn", "Hải", false, "Đăng", "hashed_pw_3", "0900000003", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d6787d36-1da7-49ff-88a9-22d5f611f857"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer1@gmail.com", "Lan", false, "Phương", "hashed_pw_4", "0900000004", "Customer", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e4fd8233-9462-4dcf-94c7-b294bc9def3d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner3@rallyhub.vn", "Trần", false, "Phú", "hashed_pw_6", "0900000006", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f7efd419-8f8d-44d1-b9df-82e8f2af2fe0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "admin@rallyhub.vn", "Quản", false, "Trị", "hashed_pw_1", "0900000001", "Admin", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("2019b663-5d37-4c6c-9ed3-1c00477850ea"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8116b849-43c6-46cd-91cb-cd19d5e011b0") },
                    { new Guid("593bb9fc-5ee9-4edb-80f9-eba5de78203f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d6787d36-1da7-49ff-88a9-22d5f611f857") }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "BusinessAddress", "BusinessName", "CreatedAt", "IsDeleted", "TaxCode", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("16aa0a59-39d0-4e9f-b70d-8bab5ece1334"), "456 Lê Lợi, Q3, HCM", "Trung Tâm Thể Thao Hải Đăng", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "9876543210", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d366d816-58b8-4bdc-a811-c179653a5058") },
                    { new Guid("8aa78cda-8186-431e-aaaa-dc03e6668d03"), "123 Nguyễn Huệ, Q1, HCM", "Sân Cầu Lông Minh Tuấn", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "0123456789", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a1dc565f-f059-46e4-8c98-1fda4fb4056b") },
                    { new Guid("c2835b11-eaa9-4d88-a5be-ff725d1e194e"), "Tôn Đức Thắng, HCM", "Sân Cầu Lông Trần Phú", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "98765434219", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("e4fd8233-9462-4dcf-94c7-b294bc9def3d") }
                });

            migrationBuilder.InsertData(
                table: "SystemReports",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("5a93c22a-98b6-427b-8339-6d592ea75fd1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Không thể thanh toán qua ví.", "Pending", "Lỗi thanh toán", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a1dc565f-f059-46e4-8c98-1fda4fb4056b") },
                    { new Guid("89b5820b-e5d5-4cd2-8efe-7c05c483fccf"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Bản đồ không load được trên iOS.", "Resolved", "Lỗi hiển thị bản đồ", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d366d816-58b8-4bdc-a811-c179653a5058") },
                    { new Guid("8c304c37-c3c0-4bee-9e3c-117abeb1fe7d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Crash khi mở trang tìm kiếm sân.", "Pending", "App bị crash", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d6787d36-1da7-49ff-88a9-22d5f611f857") },
                    { new Guid("9327d64a-f3b7-4397-ba23-14c01eba531f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Số dư hiển thị không khớp lịch sử.", "Resolved", "Sai số dư sau giao dịch", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8116b849-43c6-46cd-91cb-cd19d5e011b0") },
                    { new Guid("f00cbf07-3940-410d-a16b-bed7f595f275"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "OTP không gửi đến số điện thoại.", "Pending", "Không nhận được OTP", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d6787d36-1da7-49ff-88a9-22d5f611f857") }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version" },
                values: new object[,]
                {
                    { new Guid("1c74707f-750e-49a9-bf51-1330daeda7c1"), 12000000m, "2345678901", "Techcombank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a1dc565f-f059-46e4-8c98-1fda4fb4056b"), 0 },
                    { new Guid("2b54fc20-ca34-4bd7-88cf-a5c966d35aa2"), 2000000m, "4567890123", "MB Bank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d6787d36-1da7-49ff-88a9-22d5f611f857"), 0 },
                    { new Guid("3b688c7a-2db8-4afa-9fcf-0d511a31354f"), 3500000m, "5678901234", "VPBank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8116b849-43c6-46cd-91cb-cd19d5e011b0"), 0 },
                    { new Guid("ddb961c7-bb36-400d-a937-256565d9feeb"), 8500000m, "3456789012", "BIDV", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d366d816-58b8-4bdc-a811-c179653a5058"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount" },
                values: new object[,]
                {
                    { new Guid("0f883e67-870f-49ae-95b4-893bf6bcfae2"), "WEEKEND10", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 15m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 75000m, 250000m, new Guid("16aa0a59-39d0-4e9f-b70d-8bab5ece1334"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 200, 30 },
                    { new Guid("11c13a04-a257-4f52-a342-30dfb5742b57"), "YEUTH", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 30000m, 100000m, new Guid("8aa78cda-8186-431e-aaaa-dc03e6668d03"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 500, 87 },
                    { new Guid("1655ead5-51e7-4a47-9fc3-2e28c1e02104"), "FLASH50", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 50m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 200000m, 500000m, new Guid("8aa78cda-8186-431e-aaaa-dc03e6668d03"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10, 10 },
                    { new Guid("8ed789ce-9ddd-4ba3-8a08-cae5d9027f6c"), "LOYAL5", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 30000m, 100000m, new Guid("16aa0a59-39d0-4e9f-b70d-8bab5ece1334"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 500, 87 },
                    { new Guid("b6dc9962-d5fe-46b1-9c6a-5c7dc9117341"), "NEWUSER", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 20m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 100000m, 300000m, new Guid("16aa0a59-39d0-4e9f-b70d-8bab5ece1334"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 50, 5 },
                    { new Guid("e79b6ceb-87ec-4f06-b63e-71db4fef8134"), "SUMMER25", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 50000m, 200000m, new Guid("8aa78cda-8186-431e-aaaa-dc03e6668d03"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 100, 12 }
                });

            migrationBuilder.InsertData(
                table: "Courts",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedAt", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("9abde540-77ae-4bf0-a328-a6a6d4b8b750"), "123 Nguyễn Huệ, Q1, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, 10.77m, 106.70m, "https://maps.google.com/?q=10.77,106.70", "Sân A - Minh Tuấn", new TimeOnly(6, 0, 0), new Guid("8aa78cda-8186-431e-aaaa-dc03e6668d03"), "https://images.example.com/courts/go-vap.jpg", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c33a17da-ed59-4fad-b64c-d2cf0d669d55"), "456 Lê Lợi, Q3, HCM", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, 10.78m, 106.69m, "https://maps.google.com/?q=10.78,106.69", "Sân C - Hải Đăng", new TimeOnly(5, 30, 0), new Guid("16aa0a59-39d0-4e9f-b70d-8bab5ece1334"), "https://images.example.com/courts/go-vap.jpg", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f849e99b-ffc7-40df-812d-cda13afc034b"), "456 Lê Lợi, Q3, HCM", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, 10.78m, 106.69m, "https://maps.google.com/?q=10.78,106.69", "Sân D - Hải Đăng", new TimeOnly(5, 30, 0), new Guid("16aa0a59-39d0-4e9f-b70d-8bab5ece1334"), "https://images.example.com/courts/go-vap.jpg", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fdbe16c6-9e23-4da7-bbfc-15bf1de5e04a"), "123 Nguyễn Huệ, Q1, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, 10.77m, 106.70m, "https://maps.google.com/?q=10.77,106.70", "Sân B - Minh Tuấn", new TimeOnly(6, 0, 0), new Guid("8aa78cda-8186-431e-aaaa-dc03e6668d03"), "https://images.example.com/courts/go-vap.jpg", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "OwnerRequests",
                columns: new[] { "Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "CustomerId", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "OwnerId", "RejectionReason", "Status", "TaxCode", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("440ebf4f-eb62-4573-804c-8454eb073968"), "456 Lê Lợi, Q3, HCM", "https://cdn.rallyhub.vn/license/2.jpg", "Trung Tâm Thể Thao Hải Đăng", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2019b663-5d37-4c6c-9ed3-1c00477850ea"), "https://cdn.rallyhub.vn/cccd/2_back.jpg", "https://cdn.rallyhub.vn/cccd/2_front.jpg", "079200054321", false, new Guid("16aa0a59-39d0-4e9f-b70d-8bab5ece1334"), null, "Approved", "9876543210", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e25499a6-cbe6-4b5f-8666-78ea761cb38f"), "123 Nguyễn Huệ, Q1, HCM", "https://cdn.rallyhub.vn/license/1.jpg", "Sân Cầu Lông Minh Tuấn", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("593bb9fc-5ee9-4edb-80f9-eba5de78203f"), "https://cdn.rallyhub.vn/cccd/1_back.jpg", "https://cdn.rallyhub.vn/cccd/1_front.jpg", "079200012345", false, new Guid("8aa78cda-8186-431e-aaaa-dc03e6668d03"), null, "Approved", "0123456789", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("02fc39d8-ffa9-4476-b4c5-8c2ae36399bb"), new Guid("b6dc9962-d5fe-46b1-9c6a-5c7dc9117341"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2019b663-5d37-4c6c-9ed3-1c00477850ea"), 40000m, 360000m, false, "Banked", 400000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9b36f130-a2fd-48d8-a4f3-11a724e4becc"), new Guid("e79b6ceb-87ec-4f06-b63e-71db4fef8134"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("593bb9fc-5ee9-4edb-80f9-eba5de78203f"), 30000m, 270000m, false, "Banked", 300000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fa066cd1-0cdb-4ddc-9c23-b22c68645cfe"), new Guid("b6dc9962-d5fe-46b1-9c6a-5c7dc9117341"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2019b663-5d37-4c6c-9ed3-1c00477850ea"), 0m, 150000m, false, "Complete", 150000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fe26ff4c-f9b9-4153-b076-f16e9299eff4"), new Guid("b6dc9962-d5fe-46b1-9c6a-5c7dc9117341"), "Khách huỷ", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2019b663-5d37-4c6c-9ed3-1c00477850ea"), 50000m, 200000m, false, "Cancel", 250000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ffe055c7-1f22-432e-8984-93d6f2cd06fd"), new Guid("e79b6ceb-87ec-4f06-b63e-71db4fef8134"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("593bb9fc-5ee9-4edb-80f9-eba5de78203f"), 20000m, 180000m, false, "Complete", 200000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "CampaignCourts",
                columns: new[] { "Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11e6bf97-464c-4cd0-85e4-e15d340b315e"), new Guid("e79b6ceb-87ec-4f06-b63e-71db4fef8134"), new Guid("c33a17da-ed59-4fad-b64c-d2cf0d669d55"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("60d00289-a73c-43fc-b30a-732dd384cd69"), new Guid("e79b6ceb-87ec-4f06-b63e-71db4fef8134"), new Guid("f849e99b-ffc7-40df-812d-cda13afc034b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ad91d0f2-b407-4664-8859-70b31be8c15b"), new Guid("b6dc9962-d5fe-46b1-9c6a-5c7dc9117341"), new Guid("9abde540-77ae-4bf0-a328-a6a6d4b8b750"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c93ea608-925c-45b7-a176-62dff7e22e9b"), new Guid("b6dc9962-d5fe-46b1-9c6a-5c7dc9117341"), new Guid("fdbe16c6-9e23-4da7-bbfc-15bf1de5e04a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "LikeListDetails",
                columns: new[] { "Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("54ef6cf3-6090-4ac8-8d27-d285f6b81e17"), new Guid("9abde540-77ae-4bf0-a328-a6a6d4b8b750"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("593bb9fc-5ee9-4edb-80f9-eba5de78203f"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("67dbe6f4-92b4-4dfd-b419-82fff69bcec4"), new Guid("fdbe16c6-9e23-4da7-bbfc-15bf1de5e04a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("593bb9fc-5ee9-4edb-80f9-eba5de78203f"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9c58c8a9-c869-42f5-98dd-5ccd7b11102d"), new Guid("9abde540-77ae-4bf0-a328-a6a6d4b8b750"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2019b663-5d37-4c6c-9ed3-1c00477850ea"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a7beef89-0293-4950-bed0-f65613800dff"), new Guid("c33a17da-ed59-4fad-b64c-d2cf0d669d55"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2019b663-5d37-4c6c-9ed3-1c00477850ea"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ef400467-28c0-4de2-9d9c-34b61df7a550"), new Guid("f849e99b-ffc7-40df-812d-cda13afc034b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2019b663-5d37-4c6c-9ed3-1c00477850ea"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "SubCourts",
                columns: new[] { "Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("059c9a6c-894d-4ff5-bd70-ec44968c7826"), new Guid("f849e99b-ffc7-40df-812d-cda13afc034b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ D2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("0e660f29-dce9-41bd-a146-df93ac448d3f"), new Guid("fdbe16c6-9e23-4da7-bbfc-15bf1de5e04a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ B2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("27f0acb0-d4d7-4001-b986-dea2a38ff8de"), new Guid("c33a17da-ed59-4fad-b64c-d2cf0d669d55"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ C2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2f5bfdf9-c571-4889-8b12-469b22b11d57"), new Guid("9abde540-77ae-4bf0-a328-a6a6d4b8b750"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ A1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("71e027ae-6640-42c6-8f08-cb1876cf56f0"), new Guid("c33a17da-ed59-4fad-b64c-d2cf0d669d55"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ C1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("74ef5057-2ba8-420f-aa61-8664c4f01117"), new Guid("f849e99b-ffc7-40df-812d-cda13afc034b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ D1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7af7d729-b258-4eaa-b883-1839ee46c255"), new Guid("fdbe16c6-9e23-4da7-bbfc-15bf1de5e04a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ B1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9c26b298-fa03-496a-9369-35b762a387a6"), new Guid("9abde540-77ae-4bf0-a328-a6a6d4b8b750"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ A2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "BookingDetails",
                columns: new[] { "Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("29f12e5a-246d-4e2d-bde9-44a2bf284306"), new Guid("fa066cd1-0cdb-4ddc-9c23-b22c68645cfe"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 25, 2, 32, 42, 57, DateTimeKind.Unspecified).AddTicks(3148), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 150000m, new TimeOnly(7, 0, 0), new Guid("71e027ae-6640-42c6-8f08-cb1876cf56f0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5165a283-6157-4ec2-b5e2-61eb6084eecd"), new Guid("02fc39d8-ffa9-4476-b4c5-8c2ae36399bb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 29, 2, 32, 42, 57, DateTimeKind.Unspecified).AddTicks(3156), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 150000m, new TimeOnly(9, 0, 0), new Guid("9c26b298-fa03-496a-9369-35b762a387a6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cb78c72c-92d3-4661-9d0e-0b323db1867d"), new Guid("9b36f130-a2fd-48d8-a4f3-11a724e4becc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 23, 2, 32, 42, 57, DateTimeKind.Unspecified).AddTicks(3143), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 100000m, new TimeOnly(6, 0, 0), new Guid("7af7d729-b258-4eaa-b883-1839ee46c255"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e62c2e55-fc3e-479f-9fdf-db75cef973c7"), new Guid("ffe055c7-1f22-432e-8984-93d6f2cd06fd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 23, 2, 32, 42, 57, DateTimeKind.Unspecified).AddTicks(3082), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 100000m, new TimeOnly(8, 0, 0), new Guid("2f5bfdf9-c571-4889-8b12-469b22b11d57"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fd18202d-f55f-4878-884f-ab0e86aab669"), new Guid("fe26ff4c-f9b9-4153-b076-f16e9299eff4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 25, 2, 32, 42, 57, DateTimeKind.Unspecified).AddTicks(3152), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 150000m, new TimeOnly(6, 0, 0), new Guid("74ef5057-2ba8-420f-aa61-8664c4f01117"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ConfigSlots",
                columns: new[] { "Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0caf2978-155a-457d-9303-3bf115ff98bd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 70000m, new TimeOnly(7, 0, 0), new Guid("7af7d729-b258-4eaa-b883-1839ee46c255"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2994152b-8c98-4457-992e-0e033967945c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 100000m, new TimeOnly(6, 30, 0), new Guid("74ef5057-2ba8-420f-aa61-8664c4f01117"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2e580617-d8f2-451e-9400-7ad3b6bd7554"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 100000m, new TimeOnly(6, 0, 0), new Guid("74ef5057-2ba8-420f-aa61-8664c4f01117"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2ec30f02-fc05-441b-81e9-c708bcc01969"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 50000m, new TimeOnly(9, 0, 0), new Guid("2f5bfdf9-c571-4889-8b12-469b22b11d57"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("39a58272-f26d-4a59-9374-c9a98ff2849b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 100000m, new TimeOnly(9, 30, 0), new Guid("74ef5057-2ba8-420f-aa61-8664c4f01117"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4096c517-9d76-49f4-b242-20b843b9350d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 50000m, new TimeOnly(8, 30, 0), new Guid("2f5bfdf9-c571-4889-8b12-469b22b11d57"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("41c73983-341b-4f15-84c7-8dfb77b68d81"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 35000m, new TimeOnly(8, 0, 0), new Guid("71e027ae-6640-42c6-8f08-cb1876cf56f0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("44a9a89f-01c7-4844-824f-c978d77230e0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 35000m, new TimeOnly(6, 0, 0), new Guid("71e027ae-6640-42c6-8f08-cb1876cf56f0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("49f11e18-28e3-4101-94ea-124a82a1b370"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 70000m, new TimeOnly(8, 0, 0), new Guid("7af7d729-b258-4eaa-b883-1839ee46c255"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4f3765b3-55b0-47f0-a824-6ae868e216f7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 35000m, new TimeOnly(9, 0, 0), new Guid("71e027ae-6640-42c6-8f08-cb1876cf56f0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("53dd2155-1e94-45bc-ab95-585408158bc6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 70000m, new TimeOnly(9, 30, 0), new Guid("7af7d729-b258-4eaa-b883-1839ee46c255"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("54109344-c661-482d-90d1-7f03e80d1a08"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 70000m, new TimeOnly(8, 30, 0), new Guid("7af7d729-b258-4eaa-b883-1839ee46c255"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("57fd6c6c-c527-4b02-9164-b9ae32e513cd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 50000m, new TimeOnly(6, 0, 0), new Guid("2f5bfdf9-c571-4889-8b12-469b22b11d57"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5d04e1dc-5c76-4bd9-8620-65cebac30b12"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 50000m, new TimeOnly(7, 0, 0), new Guid("2f5bfdf9-c571-4889-8b12-469b22b11d57"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5ed2cce2-42da-4a46-b18b-99482b7a15ca"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 100000m, new TimeOnly(7, 30, 0), new Guid("74ef5057-2ba8-420f-aa61-8664c4f01117"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6ea18f7a-44fa-4b7c-84b1-637907a92e54"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 35000m, new TimeOnly(7, 0, 0), new Guid("71e027ae-6640-42c6-8f08-cb1876cf56f0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("71749fce-2688-45c8-83ed-419328394e45"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 35000m, new TimeOnly(6, 30, 0), new Guid("71e027ae-6640-42c6-8f08-cb1876cf56f0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("753148e6-ebab-49aa-993d-78aa36d9bf9b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 50000m, new TimeOnly(6, 30, 0), new Guid("2f5bfdf9-c571-4889-8b12-469b22b11d57"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7b03eaa5-8e32-411e-9d1a-98f402b2d6d5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 70000m, new TimeOnly(6, 30, 0), new Guid("7af7d729-b258-4eaa-b883-1839ee46c255"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7ec75482-c1d9-4f6e-87f4-bdfe88b50616"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 70000m, new TimeOnly(6, 0, 0), new Guid("7af7d729-b258-4eaa-b883-1839ee46c255"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8589a2cf-f008-4867-b3b4-f95c136f2528"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 70000m, new TimeOnly(7, 30, 0), new Guid("7af7d729-b258-4eaa-b883-1839ee46c255"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("88d00cf6-01eb-4d49-b8e1-7f4b107f64dd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 100000m, new TimeOnly(7, 0, 0), new Guid("74ef5057-2ba8-420f-aa61-8664c4f01117"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8c794115-77c9-47c3-a5af-4cd098bb10f7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 70000m, new TimeOnly(9, 0, 0), new Guid("7af7d729-b258-4eaa-b883-1839ee46c255"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8f217125-e62a-434d-bba1-8d3180ca4434"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 50000m, new TimeOnly(9, 30, 0), new Guid("2f5bfdf9-c571-4889-8b12-469b22b11d57"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("941e0d1b-0e2b-4e9c-b40b-7ca5173cfe71"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 35000m, new TimeOnly(8, 30, 0), new Guid("71e027ae-6640-42c6-8f08-cb1876cf56f0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b2c3b50d-e4c6-4d8c-9271-5c3a725c14d8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 100000m, new TimeOnly(8, 30, 0), new Guid("74ef5057-2ba8-420f-aa61-8664c4f01117"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c0d0dd2f-bbee-4cc4-9c4a-7be63ed1272b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 35000m, new TimeOnly(7, 30, 0), new Guid("71e027ae-6640-42c6-8f08-cb1876cf56f0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d82b1ebd-397e-4c6f-9257-349a4af4e436"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 50000m, new TimeOnly(8, 0, 0), new Guid("2f5bfdf9-c571-4889-8b12-469b22b11d57"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e5adf1a6-c930-4976-9c79-291260237ab1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 100000m, new TimeOnly(9, 0, 0), new Guid("74ef5057-2ba8-420f-aa61-8664c4f01117"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e63694f9-3082-49d9-8512-e37567276989"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 50000m, new TimeOnly(7, 30, 0), new Guid("2f5bfdf9-c571-4889-8b12-469b22b11d57"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ebf9b4aa-a020-4a0e-af92-799653be1f32"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 100000m, new TimeOnly(8, 0, 0), new Guid("74ef5057-2ba8-420f-aa61-8664c4f01117"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ff19c793-0ead-4597-89f9-42ad0af05328"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 35000m, new TimeOnly(9, 30, 0), new Guid("71e027ae-6640-42c6-8f08-cb1876cf56f0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Exceptions",
                columns: new[] { "Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3a857115-955c-48bc-8669-4de782fea31b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Tổ chức sự kiện nội bộ", new TimeOnly(12, 0, 0), new Guid("74ef5057-2ba8-420f-aa61-8664c4f01117"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9912566d-0aae-44e3-9dfd-d7a7c53896a5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Bảo trì định kỳ", new TimeOnly(12, 0, 0), new Guid("2f5bfdf9-c571-4889-8b12-469b22b11d57"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ca54fbdd-7e3b-4fe2-bd99-30abcb18cdb2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Hỏng đèn chiếu sáng", new TimeOnly(12, 0, 0), new Guid("71e027ae-6640-42c6-8f08-cb1876cf56f0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d618c9de-4342-4b04-b561-7ebef97f5b33"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Sơn lại mặt sân", new TimeOnly(12, 0, 0), new Guid("7af7d729-b258-4eaa-b883-1839ee46c255"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("08a2c7ab-e377-4adf-a1a1-89a6dc7b8a0f"), new Guid("02fc39d8-ffa9-4476-b4c5-8c2ae36399bb"), "Đèn chiếu sáng yếu vào ban đêm.", new Guid("9abde540-77ae-4bf0-a328-a6a6d4b8b750"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2019b663-5d37-4c6c-9ed3-1c00477850ea"), false, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("51ec04ca-3dc6-4aaa-89aa-8b82d499d18b"), new Guid("fe26ff4c-f9b9-4153-b076-f16e9299eff4"), "Nhân viên thân thiện, sân sạch.", new Guid("fdbe16c6-9e23-4da7-bbfc-15bf1de5e04a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("593bb9fc-5ee9-4edb-80f9-eba5de78203f"), false, 5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8e661fbd-1891-4811-8350-f3506491716e"), new Guid("fa066cd1-0cdb-4ddc-9c23-b22c68645cfe"), "Bình thường, sân hơi cũ.", new Guid("c33a17da-ed59-4fad-b64c-d2cf0d669d55"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("593bb9fc-5ee9-4edb-80f9-eba5de78203f"), false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c318eeb0-b342-4355-aa5d-f7071bd9cdb4"), new Guid("ffe055c7-1f22-432e-8984-93d6f2cd06fd"), "Sân rất tốt, sẽ quay lại!", new Guid("9abde540-77ae-4bf0-a328-a6a6d4b8b750"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2019b663-5d37-4c6c-9ed3-1c00477850ea"), false, 5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ff01459a-1a9d-4a0c-ac65-0c7ff79444fa"), new Guid("9b36f130-a2fd-48d8-a4f3-11a724e4becc"), "Dịch vụ ổn, giá hợp lý.", new Guid("fdbe16c6-9e23-4da7-bbfc-15bf1de5e04a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2019b663-5d37-4c6c-9ed3-1c00477850ea"), false, 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("1002c3eb-b805-4f7e-b6ac-4e331f0e409a"), new Guid("fe26ff4c-f9b9-4153-b076-f16e9299eff4"), "Booking #4 đã bị huỷ. Tiền sẽ hoàn.", new Guid("f849e99b-ffc7-40df-812d-cda13afc034b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Huỷ booking", "Cancel", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8116b849-43c6-46cd-91cb-cd19d5e011b0") });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("1b63eac4-5ad2-49a3-b30e-c99295de4652"), new Guid("9b36f130-a2fd-48d8-a4f3-11a724e4becc"), "Booking #2 đã được xác nhận.", new Guid("fdbe16c6-9e23-4da7-bbfc-15bf1de5e04a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Đặt sân thành công", "Booking", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d366d816-58b8-4bdc-a811-c179653a5058") },
                    { new Guid("63d629e1-a714-4c05-b803-60b04c962ae8"), new Guid("02fc39d8-ffa9-4476-b4c5-8c2ae36399bb"), "Đã hoàn 360,000đ vào ví của bạn.", new Guid("9abde540-77ae-4bf0-a328-a6a6d4b8b750"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Hoàn tiền", "Refund", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a1dc565f-f059-46e4-8c98-1fda4fb4056b") }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("c2020b7b-616e-438b-b7d1-7ff9ed49947b"), new Guid("ffe055c7-1f22-432e-8984-93d6f2cd06fd"), "Booking #1 đã được xác nhận.", new Guid("9abde540-77ae-4bf0-a328-a6a6d4b8b750"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Đặt sân thành công", "Booking", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a1dc565f-f059-46e4-8c98-1fda4fb4056b") });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("feaa4fef-42cc-420c-af41-692dece7fea2"), new Guid("fa066cd1-0cdb-4ddc-9c23-b22c68645cfe"), "Bạn có lịch chơi vào ngày mai.", new Guid("c33a17da-ed59-4fad-b64c-d2cf0d669d55"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Nhắc nhở lịch chơi", "Remind", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d6787d36-1da7-49ff-88a9-22d5f611f857") });

            migrationBuilder.InsertData(
                table: "OverideSlots",
                columns: new[] { "Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "IsRecurring", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[] { new Guid("0e7378c9-8373-4c3e-be47-600e2540693a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(1, 1, 1), 1, new TimeOnly(20, 0, 0), false, true, 200000m, new TimeOnly(18, 0, 0), new Guid("9c26b298-fa03-496a-9369-35b762a387a6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "OverideSlots",
                columns: new[] { "Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("412bc2c4-72ff-469a-8bb6-d0b874e76b74"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 220800m, new TimeOnly(12, 0, 0), new Guid("74ef5057-2ba8-420f-aa61-8664c4f01117"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("68dff6be-76f9-4b85-a465-28f5a3c86b63"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 2054000m, new TimeOnly(12, 0, 0), new Guid("71e027ae-6640-42c6-8f08-cb1876cf56f0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8fbcc466-b0ae-40d4-932d-4db01a9dbd15"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 220500m, new TimeOnly(12, 0, 0), new Guid("7af7d729-b258-4eaa-b883-1839ee46c255"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c97a037f-9a69-49da-94d7-1bf07a3328c1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 208400m, new TimeOnly(12, 0, 0), new Guid("2f5bfdf9-c571-4889-8b12-469b22b11d57"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3047c975-7e88-422d-86f7-1fc7fc4f7160"), new Guid("fe26ff4c-f9b9-4153-b076-f16e9299eff4"), new Guid("c33a17da-ed59-4fad-b64c-d2cf0d669d55"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2019b663-5d37-4c6c-9ed3-1c00477850ea"), false, "Không hoàn tiền khi huỷ đúng hạn.", "Rejected", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("51ebae51-8a83-4aad-843f-d88dbb64a9e8"), new Guid("fa066cd1-0cdb-4ddc-9c23-b22c68645cfe"), new Guid("fdbe16c6-9e23-4da7-bbfc-15bf1de5e04a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2019b663-5d37-4c6c-9ed3-1c00477850ea"), false, "Cơ sở vật chất xuống cấp.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8e8f2aec-5ba7-4dd4-b8ce-944aa9cd6487"), new Guid("9b36f130-a2fd-48d8-a4f3-11a724e4becc"), new Guid("9abde540-77ae-4bf0-a328-a6a6d4b8b750"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("593bb9fc-5ee9-4edb-80f9-eba5de78203f"), false, "Chủ sân thái độ không tốt.", "Resolved", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c22e3ed7-0be6-4cda-b5fa-68a10e1bda49"), new Guid("ffe055c7-1f22-432e-8984-93d6f2cd06fd"), new Guid("c33a17da-ed59-4fad-b64c-d2cf0d669d55"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("593bb9fc-5ee9-4edb-80f9-eba5de78203f"), false, "Sân không đúng mô tả.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cce592f8-1fab-4164-93bc-27a75fc56736"), new Guid("02fc39d8-ffa9-4476-b4c5-8c2ae36399bb"), new Guid("f849e99b-ffc7-40df-812d-cda13afc034b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2019b663-5d37-4c6c-9ed3-1c00477850ea"), false, "Thông tin giờ mở cửa sai.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId" },
                values: new object[,]
                {
                    { new Guid("06be7fe3-c41a-4a18-9a21-16ae58813d74"), "ACT003", 200000m, 2200000m, 2000000m, "4567890123", "REF003", new Guid("fa066cd1-0cdb-4ddc-9c23-b22c68645cfe"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP003", "SIG003", "Success", "Hoàn tiền booking #4", "Refund", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2b54fc20-ca34-4bd7-88cf-a5c966d35aa2") },
                    { new Guid("106252f7-dbfa-4ee6-8280-b0382a91fc2d"), "ACT001", 180000m, 2000000m, 2180000m, "2345678901", "REF001", new Guid("ffe055c7-1f22-432e-8984-93d6f2cd06fd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP001", "SIG001", "Success", "Thanh toán booking #1", "Payment", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("1c74707f-750e-49a9-bf51-1330daeda7c1") },
                    { new Guid("892fad2c-51cb-435f-9a30-69e898422510"), "ACT002", 270000m, 3500000m, 3770000m, "3456789012", "REF002", new Guid("9b36f130-a2fd-48d8-a4f3-11a724e4becc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP002", "SIG002", "Success", "Thanh toán booking #2", "Payment", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ddb961c7-bb36-400d-a937-256565d9feeb") },
                    { new Guid("dffd45fa-eba1-443a-ada5-f18b76056c5a"), "ACT004", 500000m, 2000000m, 1500000m, "5678901234", "REF004", new Guid("02fc39d8-ffa9-4476-b4c5-8c2ae36399bb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP004", "SIG004", "Success", "Nạp tiền vào ví", "Deposit", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3b688c7a-2db8-4afa-9fcf-0d511a31354f") }
                });
        }
    }
}
