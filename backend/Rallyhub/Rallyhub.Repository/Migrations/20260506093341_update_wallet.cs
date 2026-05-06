using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rallyhub.Repository.Migrations
{
    /// <inheritdoc />
    public partial class update_wallet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("57189e97-6daf-468f-a951-e317d282f1d4"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("71c1a34d-ca56-449e-b6af-7408a4eaec2c"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("e4f528cd-bcfd-4be0-8984-18060536e18d"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("e6ca9533-5896-417e-9f93-be19d0fd308f"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("f2f57e57-3467-490a-bb64-412de6898c97"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("307cd329-708c-4527-a5b0-dfd389775078"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("4546faf4-dcec-47ad-9b80-b457c19b4d64"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("e0a81974-fb17-411a-b6d8-8ea8cf0ca657"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("ea329199-f6ce-4388-ad86-ec7e55097f0b"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("008170bc-6e14-4187-b052-c020fdf8e333"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("3a5a4c23-976a-4f08-94ed-f3aa999a8839"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("5b73dafa-764d-4230-aadc-405b1b4c6c2e"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("fba5cb4e-b89d-4017-aede-e0220963ca3f"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("0b571135-9516-47e8-ac25-e7af6d644c46"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("19957a4e-72f9-433d-846e-3c790c5b9dea"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("2f5bb542-274c-4903-9f9f-bed645fdcb16"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("311de368-2a9d-4683-a2bc-466d2d4c2cd9"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("340eaed3-2993-495a-b7f5-95de8cdfd447"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("3a51c8d5-3386-414e-b0d7-5d96da5fbc91"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("4b06a40e-0290-4fe2-9be6-ab290929b727"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("54682f55-e5b1-4aa1-a958-db64c320e32b"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("5623aa4f-c3e6-4e0b-8294-82aff265d6a1"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("610ce906-da01-41da-b7e3-e02d2f3c1d0f"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("653cab59-3429-40b9-806b-d3f16788fbc6"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("668c9fa5-353b-4371-84cf-65ab2680ff66"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("747b5939-7450-4b82-a7f1-fb0d7d0643cb"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("76528a35-b341-4ad3-a72e-131d4134c4c3"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("857f7a4f-4557-4e16-bde1-d3fccf6b6c4e"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("8625fd04-9659-4e6e-adfb-3d4958de7a3c"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("8c1ddebc-8035-4c7a-a2b9-64a6c3b2dc66"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("8f1e8980-726f-442a-be3b-5de3c13c9c89"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("918e0507-0ecf-4212-9b96-43381601a742"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("9b9b639f-6929-49fe-8ab8-ecdb4594914d"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("9daab342-eac9-420d-bf35-13cb24e23c24"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("bcc8102f-7c93-4eec-bd0e-3f5f8c01f285"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("c64afa0b-2742-47d4-821d-c052c537a942"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("da173c48-e017-4800-9ee4-1a12b34c77d0"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("e3c25948-df33-420c-b832-f8bbf8c9c7e2"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("e4800622-2918-4785-a48b-1aaf673b5fe6"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("e539cdaa-e64d-41e5-ace7-db6eeae47fe7"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("ea9a5280-f432-4aa4-a916-6724769386fb"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("f400c46d-68ba-4a36-9e67-b4d0d4bfdd40"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("f4b690cf-0d16-4a5f-be8b-6a53e669758a"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("f6edb168-5604-482e-a512-6ecfdddac454"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("f9186cb9-4552-4adc-808f-41028b155de7"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("00a7aa42-4956-4144-ac1e-49d7507935fb"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("2692b5e7-48a9-41ca-a5b3-68dd1d3fdc67"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("2d4fb3bf-6345-4420-9f72-b13709adc481"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("3011c9dc-c1dd-4de2-9c58-44f7dfdffdf5"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("229dfb3a-41d5-4b33-98af-bbdea42b2917"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("26dddab3-71d0-425e-bf53-c690810b3c1e"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("88cbdded-52ea-4590-90c4-9a1480eeaf5f"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("8c69cade-d500-47b1-a4f3-c683e3a13ba9"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("b08b37c7-ab45-41c1-a6c5-3331fe05a389"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("0f5e9113-cf19-43ce-8683-fe5bde2e172f"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("14f7b6db-8cb7-4dc7-9140-e648c1e0200f"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("562c8622-170e-4cda-aeef-1ad7bc80b056"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("cf1ce500-bf2c-40ac-9164-0964050acb16"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("f16ad1b0-8fb8-426c-bd1d-7532d9556693"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("8fdeb8de-f8c0-48f1-81f9-6fbd9e9b14d1"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("9698eaf0-e860-408d-af0e-41b3e5c0d974"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("b697daf5-c362-47ae-884d-ef922a6124b6"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("e51060b8-6df3-418f-a953-3c8e19d8611c"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("f0209fd3-3690-401f-85d8-fadd1e69dc98"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("285ef3de-5ebf-4234-8b4f-5adf881f477c"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("8963cf36-4968-4dab-86b8-0ae99f5d6afb"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("d56bb85f-0a93-4603-81a1-7bbccc3b8bbd"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("e5ee995b-0515-437b-af2b-021b3999f04e"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("f905ee09-f927-4b28-8b24-e41461c1d69c"));

            migrationBuilder.DeleteData(
                table: "OwnerRequests",
                keyColumn: "Id",
                keyValue: new Guid("3616a67e-a293-4080-b559-2734ef4b26c5"));

            migrationBuilder.DeleteData(
                table: "OwnerRequests",
                keyColumn: "Id",
                keyValue: new Guid("da28b2ba-351c-461e-8eac-e1541ba23df3"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("2fed782a-65ee-4dbf-af6c-1015dce6b89a"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("0f1cd0fc-8ad0-44ff-b4f6-85c54fa14584"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("ac98bb8d-0b4e-460c-88a4-1306688cc7d2"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("b6d58c2e-4cef-4f1b-9101-30ad21e73c3c"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("cd79249f-b957-47d1-b0bc-f870664f252f"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("f3726f55-ad24-46b2-8fe7-6b890df55087"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("33a12904-d179-4fc7-9f57-13c04335b259"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("35cdcc2c-cf29-458d-8d92-fb5767f9b5df"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("5e06f35e-a61f-4b22-aa56-910a1956b2a5"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("033f8f85-85e3-4e78-8efb-0135849857e8"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("139c49a9-0ff6-4b52-a283-d014514792e2"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("25dace77-78a7-4370-a485-51042a8ad357"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("b5b8802a-9b3e-499c-9448-c9a9ba5e4792"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("d38cfe25-aa02-4f5d-9e9e-86383269178a"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("19016315-3178-4487-ad0c-851e8b9de85c"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("96294cba-b087-4e06-afcc-09ae89326264"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("dcb65dd0-396f-4b9d-918a-b5ca480d502e"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("de081216-3d4d-45aa-8604-64da807d759d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("02a10442-2f78-45ec-9645-e613773022a3"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("4f717e84-c7b0-45d6-a67d-493a5cec466b"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("5ae2c584-60f1-4224-9b00-5e8110d6765f"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("d005daa5-e829-4abd-85a8-20efd0199a68"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("e89a3fa6-2960-4912-b5cb-2e2273c68c46"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("fd6fd8a6-7b8c-482b-83ac-18ce9286e020"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("0b0be983-1078-4517-8634-1dedc714ec2e"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("43f52bef-9141-4c61-869a-68c3aa075af2"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("559cee37-76d5-4e7d-8c36-53c7e07f536e"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("8df1aa58-3e2a-43f5-838d-4a0d2781fdeb"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("e5438395-034e-4218-818b-25f094de5de8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("56cb77da-2755-4d83-82ce-b871c5dde728"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("3849dad3-9602-4bee-a662-73f61c3cce9c"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("41316de2-357c-4bb4-bf69-f27a0db075d4"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("814c420b-79bb-4480-9527-6f766091c10b"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("fd7554ca-07bf-4071-8b6b-1706efddc0a8"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("9d393735-486f-4fb5-a6e3-25903b87dbd4"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("f40fe6be-399d-4958-a7d1-9ebd7bb1add9"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("4104dfff-0095-4809-af29-b1060c392f98"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("715682e4-c6d3-4951-ad6a-de65071c3195"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("aab2d13b-3b63-4b4c-ad40-029ea7511e89"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("d0ce7470-48da-4feb-92da-3357f459336b"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("5a53818b-25ee-4cb0-8e47-e608d7622a3c"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("a599d0d0-b91b-49e9-987b-33b76bec2bd8"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("2eb5989f-e853-4cde-a066-b29e81203094"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("a4e6b90b-e340-4179-9317-c79dd10416ee"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("897b78b3-3bf0-4603-9a0f-36a5bdd68bf9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8bee70de-c040-4d03-bb6b-8f7977f601b2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4ac51bb6-dd49-46ea-95e2-985fae562fb5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8605afea-13fe-4aea-a9e9-6d1f80bdfde0"));

            migrationBuilder.AlterColumn<string>(
                name: "BankName",
                table: "Wallets",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "BankAccount",
                table: "Wallets",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("30886b71-dd3f-4cae-a58d-50bfc5a92f1f"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner3@rallyhub.vn", "Trần", false, "Phú", "hashed_pw_6", "0900000006", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4aa5fd98-ca48-4d56-ae76-ade3a9fa7e5a"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "admin@rallyhub.vn", "Quản", false, "Trị", "hashed_pw_1", "0900000001", "Admin", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("68db079b-dd4b-4a9e-a221-f7a325ace3e3"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner1@rallyhub.vn", "Minh", false, "Tuấn", "hashed_pw_2", "0900000002", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d585a375-f860-4a1a-9579-c9cd0993958e"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer1@gmail.com", "Lan", false, "Phương", "hashed_pw_4", "0900000004", "Customer", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d5945ed9-aa4a-497a-9c98-43b60c6bbd37"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner2@rallyhub.vn", "Hải", false, "Đăng", "hashed_pw_3", "0900000003", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fe1ac37d-09fe-4bd1-87f3-f36d3da6e852"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer2@gmail.com", "Bảo", false, "Châu", "hashed_pw_5", "0900000005", "Customer", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("2020bb1d-e780-40a0-aefd-312f302b8037"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d585a375-f860-4a1a-9579-c9cd0993958e") },
                    { new Guid("778096ca-cb1b-4118-b113-d1796836b8f0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("fe1ac37d-09fe-4bd1-87f3-f36d3da6e852") }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("a1a15e8d-cda7-4770-8347-b9d770691768"), "Tôn Đức Thắng, HCM", null, "Sân Cầu Lông Trần Phú", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, false, "98765434219", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("30886b71-dd3f-4cae-a58d-50bfc5a92f1f") },
                    { new Guid("dc0126f1-6a64-4296-8f18-598539829809"), "123 Nguyễn Huệ, Q1, HCM", null, "Sân Cầu Lông Minh Tuấn", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, false, "0123456789", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("68db079b-dd4b-4a9e-a221-f7a325ace3e3") },
                    { new Guid("f1808653-58c9-437d-90a5-69bce2f524a2"), "456 Lê Lợi, Q3, HCM", null, "Trung Tâm Thể Thao Hải Đăng", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, false, "9876543210", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d5945ed9-aa4a-497a-9c98-43b60c6bbd37") }
                });

            migrationBuilder.InsertData(
                table: "SystemReports",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("6ed68149-a097-452a-b12e-61dc98fb41a8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Bản đồ không load được trên iOS.", "Resolved", "Lỗi hiển thị bản đồ", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d5945ed9-aa4a-497a-9c98-43b60c6bbd37") },
                    { new Guid("7687b464-4d55-4b81-856e-c827ef6eb421"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "OTP không gửi đến số điện thoại.", "Pending", "Không nhận được OTP", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d585a375-f860-4a1a-9579-c9cd0993958e") },
                    { new Guid("858d9ca4-12fc-40e9-b763-050c863fd330"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Crash khi mở trang tìm kiếm sân.", "Pending", "App bị crash", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d585a375-f860-4a1a-9579-c9cd0993958e") },
                    { new Guid("97b54716-c09d-4807-813c-b35d7e18ef1e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Không thể thanh toán qua ví.", "Pending", "Lỗi thanh toán", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("68db079b-dd4b-4a9e-a221-f7a325ace3e3") },
                    { new Guid("cfb70a2c-9207-4902-b7fe-8057bd5d12f8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Số dư hiển thị không khớp lịch sử.", "Resolved", "Sai số dư sau giao dịch", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("fe1ac37d-09fe-4bd1-87f3-f36d3da6e852") }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version" },
                values: new object[,]
                {
                    { new Guid("42f59242-6dce-493d-a970-5e14eb5549ef"), 2000000m, "4567890123", "MB Bank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d585a375-f860-4a1a-9579-c9cd0993958e"), 0 },
                    { new Guid("ade8c857-d19a-438b-9383-21015b35ac81"), 8500000m, "3456789012", "BIDV", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d5945ed9-aa4a-497a-9c98-43b60c6bbd37"), 0 },
                    { new Guid("b77f368d-8f7f-41e4-821b-eeb31cb7844a"), 12000000m, "2345678901", "Techcombank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("68db079b-dd4b-4a9e-a221-f7a325ace3e3"), 0 },
                    { new Guid("d3e57436-15ec-4f48-a7e3-3a62b71ea683"), 3500000m, "5678901234", "VPBank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("fe1ac37d-09fe-4bd1-87f3-f36d3da6e852"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount" },
                values: new object[,]
                {
                    { new Guid("09641cfb-d018-484b-b13f-ba2d55b6e190"), "YEUTH", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 30000m, 100000m, new Guid("dc0126f1-6a64-4296-8f18-598539829809"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 500, 87 },
                    { new Guid("35190de6-c47e-41ed-b57c-a1d19bee660f"), "NEWUSER", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 20m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 100000m, 300000m, new Guid("f1808653-58c9-437d-90a5-69bce2f524a2"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 50, 5 },
                    { new Guid("7fea04fe-77ae-4e2d-a854-ee489ed3b610"), "FLASH50", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 50m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 200000m, 500000m, new Guid("dc0126f1-6a64-4296-8f18-598539829809"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10, 10 },
                    { new Guid("8858e82e-ac7b-45e4-b2d0-a69ef7f5b3f6"), "SUMMER25", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 50000m, 200000m, new Guid("dc0126f1-6a64-4296-8f18-598539829809"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 100, 12 },
                    { new Guid("90353021-6ff7-4e23-9b9e-dbe9acf6d5c3"), "LOYAL5", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 30000m, 100000m, new Guid("f1808653-58c9-437d-90a5-69bce2f524a2"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 500, 87 },
                    { new Guid("d1632b2c-7300-4b0f-a43e-3e9c0432e66e"), "WEEKEND10", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 15m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 75000m, 250000m, new Guid("f1808653-58c9-437d-90a5-69bce2f524a2"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 200, 30 }
                });

            migrationBuilder.InsertData(
                table: "Courts",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "TimeRefundBefor", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("53a1d082-c62a-482f-b3ea-11f40cf5fa3b"), "456 Lê Lợi, Q3, HCM", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.78m, 106.69m, "https://maps.google.com/?q=10.78,106.69", "Sân D - Hải Đăng", new TimeOnly(5, 30, 0), new Guid("f1808653-58c9-437d-90a5-69bce2f524a2"), "https://images.example.com/courts/go-vap.jpg", "Active", 120, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7a8d6363-4399-4d61-8167-84269ec23b98"), "456 Lê Lợi, Q3, HCM", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.78m, 106.69m, "https://maps.google.com/?q=10.78,106.69", "Sân C - Hải Đăng", new TimeOnly(5, 30, 0), new Guid("f1808653-58c9-437d-90a5-69bce2f524a2"), "https://images.example.com/courts/go-vap.jpg", "Active", 120, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("81f641cb-0e92-4145-b498-04ae4ec03b37"), "123 Nguyễn Huệ, Q1, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.77m, 106.70m, "https://maps.google.com/?q=10.77,106.70", "Sân A - Minh Tuấn", new TimeOnly(6, 0, 0), new Guid("dc0126f1-6a64-4296-8f18-598539829809"), "https://images.example.com/courts/go-vap.jpg", "Active", 120, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b89327af-3e97-44e6-b57b-16594c55e132"), "123 Nguyễn Huệ, Q1, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.77m, 106.70m, "https://maps.google.com/?q=10.77,106.70", "Sân B - Minh Tuấn", new TimeOnly(6, 0, 0), new Guid("dc0126f1-6a64-4296-8f18-598539829809"), "https://images.example.com/courts/go-vap.jpg", "Active", 120, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "OwnerRequests",
                columns: new[] { "Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "CustomerId", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "OwnerId", "RejectionReason", "Status", "TaxCode", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("7f53ecb5-a3cc-4c0d-95a4-ac81b97cdc5d"), "123 Nguyễn Huệ, Q1, HCM", "https://cdn.rallyhub.vn/license/1.jpg", "Sân Cầu Lông Minh Tuấn", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2020bb1d-e780-40a0-aefd-312f302b8037"), "https://cdn.rallyhub.vn/cccd/1_back.jpg", "https://cdn.rallyhub.vn/cccd/1_front.jpg", "079200012345", false, new Guid("dc0126f1-6a64-4296-8f18-598539829809"), null, "Approved", "0123456789", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ef16ec32-41a7-4abf-bbf4-e5db6b5d1883"), "456 Lê Lợi, Q3, HCM", "https://cdn.rallyhub.vn/license/2.jpg", "Trung Tâm Thể Thao Hải Đăng", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("778096ca-cb1b-4118-b113-d1796836b8f0"), "https://cdn.rallyhub.vn/cccd/2_back.jpg", "https://cdn.rallyhub.vn/cccd/2_front.jpg", "079200054321", false, new Guid("f1808653-58c9-437d-90a5-69bce2f524a2"), null, "Approved", "9876543210", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3a4bf737-c2d3-4569-9223-c87d44e5fe50"), new Guid("8858e82e-ac7b-45e4-b2d0-a69ef7f5b3f6"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2020bb1d-e780-40a0-aefd-312f302b8037"), 20000m, 180000m, false, "Complete", 200000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("63515337-1e90-4305-83b6-dec5c997a7bb"), new Guid("35190de6-c47e-41ed-b57c-a1d19bee660f"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("778096ca-cb1b-4118-b113-d1796836b8f0"), 40000m, 360000m, false, "Banked", 400000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6bd19037-1fa5-4df5-8740-d4cbb92ca3db"), new Guid("8858e82e-ac7b-45e4-b2d0-a69ef7f5b3f6"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2020bb1d-e780-40a0-aefd-312f302b8037"), 30000m, 270000m, false, "Banked", 300000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("84555fcb-380b-414e-b886-a97bfa815e10"), new Guid("35190de6-c47e-41ed-b57c-a1d19bee660f"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("778096ca-cb1b-4118-b113-d1796836b8f0"), 0m, 150000m, false, "Complete", 150000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a720d251-54f4-4e2e-8aad-5598cfb75c2d"), new Guid("35190de6-c47e-41ed-b57c-a1d19bee660f"), "Khách huỷ", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("778096ca-cb1b-4118-b113-d1796836b8f0"), 50000m, 200000m, false, "Cancel", 250000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "CampaignCourts",
                columns: new[] { "Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("6084f441-6e97-4658-be8b-285a727188ec"), new Guid("8858e82e-ac7b-45e4-b2d0-a69ef7f5b3f6"), new Guid("7a8d6363-4399-4d61-8167-84269ec23b98"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("823aa459-6f60-4056-ae4b-e5ef8b4f51a9"), new Guid("35190de6-c47e-41ed-b57c-a1d19bee660f"), new Guid("b89327af-3e97-44e6-b57b-16594c55e132"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d7bb6ec1-9968-4763-9d49-871aa0f43739"), new Guid("8858e82e-ac7b-45e4-b2d0-a69ef7f5b3f6"), new Guid("53a1d082-c62a-482f-b3ea-11f40cf5fa3b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f3de4700-57d1-42a9-9e56-698a7b333b13"), new Guid("35190de6-c47e-41ed-b57c-a1d19bee660f"), new Guid("81f641cb-0e92-4145-b498-04ae4ec03b37"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "LikeListDetails",
                columns: new[] { "Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0230bea2-8a61-4c98-9813-6451d84d6c8e"), new Guid("81f641cb-0e92-4145-b498-04ae4ec03b37"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2020bb1d-e780-40a0-aefd-312f302b8037"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("037eaec1-42c5-4180-8d70-1375c7d82f25"), new Guid("81f641cb-0e92-4145-b498-04ae4ec03b37"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("778096ca-cb1b-4118-b113-d1796836b8f0"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6f6c11b4-7029-498d-a826-5e934b1afde1"), new Guid("7a8d6363-4399-4d61-8167-84269ec23b98"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("778096ca-cb1b-4118-b113-d1796836b8f0"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b71573c7-c482-4774-9449-a43b389878bd"), new Guid("53a1d082-c62a-482f-b3ea-11f40cf5fa3b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("778096ca-cb1b-4118-b113-d1796836b8f0"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f64de563-a40d-43e3-870c-d4e27dac841e"), new Guid("b89327af-3e97-44e6-b57b-16594c55e132"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2020bb1d-e780-40a0-aefd-312f302b8037"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "SubCourts",
                columns: new[] { "Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("328fa327-8284-4059-8bdb-814a1b921b11"), new Guid("7a8d6363-4399-4d61-8167-84269ec23b98"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ C2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("54898581-e339-499b-8188-bb721bc860f2"), new Guid("53a1d082-c62a-482f-b3ea-11f40cf5fa3b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ D1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6c567abb-6b18-4451-a0d2-16928eed364d"), new Guid("81f641cb-0e92-4145-b498-04ae4ec03b37"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ A1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7f008e3a-c1e7-415b-bef6-914ec0d098b1"), new Guid("81f641cb-0e92-4145-b498-04ae4ec03b37"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ A2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("88d87a5f-5add-4500-b841-631f37c8ec4b"), new Guid("7a8d6363-4399-4d61-8167-84269ec23b98"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ C1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9194d8f8-27ba-4389-a16e-d2bb6bdb5792"), new Guid("53a1d082-c62a-482f-b3ea-11f40cf5fa3b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ D2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("92e7833d-9ac6-4430-988d-2e7dc980994a"), new Guid("b89327af-3e97-44e6-b57b-16594c55e132"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ B2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f47fd4d8-d6c0-4bce-9b2a-5c45d565b350"), new Guid("b89327af-3e97-44e6-b57b-16594c55e132"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ B1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "BookingDetails",
                columns: new[] { "Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "Status", "SubCourtId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("021d5285-9a9b-437b-a38c-4bb176ee1fb6"), new Guid("63515337-1e90-4305-83b6-dec5c997a7bb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 7, 16, 33, 40, 964, DateTimeKind.Unspecified).AddTicks(7698), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 150000m, new TimeOnly(9, 0, 0), "Banked", new Guid("7f008e3a-c1e7-415b-bef6-914ec0d098b1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("25243b69-b82c-49de-9364-32519bf6a432"), new Guid("3a4bf737-c2d3-4569-9223-c87d44e5fe50"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 1, 16, 33, 40, 964, DateTimeKind.Unspecified).AddTicks(7623), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 100000m, new TimeOnly(8, 0, 0), "Banked", new Guid("6c567abb-6b18-4451-a0d2-16928eed364d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("81e7c450-6cc9-490f-85db-31d498537db9"), new Guid("a720d251-54f4-4e2e-8aad-5598cfb75c2d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 3, 16, 33, 40, 964, DateTimeKind.Unspecified).AddTicks(7682), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 150000m, new TimeOnly(6, 0, 0), "Cancel", new Guid("54898581-e339-499b-8188-bb721bc860f2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("917115d4-a015-43b1-b1a2-bf89f9124bce"), new Guid("84555fcb-380b-414e-b886-a97bfa815e10"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 3, 16, 33, 40, 964, DateTimeKind.Unspecified).AddTicks(7678), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 150000m, new TimeOnly(7, 0, 0), "Banked", new Guid("88d87a5f-5add-4500-b841-631f37c8ec4b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("eb6b8502-7ffb-47ad-a23d-4ad9fa139eb1"), new Guid("6bd19037-1fa5-4df5-8740-d4cbb92ca3db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 1, 16, 33, 40, 964, DateTimeKind.Unspecified).AddTicks(7673), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 100000m, new TimeOnly(6, 0, 0), "Banked", new Guid("f47fd4d8-d6c0-4bce-9b2a-5c45d565b350"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ConfigSlots",
                columns: new[] { "Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("04560c38-ade2-4812-8cb5-1435475ede73"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 50000m, new TimeOnly(8, 30, 0), new Guid("6c567abb-6b18-4451-a0d2-16928eed364d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("058966ae-36d2-4edf-8018-55301bc7a285"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 50000m, new TimeOnly(8, 0, 0), new Guid("6c567abb-6b18-4451-a0d2-16928eed364d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("06cc4db9-ac36-451e-a127-bf7ce2445072"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 50000m, new TimeOnly(9, 0, 0), new Guid("6c567abb-6b18-4451-a0d2-16928eed364d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("07c2b936-4706-4b79-9fb3-969fe4b90a8e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 100000m, new TimeOnly(6, 0, 0), new Guid("54898581-e339-499b-8188-bb721bc860f2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("07ffa555-755f-49e2-a5ea-776f696d675b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 70000m, new TimeOnly(9, 30, 0), new Guid("f47fd4d8-d6c0-4bce-9b2a-5c45d565b350"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("0f2b1ce8-6a11-4cba-9096-cb8a3216efb0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 35000m, new TimeOnly(7, 30, 0), new Guid("88d87a5f-5add-4500-b841-631f37c8ec4b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("185aad1f-02b4-4712-9de5-1249dc958194"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 35000m, new TimeOnly(9, 30, 0), new Guid("88d87a5f-5add-4500-b841-631f37c8ec4b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("34c42bec-5ba2-411c-b239-e0a88cadab64"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 70000m, new TimeOnly(6, 0, 0), new Guid("f47fd4d8-d6c0-4bce-9b2a-5c45d565b350"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3d769360-bbe0-489e-8573-42a0bf2e97a2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 100000m, new TimeOnly(6, 30, 0), new Guid("54898581-e339-499b-8188-bb721bc860f2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4b4f72e7-725d-42d4-a37c-bb6bd8f599ef"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 35000m, new TimeOnly(8, 0, 0), new Guid("88d87a5f-5add-4500-b841-631f37c8ec4b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("58de11cc-3d1f-43bd-8400-145db7fd1445"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 100000m, new TimeOnly(9, 0, 0), new Guid("54898581-e339-499b-8188-bb721bc860f2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5bdcd989-ed99-47ac-af06-a4fdff47ca2b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 70000m, new TimeOnly(7, 30, 0), new Guid("f47fd4d8-d6c0-4bce-9b2a-5c45d565b350"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("62eb9d4c-fc48-47d1-a519-b58970a02851"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 100000m, new TimeOnly(8, 30, 0), new Guid("54898581-e339-499b-8188-bb721bc860f2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("69a5c421-2084-4958-b380-7a8f52071c5c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 35000m, new TimeOnly(8, 30, 0), new Guid("88d87a5f-5add-4500-b841-631f37c8ec4b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6bef2e3f-14ba-4daf-b4f2-8485081c6bd2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 50000m, new TimeOnly(9, 30, 0), new Guid("6c567abb-6b18-4451-a0d2-16928eed364d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6da95394-766a-4ddb-b054-9ec1a541cf30"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 50000m, new TimeOnly(7, 0, 0), new Guid("6c567abb-6b18-4451-a0d2-16928eed364d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7d06a0ab-31f7-48c6-8ab3-5e6f3525b869"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 100000m, new TimeOnly(7, 0, 0), new Guid("54898581-e339-499b-8188-bb721bc860f2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7e8b9c2d-54c9-4045-85b8-0b02cc509436"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 70000m, new TimeOnly(8, 30, 0), new Guid("f47fd4d8-d6c0-4bce-9b2a-5c45d565b350"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8a4381ac-2bf2-4a73-8f43-1534152c410d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 50000m, new TimeOnly(6, 30, 0), new Guid("6c567abb-6b18-4451-a0d2-16928eed364d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8a754e5c-2008-4b45-b245-d4c835e1bee1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 35000m, new TimeOnly(9, 0, 0), new Guid("88d87a5f-5add-4500-b841-631f37c8ec4b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8bda2a55-81d5-4d11-bbdf-d17309bb9d0e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 100000m, new TimeOnly(9, 30, 0), new Guid("54898581-e339-499b-8188-bb721bc860f2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9eb76151-30fe-4e1e-9509-96fe26b87344"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 70000m, new TimeOnly(7, 0, 0), new Guid("f47fd4d8-d6c0-4bce-9b2a-5c45d565b350"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9edb5cd5-83c8-4347-b9cc-b6f606f8a1a8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 35000m, new TimeOnly(7, 0, 0), new Guid("88d87a5f-5add-4500-b841-631f37c8ec4b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a215510e-6f6a-48c7-81aa-6c34180f64f0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 70000m, new TimeOnly(8, 0, 0), new Guid("f47fd4d8-d6c0-4bce-9b2a-5c45d565b350"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("adc9a0bf-747e-4f79-ad3b-98af961ed8f8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 70000m, new TimeOnly(6, 30, 0), new Guid("f47fd4d8-d6c0-4bce-9b2a-5c45d565b350"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("aecf03da-e5f4-462a-b8a5-19a19f7d1a6a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 100000m, new TimeOnly(7, 30, 0), new Guid("54898581-e339-499b-8188-bb721bc860f2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cdfb3c9b-3d19-4e84-87a5-68c30fa1fc98"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 50000m, new TimeOnly(7, 30, 0), new Guid("6c567abb-6b18-4451-a0d2-16928eed364d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d884b914-4f08-4923-bcce-29df6407abd5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 50000m, new TimeOnly(6, 0, 0), new Guid("6c567abb-6b18-4451-a0d2-16928eed364d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("db21cbf1-43f4-42f1-90a0-b340302a14b8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 35000m, new TimeOnly(6, 30, 0), new Guid("88d87a5f-5add-4500-b841-631f37c8ec4b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e524233b-d021-48bb-a33d-7e740222f229"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 35000m, new TimeOnly(6, 0, 0), new Guid("88d87a5f-5add-4500-b841-631f37c8ec4b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ef995324-37e7-4e38-96b8-4da797d02ae4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 100000m, new TimeOnly(8, 0, 0), new Guid("54898581-e339-499b-8188-bb721bc860f2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f08c6e3d-f138-4c4c-9beb-893b2c0216d1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 70000m, new TimeOnly(9, 0, 0), new Guid("f47fd4d8-d6c0-4bce-9b2a-5c45d565b350"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Exceptions",
                columns: new[] { "Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0aba3ab0-d3cd-4e55-a8d0-f3e833f1bbd1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Sơn lại mặt sân", new TimeOnly(12, 0, 0), new Guid("f47fd4d8-d6c0-4bce-9b2a-5c45d565b350"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("1c1f2040-bd1a-4a7b-9c1d-34c766e57a3c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Tổ chức sự kiện nội bộ", new TimeOnly(12, 0, 0), new Guid("54898581-e339-499b-8188-bb721bc860f2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("46e99a62-47a5-4ddb-80d2-08512176c532"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Bảo trì định kỳ", new TimeOnly(12, 0, 0), new Guid("6c567abb-6b18-4451-a0d2-16928eed364d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7d084e54-299b-4654-be78-1fa05b58b6ce"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Hỏng đèn chiếu sáng", new TimeOnly(12, 0, 0), new Guid("88d87a5f-5add-4500-b841-631f37c8ec4b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("20c10436-5a4b-4c7b-b604-f7f6c8a17ab9"), new Guid("84555fcb-380b-414e-b886-a97bfa815e10"), "Bình thường, sân hơi cũ.", new Guid("7a8d6363-4399-4d61-8167-84269ec23b98"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2020bb1d-e780-40a0-aefd-312f302b8037"), false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3115fef9-ce20-4d2f-88d1-e2eab201437b"), new Guid("3a4bf737-c2d3-4569-9223-c87d44e5fe50"), "Sân rất tốt, sẽ quay lại!", new Guid("81f641cb-0e92-4145-b498-04ae4ec03b37"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("778096ca-cb1b-4118-b113-d1796836b8f0"), false, 5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("437d5404-d453-4364-b104-7be6a169914f"), new Guid("63515337-1e90-4305-83b6-dec5c997a7bb"), "Đèn chiếu sáng yếu vào ban đêm.", new Guid("81f641cb-0e92-4145-b498-04ae4ec03b37"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("778096ca-cb1b-4118-b113-d1796836b8f0"), false, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d4678415-4c2d-439a-99b0-00adca82b34d"), new Guid("6bd19037-1fa5-4df5-8740-d4cbb92ca3db"), "Dịch vụ ổn, giá hợp lý.", new Guid("b89327af-3e97-44e6-b57b-16594c55e132"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("778096ca-cb1b-4118-b113-d1796836b8f0"), false, 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e6fa02b4-ea15-4441-a769-da8751cdd2b8"), new Guid("a720d251-54f4-4e2e-8aad-5598cfb75c2d"), "Nhân viên thân thiện, sân sạch.", new Guid("b89327af-3e97-44e6-b57b-16594c55e132"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2020bb1d-e780-40a0-aefd-312f302b8037"), false, 5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("46657626-d34c-452b-ab38-fb3a7082780c"), new Guid("3a4bf737-c2d3-4569-9223-c87d44e5fe50"), "Booking #1 đã được xác nhận.", new Guid("81f641cb-0e92-4145-b498-04ae4ec03b37"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Đặt sân thành công", "Booking", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("68db079b-dd4b-4a9e-a221-f7a325ace3e3") });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("626527e6-969a-4bd5-89c6-469b1c808827"), new Guid("84555fcb-380b-414e-b886-a97bfa815e10"), "Bạn có lịch chơi vào ngày mai.", new Guid("7a8d6363-4399-4d61-8167-84269ec23b98"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Nhắc nhở lịch chơi", "Remind", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d585a375-f860-4a1a-9579-c9cd0993958e") },
                    { new Guid("7112a100-9ea5-4fed-b1a9-7d8463e3ec58"), new Guid("6bd19037-1fa5-4df5-8740-d4cbb92ca3db"), "Booking #2 đã được xác nhận.", new Guid("b89327af-3e97-44e6-b57b-16594c55e132"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Đặt sân thành công", "Booking", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d5945ed9-aa4a-497a-9c98-43b60c6bbd37") },
                    { new Guid("a8b95399-fe5c-4984-a482-29d8a71e240a"), new Guid("63515337-1e90-4305-83b6-dec5c997a7bb"), "Đã hoàn 360,000đ vào ví của bạn.", new Guid("81f641cb-0e92-4145-b498-04ae4ec03b37"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Hoàn tiền", "Refund", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("68db079b-dd4b-4a9e-a221-f7a325ace3e3") }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("ae0aca67-8e5a-4b66-8b28-eed4e06a6014"), new Guid("a720d251-54f4-4e2e-8aad-5598cfb75c2d"), "Booking #4 đã bị huỷ. Tiền sẽ hoàn.", new Guid("53a1d082-c62a-482f-b3ea-11f40cf5fa3b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Huỷ booking", "Cancel", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("fe1ac37d-09fe-4bd1-87f3-f36d3da6e852") });

            migrationBuilder.InsertData(
                table: "OverideSlots",
                columns: new[] { "Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("83746032-3b46-4b14-9d5b-1b416593f800"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 2054000m, new TimeOnly(12, 0, 0), new Guid("88d87a5f-5add-4500-b841-631f37c8ec4b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8564319b-b3db-4d23-b346-f8d1cbd34f7d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 220500m, new TimeOnly(12, 0, 0), new Guid("f47fd4d8-d6c0-4bce-9b2a-5c45d565b350"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b14f6a41-93b9-48e2-8c6d-bf0d3dce4306"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 220800m, new TimeOnly(12, 0, 0), new Guid("54898581-e339-499b-8188-bb721bc860f2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c4cc1ae9-7285-40e5-a434-00a0d6b2afb1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 208400m, new TimeOnly(12, 0, 0), new Guid("6c567abb-6b18-4451-a0d2-16928eed364d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "OverideSlots",
                columns: new[] { "Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "IsRecurring", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[] { new Guid("fa5b568a-dd92-44c3-bda9-3390e37d694e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(1, 1, 1), 1, new TimeOnly(20, 0, 0), false, true, 200000m, new TimeOnly(18, 0, 0), new Guid("7f008e3a-c1e7-415b-bef6-914ec0d098b1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("17d0aa1d-e5b9-42f4-a410-c939e73ad644"), new Guid("63515337-1e90-4305-83b6-dec5c997a7bb"), new Guid("53a1d082-c62a-482f-b3ea-11f40cf5fa3b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("778096ca-cb1b-4118-b113-d1796836b8f0"), false, "Thông tin giờ mở cửa sai.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("89ae419c-8bb8-445c-a867-9ef793c37d6b"), new Guid("3a4bf737-c2d3-4569-9223-c87d44e5fe50"), new Guid("7a8d6363-4399-4d61-8167-84269ec23b98"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2020bb1d-e780-40a0-aefd-312f302b8037"), false, "Sân không đúng mô tả.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b3b43a32-c39c-4f94-bbc9-af6cb016489f"), new Guid("6bd19037-1fa5-4df5-8740-d4cbb92ca3db"), new Guid("81f641cb-0e92-4145-b498-04ae4ec03b37"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2020bb1d-e780-40a0-aefd-312f302b8037"), false, "Chủ sân thái độ không tốt.", "Resolved", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c6dd1822-36e4-4f44-a888-c49290b58dfa"), new Guid("84555fcb-380b-414e-b886-a97bfa815e10"), new Guid("b89327af-3e97-44e6-b57b-16594c55e132"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("778096ca-cb1b-4118-b113-d1796836b8f0"), false, "Cơ sở vật chất xuống cấp.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e3c8c90f-3523-4737-ba90-c9edf149838e"), new Guid("a720d251-54f4-4e2e-8aad-5598cfb75c2d"), new Guid("7a8d6363-4399-4d61-8167-84269ec23b98"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("778096ca-cb1b-4118-b113-d1796836b8f0"), false, "Không hoàn tiền khi huỷ đúng hạn.", "Rejected", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId" },
                values: new object[,]
                {
                    { new Guid("6e249960-bb82-40cf-90f9-7af283bde1bf"), "ACT004", 500000m, 2000000m, 1500000m, "5678901234", "REF004", new Guid("63515337-1e90-4305-83b6-dec5c997a7bb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP004", "SIG004", "Success", "Nạp tiền vào ví", "Deposit", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d3e57436-15ec-4f48-a7e3-3a62b71ea683") },
                    { new Guid("9484b30f-a443-4c95-a4a2-23676c2f313f"), "ACT001", 180000m, 2000000m, 2180000m, "2345678901", "REF001", new Guid("3a4bf737-c2d3-4569-9223-c87d44e5fe50"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP001", "SIG001", "Success", "Thanh toán booking #1", "Payment", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b77f368d-8f7f-41e4-821b-eeb31cb7844a") },
                    { new Guid("98d4c49a-641f-4581-9a8d-e97db8f40035"), "ACT002", 270000m, 3500000m, 3770000m, "3456789012", "REF002", new Guid("6bd19037-1fa5-4df5-8740-d4cbb92ca3db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP002", "SIG002", "Success", "Thanh toán booking #2", "Payment", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ade8c857-d19a-438b-9383-21015b35ac81") },
                    { new Guid("d8c0d7e1-6ebc-450d-a779-dff52deb290d"), "ACT003", 200000m, 2200000m, 2000000m, "4567890123", "REF003", new Guid("84555fcb-380b-414e-b886-a97bfa815e10"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP003", "SIG003", "Success", "Hoàn tiền booking #4", "Refund", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("42f59242-6dce-493d-a970-5e14eb5549ef") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("021d5285-9a9b-437b-a38c-4bb176ee1fb6"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("25243b69-b82c-49de-9364-32519bf6a432"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("81e7c450-6cc9-490f-85db-31d498537db9"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("917115d4-a015-43b1-b1a2-bf89f9124bce"));

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: new Guid("eb6b8502-7ffb-47ad-a23d-4ad9fa139eb1"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("6084f441-6e97-4658-be8b-285a727188ec"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("823aa459-6f60-4056-ae4b-e5ef8b4f51a9"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("d7bb6ec1-9968-4763-9d49-871aa0f43739"));

            migrationBuilder.DeleteData(
                table: "CampaignCourts",
                keyColumn: "Id",
                keyValue: new Guid("f3de4700-57d1-42a9-9e56-698a7b333b13"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("09641cfb-d018-484b-b13f-ba2d55b6e190"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("7fea04fe-77ae-4e2d-a854-ee489ed3b610"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("90353021-6ff7-4e23-9b9e-dbe9acf6d5c3"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("d1632b2c-7300-4b0f-a43e-3e9c0432e66e"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("04560c38-ade2-4812-8cb5-1435475ede73"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("058966ae-36d2-4edf-8018-55301bc7a285"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("06cc4db9-ac36-451e-a127-bf7ce2445072"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("07c2b936-4706-4b79-9fb3-969fe4b90a8e"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("07ffa555-755f-49e2-a5ea-776f696d675b"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("0f2b1ce8-6a11-4cba-9096-cb8a3216efb0"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("185aad1f-02b4-4712-9de5-1249dc958194"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("34c42bec-5ba2-411c-b239-e0a88cadab64"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("3d769360-bbe0-489e-8573-42a0bf2e97a2"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("4b4f72e7-725d-42d4-a37c-bb6bd8f599ef"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("58de11cc-3d1f-43bd-8400-145db7fd1445"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("5bdcd989-ed99-47ac-af06-a4fdff47ca2b"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("62eb9d4c-fc48-47d1-a519-b58970a02851"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("69a5c421-2084-4958-b380-7a8f52071c5c"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("6bef2e3f-14ba-4daf-b4f2-8485081c6bd2"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("6da95394-766a-4ddb-b054-9ec1a541cf30"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("7d06a0ab-31f7-48c6-8ab3-5e6f3525b869"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("7e8b9c2d-54c9-4045-85b8-0b02cc509436"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("8a4381ac-2bf2-4a73-8f43-1534152c410d"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("8a754e5c-2008-4b45-b245-d4c835e1bee1"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("8bda2a55-81d5-4d11-bbdf-d17309bb9d0e"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("9eb76151-30fe-4e1e-9509-96fe26b87344"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("9edb5cd5-83c8-4347-b9cc-b6f606f8a1a8"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("a215510e-6f6a-48c7-81aa-6c34180f64f0"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("adc9a0bf-747e-4f79-ad3b-98af961ed8f8"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("aecf03da-e5f4-462a-b8a5-19a19f7d1a6a"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("cdfb3c9b-3d19-4e84-87a5-68c30fa1fc98"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("d884b914-4f08-4923-bcce-29df6407abd5"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("db21cbf1-43f4-42f1-90a0-b340302a14b8"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("e524233b-d021-48bb-a33d-7e740222f229"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("ef995324-37e7-4e38-96b8-4da797d02ae4"));

            migrationBuilder.DeleteData(
                table: "ConfigSlots",
                keyColumn: "Id",
                keyValue: new Guid("f08c6e3d-f138-4c4c-9beb-893b2c0216d1"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("0aba3ab0-d3cd-4e55-a8d0-f3e833f1bbd1"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("1c1f2040-bd1a-4a7b-9c1d-34c766e57a3c"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("46e99a62-47a5-4ddb-80d2-08512176c532"));

            migrationBuilder.DeleteData(
                table: "Exceptions",
                keyColumn: "Id",
                keyValue: new Guid("7d084e54-299b-4654-be78-1fa05b58b6ce"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("20c10436-5a4b-4c7b-b604-f7f6c8a17ab9"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("3115fef9-ce20-4d2f-88d1-e2eab201437b"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("437d5404-d453-4364-b104-7be6a169914f"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("d4678415-4c2d-439a-99b0-00adca82b34d"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("e6fa02b4-ea15-4441-a769-da8751cdd2b8"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("0230bea2-8a61-4c98-9813-6451d84d6c8e"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("037eaec1-42c5-4180-8d70-1375c7d82f25"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("6f6c11b4-7029-498d-a826-5e934b1afde1"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("b71573c7-c482-4774-9449-a43b389878bd"));

            migrationBuilder.DeleteData(
                table: "LikeListDetails",
                keyColumn: "Id",
                keyValue: new Guid("f64de563-a40d-43e3-870c-d4e27dac841e"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("46657626-d34c-452b-ab38-fb3a7082780c"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("626527e6-969a-4bd5-89c6-469b1c808827"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("7112a100-9ea5-4fed-b1a9-7d8463e3ec58"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("a8b95399-fe5c-4984-a482-29d8a71e240a"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("ae0aca67-8e5a-4b66-8b28-eed4e06a6014"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("83746032-3b46-4b14-9d5b-1b416593f800"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("8564319b-b3db-4d23-b346-f8d1cbd34f7d"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("b14f6a41-93b9-48e2-8c6d-bf0d3dce4306"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("c4cc1ae9-7285-40e5-a434-00a0d6b2afb1"));

            migrationBuilder.DeleteData(
                table: "OverideSlots",
                keyColumn: "Id",
                keyValue: new Guid("fa5b568a-dd92-44c3-bda9-3390e37d694e"));

            migrationBuilder.DeleteData(
                table: "OwnerRequests",
                keyColumn: "Id",
                keyValue: new Guid("7f53ecb5-a3cc-4c0d-95a4-ac81b97cdc5d"));

            migrationBuilder.DeleteData(
                table: "OwnerRequests",
                keyColumn: "Id",
                keyValue: new Guid("ef16ec32-41a7-4abf-bbf4-e5db6b5d1883"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("a1a15e8d-cda7-4770-8347-b9d770691768"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("17d0aa1d-e5b9-42f4-a410-c939e73ad644"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("89ae419c-8bb8-445c-a867-9ef793c37d6b"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("b3b43a32-c39c-4f94-bbc9-af6cb016489f"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("c6dd1822-36e4-4f44-a888-c49290b58dfa"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("e3c8c90f-3523-4737-ba90-c9edf149838e"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("328fa327-8284-4059-8bdb-814a1b921b11"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("9194d8f8-27ba-4389-a16e-d2bb6bdb5792"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("92e7833d-9ac6-4430-988d-2e7dc980994a"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("6ed68149-a097-452a-b12e-61dc98fb41a8"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("7687b464-4d55-4b81-856e-c827ef6eb421"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("858d9ca4-12fc-40e9-b763-050c863fd330"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("97b54716-c09d-4807-813c-b35d7e18ef1e"));

            migrationBuilder.DeleteData(
                table: "SystemReports",
                keyColumn: "Id",
                keyValue: new Guid("cfb70a2c-9207-4902-b7fe-8057bd5d12f8"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("6e249960-bb82-40cf-90f9-7af283bde1bf"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("9484b30f-a443-4c95-a4a2-23676c2f313f"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("98d4c49a-641f-4581-9a8d-e97db8f40035"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("d8c0d7e1-6ebc-450d-a779-dff52deb290d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4aa5fd98-ca48-4d56-ae76-ade3a9fa7e5a"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("3a4bf737-c2d3-4569-9223-c87d44e5fe50"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("63515337-1e90-4305-83b6-dec5c997a7bb"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("6bd19037-1fa5-4df5-8740-d4cbb92ca3db"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("84555fcb-380b-414e-b886-a97bfa815e10"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("a720d251-54f4-4e2e-8aad-5598cfb75c2d"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("54898581-e339-499b-8188-bb721bc860f2"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("6c567abb-6b18-4451-a0d2-16928eed364d"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("7f008e3a-c1e7-415b-bef6-914ec0d098b1"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("88d87a5f-5add-4500-b841-631f37c8ec4b"));

            migrationBuilder.DeleteData(
                table: "SubCourts",
                keyColumn: "Id",
                keyValue: new Guid("f47fd4d8-d6c0-4bce-9b2a-5c45d565b350"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("30886b71-dd3f-4cae-a58d-50bfc5a92f1f"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("42f59242-6dce-493d-a970-5e14eb5549ef"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("ade8c857-d19a-438b-9383-21015b35ac81"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("b77f368d-8f7f-41e4-821b-eeb31cb7844a"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("d3e57436-15ec-4f48-a7e3-3a62b71ea683"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("35190de6-c47e-41ed-b57c-a1d19bee660f"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("8858e82e-ac7b-45e4-b2d0-a69ef7f5b3f6"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("53a1d082-c62a-482f-b3ea-11f40cf5fa3b"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("7a8d6363-4399-4d61-8167-84269ec23b98"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("81f641cb-0e92-4145-b498-04ae4ec03b37"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: new Guid("b89327af-3e97-44e6-b57b-16594c55e132"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("2020bb1d-e780-40a0-aefd-312f302b8037"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("778096ca-cb1b-4118-b113-d1796836b8f0"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("dc0126f1-6a64-4296-8f18-598539829809"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("f1808653-58c9-437d-90a5-69bce2f524a2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d585a375-f860-4a1a-9579-c9cd0993958e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fe1ac37d-09fe-4bd1-87f3-f36d3da6e852"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("68db079b-dd4b-4a9e-a221-f7a325ace3e3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5945ed9-aa4a-497a-9c98-43b60c6bbd37"));

            migrationBuilder.AlterColumn<string>(
                name: "BankName",
                table: "Wallets",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BankAccount",
                table: "Wallets",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("02a10442-2f78-45ec-9645-e613773022a3"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "admin@rallyhub.vn", "Quản", false, "Trị", "hashed_pw_1", "0900000001", "Admin", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4ac51bb6-dd49-46ea-95e2-985fae562fb5"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner1@rallyhub.vn", "Minh", false, "Tuấn", "hashed_pw_2", "0900000002", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("56cb77da-2755-4d83-82ce-b871c5dde728"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner3@rallyhub.vn", "Trần", false, "Phú", "hashed_pw_6", "0900000006", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8605afea-13fe-4aea-a9e9-6d1f80bdfde0"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "owner2@rallyhub.vn", "Hải", false, "Đăng", "hashed_pw_3", "0900000003", "Owner", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("897b78b3-3bf0-4603-9a0f-36a5bdd68bf9"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer2@gmail.com", "Bảo", false, "Châu", "hashed_pw_5", "0900000005", "Customer", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8bee70de-c040-4d03-bb6b-8f7977f601b2"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSZUbcFx4F7w7LahVB5sGpVUOQxBRycQa4sA&s", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer1@gmail.com", "Lan", false, "Phương", "hashed_pw_4", "0900000004", "Customer", "Active", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("5a53818b-25ee-4cb0-8e47-e608d7622a3c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("897b78b3-3bf0-4603-9a0f-36a5bdd68bf9") },
                    { new Guid("a599d0d0-b91b-49e9-987b-33b76bec2bd8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8bee70de-c040-4d03-bb6b-8f7977f601b2") }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("2eb5989f-e853-4cde-a066-b29e81203094"), "456 Lê Lợi, Q3, HCM", null, "Trung Tâm Thể Thao Hải Đăng", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, false, "9876543210", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8605afea-13fe-4aea-a9e9-6d1f80bdfde0") },
                    { new Guid("2fed782a-65ee-4dbf-af6c-1015dce6b89a"), "Tôn Đức Thắng, HCM", null, "Sân Cầu Lông Trần Phú", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, false, "98765434219", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("56cb77da-2755-4d83-82ce-b871c5dde728") },
                    { new Guid("a4e6b90b-e340-4179-9317-c79dd10416ee"), "123 Nguyễn Huệ, Q1, HCM", null, "Sân Cầu Lông Minh Tuấn", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, false, "0123456789", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4ac51bb6-dd49-46ea-95e2-985fae562fb5") }
                });

            migrationBuilder.InsertData(
                table: "SystemReports",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("033f8f85-85e3-4e78-8efb-0135849857e8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Bản đồ không load được trên iOS.", "Resolved", "Lỗi hiển thị bản đồ", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8605afea-13fe-4aea-a9e9-6d1f80bdfde0") },
                    { new Guid("139c49a9-0ff6-4b52-a283-d014514792e2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Số dư hiển thị không khớp lịch sử.", "Resolved", "Sai số dư sau giao dịch", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("897b78b3-3bf0-4603-9a0f-36a5bdd68bf9") },
                    { new Guid("25dace77-78a7-4370-a485-51042a8ad357"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Crash khi mở trang tìm kiếm sân.", "Pending", "App bị crash", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8bee70de-c040-4d03-bb6b-8f7977f601b2") },
                    { new Guid("b5b8802a-9b3e-499c-9448-c9a9ba5e4792"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Không thể thanh toán qua ví.", "Pending", "Lỗi thanh toán", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4ac51bb6-dd49-46ea-95e2-985fae562fb5") },
                    { new Guid("d38cfe25-aa02-4f5d-9e9e-86383269178a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "OTP không gửi đến số điện thoại.", "Pending", "Không nhận được OTP", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8bee70de-c040-4d03-bb6b-8f7977f601b2") }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version" },
                values: new object[,]
                {
                    { new Guid("3849dad3-9602-4bee-a662-73f61c3cce9c"), 3500000m, "5678901234", "VPBank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("897b78b3-3bf0-4603-9a0f-36a5bdd68bf9"), 0 },
                    { new Guid("41316de2-357c-4bb4-bf69-f27a0db075d4"), 8500000m, "3456789012", "BIDV", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8605afea-13fe-4aea-a9e9-6d1f80bdfde0"), 0 },
                    { new Guid("814c420b-79bb-4480-9527-6f766091c10b"), 12000000m, "2345678901", "Techcombank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4ac51bb6-dd49-46ea-95e2-985fae562fb5"), 0 },
                    { new Guid("fd7554ca-07bf-4071-8b6b-1706efddc0a8"), 2000000m, "4567890123", "MB Bank", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8bee70de-c040-4d03-bb6b-8f7977f601b2"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount" },
                values: new object[,]
                {
                    { new Guid("008170bc-6e14-4187-b052-c020fdf8e333"), "YEUTH", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 30000m, 100000m, new Guid("a4e6b90b-e340-4179-9317-c79dd10416ee"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 500, 87 },
                    { new Guid("3a5a4c23-976a-4f08-94ed-f3aa999a8839"), "FLASH50", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 50m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 200000m, 500000m, new Guid("a4e6b90b-e340-4179-9317-c79dd10416ee"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10, 10 },
                    { new Guid("5b73dafa-764d-4230-aadc-405b1b4c6c2e"), "WEEKEND10", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 15m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 75000m, 250000m, new Guid("2eb5989f-e853-4cde-a066-b29e81203094"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 200, 30 },
                    { new Guid("9d393735-486f-4fb5-a6e3-25903b87dbd4"), "NEWUSER", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 20m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 100000m, 300000m, new Guid("2eb5989f-e853-4cde-a066-b29e81203094"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 50, 5 },
                    { new Guid("f40fe6be-399d-4958-a7d1-9ebd7bb1add9"), "SUMMER25", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 50000m, 200000m, new Guid("a4e6b90b-e340-4179-9317-c79dd10416ee"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 100, 12 },
                    { new Guid("fba5cb4e-b89d-4017-aede-e0220963ca3f"), "LOYAL5", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5m, new DateTime(2026, 6, 20, 23, 59, 59, 0, DateTimeKind.Utc), false, 30000m, 100000m, new Guid("2eb5989f-e853-4cde-a066-b29e81203094"), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 500, 87 }
                });

            migrationBuilder.InsertData(
                table: "Courts",
                columns: new[] { "Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "TimeRefundBefor", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("4104dfff-0095-4809-af29-b1060c392f98"), "123 Nguyễn Huệ, Q1, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.77m, 106.70m, "https://maps.google.com/?q=10.77,106.70", "Sân A - Minh Tuấn", new TimeOnly(6, 0, 0), new Guid("a4e6b90b-e340-4179-9317-c79dd10416ee"), "https://images.example.com/courts/go-vap.jpg", "Active", 120, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("715682e4-c6d3-4951-ad6a-de65071c3195"), "456 Lê Lợi, Q3, HCM", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.78m, 106.69m, "https://maps.google.com/?q=10.78,106.69", "Sân D - Hải Đăng", new TimeOnly(5, 30, 0), new Guid("2eb5989f-e853-4cde-a066-b29e81203094"), "https://images.example.com/courts/go-vap.jpg", "Active", 120, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("aab2d13b-3b63-4b4c-ad40-029ea7511e89"), "456 Lê Lợi, Q3, HCM", new TimeOnly(23, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.78m, 106.69m, "https://maps.google.com/?q=10.78,106.69", "Sân C - Hải Đăng", new TimeOnly(5, 30, 0), new Guid("2eb5989f-e853-4cde-a066-b29e81203094"), "https://images.example.com/courts/go-vap.jpg", "Active", 120, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d0ce7470-48da-4feb-92da-3357f459336b"), "123 Nguyễn Huệ, Q1, HCM", new TimeOnly(22, 0, 0), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 10.77m, 106.70m, "https://maps.google.com/?q=10.77,106.70", "Sân B - Minh Tuấn", new TimeOnly(6, 0, 0), new Guid("a4e6b90b-e340-4179-9317-c79dd10416ee"), "https://images.example.com/courts/go-vap.jpg", "Active", 120, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "OwnerRequests",
                columns: new[] { "Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "CustomerId", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "OwnerId", "RejectionReason", "Status", "TaxCode", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3616a67e-a293-4080-b559-2734ef4b26c5"), "456 Lê Lợi, Q3, HCM", "https://cdn.rallyhub.vn/license/2.jpg", "Trung Tâm Thể Thao Hải Đăng", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5a53818b-25ee-4cb0-8e47-e608d7622a3c"), "https://cdn.rallyhub.vn/cccd/2_back.jpg", "https://cdn.rallyhub.vn/cccd/2_front.jpg", "079200054321", false, new Guid("2eb5989f-e853-4cde-a066-b29e81203094"), null, "Approved", "9876543210", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("da28b2ba-351c-461e-8eac-e1541ba23df3"), "123 Nguyễn Huệ, Q1, HCM", "https://cdn.rallyhub.vn/license/1.jpg", "Sân Cầu Lông Minh Tuấn", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a599d0d0-b91b-49e9-987b-33b76bec2bd8"), "https://cdn.rallyhub.vn/cccd/1_back.jpg", "https://cdn.rallyhub.vn/cccd/1_front.jpg", "079200012345", false, new Guid("a4e6b90b-e340-4179-9317-c79dd10416ee"), null, "Approved", "0123456789", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("4f717e84-c7b0-45d6-a67d-493a5cec466b"), new Guid("9d393735-486f-4fb5-a6e3-25903b87dbd4"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5a53818b-25ee-4cb0-8e47-e608d7622a3c"), 40000m, 360000m, false, "Banked", 400000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5ae2c584-60f1-4224-9b00-5e8110d6765f"), new Guid("f40fe6be-399d-4958-a7d1-9ebd7bb1add9"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a599d0d0-b91b-49e9-987b-33b76bec2bd8"), 20000m, 180000m, false, "Complete", 200000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d005daa5-e829-4abd-85a8-20efd0199a68"), new Guid("9d393735-486f-4fb5-a6e3-25903b87dbd4"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5a53818b-25ee-4cb0-8e47-e608d7622a3c"), 0m, 150000m, false, "Complete", 150000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e89a3fa6-2960-4912-b5cb-2e2273c68c46"), new Guid("9d393735-486f-4fb5-a6e3-25903b87dbd4"), "Khách huỷ", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5a53818b-25ee-4cb0-8e47-e608d7622a3c"), 50000m, 200000m, false, "Cancel", 250000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fd6fd8a6-7b8c-482b-83ac-18ce9286e020"), new Guid("f40fe6be-399d-4958-a7d1-9ebd7bb1add9"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a599d0d0-b91b-49e9-987b-33b76bec2bd8"), 30000m, 270000m, false, "Banked", 300000m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "CampaignCourts",
                columns: new[] { "Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("307cd329-708c-4527-a5b0-dfd389775078"), new Guid("f40fe6be-399d-4958-a7d1-9ebd7bb1add9"), new Guid("715682e4-c6d3-4951-ad6a-de65071c3195"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4546faf4-dcec-47ad-9b80-b457c19b4d64"), new Guid("9d393735-486f-4fb5-a6e3-25903b87dbd4"), new Guid("4104dfff-0095-4809-af29-b1060c392f98"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e0a81974-fb17-411a-b6d8-8ea8cf0ca657"), new Guid("9d393735-486f-4fb5-a6e3-25903b87dbd4"), new Guid("d0ce7470-48da-4feb-92da-3357f459336b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ea329199-f6ce-4388-ad86-ec7e55097f0b"), new Guid("f40fe6be-399d-4958-a7d1-9ebd7bb1add9"), new Guid("aab2d13b-3b63-4b4c-ad40-029ea7511e89"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "LikeListDetails",
                columns: new[] { "Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0f5e9113-cf19-43ce-8683-fe5bde2e172f"), new Guid("aab2d13b-3b63-4b4c-ad40-029ea7511e89"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5a53818b-25ee-4cb0-8e47-e608d7622a3c"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("14f7b6db-8cb7-4dc7-9140-e648c1e0200f"), new Guid("715682e4-c6d3-4951-ad6a-de65071c3195"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5a53818b-25ee-4cb0-8e47-e608d7622a3c"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("562c8622-170e-4cda-aeef-1ad7bc80b056"), new Guid("4104dfff-0095-4809-af29-b1060c392f98"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a599d0d0-b91b-49e9-987b-33b76bec2bd8"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cf1ce500-bf2c-40ac-9164-0964050acb16"), new Guid("4104dfff-0095-4809-af29-b1060c392f98"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5a53818b-25ee-4cb0-8e47-e608d7622a3c"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f16ad1b0-8fb8-426c-bd1d-7532d9556693"), new Guid("d0ce7470-48da-4feb-92da-3357f459336b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a599d0d0-b91b-49e9-987b-33b76bec2bd8"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "SubCourts",
                columns: new[] { "Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0b0be983-1078-4517-8634-1dedc714ec2e"), new Guid("4104dfff-0095-4809-af29-b1060c392f98"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ A1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("33a12904-d179-4fc7-9f57-13c04335b259"), new Guid("715682e4-c6d3-4951-ad6a-de65071c3195"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ D2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("35cdcc2c-cf29-458d-8d92-fb5767f9b5df"), new Guid("d0ce7470-48da-4feb-92da-3357f459336b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ B2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("43f52bef-9141-4c61-869a-68c3aa075af2"), new Guid("d0ce7470-48da-4feb-92da-3357f459336b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ B1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("559cee37-76d5-4e7d-8c36-53c7e07f536e"), new Guid("aab2d13b-3b63-4b4c-ad40-029ea7511e89"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ C1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5e06f35e-a61f-4b22-aa56-910a1956b2a5"), new Guid("aab2d13b-3b63-4b4c-ad40-029ea7511e89"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ C2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8df1aa58-3e2a-43f5-838d-4a0d2781fdeb"), new Guid("4104dfff-0095-4809-af29-b1060c392f98"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ A2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e5438395-034e-4218-818b-25f094de5de8"), new Guid("715682e4-c6d3-4951-ad6a-de65071c3195"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Sân nhỏ D1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "BookingDetails",
                columns: new[] { "Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "Status", "SubCourtId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("57189e97-6daf-468f-a951-e317d282f1d4"), new Guid("d005daa5-e829-4abd-85a8-20efd0199a68"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 3, 2, 1, 16, 692, DateTimeKind.Unspecified).AddTicks(4101), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 150000m, new TimeOnly(7, 0, 0), "Banked", new Guid("559cee37-76d5-4e7d-8c36-53c7e07f536e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("71c1a34d-ca56-449e-b6af-7408a4eaec2c"), new Guid("5ae2c584-60f1-4224-9b00-5e8110d6765f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 1, 2, 1, 16, 692, DateTimeKind.Unspecified).AddTicks(4050), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 100000m, new TimeOnly(8, 0, 0), "Banked", new Guid("0b0be983-1078-4517-8634-1dedc714ec2e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e4f528cd-bcfd-4be0-8984-18060536e18d"), new Guid("4f717e84-c7b0-45d6-a67d-493a5cec466b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 7, 2, 1, 16, 692, DateTimeKind.Unspecified).AddTicks(4163), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 150000m, new TimeOnly(9, 0, 0), "Banked", new Guid("8df1aa58-3e2a-43f5-838d-4a0d2781fdeb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e6ca9533-5896-417e-9f93-be19d0fd308f"), new Guid("fd6fd8a6-7b8c-482b-83ac-18ce9286e020"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 1, 2, 1, 16, 692, DateTimeKind.Unspecified).AddTicks(4098), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 100000m, new TimeOnly(6, 0, 0), "Banked", new Guid("43f52bef-9141-4c61-869a-68c3aa075af2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f2f57e57-3467-490a-bb64-412de6898c97"), new Guid("e89a3fa6-2960-4912-b5cb-2e2273c68c46"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 5, 3, 2, 1, 16, 692, DateTimeKind.Unspecified).AddTicks(4104), new TimeSpan(0, 7, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 150000m, new TimeOnly(6, 0, 0), "Cancel", new Guid("e5438395-034e-4218-818b-25f094de5de8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ConfigSlots",
                columns: new[] { "Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0b571135-9516-47e8-ac25-e7af6d644c46"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 50000m, new TimeOnly(9, 0, 0), new Guid("0b0be983-1078-4517-8634-1dedc714ec2e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("19957a4e-72f9-433d-846e-3c790c5b9dea"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 100000m, new TimeOnly(6, 30, 0), new Guid("e5438395-034e-4218-818b-25f094de5de8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2f5bb542-274c-4903-9f9f-bed645fdcb16"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 35000m, new TimeOnly(9, 30, 0), new Guid("559cee37-76d5-4e7d-8c36-53c7e07f536e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("311de368-2a9d-4683-a2bc-466d2d4c2cd9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 70000m, new TimeOnly(9, 30, 0), new Guid("43f52bef-9141-4c61-869a-68c3aa075af2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("340eaed3-2993-495a-b7f5-95de8cdfd447"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 100000m, new TimeOnly(9, 0, 0), new Guid("e5438395-034e-4218-818b-25f094de5de8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3a51c8d5-3386-414e-b0d7-5d96da5fbc91"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 35000m, new TimeOnly(6, 30, 0), new Guid("559cee37-76d5-4e7d-8c36-53c7e07f536e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4b06a40e-0290-4fe2-9be6-ab290929b727"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 70000m, new TimeOnly(7, 0, 0), new Guid("43f52bef-9141-4c61-869a-68c3aa075af2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("54682f55-e5b1-4aa1-a958-db64c320e32b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 35000m, new TimeOnly(8, 0, 0), new Guid("559cee37-76d5-4e7d-8c36-53c7e07f536e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5623aa4f-c3e6-4e0b-8294-82aff265d6a1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 35000m, new TimeOnly(9, 0, 0), new Guid("559cee37-76d5-4e7d-8c36-53c7e07f536e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("610ce906-da01-41da-b7e3-e02d2f3c1d0f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 50000m, new TimeOnly(7, 30, 0), new Guid("0b0be983-1078-4517-8634-1dedc714ec2e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("653cab59-3429-40b9-806b-d3f16788fbc6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 50000m, new TimeOnly(7, 0, 0), new Guid("0b0be983-1078-4517-8634-1dedc714ec2e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("668c9fa5-353b-4371-84cf-65ab2680ff66"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 100000m, new TimeOnly(8, 0, 0), new Guid("e5438395-034e-4218-818b-25f094de5de8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("747b5939-7450-4b82-a7f1-fb0d7d0643cb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 35000m, new TimeOnly(8, 30, 0), new Guid("559cee37-76d5-4e7d-8c36-53c7e07f536e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("76528a35-b341-4ad3-a72e-131d4134c4c3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 100000m, new TimeOnly(7, 30, 0), new Guid("e5438395-034e-4218-818b-25f094de5de8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("857f7a4f-4557-4e16-bde1-d3fccf6b6c4e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 50000m, new TimeOnly(8, 0, 0), new Guid("0b0be983-1078-4517-8634-1dedc714ec2e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8625fd04-9659-4e6e-adfb-3d4958de7a3c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 35000m, new TimeOnly(7, 30, 0), new Guid("559cee37-76d5-4e7d-8c36-53c7e07f536e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8c1ddebc-8035-4c7a-a2b9-64a6c3b2dc66"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 30, 0), false, 70000m, new TimeOnly(9, 0, 0), new Guid("43f52bef-9141-4c61-869a-68c3aa075af2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8f1e8980-726f-442a-be3b-5de3c13c9c89"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 0, 0), false, 70000m, new TimeOnly(7, 30, 0), new Guid("43f52bef-9141-4c61-869a-68c3aa075af2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("918e0507-0ecf-4212-9b96-43381601a742"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 50000m, new TimeOnly(9, 30, 0), new Guid("0b0be983-1078-4517-8634-1dedc714ec2e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9b9b639f-6929-49fe-8ab8-ecdb4594914d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 70000m, new TimeOnly(8, 30, 0), new Guid("43f52bef-9141-4c61-869a-68c3aa075af2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("9daab342-eac9-420d-bf35-13cb24e23c24"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 100000m, new TimeOnly(8, 30, 0), new Guid("e5438395-034e-4218-818b-25f094de5de8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("bcc8102f-7c93-4eec-bd0e-3f5f8c01f285"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 35000m, new TimeOnly(6, 0, 0), new Guid("559cee37-76d5-4e7d-8c36-53c7e07f536e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c64afa0b-2742-47d4-821d-c052c537a942"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 50000m, new TimeOnly(6, 30, 0), new Guid("0b0be983-1078-4517-8634-1dedc714ec2e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("da173c48-e017-4800-9ee4-1a12b34c77d0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(9, 0, 0), false, 50000m, new TimeOnly(8, 30, 0), new Guid("0b0be983-1078-4517-8634-1dedc714ec2e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e3c25948-df33-420c-b832-f8bbf8c9c7e2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(8, 30, 0), false, 70000m, new TimeOnly(8, 0, 0), new Guid("43f52bef-9141-4c61-869a-68c3aa075af2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e4800622-2918-4785-a48b-1aaf673b5fe6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 70000m, new TimeOnly(6, 0, 0), new Guid("43f52bef-9141-4c61-869a-68c3aa075af2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e539cdaa-e64d-41e5-ace7-db6eeae47fe7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 0, 0), false, 70000m, new TimeOnly(6, 30, 0), new Guid("43f52bef-9141-4c61-869a-68c3aa075af2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ea9a5280-f432-4aa4-a916-6724769386fb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 100000m, new TimeOnly(7, 0, 0), new Guid("e5438395-034e-4218-818b-25f094de5de8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f400c46d-68ba-4a36-9e67-b4d0d4bfdd40"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 50000m, new TimeOnly(6, 0, 0), new Guid("0b0be983-1078-4517-8634-1dedc714ec2e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f4b690cf-0d16-4a5f-be8b-6a53e669758a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(7, 30, 0), false, 35000m, new TimeOnly(7, 0, 0), new Guid("559cee37-76d5-4e7d-8c36-53c7e07f536e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f6edb168-5604-482e-a512-6ecfdddac454"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(10, 0, 0), false, 100000m, new TimeOnly(9, 30, 0), new Guid("e5438395-034e-4218-818b-25f094de5de8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f9186cb9-4552-4adc-808f-41028b155de7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new TimeOnly(6, 30, 0), false, 100000m, new TimeOnly(6, 0, 0), new Guid("e5438395-034e-4218-818b-25f094de5de8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Exceptions",
                columns: new[] { "Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00a7aa42-4956-4144-ac1e-49d7507935fb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Hỏng đèn chiếu sáng", new TimeOnly(12, 0, 0), new Guid("559cee37-76d5-4e7d-8c36-53c7e07f536e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2692b5e7-48a9-41ca-a5b3-68dd1d3fdc67"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Sơn lại mặt sân", new TimeOnly(12, 0, 0), new Guid("43f52bef-9141-4c61-869a-68c3aa075af2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2d4fb3bf-6345-4420-9f72-b13709adc481"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Tổ chức sự kiện nội bộ", new TimeOnly(12, 0, 0), new Guid("e5438395-034e-4218-818b-25f094de5de8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3011c9dc-c1dd-4de2-9c58-44f7dfdffdf5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), new TimeOnly(17, 0, 0), false, "Bảo trì định kỳ", new TimeOnly(12, 0, 0), new Guid("0b0be983-1078-4517-8634-1dedc714ec2e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("229dfb3a-41d5-4b33-98af-bbdea42b2917"), new Guid("e89a3fa6-2960-4912-b5cb-2e2273c68c46"), "Nhân viên thân thiện, sân sạch.", new Guid("d0ce7470-48da-4feb-92da-3357f459336b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a599d0d0-b91b-49e9-987b-33b76bec2bd8"), false, 5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("26dddab3-71d0-425e-bf53-c690810b3c1e"), new Guid("fd6fd8a6-7b8c-482b-83ac-18ce9286e020"), "Dịch vụ ổn, giá hợp lý.", new Guid("d0ce7470-48da-4feb-92da-3357f459336b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5a53818b-25ee-4cb0-8e47-e608d7622a3c"), false, 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("88cbdded-52ea-4590-90c4-9a1480eeaf5f"), new Guid("4f717e84-c7b0-45d6-a67d-493a5cec466b"), "Đèn chiếu sáng yếu vào ban đêm.", new Guid("4104dfff-0095-4809-af29-b1060c392f98"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5a53818b-25ee-4cb0-8e47-e608d7622a3c"), false, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8c69cade-d500-47b1-a4f3-c683e3a13ba9"), new Guid("5ae2c584-60f1-4224-9b00-5e8110d6765f"), "Sân rất tốt, sẽ quay lại!", new Guid("4104dfff-0095-4809-af29-b1060c392f98"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5a53818b-25ee-4cb0-8e47-e608d7622a3c"), false, 5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b08b37c7-ab45-41c1-a6c5-3331fe05a389"), new Guid("d005daa5-e829-4abd-85a8-20efd0199a68"), "Bình thường, sân hơi cũ.", new Guid("aab2d13b-3b63-4b4c-ad40-029ea7511e89"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a599d0d0-b91b-49e9-987b-33b76bec2bd8"), false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("8fdeb8de-f8c0-48f1-81f9-6fbd9e9b14d1"), new Guid("5ae2c584-60f1-4224-9b00-5e8110d6765f"), "Booking #1 đã được xác nhận.", new Guid("4104dfff-0095-4809-af29-b1060c392f98"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Đặt sân thành công", "Booking", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4ac51bb6-dd49-46ea-95e2-985fae562fb5") });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("9698eaf0-e860-408d-af0e-41b3e5c0d974"), new Guid("4f717e84-c7b0-45d6-a67d-493a5cec466b"), "Đã hoàn 360,000đ vào ví của bạn.", new Guid("4104dfff-0095-4809-af29-b1060c392f98"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Hoàn tiền", "Refund", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4ac51bb6-dd49-46ea-95e2-985fae562fb5") });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("b697daf5-c362-47ae-884d-ef922a6124b6"), new Guid("e89a3fa6-2960-4912-b5cb-2e2273c68c46"), "Booking #4 đã bị huỷ. Tiền sẽ hoàn.", new Guid("715682e4-c6d3-4951-ad6a-de65071c3195"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Huỷ booking", "Cancel", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("897b78b3-3bf0-4603-9a0f-36a5bdd68bf9") });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("e51060b8-6df3-418f-a953-3c8e19d8611c"), new Guid("fd6fd8a6-7b8c-482b-83ac-18ce9286e020"), "Booking #2 đã được xác nhận.", new Guid("d0ce7470-48da-4feb-92da-3357f459336b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Đặt sân thành công", "Booking", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8605afea-13fe-4aea-a9e9-6d1f80bdfde0") },
                    { new Guid("f0209fd3-3690-401f-85d8-fadd1e69dc98"), new Guid("d005daa5-e829-4abd-85a8-20efd0199a68"), "Bạn có lịch chơi vào ngày mai.", new Guid("aab2d13b-3b63-4b4c-ad40-029ea7511e89"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Nhắc nhở lịch chơi", "Remind", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8bee70de-c040-4d03-bb6b-8f7977f601b2") }
                });

            migrationBuilder.InsertData(
                table: "OverideSlots",
                columns: new[] { "Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("285ef3de-5ebf-4234-8b4f-5adf881f477c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 220800m, new TimeOnly(12, 0, 0), new Guid("e5438395-034e-4218-818b-25f094de5de8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8963cf36-4968-4dab-86b8-0ae99f5d6afb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 220500m, new TimeOnly(12, 0, 0), new Guid("43f52bef-9141-4c61-869a-68c3aa075af2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d56bb85f-0a93-4603-81a1-7bbccc3b8bbd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 208400m, new TimeOnly(12, 0, 0), new Guid("0b0be983-1078-4517-8634-1dedc714ec2e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e5ee995b-0515-437b-af2b-021b3999f04e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2026, 4, 25), 0, new TimeOnly(17, 0, 0), false, 2054000m, new TimeOnly(12, 0, 0), new Guid("559cee37-76d5-4e7d-8c36-53c7e07f536e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "OverideSlots",
                columns: new[] { "Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "IsRecurring", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt" },
                values: new object[] { new Guid("f905ee09-f927-4b28-8b24-e41461c1d69c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(1, 1, 1), 1, new TimeOnly(20, 0, 0), false, true, 200000m, new TimeOnly(18, 0, 0), new Guid("8df1aa58-3e2a-43f5-838d-4a0d2781fdeb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0f1cd0fc-8ad0-44ff-b4f6-85c54fa14584"), new Guid("d005daa5-e829-4abd-85a8-20efd0199a68"), new Guid("d0ce7470-48da-4feb-92da-3357f459336b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5a53818b-25ee-4cb0-8e47-e608d7622a3c"), false, "Cơ sở vật chất xuống cấp.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ac98bb8d-0b4e-460c-88a4-1306688cc7d2"), new Guid("4f717e84-c7b0-45d6-a67d-493a5cec466b"), new Guid("715682e4-c6d3-4951-ad6a-de65071c3195"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5a53818b-25ee-4cb0-8e47-e608d7622a3c"), false, "Thông tin giờ mở cửa sai.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b6d58c2e-4cef-4f1b-9101-30ad21e73c3c"), new Guid("5ae2c584-60f1-4224-9b00-5e8110d6765f"), new Guid("aab2d13b-3b63-4b4c-ad40-029ea7511e89"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a599d0d0-b91b-49e9-987b-33b76bec2bd8"), false, "Sân không đúng mô tả.", "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cd79249f-b957-47d1-b0bc-f870664f252f"), new Guid("e89a3fa6-2960-4912-b5cb-2e2273c68c46"), new Guid("aab2d13b-3b63-4b4c-ad40-029ea7511e89"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5a53818b-25ee-4cb0-8e47-e608d7622a3c"), false, "Không hoàn tiền khi huỷ đúng hạn.", "Rejected", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f3726f55-ad24-46b2-8fe7-6b890df55087"), new Guid("fd6fd8a6-7b8c-482b-83ac-18ce9286e020"), new Guid("4104dfff-0095-4809-af29-b1060c392f98"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a599d0d0-b91b-49e9-987b-33b76bec2bd8"), false, "Chủ sân thái độ không tốt.", "Resolved", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId" },
                values: new object[,]
                {
                    { new Guid("19016315-3178-4487-ad0c-851e8b9de85c"), "ACT003", 200000m, 2200000m, 2000000m, "4567890123", "REF003", new Guid("d005daa5-e829-4abd-85a8-20efd0199a68"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP003", "SIG003", "Success", "Hoàn tiền booking #4", "Refund", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("fd7554ca-07bf-4071-8b6b-1706efddc0a8") },
                    { new Guid("96294cba-b087-4e06-afcc-09ae89326264"), "ACT002", 270000m, 3500000m, 3770000m, "3456789012", "REF002", new Guid("fd6fd8a6-7b8c-482b-83ac-18ce9286e020"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP002", "SIG002", "Success", "Thanh toán booking #2", "Payment", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("41316de2-357c-4bb4-bf69-f27a0db075d4") },
                    { new Guid("dcb65dd0-396f-4b9d-918a-b5ca480d502e"), "ACT001", 180000m, 2000000m, 2180000m, "2345678901", "REF001", new Guid("5ae2c584-60f1-4224-9b00-5e8110d6765f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP001", "SIG001", "Success", "Thanh toán booking #1", "Payment", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("814c420b-79bb-4480-9527-6f766091c10b") },
                    { new Guid("de081216-3d4d-45aa-8604-64da807d759d"), "ACT004", 500000m, 2000000m, 1500000m, "5678901234", "REF004", new Guid("4f717e84-c7b0-45d6-a67d-493a5cec466b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "SP004", "SIG004", "Success", "Nạp tiền vào ví", "Deposit", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("3849dad3-9602-4bee-a662-73f61c3cce9c") }
                });
        }
    }
}
