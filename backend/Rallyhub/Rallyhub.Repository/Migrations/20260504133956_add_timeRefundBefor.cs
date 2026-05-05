using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rallyhub.Repository.Migrations
{
    /// <inheritdoc />
    public partial class add_timeRefundBefor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("33e616d9-0f39-4ffb-92b5-fb51bf4e7170"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("6149a057-f09a-476b-b7ed-87391ce8f63c"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("8563bfa4-2994-4833-b006-47b3c6637f53"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("d5e4434d-7fdd-4d28-b23f-09413764524d"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("e8725c4a-0bf2-4bd3-adbc-1138c5fce8d4"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("8d1d36cd-cb88-4a17-9589-cfd93744cba4"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("9ff29122-b3bd-4b32-ae39-4af1dcdfaa30"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("ee4d417e-209f-4d0a-bdaa-c88d12e10de0"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("fa655f17-608f-4876-a2b9-ef17af4eb26d"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("364bc348-b277-4feb-8c51-1a311da6cfb1"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("7c6c0f3b-f754-4fc3-9671-0d0b1940b3ad"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("bac22ce3-6321-485f-a2dd-fc093f6bcdba"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("bdff780f-b034-40c5-83ae-4eb42cedb78e"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("01bf8f76-2bee-43fd-8231-e08bcfd246d2"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("02391615-e0a0-4d5b-a474-ed4f0c2db13b"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("106e9de6-64b2-4d34-af9d-95f794ff1499"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("13fc0774-823d-40c0-bb54-be51245f8121"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("252e2b6c-6571-49e6-8b6a-f47512bf5ab3"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("3e489144-1c36-4f1e-8803-b081c4a73354"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("48edffc1-e5ca-4d0b-967b-8b1b85f57adb"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("4b904b86-911c-4f6f-a98f-1f14572cf38a"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("4d961fa6-b0da-4892-9e14-46ad2febfe0b"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("508e5e2d-a445-4073-aa78-80671f377590"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("54cd735b-5ba5-464c-acff-1b7af488aed3"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("59186c7a-c47c-4732-b7be-c1ec82420e54"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("61bc097d-b121-464d-bf70-bbcb3a305048"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("6fc685c1-cdef-49c1-8a4a-bf3dc18026ec"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("72b8caa0-6d7c-4a6a-9424-e36706dc7141"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("7ecad6e3-acfc-4044-ac61-0e03a9d721d9"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("7fec368e-c080-4937-97cb-d1fc1a4a7e78"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("8f6fb075-9704-4b17-8bd6-1092910fef1c"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("99503c30-2c5e-4220-8739-c1f054408d60"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("9b6f7cc0-1f28-4646-88fa-c58a53b701f0"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("a446e124-dad0-4ab4-a018-290fff428e9a"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("ab787dc4-f3c9-44bd-ae20-4611fb999c23"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("b7604d49-bc6a-4e31-b8ba-618cd645bdb1"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("b76d454e-8374-4c6f-a1fa-5c1987e782e7"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("c5044090-6380-4f26-ad90-dff703dd0fb9"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("cf6fc156-095f-49d9-87de-0e0bb58800ce"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("df0095a0-af4f-47e3-9aeb-fa82ce1d6c2f"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("e666c70c-e243-4f41-9576-2c0f9cc80f01"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("e81d6ade-a0bc-46b7-b104-d27a51bd7202"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("f442eb3f-132a-4cb8-b928-9113b9cc279a"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("f85ef378-4c91-4cfc-a86d-1afc14ebef56"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("fd4597a1-567a-426d-8335-d5c1b91fd6b3"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("9c8cca2a-0aee-48f7-ba91-f56f9c8a15a3"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("ea82ad51-e282-4781-abbd-f07d707ebd8a"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("f3fc0117-9aaf-40de-9177-e6c8b7ddff36"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("ff595c65-74a3-4f61-bb31-4fc3ea4456e6"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("0587bcce-45f1-4d8c-b8b3-50dc687b6df3"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("21dc339f-30b5-44c6-a526-83d70607c4d7"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("49ff473e-dbc5-42fd-8d5d-2eec2e6ad528"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("991a71ee-8a7b-45e7-8b9e-b27f0e4fdf06"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("9e2bee27-086a-4157-a9fc-2fd732701e68"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("09713717-11db-4174-a8de-a2167c61c477"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("09df1f85-e54b-49d3-b4fa-416be50271c6"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("631a4459-0a61-4118-8b0e-1bfc84556dce"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("b02ff8b7-3ba7-41f5-8285-526303b6ac6e"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("fae8691e-bfcf-430e-925f-abfaa28d83f1"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("1093173b-f237-4b3b-860d-812394fd2743"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("124d3d40-19d1-4d38-a587-a967cc08d1fc"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("1729d2ed-5c4b-429b-b090-6b0d5e4e9994"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("695d1de6-8de6-4f40-b934-1f5e41f97d31"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("b32d9e7e-cdf5-43de-b34f-4ffffe108c71"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("2df541a3-c6e2-4a21-b81d-a967454c9d97"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("8d37aee8-d7e4-42ae-8999-156dd7c20fd9"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("a37422f2-c9df-4f1f-b3a1-796e727de5fc"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("b6a023ee-d6a0-43ac-beba-0d2a0b796236"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("e00dd348-aaae-4eee-98e1-95fecd4dfb84"));

            migrationBuilder.DeleteData(
                table: "OwnerRequests",
                keyColumn: "Id",
                keyValue: new Guid("0f00305d-d22c-4b26-910c-a65cb633d53e"));

            migrationBuilder.DeleteData(
                table: "OwnerRequests",
                keyColumn: "Id",
                keyValue: new Guid("6ef4ba80-e8e0-4b60-8a07-19cb0ab4c5cf"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("e9c28b32-e7c6-4ee3-ac02-3cd63986304e"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("01813f39-81b1-4d9e-a71e-7bb3cca6c7da"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("0558d04a-9ffd-41db-b729-d72e75c834bf"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("0938900c-0346-46b5-aef6-48f681fa6a81"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("c1773b80-214e-45fb-9ae4-fd3549080e84"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("dc42c5b3-1575-4560-8467-fe883c228c2f"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("61d647b8-7f16-4b69-9b25-62eb19a64f43"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("f9211683-3762-4f73-b68e-56f00b3bba9b"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("fba5ffb1-8ecd-46a3-8dc7-e886be4bad60"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("03216916-475c-42fb-ae89-80d2b44a0271"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("1970d018-b2a2-40af-9a8b-c87b3c86a1e0"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("210011a1-b5b8-48ae-a70c-af8a98f842e9"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("3fbf07a0-5750-460d-8bcb-a698960ea938"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("e2d385b7-44f2-4299-8dfb-7b977fbb2478"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("3e6c96df-fcc3-4122-a567-d0c8997e39d8"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("8124be6e-1486-4cdf-aee6-44767681e705"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("93667a65-6c04-49f8-8094-48e5eca83a8b"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("a22067bf-7a53-463f-a79d-31b9f4b8daae"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dbb7e7c6-48f6-436f-85c1-3d717993dc84"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("2242fa57-fe64-4a6c-a47e-47b6f3a66cb4"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("4f8f8f54-95f6-475a-bad8-ff63ad41a00a"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("667e0b35-596f-479b-ac04-d34c0e148fdf"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("dae74d67-12b2-48a6-90d3-df45750d4cfa"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("eb6c470a-9dcc-49f1-9886-4cb7c5e46812"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("6312166e-ec9b-4d3b-8df4-9574e31ea3f4"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("872e14be-cd75-4c66-86ee-287a4d1fd753"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("af33e72b-5296-4f0d-8236-d1aa32edc3c8"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("c4a042af-5043-4051-aaa4-9425f433ab84"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("db5c0f95-d3cc-4c50-a97e-2c0bee97ff8b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("987a52b4-d30f-449b-b3ba-59ec46fe2285"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("24422d5c-84e1-481d-bd81-c8a063b9ea8f"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("3210eba9-e1d4-4b45-8c0f-68f5e1b48a79"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("626d6c0a-03a4-4898-86bc-f1c7f4754719"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("a3c36211-b01f-45d0-9130-5f2b5c7b71ea"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("aa60ded0-48d2-49a4-9a66-633168fe9a2e"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("bdf129ce-a6ac-4dc0-bd7c-2c6c8a1373af"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("09a8c275-0daa-4552-bbed-024a43a71b0c"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("10d9dca7-7f55-4f6a-93f6-5df2004b0986"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("497002c0-ce8a-4222-bb08-8cb01cabbe20"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("dc4008ea-990a-4786-9aa0-7894a589dcbc"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("95ca3b83-c4db-4b26-aaf2-6104a3b9b2a6"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("f9cc43a9-6224-49e6-936a-f78230695756"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("c69db783-1aa3-4933-8dad-025af6d83e5e"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("c9bb48ca-e685-4acb-9837-92beff7be0b0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2cceeefc-9d4a-4256-b905-a0fcdcebd8be"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a14f80f-cfa2-49de-b1fc-c17dcd26d2f5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("77d83e3f-97f6-4c85-97ac-1c9b55acfe53"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fdce1303-a7a8-4ec6-a4af-653e2aef60c8"));

            migrationBuilder.AddColumn<int>(
                name: "TimeRefundBefor",
                table: "Courts",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2bb283c8-62f0-4ef6-b234-5c591f2cfefa"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "admin@rallyhub.vn", "Quản", false, "Trị", "hashed_pw_1", "0900000001", "Admin", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("31c90ac4-e959-44bb-b66c-6934f53c8c09"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer1@gmail.com", "Lan", false, "Phương", "hashed_pw_4", "0900000004", "Customer", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3d9fb550-50c1-4a7d-b1d5-ec4024e50322"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer2@gmail.com", "Bảo", false, "Châu", "hashed_pw_5", "0900000005", "Customer", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9d524944-347a-493c-b1ef-860a06ac6f74"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner3@rallyhub.vn", "Trần", false, "Phú", "hashed_pw_6", "0900000006", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e0a6e1b4-2499-4635-87f5-cbabcd4e30ca"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner1@rallyhub.vn", "Minh", false, "Tuấn", "hashed_pw_2", "0900000002", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f81e0e61-050a-4632-8da6-be56ada0cbd7"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner2@rallyhub.vn", "Hải", false, "Đăng", "hashed_pw_3", "0900000003", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("3c408123-27a3-4125-8b06-d865428866d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("31c90ac4-e959-44bb-b66c-6934f53c8c09") },
                    { new Guid("b941002b-ab0a-415d-8fd0-b8358021727b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3d9fb550-50c1-4a7d-b1d5-ec4024e50322") }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("32e68440-cb37-40b8-9b85-97e104944a30"), "123 Nguyễn Huệ, Q1, HCM", null, "Sân Cầu Lông Minh Tuấn", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, false, "0123456789", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("e0a6e1b4-2499-4635-87f5-cbabcd4e30ca") },
                    { new Guid("3f7b0ab7-5c70-4454-9703-8639999d0955"), "456 Lê Lợi, Q3, HCM", null, "Trung Tâm Thể Thao Hải Đăng", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, false, "9876543210", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f81e0e61-050a-4632-8da6-be56ada0cbd7") },
                    { new Guid("44883b2d-df6e-4812-a5cb-c031f5eb0f90"), "Tôn Đức Thắng, HCM", null, "Sân Cầu Lông Trần Phú", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, false, "98765434219", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("9d524944-347a-493c-b1ef-860a06ac6f74") }
                });

            migrationBuilder.InsertData(
                table: "SystemReports",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("0c68d871-480a-4081-8e78-f63495d1a47e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "OTP không gửi đến số điện thoại.", "Pending", "Không nhận được OTP", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("31c90ac4-e959-44bb-b66c-6934f53c8c09") },
                    { new Guid("1ce0d875-d797-4836-a46b-01f086a91e49"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Bản đồ không load được trên iOS.", "Resolved", "Lỗi hiển thị bản đồ", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f81e0e61-050a-4632-8da6-be56ada0cbd7") },
                    { new Guid("57914e20-e634-4f05-ad04-c84e6e222371"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Số dư hiển thị không khớp lịch sử.", "Resolved", "Sai số dư sau giao dịch", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3d9fb550-50c1-4a7d-b1d5-ec4024e50322") },
                    { new Guid("a63cd5dc-30b6-458a-b552-30d538359600"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Crash khi mở trang tìm kiếm sân.", "Pending", "App bị crash", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("31c90ac4-e959-44bb-b66c-6934f53c8c09") },
                    { new Guid("e68645f8-2f62-476f-91b1-a17086c61bbd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Không thể thanh toán qua ví.", "Pending", "Lỗi thanh toán", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("e0a6e1b4-2499-4635-87f5-cbabcd4e30ca") }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version" },
                values: new object[,]
                {
                    { new Guid("29f955da-918e-4d9c-afc5-d6a908bc93e0"), 3500000m, "5678901234", "VPBank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3d9fb550-50c1-4a7d-b1d5-ec4024e50322"), 0 },
                    { new Guid("44dd7d5c-592d-467d-ba9d-6b39da552553"), 12000000m, "2345678901", "Techcombank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("e0a6e1b4-2499-4635-87f5-cbabcd4e30ca"), 0 },
                    { new Guid("5ddfce9f-addf-42fc-b357-b15fb4233a7e"), 8500000m, "3456789012", "BIDV", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f81e0e61-050a-4632-8da6-be56ada0cbd7"), 0 },
                    { new Guid("9862a71a-28e6-4eca-b30a-ea9ca3960909"), 2000000m, "4567890123", "MB Bank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("31c90ac4-e959-44bb-b66c-6934f53c8c09"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount" },
                values: new object[,]
                {
                    { new Guid("17c31e98-3298-4bab-867b-f9930a863d1f"), "YEUTH", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 30000m, 100000m, new Guid("32e68440-cb37-40b8-9b85-97e104944a30"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 500, 87 },
                    { new Guid("28489800-dddf-4ae8-8318-3c5351cf834c"), "WEEKEND10", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 15m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 75000m, 250000m, new Guid("3f7b0ab7-5c70-4454-9703-8639999d0955"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 200, 30 },
                    { new Guid("487e866e-65b6-4f3d-b4c2-99b37d98d70a"), "NEWUSER", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 20m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 100000m, 300000m, new Guid("3f7b0ab7-5c70-4454-9703-8639999d0955"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 50, 5 },
                    { new Guid("61a21e80-5c42-4865-b40c-c118e22a2804"), "SUMMER25", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 50000m, 200000m, new Guid("32e68440-cb37-40b8-9b85-97e104944a30"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 100, 12 },
                    { new Guid("ac569fc5-e28f-4d7f-895b-a3a9e82fa12e"), "FLASH50", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 50m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 200000m, 500000m, new Guid("32e68440-cb37-40b8-9b85-97e104944a30"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10, 10 },
                    { new Guid("e3924f0e-9ae7-47a7-8e68-26d7cda56b11"), "LOYAL5", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 30000m, 100000m, new Guid("3f7b0ab7-5c70-4454-9703-8639999d0955"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 500, 87 }
                });

            migrationBuilder.InsertData(
                table: "Courts",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "TimeRefundBefor", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("14c77d05-8967-42a1-89bc-3538a57080e9"), "456 Lê Lợi, Q3, HCM", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.78m, 106.69m, "https://maps.google.com/?q=10.78,106.69", "Sân D - Hải Đăng", new TimeOnly(5, 30, 0), new Guid("3f7b0ab7-5c70-4454-9703-8639999d0955"), "https://images.example.com/courts/go-vap.jpg", "Active", 120, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("63ed6ba1-09a7-4839-a65b-71bbcc567d1e"), "456 Lê Lợi, Q3, HCM", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.78m, 106.69m, "https://maps.google.com/?q=10.78,106.69", "Sân C - Hải Đăng", new TimeOnly(5, 30, 0), new Guid("3f7b0ab7-5c70-4454-9703-8639999d0955"), "https://images.example.com/courts/go-vap.jpg", "Active", 120, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6a300784-2ae4-4eef-8567-0b561794c391"), "123 Nguyễn Huệ, Q1, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.77m, 106.70m, "https://maps.google.com/?q=10.77,106.70", "Sân A - Minh Tuấn", new TimeOnly(6, 0, 0), new Guid("32e68440-cb37-40b8-9b85-97e104944a30"), "https://images.example.com/courts/go-vap.jpg", "Active", 120, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8f448715-0e39-4153-8225-04f711f97f70"), "123 Nguyễn Huệ, Q1, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.77m, 106.70m, "https://maps.google.com/?q=10.77,106.70", "Sân B - Minh Tuấn", new TimeOnly(6, 0, 0), new Guid("32e68440-cb37-40b8-9b85-97e104944a30"), "https://images.example.com/courts/go-vap.jpg", "Active", 120, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "OwnerRequests",
                columns: new[] { "Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "CustomerId", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "OwnerId", "RejectionReason", "Status", "TaxCode", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("53933f15-4d1c-4f17-a1fc-cb6d425058c8"), "123 Nguyễn Huệ, Q1, HCM", "https://cdn.rallyhub.vn/license/1.jpg", "Sân Cầu Lông Minh Tuấn", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3c408123-27a3-4125-8b06-d865428866d9"), "https://cdn.rallyhub.vn/cccd/1_back.jpg", "https://cdn.rallyhub.vn/cccd/1_front.jpg", "079200012345", false, new Guid("32e68440-cb37-40b8-9b85-97e104944a30"), null, "Approved", "0123456789", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("da8784a2-b063-4b9a-9e9f-2e132dc2cb72"), "456 Lê Lợi, Q3, HCM", "https://cdn.rallyhub.vn/license/2.jpg", "Trung Tâm Thể Thao Hải Đăng", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b941002b-ab0a-415d-8fd0-b8358021727b"), "https://cdn.rallyhub.vn/cccd/2_back.jpg", "https://cdn.rallyhub.vn/cccd/2_front.jpg", "079200054321", false, new Guid("3f7b0ab7-5c70-4454-9703-8639999d0955"), null, "Approved", "9876543210", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0433041c-f32b-4f4d-81f2-292c8534802b"), new Guid("61a21e80-5c42-4865-b40c-c118e22a2804"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3c408123-27a3-4125-8b06-d865428866d9"), 20000m, 180000m, false, "Complete", 200000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("1112cfd3-54cd-4f57-b48f-f604b27f61fc"), new Guid("61a21e80-5c42-4865-b40c-c118e22a2804"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3c408123-27a3-4125-8b06-d865428866d9"), 30000m, 270000m, false, "Banked", 300000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("1fe5bd5f-e0dc-47b4-a9f4-862d78e81f66"), new Guid("487e866e-65b6-4f3d-b4c2-99b37d98d70a"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b941002b-ab0a-415d-8fd0-b8358021727b"), 0m, 150000m, false, "Complete", 150000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8e8490d1-b5ab-4f76-85e5-24ba723ca3f2"), new Guid("487e866e-65b6-4f3d-b4c2-99b37d98d70a"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b941002b-ab0a-415d-8fd0-b8358021727b"), 40000m, 360000m, false, "Banked", 400000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f6a96789-f194-4d4b-b60d-089ad93253ec"), new Guid("487e866e-65b6-4f3d-b4c2-99b37d98d70a"), "Khách huỷ", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b941002b-ab0a-415d-8fd0-b8358021727b"), 50000m, 200000m, false, "Cancel", 250000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "CampaignCourts",
                columns: new[] { "Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("13cfbcb5-111c-4f68-8f36-a69837010780"), new Guid("487e866e-65b6-4f3d-b4c2-99b37d98d70a"), new Guid("8f448715-0e39-4153-8225-04f711f97f70"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("18bf6b96-88bc-414d-ba31-0c39f54bb06f"), new Guid("487e866e-65b6-4f3d-b4c2-99b37d98d70a"), new Guid("6a300784-2ae4-4eef-8567-0b561794c391"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b7444c29-b476-4a4a-9a61-c0245a744721"), new Guid("61a21e80-5c42-4865-b40c-c118e22a2804"), new Guid("14c77d05-8967-42a1-89bc-3538a57080e9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b98270bd-07a7-4606-82e1-4e097838246c"), new Guid("61a21e80-5c42-4865-b40c-c118e22a2804"), new Guid("63ed6ba1-09a7-4839-a65b-71bbcc567d1e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "LikeListDetails",
                columns: new[] { "Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1b195077-2a75-4f5e-8434-a6de678c46d9"), new Guid("8f448715-0e39-4153-8225-04f711f97f70"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3c408123-27a3-4125-8b06-d865428866d9"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8b551d68-fba0-4331-882e-e7ee5963da8f"), new Guid("6a300784-2ae4-4eef-8567-0b561794c391"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b941002b-ab0a-415d-8fd0-b8358021727b"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9b0616e0-2426-4798-aa03-e976fece0d9d"), new Guid("63ed6ba1-09a7-4839-a65b-71bbcc567d1e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b941002b-ab0a-415d-8fd0-b8358021727b"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e6831776-f96e-492c-a362-213ba0e4d6e8"), new Guid("14c77d05-8967-42a1-89bc-3538a57080e9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b941002b-ab0a-415d-8fd0-b8358021727b"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f4c0933c-d9fb-462c-8b0a-60551dff44f5"), new Guid("6a300784-2ae4-4eef-8567-0b561794c391"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3c408123-27a3-4125-8b06-d865428866d9"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "SubCourts",
                columns: new[] { "Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0070a941-f9af-4ca7-951c-4ddc75cfb885"), new Guid("14c77d05-8967-42a1-89bc-3538a57080e9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ D1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("356ba079-e1bf-4e68-a547-0ba5b6fdb529"), new Guid("6a300784-2ae4-4eef-8567-0b561794c391"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ A1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("41007d27-2c6d-43e7-acd7-38d699c4a3ba"), new Guid("63ed6ba1-09a7-4839-a65b-71bbcc567d1e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ C2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5c6eaaa4-8b6b-4dc1-88e5-ea013e3631b1"), new Guid("6a300784-2ae4-4eef-8567-0b561794c391"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ A2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e0461c71-5db2-4ed8-bb64-48436be2223a"), new Guid("14c77d05-8967-42a1-89bc-3538a57080e9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ D2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e50a8300-d348-4b41-9b9c-323d081fd194"), new Guid("8f448715-0e39-4153-8225-04f711f97f70"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ B2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f44bf1cd-73a0-4e1e-947e-dac3543d006a"), new Guid("8f448715-0e39-4153-8225-04f711f97f70"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ B1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fd584379-6ba6-4923-bf9f-094945ae8a04"), new Guid("63ed6ba1-09a7-4839-a65b-71bbcc567d1e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ C1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "BookingDetails",
                columns: new[] { "Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "Status", "SubCourtId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("26c24bec-ca0a-470c-8d15-1117acbb9227"), new Guid("f6a96789-f194-4d4b-b60d-089ad93253ec"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 1, 20, 39, 54, 964, DateTimeKind.Unspecified).AddTicks(1898), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 150000m, new TimeOnly(6, 0, 0), "Cancel", new Guid("0070a941-f9af-4ca7-951c-4ddc75cfb885"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3308c415-08db-4a9d-9683-6800d3767efa"), new Guid("1112cfd3-54cd-4f57-b48f-f604b27f61fc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 29, 20, 39, 54, 964, DateTimeKind.Unspecified).AddTicks(1891), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 100000m, new TimeOnly(6, 0, 0), "Banked", new Guid("f44bf1cd-73a0-4e1e-947e-dac3543d006a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c62b01d0-dbf9-4fbd-8053-282d6e0a87ff"), new Guid("1fe5bd5f-e0dc-47b4-a9f4-862d78e81f66"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 1, 20, 39, 54, 964, DateTimeKind.Unspecified).AddTicks(1894), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 150000m, new TimeOnly(7, 0, 0), "Banked", new Guid("fd584379-6ba6-4923-bf9f-094945ae8a04"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d4009402-c683-4f58-a34c-16a57fd687cd"), new Guid("0433041c-f32b-4f4d-81f2-292c8534802b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 29, 20, 39, 54, 964, DateTimeKind.Unspecified).AddTicks(1840), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 100000m, new TimeOnly(8, 0, 0), "Banked", new Guid("356ba079-e1bf-4e68-a547-0ba5b6fdb529"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f905f637-3be4-450f-838c-17a832d428b8"), new Guid("8e8490d1-b5ab-4f76-85e5-24ba723ca3f2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 5, 20, 39, 54, 964, DateTimeKind.Unspecified).AddTicks(1900), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 150000m, new TimeOnly(9, 0, 0), "Banked", new Guid("5c6eaaa4-8b6b-4dc1-88e5-ea013e3631b1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ConfigSlots",
                columns: new[] { "Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("03c8917d-423e-4102-a52f-9f4fbe9d9a80"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 70000m, new TimeOnly(9, 30, 0), new Guid("f44bf1cd-73a0-4e1e-947e-dac3543d006a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("135b7f57-562e-446a-9a8e-d5e8d7ac9c17"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 35000m, new TimeOnly(7, 30, 0), new Guid("fd584379-6ba6-4923-bf9f-094945ae8a04"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("1f435b19-5299-4939-b23b-40c66d103b4b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 70000m, new TimeOnly(8, 0, 0), new Guid("f44bf1cd-73a0-4e1e-947e-dac3543d006a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2d4d016e-59e3-4145-8730-6173bdc911fd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 70000m, new TimeOnly(8, 30, 0), new Guid("f44bf1cd-73a0-4e1e-947e-dac3543d006a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3650dfc9-9117-467b-953b-9c060dd7ec81"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 50000m, new TimeOnly(8, 30, 0), new Guid("356ba079-e1bf-4e68-a547-0ba5b6fdb529"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("396077e4-5fc9-4ba2-9501-c3abbaf94049"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 50000m, new TimeOnly(9, 0, 0), new Guid("356ba079-e1bf-4e68-a547-0ba5b6fdb529"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3b95fea3-2e82-487a-bbd9-f641c5a2fbde"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 35000m, new TimeOnly(6, 30, 0), new Guid("fd584379-6ba6-4923-bf9f-094945ae8a04"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4293d11b-e0a8-4b5c-9928-29be392da047"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 70000m, new TimeOnly(6, 30, 0), new Guid("f44bf1cd-73a0-4e1e-947e-dac3543d006a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("456a8b7b-9805-42e6-b692-8ce58799db04"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 35000m, new TimeOnly(9, 0, 0), new Guid("fd584379-6ba6-4923-bf9f-094945ae8a04"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("47d3390c-d8cc-47b0-a2b6-93a680561ba0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 50000m, new TimeOnly(6, 30, 0), new Guid("356ba079-e1bf-4e68-a547-0ba5b6fdb529"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("48a6cece-3de4-4830-9271-621d847d33c0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 100000m, new TimeOnly(9, 0, 0), new Guid("0070a941-f9af-4ca7-951c-4ddc75cfb885"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4ba5caf7-ea9d-4655-ada4-ee218eaa0fc1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 35000m, new TimeOnly(8, 0, 0), new Guid("fd584379-6ba6-4923-bf9f-094945ae8a04"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("52ed3e9c-4262-4d12-b7e2-ff0a4ae85f8c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 35000m, new TimeOnly(8, 30, 0), new Guid("fd584379-6ba6-4923-bf9f-094945ae8a04"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5cf6b0d7-00fe-46e0-b3b7-066538b2d1d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 100000m, new TimeOnly(6, 0, 0), new Guid("0070a941-f9af-4ca7-951c-4ddc75cfb885"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("788f10c8-d564-4eb1-9bbc-ce2ec48fb171"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 100000m, new TimeOnly(8, 30, 0), new Guid("0070a941-f9af-4ca7-951c-4ddc75cfb885"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("78dc01fe-9293-4b60-b4e9-ce73fc65135e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 50000m, new TimeOnly(7, 30, 0), new Guid("356ba079-e1bf-4e68-a547-0ba5b6fdb529"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7b792482-51e1-4365-b8aa-d1f3edaf79a0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 70000m, new TimeOnly(7, 0, 0), new Guid("f44bf1cd-73a0-4e1e-947e-dac3543d006a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8383658f-c95d-43c0-8958-6f7f433a0e6a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 100000m, new TimeOnly(8, 0, 0), new Guid("0070a941-f9af-4ca7-951c-4ddc75cfb885"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("988c6c03-dfe0-4e9b-90aa-b4ddcbd7b98f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 70000m, new TimeOnly(7, 30, 0), new Guid("f44bf1cd-73a0-4e1e-947e-dac3543d006a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9b570707-7941-44e6-8f0d-5b39959b8d69"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 50000m, new TimeOnly(6, 0, 0), new Guid("356ba079-e1bf-4e68-a547-0ba5b6fdb529"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9ef64161-c73d-43d2-80ac-e17daa5cdee5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 100000m, new TimeOnly(7, 0, 0), new Guid("0070a941-f9af-4ca7-951c-4ddc75cfb885"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a068ded7-8d11-4bab-9ca2-7d205b164388"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 50000m, new TimeOnly(9, 30, 0), new Guid("356ba079-e1bf-4e68-a547-0ba5b6fdb529"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a78bc148-4353-4b56-bfbd-d74c41cd5ad3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 70000m, new TimeOnly(9, 0, 0), new Guid("f44bf1cd-73a0-4e1e-947e-dac3543d006a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b775d947-2384-46c0-b47c-538e6a3dfce0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 100000m, new TimeOnly(6, 30, 0), new Guid("0070a941-f9af-4ca7-951c-4ddc75cfb885"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b90594f2-1b09-4196-8230-c2dc57ceacda"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 70000m, new TimeOnly(6, 0, 0), new Guid("f44bf1cd-73a0-4e1e-947e-dac3543d006a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c69025c7-cdc5-4394-81d8-6a151721617a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 35000m, new TimeOnly(9, 30, 0), new Guid("fd584379-6ba6-4923-bf9f-094945ae8a04"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ca465e43-f3f9-4c12-9bfa-bcc63b36546c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 50000m, new TimeOnly(8, 0, 0), new Guid("356ba079-e1bf-4e68-a547-0ba5b6fdb529"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ccfab165-8a5f-48a1-ae23-9845cea0362e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 100000m, new TimeOnly(9, 30, 0), new Guid("0070a941-f9af-4ca7-951c-4ddc75cfb885"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("da45bd0e-2cff-445a-965b-091647e17b6e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 35000m, new TimeOnly(7, 0, 0), new Guid("fd584379-6ba6-4923-bf9f-094945ae8a04"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e5c50d8e-99c9-4be3-ab42-081e4d58ee13"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 50000m, new TimeOnly(7, 0, 0), new Guid("356ba079-e1bf-4e68-a547-0ba5b6fdb529"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e8e3e76d-442d-4b95-bbf0-f5c0780ca759"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 35000m, new TimeOnly(6, 0, 0), new Guid("fd584379-6ba6-4923-bf9f-094945ae8a04"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f028c895-f201-47b8-8cd7-a791e274eb87"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 100000m, new TimeOnly(7, 30, 0), new Guid("0070a941-f9af-4ca7-951c-4ddc75cfb885"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Exceptions",
                columns: new[] { "Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("301371d1-57ee-4427-b11a-0e1dddccfe61"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Hỏng đèn chiếu sáng", new TimeOnly(12, 0, 0), new Guid("fd584379-6ba6-4923-bf9f-094945ae8a04"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("42f21fb1-732f-4118-8742-3e6fc4f87dd0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Sơn lại mặt sân", new TimeOnly(12, 0, 0), new Guid("f44bf1cd-73a0-4e1e-947e-dac3543d006a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("75b86bec-6ef4-43c3-b044-8b2f616d99c4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Tổ chức sự kiện nội bộ", new TimeOnly(12, 0, 0), new Guid("0070a941-f9af-4ca7-951c-4ddc75cfb885"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c3c0c622-bfeb-4156-8f76-92e4c40ed829"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Bảo trì định kỳ", new TimeOnly(12, 0, 0), new Guid("356ba079-e1bf-4e68-a547-0ba5b6fdb529"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3ea8787e-8232-443d-b501-1578a353a18d"), new Guid("8e8490d1-b5ab-4f76-85e5-24ba723ca3f2"), "Đèn chiếu sáng yếu vào ban đêm.", new Guid("6a300784-2ae4-4eef-8567-0b561794c391"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b941002b-ab0a-415d-8fd0-b8358021727b"), false, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("49c6fe30-4583-4515-aa78-0c94962340da"), new Guid("1fe5bd5f-e0dc-47b4-a9f4-862d78e81f66"), "Bình thường, sân hơi cũ.", new Guid("63ed6ba1-09a7-4839-a65b-71bbcc567d1e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3c408123-27a3-4125-8b06-d865428866d9"), false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9dee4bbf-4ea4-43d3-8a8e-86279705ca04"), new Guid("f6a96789-f194-4d4b-b60d-089ad93253ec"), "Nhân viên thân thiện, sân sạch.", new Guid("8f448715-0e39-4153-8225-04f711f97f70"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3c408123-27a3-4125-8b06-d865428866d9"), false, 5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cbbf7f17-4324-4b3e-91e4-382836781649"), new Guid("0433041c-f32b-4f4d-81f2-292c8534802b"), "Sân rất tốt, sẽ quay lại!", new Guid("6a300784-2ae4-4eef-8567-0b561794c391"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b941002b-ab0a-415d-8fd0-b8358021727b"), false, 5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("deddf284-eaa3-4799-8daf-11c4876346e1"), new Guid("1112cfd3-54cd-4f57-b48f-f604b27f61fc"), "Dịch vụ ổn, giá hợp lý.", new Guid("8f448715-0e39-4153-8225-04f711f97f70"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b941002b-ab0a-415d-8fd0-b8358021727b"), false, 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("2aa3c54b-379b-412d-b9de-b9cfb8b2df60"), new Guid("1fe5bd5f-e0dc-47b4-a9f4-862d78e81f66"), "Bạn có lịch chơi vào ngày mai.", new Guid("63ed6ba1-09a7-4839-a65b-71bbcc567d1e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Nhắc nhở lịch chơi", "Remind", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("31c90ac4-e959-44bb-b66c-6934f53c8c09") },
                    { new Guid("381a3a58-8a13-43f2-ae86-7e13c30529e2"), new Guid("1112cfd3-54cd-4f57-b48f-f604b27f61fc"), "Booking #2 đã được xác nhận.", new Guid("8f448715-0e39-4153-8225-04f711f97f70"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Đặt sân thành công", "Booking", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f81e0e61-050a-4632-8da6-be56ada0cbd7") },
                    { new Guid("62447596-26e9-4f0d-85b0-0b63021f62bf"), new Guid("8e8490d1-b5ab-4f76-85e5-24ba723ca3f2"), "Đã hoàn 360,000đ vào ví của bạn.", new Guid("6a300784-2ae4-4eef-8567-0b561794c391"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Hoàn tiền", "Refund", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("e0a6e1b4-2499-4635-87f5-cbabcd4e30ca") }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("dba8a6fd-824b-4727-89c9-add62f6db127"), new Guid("f6a96789-f194-4d4b-b60d-089ad93253ec"), "Booking #4 đã bị huỷ. Tiền sẽ hoàn.", new Guid("14c77d05-8967-42a1-89bc-3538a57080e9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Huỷ booking", "Cancel", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3d9fb550-50c1-4a7d-b1d5-ec4024e50322") },
                    { new Guid("ea51b7d1-2009-4bd0-a318-cfef225abfda"), new Guid("0433041c-f32b-4f4d-81f2-292c8534802b"), "Booking #1 đã được xác nhận.", new Guid("6a300784-2ae4-4eef-8567-0b561794c391"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Đặt sân thành công", "Booking", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("e0a6e1b4-2499-4635-87f5-cbabcd4e30ca") }
                });

            migrationBuilder.InsertData(
                table: "OverideSlots",
                columns: new[] { "Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "IsRecurring", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[] { new Guid("0becc546-687a-498f-9ddc-a43c18800746"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(1, 1, 1), 1, new TimeOnly(20, 0, 0), false, true, 200000m, new TimeOnly(18, 0, 0), new Guid("5c6eaaa4-8b6b-4dc1-88e5-ea013e3631b1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "OverideSlots",
                columns: new[] { "Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1ec5231c-271f-4b1d-b91a-96ebefe435ec"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 220800m, new TimeOnly(12, 0, 0), new Guid("0070a941-f9af-4ca7-951c-4ddc75cfb885"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3eb1f30e-96bc-4076-8e58-9ba5209a3300"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 2054000m, new TimeOnly(12, 0, 0), new Guid("fd584379-6ba6-4923-bf9f-094945ae8a04"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("90fadc54-bf7f-48f1-a007-fd952f57b782"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 220500m, new TimeOnly(12, 0, 0), new Guid("f44bf1cd-73a0-4e1e-947e-dac3543d006a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ac47142e-d425-4856-9315-c818f4d92c94"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 208400m, new TimeOnly(12, 0, 0), new Guid("356ba079-e1bf-4e68-a547-0ba5b6fdb529"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("5dc16952-34a6-4438-a56f-a589e5219468"), new Guid("f6a96789-f194-4d4b-b60d-089ad93253ec"), new Guid("63ed6ba1-09a7-4839-a65b-71bbcc567d1e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b941002b-ab0a-415d-8fd0-b8358021727b"), false, "Không hoàn tiền khi huỷ đúng hạn.", "Rejected", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5e3d0ce4-c0ff-43a7-b762-2b58b9321487"), new Guid("8e8490d1-b5ab-4f76-85e5-24ba723ca3f2"), new Guid("14c77d05-8967-42a1-89bc-3538a57080e9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b941002b-ab0a-415d-8fd0-b8358021727b"), false, "Thông tin giờ mở cửa sai.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7f13c7b6-fbab-4bbe-af8b-db014b4433f5"), new Guid("0433041c-f32b-4f4d-81f2-292c8534802b"), new Guid("63ed6ba1-09a7-4839-a65b-71bbcc567d1e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3c408123-27a3-4125-8b06-d865428866d9"), false, "Sân không đúng mô tả.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("975b272d-197a-49f1-b99b-ddb792e95de1"), new Guid("1fe5bd5f-e0dc-47b4-a9f4-862d78e81f66"), new Guid("8f448715-0e39-4153-8225-04f711f97f70"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b941002b-ab0a-415d-8fd0-b8358021727b"), false, "Cơ sở vật chất xuống cấp.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9b25117b-3b6a-489a-aab0-ad3ea79be28f"), new Guid("1112cfd3-54cd-4f57-b48f-f604b27f61fc"), new Guid("6a300784-2ae4-4eef-8567-0b561794c391"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3c408123-27a3-4125-8b06-d865428866d9"), false, "Chủ sân thái độ không tốt.", "Resolved", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId" },
                values: new object[,]
                {
                    { new Guid("42957661-81a8-4b1b-92b2-c4a81daeab0f"), "ACT003", 200000m, 2200000m, 2000000m, "4567890123", "REF003", new Guid("1fe5bd5f-e0dc-47b4-a9f4-862d78e81f66"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP003", "SIG003", "Success", "Hoàn tiền booking #4", "Refund", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("9862a71a-28e6-4eca-b30a-ea9ca3960909") },
                    { new Guid("b95706c4-0c48-4bbe-824c-e984cf60bea2"), "ACT002", 270000m, 3500000m, 3770000m, "3456789012", "REF002", new Guid("1112cfd3-54cd-4f57-b48f-f604b27f61fc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP002", "SIG002", "Success", "Thanh toán booking #2", "Payment", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5ddfce9f-addf-42fc-b357-b15fb4233a7e") },
                    { new Guid("bf5c27d5-e33a-4747-8796-4a9f72a6aafd"), "ACT004", 500000m, 2000000m, 1500000m, "5678901234", "REF004", new Guid("8e8490d1-b5ab-4f76-85e5-24ba723ca3f2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP004", "SIG004", "Success", "Nạp tiền vào ví", "Deposit", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("29f955da-918e-4d9c-afc5-d6a908bc93e0") },
                    { new Guid("defd8f4a-6275-4e33-83cd-bbf91d2417a9"), "ACT001", 180000m, 2000000m, 2180000m, "2345678901", "REF001", new Guid("0433041c-f32b-4f4d-81f2-292c8534802b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP001", "SIG001", "Success", "Thanh toán booking #1", "Payment", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("44dd7d5c-592d-467d-ba9d-6b39da552553") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("26c24bec-ca0a-470c-8d15-1117acbb9227"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("3308c415-08db-4a9d-9683-6800d3767efa"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("c62b01d0-dbf9-4fbd-8053-282d6e0a87ff"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("d4009402-c683-4f58-a34c-16a57fd687cd"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("f905f637-3be4-450f-838c-17a832d428b8"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("13cfbcb5-111c-4f68-8f36-a69837010780"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("18bf6b96-88bc-414d-ba31-0c39f54bb06f"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("b7444c29-b476-4a4a-9a61-c0245a744721"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("b98270bd-07a7-4606-82e1-4e097838246c"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("17c31e98-3298-4bab-867b-f9930a863d1f"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("28489800-dddf-4ae8-8318-3c5351cf834c"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("ac569fc5-e28f-4d7f-895b-a3a9e82fa12e"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("e3924f0e-9ae7-47a7-8e68-26d7cda56b11"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("03c8917d-423e-4102-a52f-9f4fbe9d9a80"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("135b7f57-562e-446a-9a8e-d5e8d7ac9c17"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("1f435b19-5299-4939-b23b-40c66d103b4b"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("2d4d016e-59e3-4145-8730-6173bdc911fd"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("3650dfc9-9117-467b-953b-9c060dd7ec81"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("396077e4-5fc9-4ba2-9501-c3abbaf94049"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("3b95fea3-2e82-487a-bbd9-f641c5a2fbde"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("4293d11b-e0a8-4b5c-9928-29be392da047"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("456a8b7b-9805-42e6-b692-8ce58799db04"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("47d3390c-d8cc-47b0-a2b6-93a680561ba0"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("48a6cece-3de4-4830-9271-621d847d33c0"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("4ba5caf7-ea9d-4655-ada4-ee218eaa0fc1"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("52ed3e9c-4262-4d12-b7e2-ff0a4ae85f8c"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("5cf6b0d7-00fe-46e0-b3b7-066538b2d1d9"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("788f10c8-d564-4eb1-9bbc-ce2ec48fb171"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("78dc01fe-9293-4b60-b4e9-ce73fc65135e"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("7b792482-51e1-4365-b8aa-d1f3edaf79a0"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("8383658f-c95d-43c0-8958-6f7f433a0e6a"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("988c6c03-dfe0-4e9b-90aa-b4ddcbd7b98f"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("9b570707-7941-44e6-8f0d-5b39959b8d69"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("9ef64161-c73d-43d2-80ac-e17daa5cdee5"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("a068ded7-8d11-4bab-9ca2-7d205b164388"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("a78bc148-4353-4b56-bfbd-d74c41cd5ad3"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("b775d947-2384-46c0-b47c-538e6a3dfce0"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("b90594f2-1b09-4196-8230-c2dc57ceacda"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("c69025c7-cdc5-4394-81d8-6a151721617a"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("ca465e43-f3f9-4c12-9bfa-bcc63b36546c"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("ccfab165-8a5f-48a1-ae23-9845cea0362e"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("da45bd0e-2cff-445a-965b-091647e17b6e"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("e5c50d8e-99c9-4be3-ab42-081e4d58ee13"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("e8e3e76d-442d-4b95-bbf0-f5c0780ca759"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("f028c895-f201-47b8-8cd7-a791e274eb87"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("301371d1-57ee-4427-b11a-0e1dddccfe61"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("42f21fb1-732f-4118-8742-3e6fc4f87dd0"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("75b86bec-6ef4-43c3-b044-8b2f616d99c4"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("c3c0c622-bfeb-4156-8f76-92e4c40ed829"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("3ea8787e-8232-443d-b501-1578a353a18d"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("49c6fe30-4583-4515-aa78-0c94962340da"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("9dee4bbf-4ea4-43d3-8a8e-86279705ca04"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("cbbf7f17-4324-4b3e-91e4-382836781649"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("deddf284-eaa3-4799-8daf-11c4876346e1"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("1b195077-2a75-4f5e-8434-a6de678c46d9"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("8b551d68-fba0-4331-882e-e7ee5963da8f"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("9b0616e0-2426-4798-aa03-e976fece0d9d"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("e6831776-f96e-492c-a362-213ba0e4d6e8"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("f4c0933c-d9fb-462c-8b0a-60551dff44f5"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("2aa3c54b-379b-412d-b9de-b9cfb8b2df60"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("381a3a58-8a13-43f2-ae86-7e13c30529e2"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("62447596-26e9-4f0d-85b0-0b63021f62bf"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("dba8a6fd-824b-4727-89c9-add62f6db127"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("ea51b7d1-2009-4bd0-a318-cfef225abfda"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("0becc546-687a-498f-9ddc-a43c18800746"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("1ec5231c-271f-4b1d-b91a-96ebefe435ec"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("3eb1f30e-96bc-4076-8e58-9ba5209a3300"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("90fadc54-bf7f-48f1-a007-fd952f57b782"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("ac47142e-d425-4856-9315-c818f4d92c94"));

            migrationBuilder.DeleteData(
                table: "OwnerRequests",
                keyColumn: "Id",
                keyValue: new Guid("53933f15-4d1c-4f17-a1fc-cb6d425058c8"));

            migrationBuilder.DeleteData(
                table: "OwnerRequests",
                keyColumn: "Id",
                keyValue: new Guid("da8784a2-b063-4b9a-9e9f-2e132dc2cb72"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("44883b2d-df6e-4812-a5cb-c031f5eb0f90"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("5dc16952-34a6-4438-a56f-a589e5219468"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("5e3d0ce4-c0ff-43a7-b762-2b58b9321487"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("7f13c7b6-fbab-4bbe-af8b-db014b4433f5"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("975b272d-197a-49f1-b99b-ddb792e95de1"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("9b25117b-3b6a-489a-aab0-ad3ea79be28f"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("41007d27-2c6d-43e7-acd7-38d699c4a3ba"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("e0461c71-5db2-4ed8-bb64-48436be2223a"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("e50a8300-d348-4b41-9b9c-323d081fd194"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("0c68d871-480a-4081-8e78-f63495d1a47e"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("1ce0d875-d797-4836-a46b-01f086a91e49"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("57914e20-e634-4f05-ad04-c84e6e222371"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("a63cd5dc-30b6-458a-b552-30d538359600"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("e68645f8-2f62-476f-91b1-a17086c61bbd"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("42957661-81a8-4b1b-92b2-c4a81daeab0f"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("b95706c4-0c48-4bbe-824c-e984cf60bea2"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("bf5c27d5-e33a-4747-8796-4a9f72a6aafd"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("defd8f4a-6275-4e33-83cd-bbf91d2417a9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2bb283c8-62f0-4ef6-b234-5c591f2cfefa"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("0433041c-f32b-4f4d-81f2-292c8534802b"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("1112cfd3-54cd-4f57-b48f-f604b27f61fc"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("1fe5bd5f-e0dc-47b4-a9f4-862d78e81f66"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("8e8490d1-b5ab-4f76-85e5-24ba723ca3f2"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("f6a96789-f194-4d4b-b60d-089ad93253ec"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("0070a941-f9af-4ca7-951c-4ddc75cfb885"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("356ba079-e1bf-4e68-a547-0ba5b6fdb529"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("5c6eaaa4-8b6b-4dc1-88e5-ea013e3631b1"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("f44bf1cd-73a0-4e1e-947e-dac3543d006a"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("fd584379-6ba6-4923-bf9f-094945ae8a04"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9d524944-347a-493c-b1ef-860a06ac6f74"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("29f955da-918e-4d9c-afc5-d6a908bc93e0"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("44dd7d5c-592d-467d-ba9d-6b39da552553"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("5ddfce9f-addf-42fc-b357-b15fb4233a7e"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("9862a71a-28e6-4eca-b30a-ea9ca3960909"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("487e866e-65b6-4f3d-b4c2-99b37d98d70a"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("61a21e80-5c42-4865-b40c-c118e22a2804"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("14c77d05-8967-42a1-89bc-3538a57080e9"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("63ed6ba1-09a7-4839-a65b-71bbcc567d1e"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("6a300784-2ae4-4eef-8567-0b561794c391"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("8f448715-0e39-4153-8225-04f711f97f70"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("3c408123-27a3-4125-8b06-d865428866d9"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("b941002b-ab0a-415d-8fd0-b8358021727b"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("32e68440-cb37-40b8-9b85-97e104944a30"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("3f7b0ab7-5c70-4454-9703-8639999d0955"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("31c90ac4-e959-44bb-b66c-6934f53c8c09"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3d9fb550-50c1-4a7d-b1d5-ec4024e50322"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e0a6e1b4-2499-4635-87f5-cbabcd4e30ca"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f81e0e61-050a-4632-8da6-be56ada0cbd7"));

            migrationBuilder.DropColumn(
                name: "TimeRefundBefor",
                table: "Courts");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2cceeefc-9d4a-4256-b905-a0fcdcebd8be"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer2@gmail.com", "Bảo", false, "Châu", "hashed_pw_5", "0900000005", "Customer", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3a14f80f-cfa2-49de-b1fc-c17dcd26d2f5"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer1@gmail.com", "Lan", false, "Phương", "hashed_pw_4", "0900000004", "Customer", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("77d83e3f-97f6-4c85-97ac-1c9b55acfe53"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner1@rallyhub.vn", "Minh", false, "Tuấn", "hashed_pw_2", "0900000002", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("987a52b4-d30f-449b-b3ba-59ec46fe2285"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner3@rallyhub.vn", "Trần", false, "Phú", "hashed_pw_6", "0900000006", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("dbb7e7c6-48f6-436f-85c1-3d717993dc84"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "admin@rallyhub.vn", "Quản", false, "Trị", "hashed_pw_1", "0900000001", "Admin", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fdce1303-a7a8-4ec6-a4af-653e2aef60c8"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner2@rallyhub.vn", "Hải", false, "Đăng", "hashed_pw_3", "0900000003", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("95ca3b83-c4db-4b26-aaf2-6104a3b9b2a6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2cceeefc-9d4a-4256-b905-a0fcdcebd8be") },
                    { new Guid("f9cc43a9-6224-49e6-936a-f78230695756"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3a14f80f-cfa2-49de-b1fc-c17dcd26d2f5") }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("c69db783-1aa3-4933-8dad-025af6d83e5e"), "456 Lê Lợi, Q3, HCM", null, "Trung Tâm Thể Thao Hải Đăng", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, false, "9876543210", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("fdce1303-a7a8-4ec6-a4af-653e2aef60c8") },
                    { new Guid("c9bb48ca-e685-4acb-9837-92beff7be0b0"), "123 Nguyễn Huệ, Q1, HCM", null, "Sân Cầu Lông Minh Tuấn", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, false, "0123456789", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("77d83e3f-97f6-4c85-97ac-1c9b55acfe53") },
                    { new Guid("e9c28b32-e7c6-4ee3-ac02-3cd63986304e"), "Tôn Đức Thắng, HCM", null, "Sân Cầu Lông Trần Phú", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, false, "98765434219", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("987a52b4-d30f-449b-b3ba-59ec46fe2285") }
                });

            migrationBuilder.InsertData(
                table: "SystemReports",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("03216916-475c-42fb-ae89-80d2b44a0271"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "OTP không gửi đến số điện thoại.", "Pending", "Không nhận được OTP", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3a14f80f-cfa2-49de-b1fc-c17dcd26d2f5") },
                    { new Guid("1970d018-b2a2-40af-9a8b-c87b3c86a1e0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Không thể thanh toán qua ví.", "Pending", "Lỗi thanh toán", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("77d83e3f-97f6-4c85-97ac-1c9b55acfe53") },
                    { new Guid("210011a1-b5b8-48ae-a70c-af8a98f842e9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Số dư hiển thị không khớp lịch sử.", "Resolved", "Sai số dư sau giao dịch", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2cceeefc-9d4a-4256-b905-a0fcdcebd8be") },
                    { new Guid("3fbf07a0-5750-460d-8bcb-a698960ea938"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Bản đồ không load được trên iOS.", "Resolved", "Lỗi hiển thị bản đồ", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("fdce1303-a7a8-4ec6-a4af-653e2aef60c8") },
                    { new Guid("e2d385b7-44f2-4299-8dfb-7b977fbb2478"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Crash khi mở trang tìm kiếm sân.", "Pending", "App bị crash", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3a14f80f-cfa2-49de-b1fc-c17dcd26d2f5") }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version" },
                values: new object[,]
                {
                    { new Guid("24422d5c-84e1-481d-bd81-c8a063b9ea8f"), 3500000m, "5678901234", "VPBank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2cceeefc-9d4a-4256-b905-a0fcdcebd8be"), 0 },
                    { new Guid("3210eba9-e1d4-4b45-8c0f-68f5e1b48a79"), 2000000m, "4567890123", "MB Bank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3a14f80f-cfa2-49de-b1fc-c17dcd26d2f5"), 0 },
                    { new Guid("626d6c0a-03a4-4898-86bc-f1c7f4754719"), 8500000m, "3456789012", "BIDV", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("fdce1303-a7a8-4ec6-a4af-653e2aef60c8"), 0 },
                    { new Guid("a3c36211-b01f-45d0-9130-5f2b5c7b71ea"), 12000000m, "2345678901", "Techcombank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("77d83e3f-97f6-4c85-97ac-1c9b55acfe53"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount" },
                values: new object[,]
                {
                    { new Guid("364bc348-b277-4feb-8c51-1a311da6cfb1"), "WEEKEND10", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 15m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 75000m, 250000m, new Guid("c69db783-1aa3-4933-8dad-025af6d83e5e"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 200, 30 },
                    { new Guid("7c6c0f3b-f754-4fc3-9671-0d0b1940b3ad"), "YEUTH", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 30000m, 100000m, new Guid("c9bb48ca-e685-4acb-9837-92beff7be0b0"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 500, 87 },
                    { new Guid("aa60ded0-48d2-49a4-9a66-633168fe9a2e"), "NEWUSER", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 20m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 100000m, 300000m, new Guid("c69db783-1aa3-4933-8dad-025af6d83e5e"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 50, 5 },
                    { new Guid("bac22ce3-6321-485f-a2dd-fc093f6bcdba"), "LOYAL5", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 30000m, 100000m, new Guid("c69db783-1aa3-4933-8dad-025af6d83e5e"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 500, 87 },
                    { new Guid("bdf129ce-a6ac-4dc0-bd7c-2c6c8a1373af"), "SUMMER25", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 50000m, 200000m, new Guid("c9bb48ca-e685-4acb-9837-92beff7be0b0"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 100, 12 },
                    { new Guid("bdff780f-b034-40c5-83ae-4eb42cedb78e"), "FLASH50", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 50m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 200000m, 500000m, new Guid("c9bb48ca-e685-4acb-9837-92beff7be0b0"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "Courts",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("09a8c275-0daa-4552-bbed-024a43a71b0c"), "456 Lê Lợi, Q3, HCM", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.78m, 106.69m, "https://maps.google.com/?q=10.78,106.69", "Sân D - Hải Đăng", new TimeOnly(5, 30, 0), new Guid("c69db783-1aa3-4933-8dad-025af6d83e5e"), "https://images.example.com/courts/go-vap.jpg", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("10d9dca7-7f55-4f6a-93f6-5df2004b0986"), "123 Nguyễn Huệ, Q1, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.77m, 106.70m, "https://maps.google.com/?q=10.77,106.70", "Sân B - Minh Tuấn", new TimeOnly(6, 0, 0), new Guid("c9bb48ca-e685-4acb-9837-92beff7be0b0"), "https://images.example.com/courts/go-vap.jpg", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("497002c0-ce8a-4222-bb08-8cb01cabbe20"), "123 Nguyễn Huệ, Q1, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.77m, 106.70m, "https://maps.google.com/?q=10.77,106.70", "Sân A - Minh Tuấn", new TimeOnly(6, 0, 0), new Guid("c9bb48ca-e685-4acb-9837-92beff7be0b0"), "https://images.example.com/courts/go-vap.jpg", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("dc4008ea-990a-4786-9aa0-7894a589dcbc"), "456 Lê Lợi, Q3, HCM", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.78m, 106.69m, "https://maps.google.com/?q=10.78,106.69", "Sân C - Hải Đăng", new TimeOnly(5, 30, 0), new Guid("c69db783-1aa3-4933-8dad-025af6d83e5e"), "https://images.example.com/courts/go-vap.jpg", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "OwnerRequests",
                columns: new[] { "Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "CustomerId", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "OwnerId", "RejectionReason", "Status", "TaxCode", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0f00305d-d22c-4b26-910c-a65cb633d53e"), "456 Lê Lợi, Q3, HCM", "https://cdn.rallyhub.vn/license/2.jpg", "Trung Tâm Thể Thao Hải Đăng", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95ca3b83-c4db-4b26-aaf2-6104a3b9b2a6"), "https://cdn.rallyhub.vn/cccd/2_back.jpg", "https://cdn.rallyhub.vn/cccd/2_front.jpg", "079200054321", false, new Guid("c69db783-1aa3-4933-8dad-025af6d83e5e"), null, "Approved", "9876543210", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6ef4ba80-e8e0-4b60-8a07-19cb0ab4c5cf"), "123 Nguyễn Huệ, Q1, HCM", "https://cdn.rallyhub.vn/license/1.jpg", "Sân Cầu Lông Minh Tuấn", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f9cc43a9-6224-49e6-936a-f78230695756"), "https://cdn.rallyhub.vn/cccd/1_back.jpg", "https://cdn.rallyhub.vn/cccd/1_front.jpg", "079200012345", false, new Guid("c9bb48ca-e685-4acb-9837-92beff7be0b0"), null, "Approved", "0123456789", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2242fa57-fe64-4a6c-a47e-47b6f3a66cb4"), new Guid("aa60ded0-48d2-49a4-9a66-633168fe9a2e"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95ca3b83-c4db-4b26-aaf2-6104a3b9b2a6"), 40000m, 360000m, false, "Banked", 400000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4f8f8f54-95f6-475a-bad8-ff63ad41a00a"), new Guid("bdf129ce-a6ac-4dc0-bd7c-2c6c8a1373af"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f9cc43a9-6224-49e6-936a-f78230695756"), 30000m, 270000m, false, "Banked", 300000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("667e0b35-596f-479b-ac04-d34c0e148fdf"), new Guid("aa60ded0-48d2-49a4-9a66-633168fe9a2e"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95ca3b83-c4db-4b26-aaf2-6104a3b9b2a6"), 0m, 150000m, false, "Complete", 150000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("dae74d67-12b2-48a6-90d3-df45750d4cfa"), new Guid("bdf129ce-a6ac-4dc0-bd7c-2c6c8a1373af"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f9cc43a9-6224-49e6-936a-f78230695756"), 20000m, 180000m, false, "Complete", 200000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("eb6c470a-9dcc-49f1-9886-4cb7c5e46812"), new Guid("aa60ded0-48d2-49a4-9a66-633168fe9a2e"), "Khách huỷ", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95ca3b83-c4db-4b26-aaf2-6104a3b9b2a6"), 50000m, 200000m, false, "Cancel", 250000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "CampaignCourts",
                columns: new[] { "Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("8d1d36cd-cb88-4a17-9589-cfd93744cba4"), new Guid("aa60ded0-48d2-49a4-9a66-633168fe9a2e"), new Guid("497002c0-ce8a-4222-bb08-8cb01cabbe20"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9ff29122-b3bd-4b32-ae39-4af1dcdfaa30"), new Guid("aa60ded0-48d2-49a4-9a66-633168fe9a2e"), new Guid("10d9dca7-7f55-4f6a-93f6-5df2004b0986"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ee4d417e-209f-4d0a-bdaa-c88d12e10de0"), new Guid("bdf129ce-a6ac-4dc0-bd7c-2c6c8a1373af"), new Guid("dc4008ea-990a-4786-9aa0-7894a589dcbc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fa655f17-608f-4876-a2b9-ef17af4eb26d"), new Guid("bdf129ce-a6ac-4dc0-bd7c-2c6c8a1373af"), new Guid("09a8c275-0daa-4552-bbed-024a43a71b0c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "LikeListDetails",
                columns: new[] { "Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("09713717-11db-4174-a8de-a2167c61c477"), new Guid("497002c0-ce8a-4222-bb08-8cb01cabbe20"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95ca3b83-c4db-4b26-aaf2-6104a3b9b2a6"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("09df1f85-e54b-49d3-b4fa-416be50271c6"), new Guid("dc4008ea-990a-4786-9aa0-7894a589dcbc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95ca3b83-c4db-4b26-aaf2-6104a3b9b2a6"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("631a4459-0a61-4118-8b0e-1bfc84556dce"), new Guid("10d9dca7-7f55-4f6a-93f6-5df2004b0986"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f9cc43a9-6224-49e6-936a-f78230695756"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b02ff8b7-3ba7-41f5-8285-526303b6ac6e"), new Guid("09a8c275-0daa-4552-bbed-024a43a71b0c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95ca3b83-c4db-4b26-aaf2-6104a3b9b2a6"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fae8691e-bfcf-430e-925f-abfaa28d83f1"), new Guid("497002c0-ce8a-4222-bb08-8cb01cabbe20"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f9cc43a9-6224-49e6-936a-f78230695756"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "SubCourts",
                columns: new[] { "Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("61d647b8-7f16-4b69-9b25-62eb19a64f43"), new Guid("dc4008ea-990a-4786-9aa0-7894a589dcbc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ C2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6312166e-ec9b-4d3b-8df4-9574e31ea3f4"), new Guid("497002c0-ce8a-4222-bb08-8cb01cabbe20"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ A2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("872e14be-cd75-4c66-86ee-287a4d1fd753"), new Guid("dc4008ea-990a-4786-9aa0-7894a589dcbc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ C1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("af33e72b-5296-4f0d-8236-d1aa32edc3c8"), new Guid("09a8c275-0daa-4552-bbed-024a43a71b0c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ D1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c4a042af-5043-4051-aaa4-9425f433ab84"), new Guid("497002c0-ce8a-4222-bb08-8cb01cabbe20"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ A1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("db5c0f95-d3cc-4c50-a97e-2c0bee97ff8b"), new Guid("10d9dca7-7f55-4f6a-93f6-5df2004b0986"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ B1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f9211683-3762-4f73-b68e-56f00b3bba9b"), new Guid("10d9dca7-7f55-4f6a-93f6-5df2004b0986"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ B2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fba5ffb1-8ecd-46a3-8dc7-e886be4bad60"), new Guid("09a8c275-0daa-4552-bbed-024a43a71b0c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ D2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "BookingDetails",
                columns: new[] { "Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "Status", "SubCourtId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("33e616d9-0f39-4ffb-92b5-fb51bf4e7170"), new Guid("667e0b35-596f-479b-ac04-d34c0e148fdf"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 1, 17, 2, 1, 453, DateTimeKind.Unspecified).AddTicks(7512), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 150000m, new TimeOnly(7, 0, 0), "Banked", new Guid("872e14be-cd75-4c66-86ee-287a4d1fd753"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6149a057-f09a-476b-b7ed-87391ce8f63c"), new Guid("4f8f8f54-95f6-475a-bad8-ff63ad41a00a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 29, 17, 2, 1, 453, DateTimeKind.Unspecified).AddTicks(7509), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 100000m, new TimeOnly(6, 0, 0), "Banked", new Guid("db5c0f95-d3cc-4c50-a97e-2c0bee97ff8b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8563bfa4-2994-4833-b006-47b3c6637f53"), new Guid("2242fa57-fe64-4a6c-a47e-47b6f3a66cb4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 5, 17, 2, 1, 453, DateTimeKind.Unspecified).AddTicks(7518), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 150000m, new TimeOnly(9, 0, 0), "Banked", new Guid("6312166e-ec9b-4d3b-8df4-9574e31ea3f4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d5e4434d-7fdd-4d28-b23f-09413764524d"), new Guid("eb6c470a-9dcc-49f1-9886-4cb7c5e46812"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 1, 17, 2, 1, 453, DateTimeKind.Unspecified).AddTicks(7516), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 150000m, new TimeOnly(6, 0, 0), "Cancel", new Guid("af33e72b-5296-4f0d-8236-d1aa32edc3c8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e8725c4a-0bf2-4bd3-adbc-1138c5fce8d4"), new Guid("dae74d67-12b2-48a6-90d3-df45750d4cfa"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 4, 29, 17, 2, 1, 453, DateTimeKind.Unspecified).AddTicks(7462), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 100000m, new TimeOnly(8, 0, 0), "Banked", new Guid("c4a042af-5043-4051-aaa4-9425f433ab84"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ConfigSlots",
                columns: new[] { "Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("01bf8f76-2bee-43fd-8231-e08bcfd246d2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 70000m, new TimeOnly(6, 0, 0), new Guid("db5c0f95-d3cc-4c50-a97e-2c0bee97ff8b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("02391615-e0a0-4d5b-a474-ed4f0c2db13b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 100000m, new TimeOnly(8, 30, 0), new Guid("af33e72b-5296-4f0d-8236-d1aa32edc3c8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("106e9de6-64b2-4d34-af9d-95f794ff1499"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 50000m, new TimeOnly(6, 30, 0), new Guid("c4a042af-5043-4051-aaa4-9425f433ab84"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("13fc0774-823d-40c0-bb54-be51245f8121"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 50000m, new TimeOnly(8, 0, 0), new Guid("c4a042af-5043-4051-aaa4-9425f433ab84"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("252e2b6c-6571-49e6-8b6a-f47512bf5ab3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 70000m, new TimeOnly(9, 0, 0), new Guid("db5c0f95-d3cc-4c50-a97e-2c0bee97ff8b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3e489144-1c36-4f1e-8803-b081c4a73354"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 100000m, new TimeOnly(9, 30, 0), new Guid("af33e72b-5296-4f0d-8236-d1aa32edc3c8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("48edffc1-e5ca-4d0b-967b-8b1b85f57adb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 50000m, new TimeOnly(8, 30, 0), new Guid("c4a042af-5043-4051-aaa4-9425f433ab84"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4b904b86-911c-4f6f-a98f-1f14572cf38a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 100000m, new TimeOnly(6, 0, 0), new Guid("af33e72b-5296-4f0d-8236-d1aa32edc3c8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4d961fa6-b0da-4892-9e14-46ad2febfe0b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 100000m, new TimeOnly(9, 0, 0), new Guid("af33e72b-5296-4f0d-8236-d1aa32edc3c8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("508e5e2d-a445-4073-aa78-80671f377590"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 35000m, new TimeOnly(7, 0, 0), new Guid("872e14be-cd75-4c66-86ee-287a4d1fd753"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("54cd735b-5ba5-464c-acff-1b7af488aed3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 35000m, new TimeOnly(8, 0, 0), new Guid("872e14be-cd75-4c66-86ee-287a4d1fd753"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("59186c7a-c47c-4732-b7be-c1ec82420e54"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 35000m, new TimeOnly(7, 30, 0), new Guid("872e14be-cd75-4c66-86ee-287a4d1fd753"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("61bc097d-b121-464d-bf70-bbcb3a305048"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 100000m, new TimeOnly(7, 30, 0), new Guid("af33e72b-5296-4f0d-8236-d1aa32edc3c8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6fc685c1-cdef-49c1-8a4a-bf3dc18026ec"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 35000m, new TimeOnly(9, 30, 0), new Guid("872e14be-cd75-4c66-86ee-287a4d1fd753"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("72b8caa0-6d7c-4a6a-9424-e36706dc7141"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 50000m, new TimeOnly(9, 30, 0), new Guid("c4a042af-5043-4051-aaa4-9425f433ab84"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7ecad6e3-acfc-4044-ac61-0e03a9d721d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 50000m, new TimeOnly(6, 0, 0), new Guid("c4a042af-5043-4051-aaa4-9425f433ab84"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7fec368e-c080-4937-97cb-d1fc1a4a7e78"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 50000m, new TimeOnly(7, 30, 0), new Guid("c4a042af-5043-4051-aaa4-9425f433ab84"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8f6fb075-9704-4b17-8bd6-1092910fef1c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 70000m, new TimeOnly(7, 0, 0), new Guid("db5c0f95-d3cc-4c50-a97e-2c0bee97ff8b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("99503c30-2c5e-4220-8739-c1f054408d60"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 100000m, new TimeOnly(6, 30, 0), new Guid("af33e72b-5296-4f0d-8236-d1aa32edc3c8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9b6f7cc0-1f28-4646-88fa-c58a53b701f0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 70000m, new TimeOnly(7, 30, 0), new Guid("db5c0f95-d3cc-4c50-a97e-2c0bee97ff8b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a446e124-dad0-4ab4-a018-290fff428e9a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 100000m, new TimeOnly(7, 0, 0), new Guid("af33e72b-5296-4f0d-8236-d1aa32edc3c8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ab787dc4-f3c9-44bd-ae20-4611fb999c23"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 70000m, new TimeOnly(8, 30, 0), new Guid("db5c0f95-d3cc-4c50-a97e-2c0bee97ff8b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b7604d49-bc6a-4e31-b8ba-618cd645bdb1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 50000m, new TimeOnly(9, 0, 0), new Guid("c4a042af-5043-4051-aaa4-9425f433ab84"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b76d454e-8374-4c6f-a1fa-5c1987e782e7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 35000m, new TimeOnly(9, 0, 0), new Guid("872e14be-cd75-4c66-86ee-287a4d1fd753"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c5044090-6380-4f26-ad90-dff703dd0fb9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 70000m, new TimeOnly(9, 30, 0), new Guid("db5c0f95-d3cc-4c50-a97e-2c0bee97ff8b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cf6fc156-095f-49d9-87de-0e0bb58800ce"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 70000m, new TimeOnly(6, 30, 0), new Guid("db5c0f95-d3cc-4c50-a97e-2c0bee97ff8b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("df0095a0-af4f-47e3-9aeb-fa82ce1d6c2f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 35000m, new TimeOnly(8, 30, 0), new Guid("872e14be-cd75-4c66-86ee-287a4d1fd753"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e666c70c-e243-4f41-9576-2c0f9cc80f01"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 35000m, new TimeOnly(6, 0, 0), new Guid("872e14be-cd75-4c66-86ee-287a4d1fd753"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e81d6ade-a0bc-46b7-b104-d27a51bd7202"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 70000m, new TimeOnly(8, 0, 0), new Guid("db5c0f95-d3cc-4c50-a97e-2c0bee97ff8b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f442eb3f-132a-4cb8-b928-9113b9cc279a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 50000m, new TimeOnly(7, 0, 0), new Guid("c4a042af-5043-4051-aaa4-9425f433ab84"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f85ef378-4c91-4cfc-a86d-1afc14ebef56"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 100000m, new TimeOnly(8, 0, 0), new Guid("af33e72b-5296-4f0d-8236-d1aa32edc3c8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fd4597a1-567a-426d-8335-d5c1b91fd6b3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 35000m, new TimeOnly(6, 30, 0), new Guid("872e14be-cd75-4c66-86ee-287a4d1fd753"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Exceptions",
                columns: new[] { "Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("9c8cca2a-0aee-48f7-ba91-f56f9c8a15a3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Bảo trì định kỳ", new TimeOnly(12, 0, 0), new Guid("c4a042af-5043-4051-aaa4-9425f433ab84"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ea82ad51-e282-4781-abbd-f07d707ebd8a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Hỏng đèn chiếu sáng", new TimeOnly(12, 0, 0), new Guid("872e14be-cd75-4c66-86ee-287a4d1fd753"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f3fc0117-9aaf-40de-9177-e6c8b7ddff36"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Sơn lại mặt sân", new TimeOnly(12, 0, 0), new Guid("db5c0f95-d3cc-4c50-a97e-2c0bee97ff8b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ff595c65-74a3-4f61-bb31-4fc3ea4456e6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Tổ chức sự kiện nội bộ", new TimeOnly(12, 0, 0), new Guid("af33e72b-5296-4f0d-8236-d1aa32edc3c8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0587bcce-45f1-4d8c-b8b3-50dc687b6df3"), new Guid("dae74d67-12b2-48a6-90d3-df45750d4cfa"), "Sân rất tốt, sẽ quay lại!", new Guid("497002c0-ce8a-4222-bb08-8cb01cabbe20"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95ca3b83-c4db-4b26-aaf2-6104a3b9b2a6"), false, 5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("21dc339f-30b5-44c6-a526-83d70607c4d7"), new Guid("2242fa57-fe64-4a6c-a47e-47b6f3a66cb4"), "Đèn chiếu sáng yếu vào ban đêm.", new Guid("497002c0-ce8a-4222-bb08-8cb01cabbe20"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95ca3b83-c4db-4b26-aaf2-6104a3b9b2a6"), false, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("49ff473e-dbc5-42fd-8d5d-2eec2e6ad528"), new Guid("4f8f8f54-95f6-475a-bad8-ff63ad41a00a"), "Dịch vụ ổn, giá hợp lý.", new Guid("10d9dca7-7f55-4f6a-93f6-5df2004b0986"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95ca3b83-c4db-4b26-aaf2-6104a3b9b2a6"), false, 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("991a71ee-8a7b-45e7-8b9e-b27f0e4fdf06"), new Guid("667e0b35-596f-479b-ac04-d34c0e148fdf"), "Bình thường, sân hơi cũ.", new Guid("dc4008ea-990a-4786-9aa0-7894a589dcbc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f9cc43a9-6224-49e6-936a-f78230695756"), false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9e2bee27-086a-4157-a9fc-2fd732701e68"), new Guid("eb6c470a-9dcc-49f1-9886-4cb7c5e46812"), "Nhân viên thân thiện, sân sạch.", new Guid("10d9dca7-7f55-4f6a-93f6-5df2004b0986"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f9cc43a9-6224-49e6-936a-f78230695756"), false, 5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("1093173b-f237-4b3b-860d-812394fd2743"), new Guid("667e0b35-596f-479b-ac04-d34c0e148fdf"), "Bạn có lịch chơi vào ngày mai.", new Guid("dc4008ea-990a-4786-9aa0-7894a589dcbc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Nhắc nhở lịch chơi", "Remind", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3a14f80f-cfa2-49de-b1fc-c17dcd26d2f5") });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("124d3d40-19d1-4d38-a587-a967cc08d1fc"), new Guid("dae74d67-12b2-48a6-90d3-df45750d4cfa"), "Booking #1 đã được xác nhận.", new Guid("497002c0-ce8a-4222-bb08-8cb01cabbe20"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Đặt sân thành công", "Booking", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("77d83e3f-97f6-4c85-97ac-1c9b55acfe53") },
                    { new Guid("1729d2ed-5c4b-429b-b090-6b0d5e4e9994"), new Guid("eb6c470a-9dcc-49f1-9886-4cb7c5e46812"), "Booking #4 đã bị huỷ. Tiền sẽ hoàn.", new Guid("09a8c275-0daa-4552-bbed-024a43a71b0c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Huỷ booking", "Cancel", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2cceeefc-9d4a-4256-b905-a0fcdcebd8be") }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("695d1de6-8de6-4f40-b934-1f5e41f97d31"), new Guid("4f8f8f54-95f6-475a-bad8-ff63ad41a00a"), "Booking #2 đã được xác nhận.", new Guid("10d9dca7-7f55-4f6a-93f6-5df2004b0986"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Đặt sân thành công", "Booking", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("fdce1303-a7a8-4ec6-a4af-653e2aef60c8") },
                    { new Guid("b32d9e7e-cdf5-43de-b34f-4ffffe108c71"), new Guid("2242fa57-fe64-4a6c-a47e-47b6f3a66cb4"), "Đã hoàn 360,000đ vào ví của bạn.", new Guid("497002c0-ce8a-4222-bb08-8cb01cabbe20"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Hoàn tiền", "Refund", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("77d83e3f-97f6-4c85-97ac-1c9b55acfe53") }
                });

            migrationBuilder.InsertData(
                table: "OverideSlots",
                columns: new[] { "Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "IsRecurring", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[] { new Guid("2df541a3-c6e2-4a21-b81d-a967454c9d97"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(1, 1, 1), 1, new TimeOnly(20, 0, 0), false, true, 200000m, new TimeOnly(18, 0, 0), new Guid("6312166e-ec9b-4d3b-8df4-9574e31ea3f4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "OverideSlots",
                columns: new[] { "Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("8d37aee8-d7e4-42ae-8999-156dd7c20fd9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 2054000m, new TimeOnly(12, 0, 0), new Guid("872e14be-cd75-4c66-86ee-287a4d1fd753"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a37422f2-c9df-4f1f-b3a1-796e727de5fc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 220800m, new TimeOnly(12, 0, 0), new Guid("af33e72b-5296-4f0d-8236-d1aa32edc3c8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b6a023ee-d6a0-43ac-beba-0d2a0b796236"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 208400m, new TimeOnly(12, 0, 0), new Guid("c4a042af-5043-4051-aaa4-9425f433ab84"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e00dd348-aaae-4eee-98e1-95fecd4dfb84"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 220500m, new TimeOnly(12, 0, 0), new Guid("db5c0f95-d3cc-4c50-a97e-2c0bee97ff8b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("01813f39-81b1-4d9e-a71e-7bb3cca6c7da"), new Guid("667e0b35-596f-479b-ac04-d34c0e148fdf"), new Guid("10d9dca7-7f55-4f6a-93f6-5df2004b0986"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95ca3b83-c4db-4b26-aaf2-6104a3b9b2a6"), false, "Cơ sở vật chất xuống cấp.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("0558d04a-9ffd-41db-b729-d72e75c834bf"), new Guid("dae74d67-12b2-48a6-90d3-df45750d4cfa"), new Guid("dc4008ea-990a-4786-9aa0-7894a589dcbc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f9cc43a9-6224-49e6-936a-f78230695756"), false, "Sân không đúng mô tả.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("0938900c-0346-46b5-aef6-48f681fa6a81"), new Guid("4f8f8f54-95f6-475a-bad8-ff63ad41a00a"), new Guid("497002c0-ce8a-4222-bb08-8cb01cabbe20"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f9cc43a9-6224-49e6-936a-f78230695756"), false, "Chủ sân thái độ không tốt.", "Resolved", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c1773b80-214e-45fb-9ae4-fd3549080e84"), new Guid("2242fa57-fe64-4a6c-a47e-47b6f3a66cb4"), new Guid("09a8c275-0daa-4552-bbed-024a43a71b0c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95ca3b83-c4db-4b26-aaf2-6104a3b9b2a6"), false, "Thông tin giờ mở cửa sai.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("dc42c5b3-1575-4560-8467-fe883c228c2f"), new Guid("eb6c470a-9dcc-49f1-9886-4cb7c5e46812"), new Guid("dc4008ea-990a-4786-9aa0-7894a589dcbc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95ca3b83-c4db-4b26-aaf2-6104a3b9b2a6"), false, "Không hoàn tiền khi huỷ đúng hạn.", "Rejected", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId" },
                values: new object[,]
                {
                    { new Guid("3e6c96df-fcc3-4122-a567-d0c8997e39d8"), "ACT001", 180000m, 2000000m, 2180000m, "2345678901", "REF001", new Guid("dae74d67-12b2-48a6-90d3-df45750d4cfa"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP001", "SIG001", "Success", "Thanh toán booking #1", "Payment", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a3c36211-b01f-45d0-9130-5f2b5c7b71ea") },
                    { new Guid("8124be6e-1486-4cdf-aee6-44767681e705"), "ACT003", 200000m, 2200000m, 2000000m, "4567890123", "REF003", new Guid("667e0b35-596f-479b-ac04-d34c0e148fdf"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP003", "SIG003", "Success", "Hoàn tiền booking #4", "Refund", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3210eba9-e1d4-4b45-8c0f-68f5e1b48a79") },
                    { new Guid("93667a65-6c04-49f8-8094-48e5eca83a8b"), "ACT004", 500000m, 2000000m, 1500000m, "5678901234", "REF004", new Guid("2242fa57-fe64-4a6c-a47e-47b6f3a66cb4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP004", "SIG004", "Success", "Nạp tiền vào ví", "Deposit", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("24422d5c-84e1-481d-bd81-c8a063b9ea8f") },
                    { new Guid("a22067bf-7a53-463f-a79d-31b9f4b8daae"), "ACT002", 270000m, 3500000m, 3770000m, "3456789012", "REF002", new Guid("4f8f8f54-95f6-475a-bad8-ff63ad41a00a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP002", "SIG002", "Success", "Thanh toán booking #2", "Payment", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("626d6c0a-03a4-4898-86bc-f1c7f4754719") }
                });
        }
    }
}
