using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rallyhub.Repository.Migrations
{
    /// <inheritdoc />
    public partial class update_booking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "CampaignId",
                table: "Bookings",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ExpiresAt",
                table: "Bookings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ExpiresAt",
                table: "Bookings");

            migrationBuilder.AlterColumn<Guid>(
                name: "CampaignId",
                table: "Bookings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

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
    }
}
