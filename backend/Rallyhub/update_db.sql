CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE TABLE "Users" (
        "Id" uuid NOT NULL,
        "Email" character varying(50) NOT NULL,
        "PasswordHash" character varying(100) NOT NULL,
        "Role" character varying(50) NOT NULL DEFAULT 'Customer',
        "FirstName" character varying(100) NOT NULL,
        "LastName" character varying(100) NOT NULL,
        "PhoneNumber" character varying(11),
        "Status" character varying(50) NOT NULL DEFAULT 'Active',
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Users" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE TABLE "Customers" (
        "Id" uuid NOT NULL,
        "UserId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Customers" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Customers_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE TABLE "Owners" (
        "Id" uuid NOT NULL,
        "BusinessName" character varying(500) NOT NULL,
        "TaxCode" character varying(50) NOT NULL,
        "BusinessAddress" character varying(500) NOT NULL,
        "BusinessLicenseUrl" text,
        "IdentityNumber" text,
        "IdentityCardFrontUrl" text,
        "IdentityCardBackUrl" text,
        "UserId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Owners" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Owners_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE TABLE "SystemReports" (
        "Id" uuid NOT NULL,
        "Title" character varying(50) NOT NULL,
        "Reason" character varying(500) NOT NULL,
        "Status" text NOT NULL DEFAULT 'Pending',
        "UserId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_SystemReports" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_SystemReports_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE TABLE "Wallets" (
        "Id" uuid NOT NULL,
        "BankName" character varying(50) NOT NULL,
        "BankAccount" character varying(100) NOT NULL,
        "Balance" numeric(18,2) NOT NULL DEFAULT 0.0,
        "Version" integer NOT NULL,
        "UserId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Wallets" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Wallets_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE TABLE "Campaigns" (
        "Id" uuid NOT NULL,
        "Code" character varying(50) NOT NULL,
        "IsGlobal" boolean NOT NULL DEFAULT FALSE,
        "DiscountPercent" numeric(18,2) NOT NULL,
        "MaxDiscountAmount" numeric(18,2) NOT NULL,
        "MinBookingAmount" numeric(18,2),
        "UsageLimit" integer NOT NULL,
        "UsedCount" integer NOT NULL,
        "StartDate" timestamp with time zone NOT NULL,
        "EndDate" timestamp with time zone NOT NULL,
        "OwnerId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Campaigns" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Campaigns_Owners_OwnerId" FOREIGN KEY ("OwnerId") REFERENCES "Owners" ("Id") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE TABLE "Courts" (
        "Id" uuid NOT NULL,
        "Name" character varying(50) NOT NULL,
        "Address" character varying(100) NOT NULL,
        "OpenTime" time without time zone NOT NULL,
        "CloseTime" time without time zone NOT NULL,
        "Status" character varying(50) NOT NULL DEFAULT 'Active',
        "Latitude" numeric(10,8) NOT NULL,
        "Longitude" numeric(11,8) NOT NULL,
        "MapUrl" character varying(200) NOT NULL,
        "PictureUrl" character varying(200) NOT NULL,
        "Description" text,
        "OwnerId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Courts" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Courts_Owners_OwnerId" FOREIGN KEY ("OwnerId") REFERENCES "Owners" ("Id") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE TABLE "OwnerRequests" (
        "Id" uuid NOT NULL,
        "BusinessName" character varying(500) NOT NULL,
        "TaxCode" character varying(50) NOT NULL,
        "BusinessAddress" character varying(500) NOT NULL,
        "BusinessLicenseUrl" character varying(200) NOT NULL,
        "IdentityNumber" character varying(12) NOT NULL,
        "IdentityCardFrontUrl" character varying(200) NOT NULL,
        "IdentityCardBackUrl" character varying(200) NOT NULL,
        "Status" character varying(15) NOT NULL DEFAULT 'Pending',
        "RejectionReason" character varying(200),
        "OwnerId" uuid,
        "CustomerId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_OwnerRequests" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_OwnerRequests_Customers_CustomerId" FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_OwnerRequests_Owners_OwnerId" FOREIGN KEY ("OwnerId") REFERENCES "Owners" ("Id") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE TABLE "Bookings" (
        "Id" uuid NOT NULL,
        "TotalPrice" numeric(18,2) NOT NULL,
        "DiscountAmount" numeric(18,2),
        "FinalPrice" numeric NOT NULL,
        "Status" character varying(100) NOT NULL DEFAULT 'Pending',
        "CancellationReason" character varying(500),
        "CampaignId" uuid NOT NULL,
        "CustomerId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Bookings" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Bookings_Campaigns_CampaignId" FOREIGN KEY ("CampaignId") REFERENCES "Campaigns" ("Id") ON DELETE RESTRICT,
        CONSTRAINT "FK_Bookings_Customers_CustomerId" FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("Id") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE TABLE "CampaignCourts" (
        "Id" uuid NOT NULL,
        "CourtId" uuid NOT NULL,
        "CampaignId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_CampaignCourts" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_CampaignCourts_Campaigns_CampaignId" FOREIGN KEY ("CampaignId") REFERENCES "Campaigns" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_CampaignCourts_Courts_CourtId" FOREIGN KEY ("CourtId") REFERENCES "Courts" ("Id") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE TABLE "LikeListDetails" (
        "Id" uuid NOT NULL,
        "CourtId" uuid NOT NULL,
        "CustomerId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_LikeListDetails" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_LikeListDetails_Courts_CourtId" FOREIGN KEY ("CourtId") REFERENCES "Courts" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_LikeListDetails_Customers_CustomerId" FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE TABLE "SubCourts" (
        "Id" uuid NOT NULL,
        "Name" character varying(50) NOT NULL,
        "CourtId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_SubCourts" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_SubCourts_Courts_CourtId" FOREIGN KEY ("CourtId") REFERENCES "Courts" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE TABLE "Feedbacks" (
        "Id" uuid NOT NULL,
        "Rating" integer NOT NULL,
        "Comment" character varying(500),
        "CourtId" uuid NOT NULL,
        "CustomerId" uuid NOT NULL,
        "BookingId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Feedbacks" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Feedbacks_Bookings_BookingId" FOREIGN KEY ("BookingId") REFERENCES "Bookings" ("Id") ON DELETE RESTRICT,
        CONSTRAINT "FK_Feedbacks_Courts_CourtId" FOREIGN KEY ("CourtId") REFERENCES "Courts" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_Feedbacks_Customers_CustomerId" FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("Id") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE TABLE "Notifications" (
        "Id" uuid NOT NULL,
        "BookingId" uuid NOT NULL,
        "UserId" uuid NOT NULL,
        "Title" character varying(500) NOT NULL,
        "Content" character varying(500) NOT NULL,
        "Type" character varying(10) NOT NULL,
        "IsRead" boolean NOT NULL DEFAULT FALSE,
        "CourtId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Notifications" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Notifications_Bookings_BookingId" FOREIGN KEY ("BookingId") REFERENCES "Bookings" ("Id") ON DELETE RESTRICT,
        CONSTRAINT "FK_Notifications_Courts_CourtId" FOREIGN KEY ("CourtId") REFERENCES "Courts" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_Notifications_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE TABLE "Reports" (
        "Id" uuid NOT NULL,
        "Reason" character varying(500) NOT NULL,
        "Status" text NOT NULL DEFAULT 'Pending',
        "CustomerId" uuid NOT NULL,
        "CourtId" uuid NOT NULL,
        "BookingId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Reports" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Reports_Bookings_BookingId" FOREIGN KEY ("BookingId") REFERENCES "Bookings" ("Id") ON DELETE RESTRICT,
        CONSTRAINT "FK_Reports_Courts_CourtId" FOREIGN KEY ("CourtId") REFERENCES "Courts" ("Id") ON DELETE RESTRICT,
        CONSTRAINT "FK_Reports_Customers_CustomerId" FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("Id") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE TABLE "Transactions" (
        "Id" uuid NOT NULL,
        "Type" character varying(15) NOT NULL,
        "Amount" numeric(18,2) NOT NULL,
        "BalanceBefore" numeric(18,2) NOT NULL,
        "BalanceAfter" numeric(18,2) NOT NULL,
        "SePayId" character varying(50) NOT NULL,
        "BankRefCode" character varying(50) NOT NULL,
        "BankAccountNumber" character varying(500) NOT NULL,
        "TransferContent" character varying(500) NOT NULL,
        "ActionCode" character varying(50) NOT NULL,
        "Signature" character varying(50) NOT NULL,
        "Status" text NOT NULL DEFAULT 'Success',
        "BookingId" uuid NOT NULL,
        "WalletId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Transactions" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Transactions_Bookings_BookingId" FOREIGN KEY ("BookingId") REFERENCES "Bookings" ("Id") ON DELETE RESTRICT,
        CONSTRAINT "FK_Transactions_Wallets_WalletId" FOREIGN KEY ("WalletId") REFERENCES "Wallets" ("Id") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE TABLE "BookingDetails" (
        "Id" uuid NOT NULL,
        "SubCourtId" uuid NOT NULL,
        "BookingId" uuid NOT NULL,
        "Date" timestamp with time zone NOT NULL,
        "StartTime" time NOT NULL,
        "EndTime" time NOT NULL,
        "Price" numeric(18,2) NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_BookingDetails" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_BookingDetails_Bookings_BookingId" FOREIGN KEY ("BookingId") REFERENCES "Bookings" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_BookingDetails_SubCourts_SubCourtId" FOREIGN KEY ("SubCourtId") REFERENCES "SubCourts" ("Id") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE TABLE "ConfigSlots" (
        "Id" uuid NOT NULL,
        "SubCourtDetailId" uuid NOT NULL,
        "StartTime" time NOT NULL,
        "EndTime" time NOT NULL,
        "Price" numeric(18,2) NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_ConfigSlots" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_ConfigSlots_SubCourts_SubCourtDetailId" FOREIGN KEY ("SubCourtDetailId") REFERENCES "SubCourts" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE TABLE "Exceptions" (
        "Id" uuid NOT NULL,
        "SubCourtDetailId" uuid NOT NULL,
        "Date" date NOT NULL,
        "StartTime" time NOT NULL,
        "EndTime" time NOT NULL,
        "Reason" character varying(500) NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Exceptions" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Exceptions_SubCourts_SubCourtDetailId" FOREIGN KEY ("SubCourtDetailId") REFERENCES "SubCourts" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE TABLE "OverideSlots" (
        "Id" uuid NOT NULL,
        "SubCourtDetailId" uuid NOT NULL,
        "IsRecurring" boolean NOT NULL DEFAULT FALSE,
        "DayOfWeek" integer NOT NULL,
        "Date" date NOT NULL,
        "StartTime" time NOT NULL,
        "EndTime" time NOT NULL,
        "Price" numeric(18,2) NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_OverideSlots" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_OverideSlots_SubCourts_SubCourtDetailId" FOREIGN KEY ("SubCourtDetailId") REFERENCES "SubCourts" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('2bb8cc43-6ceb-4e86-b085-528679bca6b3', TIMESTAMPTZ '-infinity', 'owner2@rallyhub.vn', 'Hải', FALSE, 'Đăng', 'hashed_pw_3', '0900000003', 'Owner', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('83b95f86-62d5-40fc-bd68-f6fd9c05ba4e', TIMESTAMPTZ '-infinity', 'admin@rallyhub.vn', 'Quản', FALSE, 'Trị', 'hashed_pw_1', '0900000001', 'Admin', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('8a3b27fa-dd6d-49b7-83b8-3e1712cc19db', TIMESTAMPTZ '-infinity', 'owner1@rallyhub.vn', 'Minh', FALSE, 'Tuấn', 'hashed_pw_2', '0900000002', 'Owner', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('a6f0c3fe-2085-4f76-bf29-7c690f0b1d6f', TIMESTAMPTZ '-infinity', 'owner3@rallyhub.vn', 'Trần', FALSE, 'Phú', 'hashed_pw_6', '0900000006', 'Owner', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('ab66bf11-307a-437d-8825-69d620e05638', TIMESTAMPTZ '-infinity', 'customer1@gmail.com', 'Lan', FALSE, 'Phương', 'hashed_pw_4', '0900000004', 'Customer', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('e381df1d-6157-4c3c-84e2-871b67db78a6', TIMESTAMPTZ '-infinity', 'customer2@gmail.com', 'Bảo', FALSE, 'Châu', 'hashed_pw_5', '0900000005', 'Customer', 'Active', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "Customers" ("Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId")
    VALUES ('2c854d5c-e88b-48dd-befd-271a5713ce50', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', 'ab66bf11-307a-437d-8825-69d620e05638');
    INSERT INTO "Customers" ("Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId")
    VALUES ('4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', 'e381df1d-6157-4c3c-84e2-871b67db78a6');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "Owners" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId")
    VALUES ('2c37b4dc-93c5-45ec-a159-1652e0be4166', '123 Nguyễn Huệ, Q1, HCM', NULL, 'Sân Cầu Lông Minh Tuấn', TIMESTAMPTZ '-infinity', NULL, NULL, NULL, FALSE, '0123456789', TIMESTAMPTZ '-infinity', '8a3b27fa-dd6d-49b7-83b8-3e1712cc19db');
    INSERT INTO "Owners" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId")
    VALUES ('b6d05ded-a3dc-4f1f-8820-f926f2c32434', 'Tôn Đức Thắng, HCM', NULL, 'Sân Cầu Lông Trần Phú', TIMESTAMPTZ '-infinity', NULL, NULL, NULL, FALSE, '98765434219', TIMESTAMPTZ '-infinity', 'a6f0c3fe-2085-4f76-bf29-7c690f0b1d6f');
    INSERT INTO "Owners" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId")
    VALUES ('fbfa9163-b847-4d0f-b7b6-239dcbd9086d', '456 Lê Lợi, Q3, HCM', NULL, 'Trung Tâm Thể Thao Hải Đăng', TIMESTAMPTZ '-infinity', NULL, NULL, NULL, FALSE, '9876543210', TIMESTAMPTZ '-infinity', '2bb8cc43-6ceb-4e86-b085-528679bca6b3');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('0ee9863b-3d52-4fda-b2e7-93c329665b36', TIMESTAMPTZ '-infinity', FALSE, 'Không thể thanh toán qua ví.', 'Pending', 'Lỗi thanh toán', TIMESTAMPTZ '-infinity', '8a3b27fa-dd6d-49b7-83b8-3e1712cc19db');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('2b040261-a690-4cd9-9701-7721fa2e4808', TIMESTAMPTZ '-infinity', FALSE, 'OTP không gửi đến số điện thoại.', 'Pending', 'Không nhận được OTP', TIMESTAMPTZ '-infinity', 'ab66bf11-307a-437d-8825-69d620e05638');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('b3668f9c-274b-4007-a4cc-608c57448a8f', TIMESTAMPTZ '-infinity', FALSE, 'Số dư hiển thị không khớp lịch sử.', 'Resolved', 'Sai số dư sau giao dịch', TIMESTAMPTZ '-infinity', 'e381df1d-6157-4c3c-84e2-871b67db78a6');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('e6c2c9ff-2c19-47e3-802c-2072cda49268', TIMESTAMPTZ '-infinity', FALSE, 'Crash khi mở trang tìm kiếm sân.', 'Pending', 'App bị crash', TIMESTAMPTZ '-infinity', 'ab66bf11-307a-437d-8825-69d620e05638');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('f68c1408-dbf3-4254-aae3-dd87bfa87f1c', TIMESTAMPTZ '-infinity', FALSE, 'Bản đồ không load được trên iOS.', 'Resolved', 'Lỗi hiển thị bản đồ', TIMESTAMPTZ '-infinity', '2bb8cc43-6ceb-4e86-b085-528679bca6b3');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('16afe692-bf8d-43ae-a28f-375a7b2fe854', 12000000.0, '2345678901', 'Techcombank', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '8a3b27fa-dd6d-49b7-83b8-3e1712cc19db', 0);
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('c6170538-b504-4ee1-af8f-ab27d415b225', 8500000.0, '3456789012', 'BIDV', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '2bb8cc43-6ceb-4e86-b085-528679bca6b3', 0);
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('f17c0bc4-4b94-4f9e-bcb3-46878e4f9f6a', 3500000.0, '5678901234', 'VPBank', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', 'e381df1d-6157-4c3c-84e2-871b67db78a6', 0);
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('fa434c49-dad2-48e0-a3ba-aeb4c0094623', 2000000.0, '4567890123', 'MB Bank', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', 'ab66bf11-307a-437d-8825-69d620e05638', 0);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('0465f92a-28a2-4e65-a117-4d2740b4d7bf', 'LOYAL5', TIMESTAMPTZ '-infinity', 5.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 30000.0, 100000.0, 'fbfa9163-b847-4d0f-b7b6-239dcbd9086d', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 500, 87);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('31378b0d-5851-4cb3-8283-897863472854', 'WEEKEND10', TIMESTAMPTZ '-infinity', 15.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 75000.0, 250000.0, 'fbfa9163-b847-4d0f-b7b6-239dcbd9086d', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 200, 30);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('b11ab76c-48a0-406c-b2fd-bdaa412ab515', 'SUMMER25', TIMESTAMPTZ '-infinity', 10.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 50000.0, 200000.0, '2c37b4dc-93c5-45ec-a159-1652e0be4166', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 100, 12);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('c54e7607-18ed-4b18-8e78-83d472fcf4be', 'NEWUSER', TIMESTAMPTZ '-infinity', 20.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 100000.0, 300000.0, 'fbfa9163-b847-4d0f-b7b6-239dcbd9086d', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 50, 5);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('c7f10bf4-3255-4934-a5cd-86ef3cea2a26', 'YEUTH', TIMESTAMPTZ '-infinity', 5.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 30000.0, 100000.0, '2c37b4dc-93c5-45ec-a159-1652e0be4166', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 500, 87);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('f2238419-bc05-4e24-a529-ad4fa031deab', 'FLASH50', TIMESTAMPTZ '-infinity', 50.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 200000.0, 500000.0, '2c37b4dc-93c5-45ec-a159-1652e0be4166', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 10, 10);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('3091f52d-4ec1-4084-b29d-fe44239b41c4', '456 Lê Lợi, Q3, HCM', TIME '23:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.78, 106.69, 'https://maps.google.com/?q=10.78,106.69', 'Sân C - Hải Đăng', TIME '05:30:00', 'fbfa9163-b847-4d0f-b7b6-239dcbd9086d', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('6c727fa5-a22e-48eb-b839-7be005527b6f', '123 Nguyễn Huệ, Q1, HCM', TIME '22:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.77, 106.7, 'https://maps.google.com/?q=10.77,106.70', 'Sân A - Minh Tuấn', TIME '06:00:00', '2c37b4dc-93c5-45ec-a159-1652e0be4166', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('a6ced920-265d-4b14-bc0f-ef8124f4577b', '456 Lê Lợi, Q3, HCM', TIME '23:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.78, 106.69, 'https://maps.google.com/?q=10.78,106.69', 'Sân D - Hải Đăng', TIME '05:30:00', 'fbfa9163-b847-4d0f-b7b6-239dcbd9086d', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('e94ededf-b3a9-4c6c-9d19-1754ac62f6f9', '123 Nguyễn Huệ, Q1, HCM', TIME '22:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.77, 106.7, 'https://maps.google.com/?q=10.77,106.70', 'Sân B - Minh Tuấn', TIME '06:00:00', '2c37b4dc-93c5-45ec-a159-1652e0be4166', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "OwnerRequests" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "CustomerId", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "OwnerId", "RejectionReason", "Status", "TaxCode", "UpdatedAt")
    VALUES ('94349f48-3bc4-46b2-bab2-2dfc971df84f', '123 Nguyễn Huệ, Q1, HCM', 'https://cdn.rallyhub.vn/license/1.jpg', 'Sân Cầu Lông Minh Tuấn', TIMESTAMPTZ '-infinity', '2c854d5c-e88b-48dd-befd-271a5713ce50', 'https://cdn.rallyhub.vn/cccd/1_back.jpg', 'https://cdn.rallyhub.vn/cccd/1_front.jpg', '079200012345', FALSE, '2c37b4dc-93c5-45ec-a159-1652e0be4166', NULL, 'Approved', '0123456789', TIMESTAMPTZ '-infinity');
    INSERT INTO "OwnerRequests" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "CustomerId", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "OwnerId", "RejectionReason", "Status", "TaxCode", "UpdatedAt")
    VALUES ('ae72f2c0-a1d5-4639-add1-21aa257d927c', '456 Lê Lợi, Q3, HCM', 'https://cdn.rallyhub.vn/license/2.jpg', 'Trung Tâm Thể Thao Hải Đăng', TIMESTAMPTZ '-infinity', '4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3', 'https://cdn.rallyhub.vn/cccd/2_back.jpg', 'https://cdn.rallyhub.vn/cccd/2_front.jpg', '079200054321', FALSE, 'fbfa9163-b847-4d0f-b7b6-239dcbd9086d', NULL, 'Approved', '9876543210', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('0c4873a0-c8ca-46b0-876a-af8ef7e7111f', 'b11ab76c-48a0-406c-b2fd-bdaa412ab515', NULL, TIMESTAMPTZ '-infinity', '2c854d5c-e88b-48dd-befd-271a5713ce50', 30000.0, 270000.0, FALSE, 'Banked', 300000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('3bdcb9d0-ef7b-4eea-a34d-b0c1aa469376', 'b11ab76c-48a0-406c-b2fd-bdaa412ab515', NULL, TIMESTAMPTZ '-infinity', '2c854d5c-e88b-48dd-befd-271a5713ce50', 20000.0, 180000.0, FALSE, 'Complete', 200000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('5189db6e-2a50-4c4c-b0b6-de4c1501ce56', 'c54e7607-18ed-4b18-8e78-83d472fcf4be', NULL, TIMESTAMPTZ '-infinity', '4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3', 40000.0, 360000.0, FALSE, 'Banked', 400000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('71aeab11-b0d7-4d5e-bcb5-5d761015597e', 'c54e7607-18ed-4b18-8e78-83d472fcf4be', 'Khách huỷ', TIMESTAMPTZ '-infinity', '4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3', 50000.0, 200000.0, FALSE, 'Cancel', 250000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('8901485b-9898-4112-8237-4463df23ba59', 'c54e7607-18ed-4b18-8e78-83d472fcf4be', NULL, TIMESTAMPTZ '-infinity', '4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3', 0.0, 150000.0, FALSE, 'Complete', 150000.0, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('2bb5078f-4302-4864-a934-2915f096e727', 'c54e7607-18ed-4b18-8e78-83d472fcf4be', '6c727fa5-a22e-48eb-b839-7be005527b6f', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('3b88c1a9-fa41-4a6a-82d4-a75ad40d1485', 'c54e7607-18ed-4b18-8e78-83d472fcf4be', 'e94ededf-b3a9-4c6c-9d19-1754ac62f6f9', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('9551358b-f4f0-4cda-85a0-fe1859ee356e', 'b11ab76c-48a0-406c-b2fd-bdaa412ab515', '3091f52d-4ec1-4084-b29d-fe44239b41c4', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('f8299f7b-d82c-423b-883e-a86d7d1d124b', 'b11ab76c-48a0-406c-b2fd-bdaa412ab515', 'a6ced920-265d-4b14-bc0f-ef8124f4577b', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('075f0057-b21c-4fa8-9070-4351b1427c7a', 'e94ededf-b3a9-4c6c-9d19-1754ac62f6f9', TIMESTAMPTZ '-infinity', '2c854d5c-e88b-48dd-befd-271a5713ce50', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('4ab5c1f0-0e73-4763-acce-a6b55ed36c24', '6c727fa5-a22e-48eb-b839-7be005527b6f', TIMESTAMPTZ '-infinity', '4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('5afc1587-4103-427b-b9aa-a3f8f29921af', '3091f52d-4ec1-4084-b29d-fe44239b41c4', TIMESTAMPTZ '-infinity', '4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('608346c8-ece0-48cd-b26c-3a2e042a3fc6', 'a6ced920-265d-4b14-bc0f-ef8124f4577b', TIMESTAMPTZ '-infinity', '4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('78a604ea-af15-4ef5-b35a-714714e56c66', '6c727fa5-a22e-48eb-b839-7be005527b6f', TIMESTAMPTZ '-infinity', '2c854d5c-e88b-48dd-befd-271a5713ce50', FALSE, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('5bd4c722-5700-48a6-b962-717b68af8d4d', 'a6ced920-265d-4b14-bc0f-ef8124f4577b', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ D1', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('62c8dcc8-d051-445c-870a-41b8afa226c0', '3091f52d-4ec1-4084-b29d-fe44239b41c4', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ C1', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('7226ea0b-efbc-4c58-b003-f5122480e7df', 'a6ced920-265d-4b14-bc0f-ef8124f4577b', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ D2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('800676e0-f4d8-4bf9-bbbe-4b020f781fda', 'e94ededf-b3a9-4c6c-9d19-1754ac62f6f9', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ B1', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('900ac525-eb92-4e29-8f97-d46222389e1d', '6c727fa5-a22e-48eb-b839-7be005527b6f', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ A1', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('e0843b76-e683-44bd-8c6a-12f091ff3fa2', 'e94ededf-b3a9-4c6c-9d19-1754ac62f6f9', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ B2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('e6ebdb58-afe4-490b-bb52-9d787fbf9cb9', '6c727fa5-a22e-48eb-b839-7be005527b6f', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ A2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('faaf79f6-9f7e-40dc-99c5-378edbc57ebb', '3091f52d-4ec1-4084-b29d-fe44239b41c4', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ C2', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtId", "UpdatedAt")
    VALUES ('4dcd68d1-0650-4453-867e-7f1a94f4e3aa', '3bdcb9d0-ef7b-4eea-a34d-b0c1aa469376', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-25T12:31:28.312972+07:00', TIME '10:00:00', FALSE, 100000.0, TIME '08:00:00', '900ac525-eb92-4e29-8f97-d46222389e1d', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtId", "UpdatedAt")
    VALUES ('5bbb6a15-ab4e-42f1-914f-efb2e66a2355', '71aeab11-b0d7-4d5e-bcb5-5d761015597e', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-27T12:31:28.31298+07:00', TIME '10:00:00', FALSE, 150000.0, TIME '06:00:00', '5bd4c722-5700-48a6-b962-717b68af8d4d', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtId", "UpdatedAt")
    VALUES ('6d01bcae-4e90-4ed8-aa6a-9d9c8eaf4d29', '5189db6e-2a50-4c4c-b0b6-de4c1501ce56', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-05-01T12:31:28.312981+07:00', TIME '10:00:00', FALSE, 150000.0, TIME '09:00:00', 'e6ebdb58-afe4-490b-bb52-9d787fbf9cb9', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtId", "UpdatedAt")
    VALUES ('8f753b07-6141-4404-8028-49dec223541b', '8901485b-9898-4112-8237-4463df23ba59', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-27T12:31:28.31298+07:00', TIME '08:00:00', FALSE, 150000.0, TIME '07:00:00', '62c8dcc8-d051-445c-870a-41b8afa226c0', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtId", "UpdatedAt")
    VALUES ('e683f292-9f36-4130-a403-e33fccf54bc5', '0c4873a0-c8ca-46b0-876a-af8ef7e7111f', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-25T12:31:28.312979+07:00', TIME '07:00:00', FALSE, 100000.0, TIME '06:00:00', '800676e0-f4d8-4bf9-bbbe-4b020f781fda', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('079c3582-f347-4933-bccb-4b840c262b0b', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 50000.0, TIME '09:00:00', '900ac525-eb92-4e29-8f97-d46222389e1d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('0bfadfa2-3691-4274-b3bb-1a6dbb1bf811', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 35000.0, TIME '06:00:00', '62c8dcc8-d051-445c-870a-41b8afa226c0', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('140db18c-adc6-417f-a515-4310641c7ea7', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 100000.0, TIME '07:00:00', '5bd4c722-5700-48a6-b962-717b68af8d4d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('20efc2a5-b1ef-43c1-8730-0c7a287a5749', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 50000.0, TIME '08:30:00', '900ac525-eb92-4e29-8f97-d46222389e1d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('4e860d98-39a0-4128-aa92-52d7b243be87', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 70000.0, TIME '06:30:00', '800676e0-f4d8-4bf9-bbbe-4b020f781fda', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('4f1eecfd-a06e-4a4c-825b-9a901f06645d', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 35000.0, TIME '06:30:00', '62c8dcc8-d051-445c-870a-41b8afa226c0', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('501d59cb-bddf-44c5-ae9e-746594d4da91', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 35000.0, TIME '07:00:00', '62c8dcc8-d051-445c-870a-41b8afa226c0', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('5081c69a-a459-41b5-adfa-caa7456ac905', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 50000.0, TIME '07:00:00', '900ac525-eb92-4e29-8f97-d46222389e1d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('58c9834a-c6ea-4b6f-8530-2e1182a9a80c', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 70000.0, TIME '07:30:00', '800676e0-f4d8-4bf9-bbbe-4b020f781fda', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('5ce3f5ae-1ad0-441f-9dbb-e497ef670d26', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 100000.0, TIME '08:30:00', '5bd4c722-5700-48a6-b962-717b68af8d4d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('5eb9cbc1-931c-4d57-a866-b0278ec11d2b', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 35000.0, TIME '08:30:00', '62c8dcc8-d051-445c-870a-41b8afa226c0', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('683a564c-7fc9-4dd4-8a9f-72eabcd5ac57', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 100000.0, TIME '09:30:00', '5bd4c722-5700-48a6-b962-717b68af8d4d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('6ce48bc5-dad2-45a7-8afe-fe29fc7b839b', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 50000.0, TIME '08:00:00', '900ac525-eb92-4e29-8f97-d46222389e1d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('73e980c2-24eb-4259-bf38-b57d0aaa43c5', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 70000.0, TIME '06:00:00', '800676e0-f4d8-4bf9-bbbe-4b020f781fda', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('78ba0aa9-d45a-422f-9171-dbff845dcb5e', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 100000.0, TIME '09:00:00', '5bd4c722-5700-48a6-b962-717b68af8d4d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('864af20b-ac6e-4633-84b5-f573dd3190bd', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 100000.0, TIME '08:00:00', '5bd4c722-5700-48a6-b962-717b68af8d4d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('96a2123b-f3b6-4f99-9d5b-f0153497fb42', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 35000.0, TIME '09:00:00', '62c8dcc8-d051-445c-870a-41b8afa226c0', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('a1ee54f8-ecf2-4222-abf6-dbbfcf3d810d', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 100000.0, TIME '07:30:00', '5bd4c722-5700-48a6-b962-717b68af8d4d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('b64ef4b4-afb4-4917-9914-5995ecc1a11a', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 35000.0, TIME '08:00:00', '62c8dcc8-d051-445c-870a-41b8afa226c0', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('be433d76-2d4a-4c8c-83e1-8daed8f8e4ef', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 50000.0, TIME '06:00:00', '900ac525-eb92-4e29-8f97-d46222389e1d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('c31af39a-6d40-47a8-9ff4-3a8026fb5daf', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 50000.0, TIME '07:30:00', '900ac525-eb92-4e29-8f97-d46222389e1d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('cae78988-ad24-40af-9b52-a44b37f7ea27', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 35000.0, TIME '07:30:00', '62c8dcc8-d051-445c-870a-41b8afa226c0', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('d116561a-c113-44f2-9cc2-f6623f62ed0e', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 100000.0, TIME '06:00:00', '5bd4c722-5700-48a6-b962-717b68af8d4d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('d185045e-4c91-4cc4-b667-94c897b5e3a1', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 70000.0, TIME '08:30:00', '800676e0-f4d8-4bf9-bbbe-4b020f781fda', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('d44fc0eb-03e5-43b9-a1e0-6635c3d6a1ed', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 70000.0, TIME '08:00:00', '800676e0-f4d8-4bf9-bbbe-4b020f781fda', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('df965cf4-e067-4aa9-b1dd-b55d59bc6821', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 50000.0, TIME '06:30:00', '900ac525-eb92-4e29-8f97-d46222389e1d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('f5af813e-1e91-49aa-9f0b-ac4cd79487f1', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 70000.0, TIME '07:00:00', '800676e0-f4d8-4bf9-bbbe-4b020f781fda', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('fa1989ed-e4d3-4831-b611-602a265b2fe8', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 50000.0, TIME '09:30:00', '900ac525-eb92-4e29-8f97-d46222389e1d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('fb108f81-339c-4c1a-90cd-2a0dde4a5d83', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 70000.0, TIME '09:30:00', '800676e0-f4d8-4bf9-bbbe-4b020f781fda', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('fb1cc836-a0fd-41ba-b24d-341797442267', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 35000.0, TIME '09:30:00', '62c8dcc8-d051-445c-870a-41b8afa226c0', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('fdc53d38-6cf3-44a4-b5c1-e3968a11033f', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 70000.0, TIME '09:00:00', '800676e0-f4d8-4bf9-bbbe-4b020f781fda', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('ff544347-ef71-493c-aa5e-fb607e8208ce', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 100000.0, TIME '06:30:00', '5bd4c722-5700-48a6-b962-717b68af8d4d', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('2d183184-15fe-4a20-aba5-83ea2fc9702f', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Tổ chức sự kiện nội bộ', TIME '12:00:00', '5bd4c722-5700-48a6-b962-717b68af8d4d', TIMESTAMPTZ '-infinity');
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('47cf10b5-55ef-4585-b4ba-3129d4247370', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Bảo trì định kỳ', TIME '12:00:00', '900ac525-eb92-4e29-8f97-d46222389e1d', TIMESTAMPTZ '-infinity');
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('d810b00d-215c-43d7-9344-db37271072c8', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Hỏng đèn chiếu sáng', TIME '12:00:00', '62c8dcc8-d051-445c-870a-41b8afa226c0', TIMESTAMPTZ '-infinity');
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('f0cc07be-0a34-48fe-a63e-36236aeed12a', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Sơn lại mặt sân', TIME '12:00:00', '800676e0-f4d8-4bf9-bbbe-4b020f781fda', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('15f70445-277b-459c-b2da-c6094a9ee8fd', '71aeab11-b0d7-4d5e-bcb5-5d761015597e', 'Nhân viên thân thiện, sân sạch.', 'e94ededf-b3a9-4c6c-9d19-1754ac62f6f9', TIMESTAMPTZ '-infinity', '2c854d5c-e88b-48dd-befd-271a5713ce50', FALSE, 5, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('52e9a8bf-9c61-47b0-baa1-508fe10d0720', '8901485b-9898-4112-8237-4463df23ba59', 'Bình thường, sân hơi cũ.', '3091f52d-4ec1-4084-b29d-fe44239b41c4', TIMESTAMPTZ '-infinity', '2c854d5c-e88b-48dd-befd-271a5713ce50', FALSE, 3, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('6490d792-e7a0-454e-97bb-e625e806025f', '5189db6e-2a50-4c4c-b0b6-de4c1501ce56', 'Đèn chiếu sáng yếu vào ban đêm.', '6c727fa5-a22e-48eb-b839-7be005527b6f', TIMESTAMPTZ '-infinity', '4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3', FALSE, 2, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('bf8194fa-9b82-48a0-9e0f-c073785be537', '0c4873a0-c8ca-46b0-876a-af8ef7e7111f', 'Dịch vụ ổn, giá hợp lý.', 'e94ededf-b3a9-4c6c-9d19-1754ac62f6f9', TIMESTAMPTZ '-infinity', '4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3', FALSE, 4, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('cb905bcd-795f-4718-b7ef-de821e35086b', '3bdcb9d0-ef7b-4eea-a34d-b0c1aa469376', 'Sân rất tốt, sẽ quay lại!', '6c727fa5-a22e-48eb-b839-7be005527b6f', TIMESTAMPTZ '-infinity', '4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3', FALSE, 5, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('0e55c478-5709-45ef-966b-799cd256e965', '0c4873a0-c8ca-46b0-876a-af8ef7e7111f', 'Booking #2 đã được xác nhận.', 'e94ededf-b3a9-4c6c-9d19-1754ac62f6f9', TIMESTAMPTZ '-infinity', FALSE, 'Đặt sân thành công', 'Booking', TIMESTAMPTZ '-infinity', '2bb8cc43-6ceb-4e86-b085-528679bca6b3');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('7df76c4e-d3ea-47b4-94dc-18cef99f5e94', '71aeab11-b0d7-4d5e-bcb5-5d761015597e', 'Booking #4 đã bị huỷ. Tiền sẽ hoàn.', 'a6ced920-265d-4b14-bc0f-ef8124f4577b', TIMESTAMPTZ '-infinity', FALSE, TRUE, 'Huỷ booking', 'Cancel', TIMESTAMPTZ '-infinity', 'e381df1d-6157-4c3c-84e2-871b67db78a6');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('83fe89b6-86ac-40a6-80e1-0c1737c0c458', '5189db6e-2a50-4c4c-b0b6-de4c1501ce56', 'Đã hoàn 360,000đ vào ví của bạn.', '6c727fa5-a22e-48eb-b839-7be005527b6f', TIMESTAMPTZ '-infinity', FALSE, 'Hoàn tiền', 'Refund', TIMESTAMPTZ '-infinity', '8a3b27fa-dd6d-49b7-83b8-3e1712cc19db');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('8d485a07-2f0a-4a43-9653-70516d909fb1', '3bdcb9d0-ef7b-4eea-a34d-b0c1aa469376', 'Booking #1 đã được xác nhận.', '6c727fa5-a22e-48eb-b839-7be005527b6f', TIMESTAMPTZ '-infinity', FALSE, TRUE, 'Đặt sân thành công', 'Booking', TIMESTAMPTZ '-infinity', '8a3b27fa-dd6d-49b7-83b8-3e1712cc19db');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('99a3b29c-412e-49ce-98c3-f9627b8499bd', '8901485b-9898-4112-8237-4463df23ba59', 'Bạn có lịch chơi vào ngày mai.', '3091f52d-4ec1-4084-b29d-fe44239b41c4', TIMESTAMPTZ '-infinity', FALSE, 'Nhắc nhở lịch chơi', 'Remind', TIMESTAMPTZ '-infinity', 'ab66bf11-307a-437d-8825-69d620e05638');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('4b5540c6-0970-4a1e-b939-3b8649f7837c', TIMESTAMPTZ '-infinity', DATE '2026-04-25', 0, TIME '17:00:00', FALSE, 208400.0, TIME '12:00:00', '900ac525-eb92-4e29-8f97-d46222389e1d', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "IsRecurring", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('75bf9b63-5f2b-439b-91dd-35291c7bab48', TIMESTAMPTZ '-infinity', DATE '-infinity', 1, TIME '20:00:00', FALSE, TRUE, 200000.0, TIME '18:00:00', 'e6ebdb58-afe4-490b-bb52-9d787fbf9cb9', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('8db0e48e-8cec-471f-b7f4-9f629a6cd54d', TIMESTAMPTZ '-infinity', DATE '2026-04-25', 0, TIME '17:00:00', FALSE, 220500.0, TIME '12:00:00', '800676e0-f4d8-4bf9-bbbe-4b020f781fda', TIMESTAMPTZ '-infinity');
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('99aedf0e-9433-4187-8d91-4addb3e7d048', TIMESTAMPTZ '-infinity', DATE '2026-04-25', 0, TIME '17:00:00', FALSE, 2054000.0, TIME '12:00:00', '62c8dcc8-d051-445c-870a-41b8afa226c0', TIMESTAMPTZ '-infinity');
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('e67ef3c8-4f24-4e8d-ba3f-41ccb138b2a6', TIMESTAMPTZ '-infinity', DATE '2026-04-25', 0, TIME '17:00:00', FALSE, 220800.0, TIME '12:00:00', '5bd4c722-5700-48a6-b962-717b68af8d4d', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('194b20ee-077d-4dc6-89c8-76c01384f9c8', '0c4873a0-c8ca-46b0-876a-af8ef7e7111f', '6c727fa5-a22e-48eb-b839-7be005527b6f', TIMESTAMPTZ '-infinity', '2c854d5c-e88b-48dd-befd-271a5713ce50', FALSE, 'Chủ sân thái độ không tốt.', 'Resolved', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('d7675c76-7cc3-454b-bcd8-6938a6fac8c1', '5189db6e-2a50-4c4c-b0b6-de4c1501ce56', 'a6ced920-265d-4b14-bc0f-ef8124f4577b', TIMESTAMPTZ '-infinity', '4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3', FALSE, 'Thông tin giờ mở cửa sai.', 'Pending', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('d93821dc-2855-4222-851a-6739b02075d4', '71aeab11-b0d7-4d5e-bcb5-5d761015597e', '3091f52d-4ec1-4084-b29d-fe44239b41c4', TIMESTAMPTZ '-infinity', '4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3', FALSE, 'Không hoàn tiền khi huỷ đúng hạn.', 'Rejected', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('f339352f-b6e8-473b-88b7-c7213ae2d510', '8901485b-9898-4112-8237-4463df23ba59', 'e94ededf-b3a9-4c6c-9d19-1754ac62f6f9', TIMESTAMPTZ '-infinity', '4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3', FALSE, 'Cơ sở vật chất xuống cấp.', 'Pending', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('fe9aef0c-5a6d-48f7-a7e1-8b7fa525975a', '3bdcb9d0-ef7b-4eea-a34d-b0c1aa469376', '3091f52d-4ec1-4084-b29d-fe44239b41c4', TIMESTAMPTZ '-infinity', '2c854d5c-e88b-48dd-befd-271a5713ce50', FALSE, 'Sân không đúng mô tả.', 'Pending', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('39dcedba-942d-4981-a914-02db1de86c8e', 'ACT004', 500000.0, 2000000.0, 1500000.0, '5678901234', 'REF004', '5189db6e-2a50-4c4c-b0b6-de4c1501ce56', TIMESTAMPTZ '-infinity', FALSE, 'SP004', 'SIG004', 'Success', 'Nạp tiền vào ví', 'Deposit', TIMESTAMPTZ '-infinity', 'f17c0bc4-4b94-4f9e-bcb3-46878e4f9f6a');
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('3a3a9e0a-c23a-467f-9783-259b22b1c29d', 'ACT001', 180000.0, 2000000.0, 2180000.0, '2345678901', 'REF001', '3bdcb9d0-ef7b-4eea-a34d-b0c1aa469376', TIMESTAMPTZ '-infinity', FALSE, 'SP001', 'SIG001', 'Success', 'Thanh toán booking #1', 'Payment', TIMESTAMPTZ '-infinity', '16afe692-bf8d-43ae-a28f-375a7b2fe854');
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('ca9feb60-5224-4cf3-a274-665ef221f127', 'ACT003', 200000.0, 2200000.0, 2000000.0, '4567890123', 'REF003', '8901485b-9898-4112-8237-4463df23ba59', TIMESTAMPTZ '-infinity', FALSE, 'SP003', 'SIG003', 'Success', 'Hoàn tiền booking #4', 'Refund', TIMESTAMPTZ '-infinity', 'fa434c49-dad2-48e0-a3ba-aeb4c0094623');
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('ff0efc83-838b-4ab5-9306-5ab6abca452e', 'ACT002', 270000.0, 3500000.0, 3770000.0, '3456789012', 'REF002', '0c4873a0-c8ca-46b0-876a-af8ef7e7111f', TIMESTAMPTZ '-infinity', FALSE, 'SP002', 'SIG002', 'Success', 'Thanh toán booking #2', 'Payment', TIMESTAMPTZ '-infinity', 'c6170538-b504-4ee1-af8f-ab27d415b225');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_BookingDetails_BookingId" ON "BookingDetails" ("BookingId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_BookingDetails_SubCourtId" ON "BookingDetails" ("SubCourtId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_Bookings_CampaignId" ON "Bookings" ("CampaignId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_Bookings_CustomerId" ON "Bookings" ("CustomerId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_CampaignCourts_CampaignId" ON "CampaignCourts" ("CampaignId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_CampaignCourts_CourtId" ON "CampaignCourts" ("CourtId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE UNIQUE INDEX "IX_Campaigns_Code" ON "Campaigns" ("Code");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_Campaigns_OwnerId" ON "Campaigns" ("OwnerId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_ConfigSlots_SubCourtDetailId" ON "ConfigSlots" ("SubCourtDetailId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE UNIQUE INDEX "IX_Courts_Name" ON "Courts" ("Name");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_Courts_OwnerId" ON "Courts" ("OwnerId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE UNIQUE INDEX "IX_Customers_UserId" ON "Customers" ("UserId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_Exceptions_SubCourtDetailId" ON "Exceptions" ("SubCourtDetailId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_Feedbacks_BookingId" ON "Feedbacks" ("BookingId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_Feedbacks_CourtId" ON "Feedbacks" ("CourtId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_Feedbacks_CustomerId" ON "Feedbacks" ("CustomerId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_LikeListDetails_CourtId" ON "LikeListDetails" ("CourtId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_LikeListDetails_CustomerId" ON "LikeListDetails" ("CustomerId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_Notifications_BookingId" ON "Notifications" ("BookingId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_Notifications_CourtId" ON "Notifications" ("CourtId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_Notifications_UserId" ON "Notifications" ("UserId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_OverideSlots_SubCourtDetailId" ON "OverideSlots" ("SubCourtDetailId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_OwnerRequests_CustomerId" ON "OwnerRequests" ("CustomerId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE UNIQUE INDEX "IX_OwnerRequests_OwnerId" ON "OwnerRequests" ("OwnerId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE UNIQUE INDEX "IX_OwnerRequests_TaxCode" ON "OwnerRequests" ("TaxCode");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE UNIQUE INDEX "IX_Owners_TaxCode" ON "Owners" ("TaxCode");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE UNIQUE INDEX "IX_Owners_UserId" ON "Owners" ("UserId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_Reports_BookingId" ON "Reports" ("BookingId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_Reports_CourtId" ON "Reports" ("CourtId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_Reports_CustomerId" ON "Reports" ("CustomerId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_SubCourts_CourtId" ON "SubCourts" ("CourtId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_SystemReports_UserId" ON "SystemReports" ("UserId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE UNIQUE INDEX "IX_Transactions_ActionCode" ON "Transactions" ("ActionCode");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE UNIQUE INDEX "IX_Transactions_BankRefCode" ON "Transactions" ("BankRefCode");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_Transactions_BookingId" ON "Transactions" ("BookingId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE UNIQUE INDEX "IX_Transactions_SePayId" ON "Transactions" ("SePayId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE INDEX "IX_Transactions_WalletId" ON "Transactions" ("WalletId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE UNIQUE INDEX "IX_Users_Email" ON "Users" ("Email");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    CREATE UNIQUE INDEX "IX_Wallets_UserId" ON "Wallets" ("UserId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430053128_Initial') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20260430053128_Initial', '8.0.0');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "BookingDetails" DROP CONSTRAINT "FK_BookingDetails_SubCourts_SubCourtId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Bookings" DROP CONSTRAINT "FK_Bookings_Campaigns_CampaignId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Bookings" DROP CONSTRAINT "FK_Bookings_Customers_CustomerId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "CampaignCourts" DROP CONSTRAINT "FK_CampaignCourts_Courts_CourtId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Campaigns" DROP CONSTRAINT "FK_Campaigns_Owners_OwnerId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Courts" DROP CONSTRAINT "FK_Courts_Owners_OwnerId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Customers" DROP CONSTRAINT "FK_Customers_Users_UserId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Feedbacks" DROP CONSTRAINT "FK_Feedbacks_Bookings_BookingId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Feedbacks" DROP CONSTRAINT "FK_Feedbacks_Customers_CustomerId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Notifications" DROP CONSTRAINT "FK_Notifications_Bookings_BookingId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Notifications" DROP CONSTRAINT "FK_Notifications_Users_UserId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "OwnerRequests" DROP CONSTRAINT "FK_OwnerRequests_Owners_OwnerId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Owners" DROP CONSTRAINT "FK_Owners_Users_UserId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Reports" DROP CONSTRAINT "FK_Reports_Bookings_BookingId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Reports" DROP CONSTRAINT "FK_Reports_Courts_CourtId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Reports" DROP CONSTRAINT "FK_Reports_Customers_CustomerId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "SystemReports" DROP CONSTRAINT "FK_SystemReports_Users_UserId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Transactions" DROP CONSTRAINT "FK_Transactions_Bookings_BookingId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Transactions" DROP CONSTRAINT "FK_Transactions_Wallets_WalletId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Wallets" DROP CONSTRAINT "FK_Wallets_Users_UserId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = '4dcd68d1-0650-4453-867e-7f1a94f4e3aa';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = '5bbb6a15-ab4e-42f1-914f-efb2e66a2355';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = '6d01bcae-4e90-4ed8-aa6a-9d9c8eaf4d29';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = '8f753b07-6141-4404-8028-49dec223541b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = 'e683f292-9f36-4130-a403-e33fccf54bc5';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "CampaignCourts"
    WHERE "Id" = '2bb5078f-4302-4864-a934-2915f096e727';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "CampaignCourts"
    WHERE "Id" = '3b88c1a9-fa41-4a6a-82d4-a75ad40d1485';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "CampaignCourts"
    WHERE "Id" = '9551358b-f4f0-4cda-85a0-fe1859ee356e';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "CampaignCourts"
    WHERE "Id" = 'f8299f7b-d82c-423b-883e-a86d7d1d124b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = '0465f92a-28a2-4e65-a117-4d2740b4d7bf';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = '31378b0d-5851-4cb3-8283-897863472854';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = 'c7f10bf4-3255-4934-a5cd-86ef3cea2a26';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = 'f2238419-bc05-4e24-a529-ad4fa031deab';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '079c3582-f347-4933-bccb-4b840c262b0b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '0bfadfa2-3691-4274-b3bb-1a6dbb1bf811';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '140db18c-adc6-417f-a515-4310641c7ea7';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '20efc2a5-b1ef-43c1-8730-0c7a287a5749';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '4e860d98-39a0-4128-aa92-52d7b243be87';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '4f1eecfd-a06e-4a4c-825b-9a901f06645d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '501d59cb-bddf-44c5-ae9e-746594d4da91';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '5081c69a-a459-41b5-adfa-caa7456ac905';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '58c9834a-c6ea-4b6f-8530-2e1182a9a80c';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '5ce3f5ae-1ad0-441f-9dbb-e497ef670d26';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '5eb9cbc1-931c-4d57-a866-b0278ec11d2b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '683a564c-7fc9-4dd4-8a9f-72eabcd5ac57';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '6ce48bc5-dad2-45a7-8afe-fe29fc7b839b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '73e980c2-24eb-4259-bf38-b57d0aaa43c5';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '78ba0aa9-d45a-422f-9171-dbff845dcb5e';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '864af20b-ac6e-4633-84b5-f573dd3190bd';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '96a2123b-f3b6-4f99-9d5b-f0153497fb42';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'a1ee54f8-ecf2-4222-abf6-dbbfcf3d810d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'b64ef4b4-afb4-4917-9914-5995ecc1a11a';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'be433d76-2d4a-4c8c-83e1-8daed8f8e4ef';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'c31af39a-6d40-47a8-9ff4-3a8026fb5daf';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'cae78988-ad24-40af-9b52-a44b37f7ea27';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'd116561a-c113-44f2-9cc2-f6623f62ed0e';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'd185045e-4c91-4cc4-b667-94c897b5e3a1';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'd44fc0eb-03e5-43b9-a1e0-6635c3d6a1ed';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'df965cf4-e067-4aa9-b1dd-b55d59bc6821';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'f5af813e-1e91-49aa-9f0b-ac4cd79487f1';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'fa1989ed-e4d3-4831-b611-602a265b2fe8';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'fb108f81-339c-4c1a-90cd-2a0dde4a5d83';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'fb1cc836-a0fd-41ba-b24d-341797442267';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'fdc53d38-6cf3-44a4-b5c1-e3968a11033f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'ff544347-ef71-493c-aa5e-fb607e8208ce';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Exceptions"
    WHERE "Id" = '2d183184-15fe-4a20-aba5-83ea2fc9702f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Exceptions"
    WHERE "Id" = '47cf10b5-55ef-4585-b4ba-3129d4247370';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Exceptions"
    WHERE "Id" = 'd810b00d-215c-43d7-9344-db37271072c8';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Exceptions"
    WHERE "Id" = 'f0cc07be-0a34-48fe-a63e-36236aeed12a';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = '15f70445-277b-459c-b2da-c6094a9ee8fd';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = '52e9a8bf-9c61-47b0-baa1-508fe10d0720';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = '6490d792-e7a0-454e-97bb-e625e806025f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = 'bf8194fa-9b82-48a0-9e0f-c073785be537';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = 'cb905bcd-795f-4718-b7ef-de821e35086b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = '075f0057-b21c-4fa8-9070-4351b1427c7a';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = '4ab5c1f0-0e73-4763-acce-a6b55ed36c24';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = '5afc1587-4103-427b-b9aa-a3f8f29921af';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = '608346c8-ece0-48cd-b26c-3a2e042a3fc6';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = '78a604ea-af15-4ef5-b35a-714714e56c66';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = '0e55c478-5709-45ef-966b-799cd256e965';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = '7df76c4e-d3ea-47b4-94dc-18cef99f5e94';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = '83fe89b6-86ac-40a6-80e1-0c1737c0c458';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = '8d485a07-2f0a-4a43-9653-70516d909fb1';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = '99a3b29c-412e-49ce-98c3-f9627b8499bd';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = '4b5540c6-0970-4a1e-b939-3b8649f7837c';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = '75bf9b63-5f2b-439b-91dd-35291c7bab48';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = '8db0e48e-8cec-471f-b7f4-9f629a6cd54d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = '99aedf0e-9433-4187-8d91-4addb3e7d048';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = 'e67ef3c8-4f24-4e8d-ba3f-41ccb138b2a6';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "OwnerRequests"
    WHERE "Id" = '94349f48-3bc4-46b2-bab2-2dfc971df84f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "OwnerRequests"
    WHERE "Id" = 'ae72f2c0-a1d5-4639-add1-21aa257d927c';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Owners"
    WHERE "Id" = 'b6d05ded-a3dc-4f1f-8820-f926f2c32434';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Reports"
    WHERE "Id" = '194b20ee-077d-4dc6-89c8-76c01384f9c8';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Reports"
    WHERE "Id" = 'd7675c76-7cc3-454b-bcd8-6938a6fac8c1';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Reports"
    WHERE "Id" = 'd93821dc-2855-4222-851a-6739b02075d4';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Reports"
    WHERE "Id" = 'f339352f-b6e8-473b-88b7-c7213ae2d510';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Reports"
    WHERE "Id" = 'fe9aef0c-5a6d-48f7-a7e1-8b7fa525975a';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = '7226ea0b-efbc-4c58-b003-f5122480e7df';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = 'e0843b76-e683-44bd-8c6a-12f091ff3fa2';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = 'faaf79f6-9f7e-40dc-99c5-378edbc57ebb';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = '0ee9863b-3d52-4fda-b2e7-93c329665b36';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = '2b040261-a690-4cd9-9701-7721fa2e4808';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = 'b3668f9c-274b-4007-a4cc-608c57448a8f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = 'e6c2c9ff-2c19-47e3-802c-2072cda49268';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = 'f68c1408-dbf3-4254-aae3-dd87bfa87f1c';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Transactions"
    WHERE "Id" = '39dcedba-942d-4981-a914-02db1de86c8e';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Transactions"
    WHERE "Id" = '3a3a9e0a-c23a-467f-9783-259b22b1c29d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Transactions"
    WHERE "Id" = 'ca9feb60-5224-4cf3-a274-665ef221f127';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Transactions"
    WHERE "Id" = 'ff0efc83-838b-4ab5-9306-5ab6abca452e';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Users"
    WHERE "Id" = '83b95f86-62d5-40fc-bd68-f6fd9c05ba4e';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = '0c4873a0-c8ca-46b0-876a-af8ef7e7111f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = '3bdcb9d0-ef7b-4eea-a34d-b0c1aa469376';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = '5189db6e-2a50-4c4c-b0b6-de4c1501ce56';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = '71aeab11-b0d7-4d5e-bcb5-5d761015597e';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = '8901485b-9898-4112-8237-4463df23ba59';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = '5bd4c722-5700-48a6-b962-717b68af8d4d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = '62c8dcc8-d051-445c-870a-41b8afa226c0';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = '800676e0-f4d8-4bf9-bbbe-4b020f781fda';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = '900ac525-eb92-4e29-8f97-d46222389e1d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = 'e6ebdb58-afe4-490b-bb52-9d787fbf9cb9';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Users"
    WHERE "Id" = 'a6f0c3fe-2085-4f76-bf29-7c690f0b1d6f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Wallets"
    WHERE "Id" = '16afe692-bf8d-43ae-a28f-375a7b2fe854';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Wallets"
    WHERE "Id" = 'c6170538-b504-4ee1-af8f-ab27d415b225';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Wallets"
    WHERE "Id" = 'f17c0bc4-4b94-4f9e-bcb3-46878e4f9f6a';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Wallets"
    WHERE "Id" = 'fa434c49-dad2-48e0-a3ba-aeb4c0094623';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = 'b11ab76c-48a0-406c-b2fd-bdaa412ab515';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = 'c54e7607-18ed-4b18-8e78-83d472fcf4be';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Courts"
    WHERE "Id" = '3091f52d-4ec1-4084-b29d-fe44239b41c4';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Courts"
    WHERE "Id" = '6c727fa5-a22e-48eb-b839-7be005527b6f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Courts"
    WHERE "Id" = 'a6ced920-265d-4b14-bc0f-ef8124f4577b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Courts"
    WHERE "Id" = 'e94ededf-b3a9-4c6c-9d19-1754ac62f6f9';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Customers"
    WHERE "Id" = '2c854d5c-e88b-48dd-befd-271a5713ce50';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Customers"
    WHERE "Id" = '4b00b20c-6f56-4d5c-8fd3-eef3e76f20f3';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Owners"
    WHERE "Id" = '2c37b4dc-93c5-45ec-a159-1652e0be4166';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Owners"
    WHERE "Id" = 'fbfa9163-b847-4d0f-b7b6-239dcbd9086d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Users"
    WHERE "Id" = 'ab66bf11-307a-437d-8825-69d620e05638';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Users"
    WHERE "Id" = 'e381df1d-6157-4c3c-84e2-871b67db78a6';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Users"
    WHERE "Id" = '2bb8cc43-6ceb-4e86-b085-528679bca6b3';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    DELETE FROM "Users"
    WHERE "Id" = '8a3b27fa-dd6d-49b7-83b8-3e1712cc19db';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('3aa29cf2-fb4e-4883-9da7-09f01aad3a24', TIMESTAMPTZ '-infinity', 'owner2@rallyhub.vn', 'Hải', FALSE, 'Đăng', 'hashed_pw_3', '0900000003', 'Owner', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('70c426f7-2219-4083-b3a4-8a6e9f3aec90', TIMESTAMPTZ '-infinity', 'owner1@rallyhub.vn', 'Minh', FALSE, 'Tuấn', 'hashed_pw_2', '0900000002', 'Owner', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('74e2566a-4799-4776-aa99-afa7f9412d5c', TIMESTAMPTZ '-infinity', 'customer2@gmail.com', 'Bảo', FALSE, 'Châu', 'hashed_pw_5', '0900000005', 'Customer', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('9aa16a91-e515-4ab6-b804-83a012f7e2ca', TIMESTAMPTZ '-infinity', 'owner3@rallyhub.vn', 'Trần', FALSE, 'Phú', 'hashed_pw_6', '0900000006', 'Owner', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('b1a78501-1cd4-4d15-8fee-437302bbced0', TIMESTAMPTZ '-infinity', 'admin@rallyhub.vn', 'Quản', FALSE, 'Trị', 'hashed_pw_1', '0900000001', 'Admin', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('f014b885-130c-44a7-8b92-03240e56ddf5', TIMESTAMPTZ '-infinity', 'customer1@gmail.com', 'Lan', FALSE, 'Phương', 'hashed_pw_4', '0900000004', 'Customer', 'Active', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "Customers" ("Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId")
    VALUES ('14204186-d031-4052-bb86-32af7692a2cc', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', 'f014b885-130c-44a7-8b92-03240e56ddf5');
    INSERT INTO "Customers" ("Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId")
    VALUES ('ddb9a44b-0e25-4364-a5de-42c8d6c57b0a', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '74e2566a-4799-4776-aa99-afa7f9412d5c');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "Owners" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId")
    VALUES ('0127ab70-281c-4f47-827e-c0cf0445fbe7', '456 Lê Lợi, Q3, HCM', NULL, 'Trung Tâm Thể Thao Hải Đăng', TIMESTAMPTZ '-infinity', NULL, NULL, NULL, FALSE, '9876543210', TIMESTAMPTZ '-infinity', '3aa29cf2-fb4e-4883-9da7-09f01aad3a24');
    INSERT INTO "Owners" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId")
    VALUES ('95fee089-85d9-4424-97d0-80ac7ecba45f', '123 Nguyễn Huệ, Q1, HCM', NULL, 'Sân Cầu Lông Minh Tuấn', TIMESTAMPTZ '-infinity', NULL, NULL, NULL, FALSE, '0123456789', TIMESTAMPTZ '-infinity', '70c426f7-2219-4083-b3a4-8a6e9f3aec90');
    INSERT INTO "Owners" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId")
    VALUES ('e6faadf1-5124-48ab-8f11-5034c003d4b9', 'Tôn Đức Thắng, HCM', NULL, 'Sân Cầu Lông Trần Phú', TIMESTAMPTZ '-infinity', NULL, NULL, NULL, FALSE, '98765434219', TIMESTAMPTZ '-infinity', '9aa16a91-e515-4ab6-b804-83a012f7e2ca');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('15df93ad-b66d-4c4e-9688-42d1f1b9c653', TIMESTAMPTZ '-infinity', FALSE, 'Không thể thanh toán qua ví.', 'Pending', 'Lỗi thanh toán', TIMESTAMPTZ '-infinity', '70c426f7-2219-4083-b3a4-8a6e9f3aec90');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('3744f2bd-db27-4956-a8a0-c638949fb35e', TIMESTAMPTZ '-infinity', FALSE, 'Crash khi mở trang tìm kiếm sân.', 'Pending', 'App bị crash', TIMESTAMPTZ '-infinity', 'f014b885-130c-44a7-8b92-03240e56ddf5');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('a8a590ad-2ee6-4e3b-85a9-41a127710bcc', TIMESTAMPTZ '-infinity', FALSE, 'Số dư hiển thị không khớp lịch sử.', 'Resolved', 'Sai số dư sau giao dịch', TIMESTAMPTZ '-infinity', '74e2566a-4799-4776-aa99-afa7f9412d5c');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('c105d213-903b-4f10-8349-17ad56b2fe1b', TIMESTAMPTZ '-infinity', FALSE, 'OTP không gửi đến số điện thoại.', 'Pending', 'Không nhận được OTP', TIMESTAMPTZ '-infinity', 'f014b885-130c-44a7-8b92-03240e56ddf5');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('ca831a17-a598-48dc-8383-663a4e07e689', TIMESTAMPTZ '-infinity', FALSE, 'Bản đồ không load được trên iOS.', 'Resolved', 'Lỗi hiển thị bản đồ', TIMESTAMPTZ '-infinity', '3aa29cf2-fb4e-4883-9da7-09f01aad3a24');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('20a79c42-5b41-459e-927c-ac58873b942f', 3500000.0, '5678901234', 'VPBank', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '74e2566a-4799-4776-aa99-afa7f9412d5c', 0);
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('3e150f3d-5d55-4328-99a6-9c7186ce981d', 2000000.0, '4567890123', 'MB Bank', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', 'f014b885-130c-44a7-8b92-03240e56ddf5', 0);
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('63632a52-abf9-444f-b919-6fc39f1e17f9', 12000000.0, '2345678901', 'Techcombank', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '70c426f7-2219-4083-b3a4-8a6e9f3aec90', 0);
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('70e6c118-8e1b-4b12-b138-a29b47d2efd2', 8500000.0, '3456789012', 'BIDV', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '3aa29cf2-fb4e-4883-9da7-09f01aad3a24', 0);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('150f1fa5-a12c-4076-b30d-f5be62ecf1b8', 'SUMMER25', TIMESTAMPTZ '-infinity', 10.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 50000.0, 200000.0, '95fee089-85d9-4424-97d0-80ac7ecba45f', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 100, 12);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('42743bc5-c630-496b-a30d-6baacbec5f6f', 'FLASH50', TIMESTAMPTZ '-infinity', 50.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 200000.0, 500000.0, '95fee089-85d9-4424-97d0-80ac7ecba45f', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 10, 10);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('756c7617-141a-4122-aa4b-a6375c5d4ded', 'NEWUSER', TIMESTAMPTZ '-infinity', 20.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 100000.0, 300000.0, '0127ab70-281c-4f47-827e-c0cf0445fbe7', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 50, 5);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('b831b0c7-7bc4-4f3f-86fb-be235e9db520', 'WEEKEND10', TIMESTAMPTZ '-infinity', 15.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 75000.0, 250000.0, '0127ab70-281c-4f47-827e-c0cf0445fbe7', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 200, 30);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('e96d0185-562e-4368-b915-7640daa4d6e7', 'YEUTH', TIMESTAMPTZ '-infinity', 5.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 30000.0, 100000.0, '95fee089-85d9-4424-97d0-80ac7ecba45f', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 500, 87);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('f6ec7a65-05fe-4e82-8a3a-da51da5b775b', 'LOYAL5', TIMESTAMPTZ '-infinity', 5.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 30000.0, 100000.0, '0127ab70-281c-4f47-827e-c0cf0445fbe7', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 500, 87);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('07c0a296-c6dc-455a-954b-82dd557f410a', '456 Lê Lợi, Q3, HCM', TIME '23:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.78, 106.69, 'https://maps.google.com/?q=10.78,106.69', 'Sân D - Hải Đăng', TIME '05:30:00', '0127ab70-281c-4f47-827e-c0cf0445fbe7', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('321c4900-68e7-4780-934d-2928414af7fe', '456 Lê Lợi, Q3, HCM', TIME '23:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.78, 106.69, 'https://maps.google.com/?q=10.78,106.69', 'Sân C - Hải Đăng', TIME '05:30:00', '0127ab70-281c-4f47-827e-c0cf0445fbe7', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('8c439a86-f874-46e1-825e-646f900d77aa', '123 Nguyễn Huệ, Q1, HCM', TIME '22:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.77, 106.7, 'https://maps.google.com/?q=10.77,106.70', 'Sân A - Minh Tuấn', TIME '06:00:00', '95fee089-85d9-4424-97d0-80ac7ecba45f', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('e70101df-01de-44e7-83c3-d6756b1cc56d', '123 Nguyễn Huệ, Q1, HCM', TIME '22:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.77, 106.7, 'https://maps.google.com/?q=10.77,106.70', 'Sân B - Minh Tuấn', TIME '06:00:00', '95fee089-85d9-4424-97d0-80ac7ecba45f', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "OwnerRequests" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "CustomerId", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "OwnerId", "RejectionReason", "Status", "TaxCode", "UpdatedAt")
    VALUES ('23be78b3-7ee3-4dc4-870a-44b36309c284', '123 Nguyễn Huệ, Q1, HCM', 'https://cdn.rallyhub.vn/license/1.jpg', 'Sân Cầu Lông Minh Tuấn', TIMESTAMPTZ '-infinity', '14204186-d031-4052-bb86-32af7692a2cc', 'https://cdn.rallyhub.vn/cccd/1_back.jpg', 'https://cdn.rallyhub.vn/cccd/1_front.jpg', '079200012345', FALSE, '95fee089-85d9-4424-97d0-80ac7ecba45f', NULL, 'Approved', '0123456789', TIMESTAMPTZ '-infinity');
    INSERT INTO "OwnerRequests" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "CustomerId", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "OwnerId", "RejectionReason", "Status", "TaxCode", "UpdatedAt")
    VALUES ('853a212c-66df-436c-8d61-ffb113f0eb54', '456 Lê Lợi, Q3, HCM', 'https://cdn.rallyhub.vn/license/2.jpg', 'Trung Tâm Thể Thao Hải Đăng', TIMESTAMPTZ '-infinity', 'ddb9a44b-0e25-4364-a5de-42c8d6c57b0a', 'https://cdn.rallyhub.vn/cccd/2_back.jpg', 'https://cdn.rallyhub.vn/cccd/2_front.jpg', '079200054321', FALSE, '0127ab70-281c-4f47-827e-c0cf0445fbe7', NULL, 'Approved', '9876543210', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('2f305eaa-2245-4b04-9553-40f6fb3e0913', '756c7617-141a-4122-aa4b-a6375c5d4ded', 'Khách huỷ', TIMESTAMPTZ '-infinity', 'ddb9a44b-0e25-4364-a5de-42c8d6c57b0a', 50000.0, 200000.0, FALSE, 'Cancel', 250000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('931fc5e4-664d-4b3f-92ff-03ce5d2e2086', '150f1fa5-a12c-4076-b30d-f5be62ecf1b8', NULL, TIMESTAMPTZ '-infinity', '14204186-d031-4052-bb86-32af7692a2cc', 20000.0, 180000.0, FALSE, 'Complete', 200000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('ad57c07f-a0b7-4898-bfce-23855acbeaff', '756c7617-141a-4122-aa4b-a6375c5d4ded', NULL, TIMESTAMPTZ '-infinity', 'ddb9a44b-0e25-4364-a5de-42c8d6c57b0a', 0.0, 150000.0, FALSE, 'Complete', 150000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('adb1b67d-6fb5-4431-bb2c-0f6e92d0c926', '150f1fa5-a12c-4076-b30d-f5be62ecf1b8', NULL, TIMESTAMPTZ '-infinity', '14204186-d031-4052-bb86-32af7692a2cc', 30000.0, 270000.0, FALSE, 'Banked', 300000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('e9c9db67-186d-4110-8a41-a88bea3124f5', '756c7617-141a-4122-aa4b-a6375c5d4ded', NULL, TIMESTAMPTZ '-infinity', 'ddb9a44b-0e25-4364-a5de-42c8d6c57b0a', 40000.0, 360000.0, FALSE, 'Banked', 400000.0, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('68e9715d-a8b3-4cc7-9185-f942f1226e62', '756c7617-141a-4122-aa4b-a6375c5d4ded', 'e70101df-01de-44e7-83c3-d6756b1cc56d', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('9c7d896d-d35f-4e33-b69e-e6c0f2fcad39', '756c7617-141a-4122-aa4b-a6375c5d4ded', '8c439a86-f874-46e1-825e-646f900d77aa', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('ba03879c-f8de-4926-ad42-ba337da7fe38', '150f1fa5-a12c-4076-b30d-f5be62ecf1b8', '321c4900-68e7-4780-934d-2928414af7fe', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('d7242e7c-3ce6-4b13-9129-8c4c8f083466', '150f1fa5-a12c-4076-b30d-f5be62ecf1b8', '07c0a296-c6dc-455a-954b-82dd557f410a', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('1541f971-9010-4506-86dc-05533890cca8', '8c439a86-f874-46e1-825e-646f900d77aa', TIMESTAMPTZ '-infinity', '14204186-d031-4052-bb86-32af7692a2cc', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('2c5893b9-25d6-470f-a775-01bce00b561d', '07c0a296-c6dc-455a-954b-82dd557f410a', TIMESTAMPTZ '-infinity', 'ddb9a44b-0e25-4364-a5de-42c8d6c57b0a', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('6e9be15c-4f68-4438-9ad2-45defcd6f24f', '8c439a86-f874-46e1-825e-646f900d77aa', TIMESTAMPTZ '-infinity', 'ddb9a44b-0e25-4364-a5de-42c8d6c57b0a', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('c7fbbb97-9ed1-40c3-8e44-9edf4491befd', '321c4900-68e7-4780-934d-2928414af7fe', TIMESTAMPTZ '-infinity', 'ddb9a44b-0e25-4364-a5de-42c8d6c57b0a', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('f9bc7b7a-ebae-4202-8bfb-53ae63a808a7', 'e70101df-01de-44e7-83c3-d6756b1cc56d', TIMESTAMPTZ '-infinity', '14204186-d031-4052-bb86-32af7692a2cc', FALSE, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('002afa91-87ea-4069-b01a-b0695f01d92c', '321c4900-68e7-4780-934d-2928414af7fe', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ C1', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('0a99b240-4cac-4967-8cf1-c7eca180d738', 'e70101df-01de-44e7-83c3-d6756b1cc56d', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ B2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('50a7d8a0-8750-441c-9ef7-a23e5024e8cb', '07c0a296-c6dc-455a-954b-82dd557f410a', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ D2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('7a02a21e-c779-4f0f-8fb8-2b8280d2a0bc', '321c4900-68e7-4780-934d-2928414af7fe', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ C2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('cc307fef-d579-4b6b-9609-40c9bdb5a69d', '8c439a86-f874-46e1-825e-646f900d77aa', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ A1', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('d09add50-3fab-4b28-be52-57a0046af06d', '07c0a296-c6dc-455a-954b-82dd557f410a', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ D1', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('e3890d76-d401-431f-9286-5b43571f8822', 'e70101df-01de-44e7-83c3-d6756b1cc56d', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ B1', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('ed040c6f-86f0-42f0-ae2d-4bb4a7048cd8', '8c439a86-f874-46e1-825e-646f900d77aa', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ A2', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtId", "UpdatedAt")
    VALUES ('da62a70e-94b9-4517-aa6f-30a60c8080e6', '2f305eaa-2245-4b04-9553-40f6fb3e0913', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-27T12:45:13.249427+07:00', TIME '10:00:00', FALSE, 150000.0, TIME '06:00:00', 'd09add50-3fab-4b28-be52-57a0046af06d', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtId", "UpdatedAt")
    VALUES ('dfd3203d-2851-4ff2-9251-9d8ed7c7df96', '931fc5e4-664d-4b3f-92ff-03ce5d2e2086', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-25T12:45:13.24942+07:00', TIME '10:00:00', FALSE, 100000.0, TIME '08:00:00', 'cc307fef-d579-4b6b-9609-40c9bdb5a69d', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtId", "UpdatedAt")
    VALUES ('e714b1f7-ffc0-4d2e-b6d2-9ba869861dad', 'e9c9db67-186d-4110-8a41-a88bea3124f5', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-05-01T12:45:13.249429+07:00', TIME '10:00:00', FALSE, 150000.0, TIME '09:00:00', 'ed040c6f-86f0-42f0-ae2d-4bb4a7048cd8', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtId", "UpdatedAt")
    VALUES ('f93730ad-8121-40d3-93fa-ad65af7f4cb6', 'ad57c07f-a0b7-4898-bfce-23855acbeaff', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-27T12:45:13.249427+07:00', TIME '08:00:00', FALSE, 150000.0, TIME '07:00:00', '002afa91-87ea-4069-b01a-b0695f01d92c', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtId", "UpdatedAt")
    VALUES ('ff838465-01a7-4f9d-8ce7-a86442b51ac5', 'adb1b67d-6fb5-4431-bb2c-0f6e92d0c926', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-25T12:45:13.249427+07:00', TIME '07:00:00', FALSE, 100000.0, TIME '06:00:00', 'e3890d76-d401-431f-9286-5b43571f8822', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('0fe5965e-01ab-4e57-bcfd-98dc3ed4a9e4', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 35000.0, TIME '07:30:00', '002afa91-87ea-4069-b01a-b0695f01d92c', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('12290f1a-5a85-438f-9758-a50050a43580', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 100000.0, TIME '06:00:00', 'd09add50-3fab-4b28-be52-57a0046af06d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('179252ae-ca95-443a-ac85-091500e3d5f9', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 35000.0, TIME '07:00:00', '002afa91-87ea-4069-b01a-b0695f01d92c', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('1ad1dc94-71f8-48f5-8e7c-949d3808b68c', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 50000.0, TIME '08:00:00', 'cc307fef-d579-4b6b-9609-40c9bdb5a69d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('2ad4a992-5fae-4ea9-aa29-6000f9626835', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 100000.0, TIME '08:00:00', 'd09add50-3fab-4b28-be52-57a0046af06d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('2affca85-f54d-4883-8cda-59b6de11c117', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 70000.0, TIME '09:30:00', 'e3890d76-d401-431f-9286-5b43571f8822', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('2b551390-8cb7-47a1-a68e-545ae5d3e74c', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 35000.0, TIME '08:30:00', '002afa91-87ea-4069-b01a-b0695f01d92c', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('2c26ce59-e108-495c-9a45-01993b8a071e', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 100000.0, TIME '07:00:00', 'd09add50-3fab-4b28-be52-57a0046af06d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('31c3ddab-3c01-4110-b925-df4700d5791d', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 35000.0, TIME '08:00:00', '002afa91-87ea-4069-b01a-b0695f01d92c', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('3431212d-84e8-4166-baae-894c17575796', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 35000.0, TIME '06:00:00', '002afa91-87ea-4069-b01a-b0695f01d92c', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('3678b89f-0e0b-4191-a20c-a95907efb9ff', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 70000.0, TIME '07:00:00', 'e3890d76-d401-431f-9286-5b43571f8822', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('37c04cb5-2e1c-4742-9265-21441ddedf05', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 70000.0, TIME '06:00:00', 'e3890d76-d401-431f-9286-5b43571f8822', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('53a4a846-1542-4ced-aef3-c62bbb538fec', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 100000.0, TIME '06:30:00', 'd09add50-3fab-4b28-be52-57a0046af06d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('7191558e-a5cf-4a1b-b819-f0db5750aba7', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 100000.0, TIME '08:30:00', 'd09add50-3fab-4b28-be52-57a0046af06d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('750c6af2-60df-49d3-8e9d-94289f1e482e', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 50000.0, TIME '06:00:00', 'cc307fef-d579-4b6b-9609-40c9bdb5a69d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('795741a3-aed1-421d-84f5-0dd51daec831', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 50000.0, TIME '09:00:00', 'cc307fef-d579-4b6b-9609-40c9bdb5a69d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('79ab0407-780f-4857-b411-fe6d16e1a13e', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 35000.0, TIME '09:30:00', '002afa91-87ea-4069-b01a-b0695f01d92c', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('82ad649d-9586-4f65-b98a-74fa1b33501e', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 35000.0, TIME '06:30:00', '002afa91-87ea-4069-b01a-b0695f01d92c', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('8444c62b-8b69-422c-8b02-e590ff9d8f50', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 50000.0, TIME '09:30:00', 'cc307fef-d579-4b6b-9609-40c9bdb5a69d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('8b3e4fa6-f588-4d2b-a9ee-5f7739e0279a', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 70000.0, TIME '07:30:00', 'e3890d76-d401-431f-9286-5b43571f8822', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('90da06b6-a898-402f-aee5-08ba0d4e7f25', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 100000.0, TIME '09:30:00', 'd09add50-3fab-4b28-be52-57a0046af06d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('99623a2e-809e-4f3d-8044-45a36badec47', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 70000.0, TIME '08:30:00', 'e3890d76-d401-431f-9286-5b43571f8822', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('a5004e51-b57f-461b-9a42-398c7f0fa352', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 100000.0, TIME '07:30:00', 'd09add50-3fab-4b28-be52-57a0046af06d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('ae0aea54-a42d-41d9-8868-abffa74df46f', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 70000.0, TIME '06:30:00', 'e3890d76-d401-431f-9286-5b43571f8822', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('b1f9f8fb-4428-4f06-a294-0be88f05ce1f', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 50000.0, TIME '07:30:00', 'cc307fef-d579-4b6b-9609-40c9bdb5a69d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('b5932c36-d999-4a58-aafe-e0fb1b4509a4', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 50000.0, TIME '07:00:00', 'cc307fef-d579-4b6b-9609-40c9bdb5a69d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('b7721f55-cfbb-4c85-a847-49a825f16b2b', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 100000.0, TIME '09:00:00', 'd09add50-3fab-4b28-be52-57a0046af06d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('b96f8849-4047-4da7-9ffa-7b01a9c95a90', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 35000.0, TIME '09:00:00', '002afa91-87ea-4069-b01a-b0695f01d92c', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('c1202c49-b801-4ede-8096-4d0a7a7c54d9', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 50000.0, TIME '08:30:00', 'cc307fef-d579-4b6b-9609-40c9bdb5a69d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('d25bbd18-08e8-4eaa-8a9f-9364c13860e9', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 70000.0, TIME '09:00:00', 'e3890d76-d401-431f-9286-5b43571f8822', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('d262e143-a5fe-4a97-acb3-6a978a60613c', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 70000.0, TIME '08:00:00', 'e3890d76-d401-431f-9286-5b43571f8822', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('e62c767d-907f-47c9-9092-6d0f423a14d4', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 50000.0, TIME '06:30:00', 'cc307fef-d579-4b6b-9609-40c9bdb5a69d', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('40c5d037-81b9-4c26-a04d-2ad5028a05fd', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Bảo trì định kỳ', TIME '12:00:00', 'cc307fef-d579-4b6b-9609-40c9bdb5a69d', TIMESTAMPTZ '-infinity');
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('41806e89-a5b6-4404-9d5c-49ead9df56ac', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Tổ chức sự kiện nội bộ', TIME '12:00:00', 'd09add50-3fab-4b28-be52-57a0046af06d', TIMESTAMPTZ '-infinity');
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('853053de-3f6e-4b0c-91c0-d72e9c1b1517', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Sơn lại mặt sân', TIME '12:00:00', 'e3890d76-d401-431f-9286-5b43571f8822', TIMESTAMPTZ '-infinity');
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('cff90351-df45-4514-8316-6ce354106ecb', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Hỏng đèn chiếu sáng', TIME '12:00:00', '002afa91-87ea-4069-b01a-b0695f01d92c', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('30a74e45-9839-4d57-87e1-d6f4769aa358', 'adb1b67d-6fb5-4431-bb2c-0f6e92d0c926', 'Dịch vụ ổn, giá hợp lý.', 'e70101df-01de-44e7-83c3-d6756b1cc56d', TIMESTAMPTZ '-infinity', 'ddb9a44b-0e25-4364-a5de-42c8d6c57b0a', FALSE, 4, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('5a60dc88-248a-4886-bb2c-63ff1dbd4f00', '931fc5e4-664d-4b3f-92ff-03ce5d2e2086', 'Sân rất tốt, sẽ quay lại!', '8c439a86-f874-46e1-825e-646f900d77aa', TIMESTAMPTZ '-infinity', 'ddb9a44b-0e25-4364-a5de-42c8d6c57b0a', FALSE, 5, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('8c6af176-81b9-4a0b-8e6f-97aad328ff29', 'e9c9db67-186d-4110-8a41-a88bea3124f5', 'Đèn chiếu sáng yếu vào ban đêm.', '8c439a86-f874-46e1-825e-646f900d77aa', TIMESTAMPTZ '-infinity', 'ddb9a44b-0e25-4364-a5de-42c8d6c57b0a', FALSE, 2, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('9d2f4910-f8d2-4800-8ec2-3252bf2bd317', '2f305eaa-2245-4b04-9553-40f6fb3e0913', 'Nhân viên thân thiện, sân sạch.', 'e70101df-01de-44e7-83c3-d6756b1cc56d', TIMESTAMPTZ '-infinity', '14204186-d031-4052-bb86-32af7692a2cc', FALSE, 5, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('fb2233f5-c08b-4763-b5b9-8905a808da7b', 'ad57c07f-a0b7-4898-bfce-23855acbeaff', 'Bình thường, sân hơi cũ.', '321c4900-68e7-4780-934d-2928414af7fe', TIMESTAMPTZ '-infinity', '14204186-d031-4052-bb86-32af7692a2cc', FALSE, 3, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('05f904de-8ef0-4f4f-b46f-b2baac0a3afe', 'adb1b67d-6fb5-4431-bb2c-0f6e92d0c926', 'Booking #2 đã được xác nhận.', 'e70101df-01de-44e7-83c3-d6756b1cc56d', TIMESTAMPTZ '-infinity', FALSE, 'Đặt sân thành công', 'Booking', TIMESTAMPTZ '-infinity', '3aa29cf2-fb4e-4883-9da7-09f01aad3a24');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('1a3b95a2-faab-4f4f-9918-a30c8d3279bd', '931fc5e4-664d-4b3f-92ff-03ce5d2e2086', 'Booking #1 đã được xác nhận.', '8c439a86-f874-46e1-825e-646f900d77aa', TIMESTAMPTZ '-infinity', FALSE, TRUE, 'Đặt sân thành công', 'Booking', TIMESTAMPTZ '-infinity', '70c426f7-2219-4083-b3a4-8a6e9f3aec90');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('6d55c45e-e0d6-4c33-838f-c9b58fe302a5', 'ad57c07f-a0b7-4898-bfce-23855acbeaff', 'Bạn có lịch chơi vào ngày mai.', '321c4900-68e7-4780-934d-2928414af7fe', TIMESTAMPTZ '-infinity', FALSE, 'Nhắc nhở lịch chơi', 'Remind', TIMESTAMPTZ '-infinity', 'f014b885-130c-44a7-8b92-03240e56ddf5');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('7129634b-2ced-4328-b141-dbda4b8579d7', '2f305eaa-2245-4b04-9553-40f6fb3e0913', 'Booking #4 đã bị huỷ. Tiền sẽ hoàn.', '07c0a296-c6dc-455a-954b-82dd557f410a', TIMESTAMPTZ '-infinity', FALSE, TRUE, 'Huỷ booking', 'Cancel', TIMESTAMPTZ '-infinity', '74e2566a-4799-4776-aa99-afa7f9412d5c');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('f51a171f-57d3-410c-91c7-f6030b487227', 'e9c9db67-186d-4110-8a41-a88bea3124f5', 'Đã hoàn 360,000đ vào ví của bạn.', '8c439a86-f874-46e1-825e-646f900d77aa', TIMESTAMPTZ '-infinity', FALSE, 'Hoàn tiền', 'Refund', TIMESTAMPTZ '-infinity', '70c426f7-2219-4083-b3a4-8a6e9f3aec90');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('02a95818-600b-4ded-898b-041c836d4c5e', TIMESTAMPTZ '-infinity', DATE '2026-04-25', 0, TIME '17:00:00', FALSE, 220500.0, TIME '12:00:00', 'e3890d76-d401-431f-9286-5b43571f8822', TIMESTAMPTZ '-infinity');
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('4aad9e2a-9f93-4666-9196-1c2e180438e8', TIMESTAMPTZ '-infinity', DATE '2026-04-25', 0, TIME '17:00:00', FALSE, 220800.0, TIME '12:00:00', 'd09add50-3fab-4b28-be52-57a0046af06d', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "IsRecurring", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('621eb4ab-451b-4c2b-a239-f6b8c91231a4', TIMESTAMPTZ '-infinity', DATE '-infinity', 1, TIME '20:00:00', FALSE, TRUE, 200000.0, TIME '18:00:00', 'ed040c6f-86f0-42f0-ae2d-4bb4a7048cd8', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('b240bf91-b514-417d-ad9d-a73724c424d5', TIMESTAMPTZ '-infinity', DATE '2026-04-25', 0, TIME '17:00:00', FALSE, 2054000.0, TIME '12:00:00', '002afa91-87ea-4069-b01a-b0695f01d92c', TIMESTAMPTZ '-infinity');
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('fa2f9115-7ed1-451b-b36f-c5a22a3c2333', TIMESTAMPTZ '-infinity', DATE '2026-04-25', 0, TIME '17:00:00', FALSE, 208400.0, TIME '12:00:00', 'cc307fef-d579-4b6b-9609-40c9bdb5a69d', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('0d389f5c-d243-4ae6-9819-2211a257d141', '2f305eaa-2245-4b04-9553-40f6fb3e0913', '321c4900-68e7-4780-934d-2928414af7fe', TIMESTAMPTZ '-infinity', 'ddb9a44b-0e25-4364-a5de-42c8d6c57b0a', FALSE, 'Không hoàn tiền khi huỷ đúng hạn.', 'Rejected', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('588e77ad-bd00-409f-bab6-50e0b8e1b9c1', '931fc5e4-664d-4b3f-92ff-03ce5d2e2086', '321c4900-68e7-4780-934d-2928414af7fe', TIMESTAMPTZ '-infinity', '14204186-d031-4052-bb86-32af7692a2cc', FALSE, 'Sân không đúng mô tả.', 'Pending', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('940aa375-5e62-4b1b-a6e1-e16f438927c7', 'adb1b67d-6fb5-4431-bb2c-0f6e92d0c926', '8c439a86-f874-46e1-825e-646f900d77aa', TIMESTAMPTZ '-infinity', '14204186-d031-4052-bb86-32af7692a2cc', FALSE, 'Chủ sân thái độ không tốt.', 'Resolved', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('b5f3efd3-8039-4416-b1cd-a2db4ef90e27', 'ad57c07f-a0b7-4898-bfce-23855acbeaff', 'e70101df-01de-44e7-83c3-d6756b1cc56d', TIMESTAMPTZ '-infinity', 'ddb9a44b-0e25-4364-a5de-42c8d6c57b0a', FALSE, 'Cơ sở vật chất xuống cấp.', 'Pending', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('e590cc75-eadf-486b-8851-9431052560a8', 'e9c9db67-186d-4110-8a41-a88bea3124f5', '07c0a296-c6dc-455a-954b-82dd557f410a', TIMESTAMPTZ '-infinity', 'ddb9a44b-0e25-4364-a5de-42c8d6c57b0a', FALSE, 'Thông tin giờ mở cửa sai.', 'Pending', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('24149845-41a1-49f5-ac27-a91559d7008b', 'ACT001', 180000.0, 2000000.0, 2180000.0, '2345678901', 'REF001', '931fc5e4-664d-4b3f-92ff-03ce5d2e2086', TIMESTAMPTZ '-infinity', FALSE, 'SP001', 'SIG001', 'Success', 'Thanh toán booking #1', 'Payment', TIMESTAMPTZ '-infinity', '63632a52-abf9-444f-b919-6fc39f1e17f9');
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('70dd923b-eebc-4b64-9e47-4136e1528eb6', 'ACT003', 200000.0, 2200000.0, 2000000.0, '4567890123', 'REF003', 'ad57c07f-a0b7-4898-bfce-23855acbeaff', TIMESTAMPTZ '-infinity', FALSE, 'SP003', 'SIG003', 'Success', 'Hoàn tiền booking #4', 'Refund', TIMESTAMPTZ '-infinity', '3e150f3d-5d55-4328-99a6-9c7186ce981d');
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('8751cffe-20db-496c-8a00-04cc7ca18aaf', 'ACT004', 500000.0, 2000000.0, 1500000.0, '5678901234', 'REF004', 'e9c9db67-186d-4110-8a41-a88bea3124f5', TIMESTAMPTZ '-infinity', FALSE, 'SP004', 'SIG004', 'Success', 'Nạp tiền vào ví', 'Deposit', TIMESTAMPTZ '-infinity', '20a79c42-5b41-459e-927c-ac58873b942f');
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('c4e41946-4e7f-4531-b88d-71758688d13d', 'ACT002', 270000.0, 3500000.0, 3770000.0, '3456789012', 'REF002', 'adb1b67d-6fb5-4431-bb2c-0f6e92d0c926', TIMESTAMPTZ '-infinity', FALSE, 'SP002', 'SIG002', 'Success', 'Thanh toán booking #2', 'Payment', TIMESTAMPTZ '-infinity', '70e6c118-8e1b-4b12-b138-a29b47d2efd2');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "BookingDetails" ADD CONSTRAINT "FK_BookingDetails_SubCourts_SubCourtId" FOREIGN KEY ("SubCourtId") REFERENCES "SubCourts" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Bookings" ADD CONSTRAINT "FK_Bookings_Campaigns_CampaignId" FOREIGN KEY ("CampaignId") REFERENCES "Campaigns" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Bookings" ADD CONSTRAINT "FK_Bookings_Customers_CustomerId" FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "CampaignCourts" ADD CONSTRAINT "FK_CampaignCourts_Courts_CourtId" FOREIGN KEY ("CourtId") REFERENCES "Courts" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Campaigns" ADD CONSTRAINT "FK_Campaigns_Owners_OwnerId" FOREIGN KEY ("OwnerId") REFERENCES "Owners" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Courts" ADD CONSTRAINT "FK_Courts_Owners_OwnerId" FOREIGN KEY ("OwnerId") REFERENCES "Owners" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Customers" ADD CONSTRAINT "FK_Customers_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Feedbacks" ADD CONSTRAINT "FK_Feedbacks_Bookings_BookingId" FOREIGN KEY ("BookingId") REFERENCES "Bookings" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Feedbacks" ADD CONSTRAINT "FK_Feedbacks_Customers_CustomerId" FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Notifications" ADD CONSTRAINT "FK_Notifications_Bookings_BookingId" FOREIGN KEY ("BookingId") REFERENCES "Bookings" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Notifications" ADD CONSTRAINT "FK_Notifications_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "OwnerRequests" ADD CONSTRAINT "FK_OwnerRequests_Owners_OwnerId" FOREIGN KEY ("OwnerId") REFERENCES "Owners" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Owners" ADD CONSTRAINT "FK_Owners_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Reports" ADD CONSTRAINT "FK_Reports_Bookings_BookingId" FOREIGN KEY ("BookingId") REFERENCES "Bookings" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Reports" ADD CONSTRAINT "FK_Reports_Courts_CourtId" FOREIGN KEY ("CourtId") REFERENCES "Courts" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Reports" ADD CONSTRAINT "FK_Reports_Customers_CustomerId" FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "SystemReports" ADD CONSTRAINT "FK_SystemReports_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Transactions" ADD CONSTRAINT "FK_Transactions_Bookings_BookingId" FOREIGN KEY ("BookingId") REFERENCES "Bookings" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Transactions" ADD CONSTRAINT "FK_Transactions_Wallets_WalletId" FOREIGN KEY ("WalletId") REFERENCES "Wallets" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    ALTER TABLE "Wallets" ADD CONSTRAINT "FK_Wallets_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260430054513_UpdateOnDelete') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20260430054513_UpdateOnDelete', '8.0.0');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = 'da62a70e-94b9-4517-aa6f-30a60c8080e6';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = 'dfd3203d-2851-4ff2-9251-9d8ed7c7df96';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = 'e714b1f7-ffc0-4d2e-b6d2-9ba869861dad';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = 'f93730ad-8121-40d3-93fa-ad65af7f4cb6';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = 'ff838465-01a7-4f9d-8ce7-a86442b51ac5';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "CampaignCourts"
    WHERE "Id" = '68e9715d-a8b3-4cc7-9185-f942f1226e62';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "CampaignCourts"
    WHERE "Id" = '9c7d896d-d35f-4e33-b69e-e6c0f2fcad39';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "CampaignCourts"
    WHERE "Id" = 'ba03879c-f8de-4926-ad42-ba337da7fe38';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "CampaignCourts"
    WHERE "Id" = 'd7242e7c-3ce6-4b13-9129-8c4c8f083466';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = '42743bc5-c630-496b-a30d-6baacbec5f6f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = 'b831b0c7-7bc4-4f3f-86fb-be235e9db520';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = 'e96d0185-562e-4368-b915-7640daa4d6e7';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = 'f6ec7a65-05fe-4e82-8a3a-da51da5b775b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '0fe5965e-01ab-4e57-bcfd-98dc3ed4a9e4';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '12290f1a-5a85-438f-9758-a50050a43580';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '179252ae-ca95-443a-ac85-091500e3d5f9';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '1ad1dc94-71f8-48f5-8e7c-949d3808b68c';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '2ad4a992-5fae-4ea9-aa29-6000f9626835';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '2affca85-f54d-4883-8cda-59b6de11c117';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '2b551390-8cb7-47a1-a68e-545ae5d3e74c';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '2c26ce59-e108-495c-9a45-01993b8a071e';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '31c3ddab-3c01-4110-b925-df4700d5791d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '3431212d-84e8-4166-baae-894c17575796';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '3678b89f-0e0b-4191-a20c-a95907efb9ff';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '37c04cb5-2e1c-4742-9265-21441ddedf05';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '53a4a846-1542-4ced-aef3-c62bbb538fec';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '7191558e-a5cf-4a1b-b819-f0db5750aba7';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '750c6af2-60df-49d3-8e9d-94289f1e482e';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '795741a3-aed1-421d-84f5-0dd51daec831';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '79ab0407-780f-4857-b411-fe6d16e1a13e';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '82ad649d-9586-4f65-b98a-74fa1b33501e';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '8444c62b-8b69-422c-8b02-e590ff9d8f50';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '8b3e4fa6-f588-4d2b-a9ee-5f7739e0279a';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '90da06b6-a898-402f-aee5-08ba0d4e7f25';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '99623a2e-809e-4f3d-8044-45a36badec47';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'a5004e51-b57f-461b-9a42-398c7f0fa352';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'ae0aea54-a42d-41d9-8868-abffa74df46f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'b1f9f8fb-4428-4f06-a294-0be88f05ce1f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'b5932c36-d999-4a58-aafe-e0fb1b4509a4';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'b7721f55-cfbb-4c85-a847-49a825f16b2b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'b96f8849-4047-4da7-9ffa-7b01a9c95a90';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'c1202c49-b801-4ede-8096-4d0a7a7c54d9';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'd25bbd18-08e8-4eaa-8a9f-9364c13860e9';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'd262e143-a5fe-4a97-acb3-6a978a60613c';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'e62c767d-907f-47c9-9092-6d0f423a14d4';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Exceptions"
    WHERE "Id" = '40c5d037-81b9-4c26-a04d-2ad5028a05fd';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Exceptions"
    WHERE "Id" = '41806e89-a5b6-4404-9d5c-49ead9df56ac';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Exceptions"
    WHERE "Id" = '853053de-3f6e-4b0c-91c0-d72e9c1b1517';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Exceptions"
    WHERE "Id" = 'cff90351-df45-4514-8316-6ce354106ecb';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = '30a74e45-9839-4d57-87e1-d6f4769aa358';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = '5a60dc88-248a-4886-bb2c-63ff1dbd4f00';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = '8c6af176-81b9-4a0b-8e6f-97aad328ff29';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = '9d2f4910-f8d2-4800-8ec2-3252bf2bd317';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = 'fb2233f5-c08b-4763-b5b9-8905a808da7b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = '1541f971-9010-4506-86dc-05533890cca8';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = '2c5893b9-25d6-470f-a775-01bce00b561d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = '6e9be15c-4f68-4438-9ad2-45defcd6f24f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = 'c7fbbb97-9ed1-40c3-8e44-9edf4491befd';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = 'f9bc7b7a-ebae-4202-8bfb-53ae63a808a7';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = '05f904de-8ef0-4f4f-b46f-b2baac0a3afe';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = '1a3b95a2-faab-4f4f-9918-a30c8d3279bd';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = '6d55c45e-e0d6-4c33-838f-c9b58fe302a5';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = '7129634b-2ced-4328-b141-dbda4b8579d7';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = 'f51a171f-57d3-410c-91c7-f6030b487227';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = '02a95818-600b-4ded-898b-041c836d4c5e';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = '4aad9e2a-9f93-4666-9196-1c2e180438e8';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = '621eb4ab-451b-4c2b-a239-f6b8c91231a4';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = 'b240bf91-b514-417d-ad9d-a73724c424d5';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = 'fa2f9115-7ed1-451b-b36f-c5a22a3c2333';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "OwnerRequests"
    WHERE "Id" = '23be78b3-7ee3-4dc4-870a-44b36309c284';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "OwnerRequests"
    WHERE "Id" = '853a212c-66df-436c-8d61-ffb113f0eb54';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Owners"
    WHERE "Id" = 'e6faadf1-5124-48ab-8f11-5034c003d4b9';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Reports"
    WHERE "Id" = '0d389f5c-d243-4ae6-9819-2211a257d141';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Reports"
    WHERE "Id" = '588e77ad-bd00-409f-bab6-50e0b8e1b9c1';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Reports"
    WHERE "Id" = '940aa375-5e62-4b1b-a6e1-e16f438927c7';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Reports"
    WHERE "Id" = 'b5f3efd3-8039-4416-b1cd-a2db4ef90e27';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Reports"
    WHERE "Id" = 'e590cc75-eadf-486b-8851-9431052560a8';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = '0a99b240-4cac-4967-8cf1-c7eca180d738';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = '50a7d8a0-8750-441c-9ef7-a23e5024e8cb';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = '7a02a21e-c779-4f0f-8fb8-2b8280d2a0bc';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = '15df93ad-b66d-4c4e-9688-42d1f1b9c653';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = '3744f2bd-db27-4956-a8a0-c638949fb35e';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = 'a8a590ad-2ee6-4e3b-85a9-41a127710bcc';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = 'c105d213-903b-4f10-8349-17ad56b2fe1b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = 'ca831a17-a598-48dc-8383-663a4e07e689';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Transactions"
    WHERE "Id" = '24149845-41a1-49f5-ac27-a91559d7008b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Transactions"
    WHERE "Id" = '70dd923b-eebc-4b64-9e47-4136e1528eb6';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Transactions"
    WHERE "Id" = '8751cffe-20db-496c-8a00-04cc7ca18aaf';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Transactions"
    WHERE "Id" = 'c4e41946-4e7f-4531-b88d-71758688d13d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Users"
    WHERE "Id" = 'b1a78501-1cd4-4d15-8fee-437302bbced0';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = '2f305eaa-2245-4b04-9553-40f6fb3e0913';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = '931fc5e4-664d-4b3f-92ff-03ce5d2e2086';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = 'ad57c07f-a0b7-4898-bfce-23855acbeaff';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = 'adb1b67d-6fb5-4431-bb2c-0f6e92d0c926';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = 'e9c9db67-186d-4110-8a41-a88bea3124f5';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = '002afa91-87ea-4069-b01a-b0695f01d92c';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = 'cc307fef-d579-4b6b-9609-40c9bdb5a69d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = 'd09add50-3fab-4b28-be52-57a0046af06d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = 'e3890d76-d401-431f-9286-5b43571f8822';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = 'ed040c6f-86f0-42f0-ae2d-4bb4a7048cd8';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Users"
    WHERE "Id" = '9aa16a91-e515-4ab6-b804-83a012f7e2ca';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Wallets"
    WHERE "Id" = '20a79c42-5b41-459e-927c-ac58873b942f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Wallets"
    WHERE "Id" = '3e150f3d-5d55-4328-99a6-9c7186ce981d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Wallets"
    WHERE "Id" = '63632a52-abf9-444f-b919-6fc39f1e17f9';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Wallets"
    WHERE "Id" = '70e6c118-8e1b-4b12-b138-a29b47d2efd2';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = '150f1fa5-a12c-4076-b30d-f5be62ecf1b8';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = '756c7617-141a-4122-aa4b-a6375c5d4ded';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Courts"
    WHERE "Id" = '07c0a296-c6dc-455a-954b-82dd557f410a';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Courts"
    WHERE "Id" = '321c4900-68e7-4780-934d-2928414af7fe';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Courts"
    WHERE "Id" = '8c439a86-f874-46e1-825e-646f900d77aa';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Courts"
    WHERE "Id" = 'e70101df-01de-44e7-83c3-d6756b1cc56d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Customers"
    WHERE "Id" = '14204186-d031-4052-bb86-32af7692a2cc';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Customers"
    WHERE "Id" = 'ddb9a44b-0e25-4364-a5de-42c8d6c57b0a';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Owners"
    WHERE "Id" = '0127ab70-281c-4f47-827e-c0cf0445fbe7';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Owners"
    WHERE "Id" = '95fee089-85d9-4424-97d0-80ac7ecba45f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Users"
    WHERE "Id" = '74e2566a-4799-4776-aa99-afa7f9412d5c';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Users"
    WHERE "Id" = 'f014b885-130c-44a7-8b92-03240e56ddf5';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Users"
    WHERE "Id" = '3aa29cf2-fb4e-4883-9da7-09f01aad3a24';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    DELETE FROM "Users"
    WHERE "Id" = '70c426f7-2219-4083-b3a4-8a6e9f3aec90';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('428293e2-af5c-403f-a42b-52bef4859b44', TIMESTAMPTZ '-infinity', 'admin@rallyhub.vn', 'Quản', FALSE, 'Trị', 'hashed_pw_1', '0900000001', 'Admin', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('557436f5-9baf-4a6a-afe2-1c9f1db0f338', TIMESTAMPTZ '-infinity', 'owner2@rallyhub.vn', 'Hải', FALSE, 'Đăng', 'hashed_pw_3', '0900000003', 'Owner', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('5d51fb2e-57c6-4570-9bf6-a9bc5ff87d0b', TIMESTAMPTZ '-infinity', 'customer1@gmail.com', 'Lan', FALSE, 'Phương', 'hashed_pw_4', '0900000004', 'Customer', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('61485227-f8c7-4be5-b57b-93010b2561bf', TIMESTAMPTZ '-infinity', 'owner3@rallyhub.vn', 'Trần', FALSE, 'Phú', 'hashed_pw_6', '0900000006', 'Owner', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('73fe8d83-9cc4-4d90-ae10-3b7e6209a769', TIMESTAMPTZ '-infinity', 'owner1@rallyhub.vn', 'Minh', FALSE, 'Tuấn', 'hashed_pw_2', '0900000002', 'Owner', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('eab78c5c-73bc-4e0b-857c-e162001042de', TIMESTAMPTZ '-infinity', 'customer2@gmail.com', 'Bảo', FALSE, 'Châu', 'hashed_pw_5', '0900000005', 'Customer', 'Active', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    INSERT INTO "Customers" ("Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId")
    VALUES ('23cca870-0abe-4ef7-beb7-686ac4524a01', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', 'eab78c5c-73bc-4e0b-857c-e162001042de');
    INSERT INTO "Customers" ("Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId")
    VALUES ('ca54ded0-2e30-4ef9-b12f-7d819d25fb98', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '5d51fb2e-57c6-4570-9bf6-a9bc5ff87d0b');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    INSERT INTO "Owners" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId")
    VALUES ('368c7cb1-c8b5-4551-a4e5-cad41c18a1b0', 'Tôn Đức Thắng, HCM', NULL, 'Sân Cầu Lông Trần Phú', TIMESTAMPTZ '-infinity', NULL, NULL, NULL, FALSE, '98765434219', TIMESTAMPTZ '-infinity', '61485227-f8c7-4be5-b57b-93010b2561bf');
    INSERT INTO "Owners" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId")
    VALUES ('58ee84f5-d10c-4c4e-9881-c9cf9e5c7225', '456 Lê Lợi, Q3, HCM', NULL, 'Trung Tâm Thể Thao Hải Đăng', TIMESTAMPTZ '-infinity', NULL, NULL, NULL, FALSE, '9876543210', TIMESTAMPTZ '-infinity', '557436f5-9baf-4a6a-afe2-1c9f1db0f338');
    INSERT INTO "Owners" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId")
    VALUES ('c071402c-7661-4302-807c-5ecf0b13d1c4', '123 Nguyễn Huệ, Q1, HCM', NULL, 'Sân Cầu Lông Minh Tuấn', TIMESTAMPTZ '-infinity', NULL, NULL, NULL, FALSE, '0123456789', TIMESTAMPTZ '-infinity', '73fe8d83-9cc4-4d90-ae10-3b7e6209a769');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('645deb9b-5b1c-44db-bdf0-ca3aab4ccba2', TIMESTAMPTZ '-infinity', FALSE, 'Không thể thanh toán qua ví.', 'Pending', 'Lỗi thanh toán', TIMESTAMPTZ '-infinity', '73fe8d83-9cc4-4d90-ae10-3b7e6209a769');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('7ed59841-5fe1-4ccd-bf86-1183fc748039', TIMESTAMPTZ '-infinity', FALSE, 'OTP không gửi đến số điện thoại.', 'Pending', 'Không nhận được OTP', TIMESTAMPTZ '-infinity', '5d51fb2e-57c6-4570-9bf6-a9bc5ff87d0b');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('88ea9d63-0c13-4a9c-8d0f-043fedffdb19', TIMESTAMPTZ '-infinity', FALSE, 'Số dư hiển thị không khớp lịch sử.', 'Resolved', 'Sai số dư sau giao dịch', TIMESTAMPTZ '-infinity', 'eab78c5c-73bc-4e0b-857c-e162001042de');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('a5b4a9ae-036a-4dcf-a459-7a13080ca8f6', TIMESTAMPTZ '-infinity', FALSE, 'Bản đồ không load được trên iOS.', 'Resolved', 'Lỗi hiển thị bản đồ', TIMESTAMPTZ '-infinity', '557436f5-9baf-4a6a-afe2-1c9f1db0f338');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('c11a4a61-e753-4923-bde6-2c05b7f28a3b', TIMESTAMPTZ '-infinity', FALSE, 'Crash khi mở trang tìm kiếm sân.', 'Pending', 'App bị crash', TIMESTAMPTZ '-infinity', '5d51fb2e-57c6-4570-9bf6-a9bc5ff87d0b');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('ac0327ea-1410-4906-907a-b5c4f3bd81c1', 12000000.0, '2345678901', 'Techcombank', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '73fe8d83-9cc4-4d90-ae10-3b7e6209a769', 0);
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('c8330d4e-2bca-4c11-b7a7-06062d5f164b', 2000000.0, '4567890123', 'MB Bank', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '5d51fb2e-57c6-4570-9bf6-a9bc5ff87d0b', 0);
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('d73a2d90-7caf-487f-8048-8ebc8e8e24d6', 8500000.0, '3456789012', 'BIDV', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '557436f5-9baf-4a6a-afe2-1c9f1db0f338', 0);
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('d8121e37-6564-4774-909d-47465a53fc80', 3500000.0, '5678901234', 'VPBank', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', 'eab78c5c-73bc-4e0b-857c-e162001042de', 0);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('127c6199-7c17-4a3b-9869-79505060b5c8', 'SUMMER25', TIMESTAMPTZ '-infinity', 10.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 50000.0, 200000.0, 'c071402c-7661-4302-807c-5ecf0b13d1c4', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 100, 12);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('2097abf9-0ccd-43d7-9f47-e327343bb482', 'FLASH50', TIMESTAMPTZ '-infinity', 50.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 200000.0, 500000.0, 'c071402c-7661-4302-807c-5ecf0b13d1c4', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 10, 10);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('3bba838f-ad78-4d0b-b513-45aafdf90829', 'WEEKEND10', TIMESTAMPTZ '-infinity', 15.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 75000.0, 250000.0, '58ee84f5-d10c-4c4e-9881-c9cf9e5c7225', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 200, 30);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('7464906e-1e0c-4904-bd19-a69bb3d29067', 'LOYAL5', TIMESTAMPTZ '-infinity', 5.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 30000.0, 100000.0, '58ee84f5-d10c-4c4e-9881-c9cf9e5c7225', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 500, 87);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('9ef6ba3a-ba71-4925-ae36-7a2086efc68d', 'YEUTH', TIMESTAMPTZ '-infinity', 5.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 30000.0, 100000.0, 'c071402c-7661-4302-807c-5ecf0b13d1c4', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 500, 87);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('e0e04d5b-5b63-46b4-9d53-654fa05b996d', 'NEWUSER', TIMESTAMPTZ '-infinity', 20.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 100000.0, 300000.0, '58ee84f5-d10c-4c4e-9881-c9cf9e5c7225', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 50, 5);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('471ec123-f0d7-4a6e-93b9-e77da0e264a1', '456 Lê Lợi, Q3, HCM', TIME '23:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.78, 106.69, 'https://maps.google.com/?q=10.78,106.69', 'Sân D - Hải Đăng', TIME '05:30:00', '58ee84f5-d10c-4c4e-9881-c9cf9e5c7225', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('8a61f04c-fa46-4722-a431-19b6c399c5c2', '123 Nguyễn Huệ, Q1, HCM', TIME '22:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.77, 106.7, 'https://maps.google.com/?q=10.77,106.70', 'Sân A - Minh Tuấn', TIME '06:00:00', 'c071402c-7661-4302-807c-5ecf0b13d1c4', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('d8598918-3f35-40fb-bf5d-1f9bc43bf4f5', '123 Nguyễn Huệ, Q1, HCM', TIME '22:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.77, 106.7, 'https://maps.google.com/?q=10.77,106.70', 'Sân B - Minh Tuấn', TIME '06:00:00', 'c071402c-7661-4302-807c-5ecf0b13d1c4', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('ec7e0979-80d4-44ab-9335-05c2c6472c18', '456 Lê Lợi, Q3, HCM', TIME '23:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.78, 106.69, 'https://maps.google.com/?q=10.78,106.69', 'Sân C - Hải Đăng', TIME '05:30:00', '58ee84f5-d10c-4c4e-9881-c9cf9e5c7225', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    INSERT INTO "OwnerRequests" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "CustomerId", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "OwnerId", "RejectionReason", "Status", "TaxCode", "UpdatedAt")
    VALUES ('84e16218-8197-40db-867f-1e288b09da1f', '123 Nguyễn Huệ, Q1, HCM', 'https://cdn.rallyhub.vn/license/1.jpg', 'Sân Cầu Lông Minh Tuấn', TIMESTAMPTZ '-infinity', 'ca54ded0-2e30-4ef9-b12f-7d819d25fb98', 'https://cdn.rallyhub.vn/cccd/1_back.jpg', 'https://cdn.rallyhub.vn/cccd/1_front.jpg', '079200012345', FALSE, 'c071402c-7661-4302-807c-5ecf0b13d1c4', NULL, 'Approved', '0123456789', TIMESTAMPTZ '-infinity');
    INSERT INTO "OwnerRequests" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "CustomerId", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "OwnerId", "RejectionReason", "Status", "TaxCode", "UpdatedAt")
    VALUES ('f5cc46e4-fedb-4abb-9518-f3005b546c89', '456 Lê Lợi, Q3, HCM', 'https://cdn.rallyhub.vn/license/2.jpg', 'Trung Tâm Thể Thao Hải Đăng', TIMESTAMPTZ '-infinity', '23cca870-0abe-4ef7-beb7-686ac4524a01', 'https://cdn.rallyhub.vn/cccd/2_back.jpg', 'https://cdn.rallyhub.vn/cccd/2_front.jpg', '079200054321', FALSE, '58ee84f5-d10c-4c4e-9881-c9cf9e5c7225', NULL, 'Approved', '9876543210', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('43bc9ad9-72ed-4e51-9830-0cc50361f249', '127c6199-7c17-4a3b-9869-79505060b5c8', NULL, TIMESTAMPTZ '-infinity', 'ca54ded0-2e30-4ef9-b12f-7d819d25fb98', 20000.0, 180000.0, FALSE, 'Complete', 200000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('50abcbb7-e3e4-439d-9ee4-975cc834c04c', '127c6199-7c17-4a3b-9869-79505060b5c8', NULL, TIMESTAMPTZ '-infinity', 'ca54ded0-2e30-4ef9-b12f-7d819d25fb98', 30000.0, 270000.0, FALSE, 'Banked', 300000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('6d3c707d-d8b0-4bd4-965b-bf95de511c1c', 'e0e04d5b-5b63-46b4-9d53-654fa05b996d', NULL, TIMESTAMPTZ '-infinity', '23cca870-0abe-4ef7-beb7-686ac4524a01', 40000.0, 360000.0, FALSE, 'Banked', 400000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('9d8bddb5-3531-4bdf-a38c-53bd23e2a972', 'e0e04d5b-5b63-46b4-9d53-654fa05b996d', NULL, TIMESTAMPTZ '-infinity', '23cca870-0abe-4ef7-beb7-686ac4524a01', 0.0, 150000.0, FALSE, 'Complete', 150000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('a8f70a71-66e9-46cc-be79-5f0e9bba35b7', 'e0e04d5b-5b63-46b4-9d53-654fa05b996d', 'Khách huỷ', TIMESTAMPTZ '-infinity', '23cca870-0abe-4ef7-beb7-686ac4524a01', 50000.0, 200000.0, FALSE, 'Cancel', 250000.0, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('044916d7-f54a-46aa-989e-4e111eb3efe6', 'e0e04d5b-5b63-46b4-9d53-654fa05b996d', '8a61f04c-fa46-4722-a431-19b6c399c5c2', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('33bac512-ce42-497f-865b-06f61786f315', '127c6199-7c17-4a3b-9869-79505060b5c8', 'ec7e0979-80d4-44ab-9335-05c2c6472c18', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('8f9a2c01-7c70-47db-8ddc-ac78687fd37b', 'e0e04d5b-5b63-46b4-9d53-654fa05b996d', 'd8598918-3f35-40fb-bf5d-1f9bc43bf4f5', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('b5b9d92b-b620-4eed-ac3e-45023b155ce1', '127c6199-7c17-4a3b-9869-79505060b5c8', '471ec123-f0d7-4a6e-93b9-e77da0e264a1', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('00a10e93-db80-4e76-a25f-d57ee9a5f054', '8a61f04c-fa46-4722-a431-19b6c399c5c2', TIMESTAMPTZ '-infinity', '23cca870-0abe-4ef7-beb7-686ac4524a01', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('01eed8bf-b5d9-45ee-b93f-adb7aa07b854', '8a61f04c-fa46-4722-a431-19b6c399c5c2', TIMESTAMPTZ '-infinity', 'ca54ded0-2e30-4ef9-b12f-7d819d25fb98', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('4d93962d-ffa0-4e45-b4d1-578a6fd3b0a5', 'd8598918-3f35-40fb-bf5d-1f9bc43bf4f5', TIMESTAMPTZ '-infinity', 'ca54ded0-2e30-4ef9-b12f-7d819d25fb98', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('70663472-bbf9-43e5-b942-f92694f8c46d', 'ec7e0979-80d4-44ab-9335-05c2c6472c18', TIMESTAMPTZ '-infinity', '23cca870-0abe-4ef7-beb7-686ac4524a01', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('ecfddaa5-fb08-45d2-a18d-e38d7fdc8978', '471ec123-f0d7-4a6e-93b9-e77da0e264a1', TIMESTAMPTZ '-infinity', '23cca870-0abe-4ef7-beb7-686ac4524a01', FALSE, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('014f0353-cbf3-4e66-af7c-4eeee0e2bf2d', '8a61f04c-fa46-4722-a431-19b6c399c5c2', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ A2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('0765006d-fd8b-4c4b-870b-619d766dbc4b', '8a61f04c-fa46-4722-a431-19b6c399c5c2', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ A1', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('540d3f24-2824-493a-9d11-cb13b93436dd', '471ec123-f0d7-4a6e-93b9-e77da0e264a1', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ D2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('6eb874f4-2782-437d-bb4d-369b6e637112', 'd8598918-3f35-40fb-bf5d-1f9bc43bf4f5', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ B2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('a5fa4909-8314-4182-9189-c767f92e37c7', 'ec7e0979-80d4-44ab-9335-05c2c6472c18', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ C1', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('ab2e1c7a-8686-48c8-8b84-fd4eb554e79f', '471ec123-f0d7-4a6e-93b9-e77da0e264a1', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ D1', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('ce5bc867-9947-421c-8603-48c0eedf9a4f', 'ec7e0979-80d4-44ab-9335-05c2c6472c18', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ C2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('dff69c69-4418-4c3f-b684-2604d4e3918d', 'd8598918-3f35-40fb-bf5d-1f9bc43bf4f5', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ B1', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtId", "UpdatedAt")
    VALUES ('25bb20cb-3237-4207-b8ca-37d104537d44', '9d8bddb5-3531-4bdf-a38c-53bd23e2a972', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-28T14:22:07.463384+07:00', TIME '08:00:00', FALSE, 150000.0, TIME '07:00:00', 'a5fa4909-8314-4182-9189-c767f92e37c7', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtId", "UpdatedAt")
    VALUES ('98496677-2303-474f-86c5-e90a6a3dbe74', '6d3c707d-d8b0-4bd4-965b-bf95de511c1c', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-05-02T14:22:07.463384+07:00', TIME '10:00:00', FALSE, 150000.0, TIME '09:00:00', '014f0353-cbf3-4e66-af7c-4eeee0e2bf2d', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtId", "UpdatedAt")
    VALUES ('9cc71f41-7c2c-4b08-ab39-9a96a4a6a410', '50abcbb7-e3e4-439d-9ee4-975cc834c04c', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-26T14:22:07.463383+07:00', TIME '07:00:00', FALSE, 100000.0, TIME '06:00:00', 'dff69c69-4418-4c3f-b684-2604d4e3918d', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtId", "UpdatedAt")
    VALUES ('b6028b6d-263f-4eac-93b5-450f68897579', '43bc9ad9-72ed-4e51-9830-0cc50361f249', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-26T14:22:07.463377+07:00', TIME '10:00:00', FALSE, 100000.0, TIME '08:00:00', '0765006d-fd8b-4c4b-870b-619d766dbc4b', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtId", "UpdatedAt")
    VALUES ('c5eef06b-d205-4107-8bcb-60328ab8481f', 'a8f70a71-66e9-46cc-be79-5f0e9bba35b7', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-28T14:22:07.463384+07:00', TIME '10:00:00', FALSE, 150000.0, TIME '06:00:00', 'ab2e1c7a-8686-48c8-8b84-fd4eb554e79f', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('01937a2a-8af7-434b-ba67-0a1dd25fc63f', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 70000.0, TIME '07:30:00', 'dff69c69-4418-4c3f-b684-2604d4e3918d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('0b198d3c-1abc-4d2d-8f43-1e619da983df', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 50000.0, TIME '06:30:00', '0765006d-fd8b-4c4b-870b-619d766dbc4b', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('0fe12a15-f60a-46ed-aafa-3c55b20a2d8f', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 35000.0, TIME '06:00:00', 'a5fa4909-8314-4182-9189-c767f92e37c7', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('16433687-a6f4-4c66-9bc3-cd87d8c6469c', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 70000.0, TIME '06:30:00', 'dff69c69-4418-4c3f-b684-2604d4e3918d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('1ce5dacf-3103-414c-8d65-b675d5e2c642', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 70000.0, TIME '09:00:00', 'dff69c69-4418-4c3f-b684-2604d4e3918d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('29585fa4-cec4-4e2a-9af5-a22984000671', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 50000.0, TIME '09:30:00', '0765006d-fd8b-4c4b-870b-619d766dbc4b', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('3276f7ec-994d-47d6-86c1-75ce4789f092', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 35000.0, TIME '06:30:00', 'a5fa4909-8314-4182-9189-c767f92e37c7', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('42c84960-5648-4e2b-8575-8c111e8e4677', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 35000.0, TIME '09:30:00', 'a5fa4909-8314-4182-9189-c767f92e37c7', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('45247902-28fb-49c9-816d-2ac4f252e7e0', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 100000.0, TIME '08:00:00', 'ab2e1c7a-8686-48c8-8b84-fd4eb554e79f', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('474c3e1e-3040-4b6f-97bd-634f303f2678', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 35000.0, TIME '08:00:00', 'a5fa4909-8314-4182-9189-c767f92e37c7', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('6002f3e4-7ab4-4be2-b783-cf6d2ba72b48', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 50000.0, TIME '08:00:00', '0765006d-fd8b-4c4b-870b-619d766dbc4b', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('64e2d27b-7969-4acb-b285-fceab2f3462a', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 100000.0, TIME '06:30:00', 'ab2e1c7a-8686-48c8-8b84-fd4eb554e79f', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('6ec17ad0-3eca-4b60-9d62-c3071433fe8b', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 50000.0, TIME '07:00:00', '0765006d-fd8b-4c4b-870b-619d766dbc4b', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('757d7cc5-7007-4cc6-a35c-e5c6ecca2027', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 70000.0, TIME '07:00:00', 'dff69c69-4418-4c3f-b684-2604d4e3918d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('8b4c2793-e5ab-47df-9b33-b18976117c51', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 35000.0, TIME '07:30:00', 'a5fa4909-8314-4182-9189-c767f92e37c7', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('9ec06a3c-69c2-446f-b69a-10644bcdf13b', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 100000.0, TIME '07:30:00', 'ab2e1c7a-8686-48c8-8b84-fd4eb554e79f', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('a2aacd2c-ab6d-4416-b69f-9a15606a6fed', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 70000.0, TIME '08:30:00', 'dff69c69-4418-4c3f-b684-2604d4e3918d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('a4331885-604c-4ac1-8077-c9b2aee83a14', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 35000.0, TIME '09:00:00', 'a5fa4909-8314-4182-9189-c767f92e37c7', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('a721eb20-ba9d-4b9a-8966-7098682a0152', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 100000.0, TIME '09:00:00', 'ab2e1c7a-8686-48c8-8b84-fd4eb554e79f', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('a861aca8-4794-4ffe-893b-6dba755de86e', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 50000.0, TIME '09:00:00', '0765006d-fd8b-4c4b-870b-619d766dbc4b', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('b1aaa036-3372-4df0-841f-9902fd747b43', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 50000.0, TIME '08:30:00', '0765006d-fd8b-4c4b-870b-619d766dbc4b', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('b7ccd409-629f-48e0-a97a-e72d560584d7', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 70000.0, TIME '06:00:00', 'dff69c69-4418-4c3f-b684-2604d4e3918d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('b8e47492-e950-4308-81d4-9c8c3a75868d', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 100000.0, TIME '08:30:00', 'ab2e1c7a-8686-48c8-8b84-fd4eb554e79f', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('ba10c483-e293-4e5f-a743-2a5ae4adcefe', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 100000.0, TIME '09:30:00', 'ab2e1c7a-8686-48c8-8b84-fd4eb554e79f', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('c26ea46c-d013-4aa2-9573-9fc790cdf69f', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 50000.0, TIME '07:30:00', '0765006d-fd8b-4c4b-870b-619d766dbc4b', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('c6101f9b-ab75-4df6-a2fa-76b1f71af020', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 100000.0, TIME '07:00:00', 'ab2e1c7a-8686-48c8-8b84-fd4eb554e79f', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('cab02943-17df-4ea1-a28c-1d8bd17489af', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 35000.0, TIME '07:00:00', 'a5fa4909-8314-4182-9189-c767f92e37c7', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('cc8628c3-8623-45ca-bb12-654e50e3020f', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 70000.0, TIME '08:00:00', 'dff69c69-4418-4c3f-b684-2604d4e3918d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('d14a4c20-d86d-4cda-82cb-b79b598df8d2', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 50000.0, TIME '06:00:00', '0765006d-fd8b-4c4b-870b-619d766dbc4b', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('e63fdcac-af31-45ca-aba2-52cf2b6c5d3f', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 35000.0, TIME '08:30:00', 'a5fa4909-8314-4182-9189-c767f92e37c7', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('f0fc9fd2-335c-49bc-aacc-d05dfa344676', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 100000.0, TIME '06:00:00', 'ab2e1c7a-8686-48c8-8b84-fd4eb554e79f', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('fb2f3a5b-ae85-40ac-935b-e53b34afccc4', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 70000.0, TIME '09:30:00', 'dff69c69-4418-4c3f-b684-2604d4e3918d', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('55900e21-684e-4e8e-b636-93bade58fd98', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Sơn lại mặt sân', TIME '12:00:00', 'dff69c69-4418-4c3f-b684-2604d4e3918d', TIMESTAMPTZ '-infinity');
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('77bce1ba-8bf4-453d-88f0-1c43944710f0', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Bảo trì định kỳ', TIME '12:00:00', '0765006d-fd8b-4c4b-870b-619d766dbc4b', TIMESTAMPTZ '-infinity');
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('bbca5ce7-1a4c-45cd-bf6a-858fd5d907f7', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Hỏng đèn chiếu sáng', TIME '12:00:00', 'a5fa4909-8314-4182-9189-c767f92e37c7', TIMESTAMPTZ '-infinity');
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('c54c235e-b225-4787-a8ad-a1cb9d64a198', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Tổ chức sự kiện nội bộ', TIME '12:00:00', 'ab2e1c7a-8686-48c8-8b84-fd4eb554e79f', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('48f652b5-918e-499a-b324-f9081da607b9', '9d8bddb5-3531-4bdf-a38c-53bd23e2a972', 'Bình thường, sân hơi cũ.', 'ec7e0979-80d4-44ab-9335-05c2c6472c18', TIMESTAMPTZ '-infinity', 'ca54ded0-2e30-4ef9-b12f-7d819d25fb98', FALSE, 3, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('6c152b49-3a9c-492b-9ed1-97d8d69da973', 'a8f70a71-66e9-46cc-be79-5f0e9bba35b7', 'Nhân viên thân thiện, sân sạch.', 'd8598918-3f35-40fb-bf5d-1f9bc43bf4f5', TIMESTAMPTZ '-infinity', 'ca54ded0-2e30-4ef9-b12f-7d819d25fb98', FALSE, 5, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('be619c6f-e98f-4967-84d2-91f603105bd4', '50abcbb7-e3e4-439d-9ee4-975cc834c04c', 'Dịch vụ ổn, giá hợp lý.', 'd8598918-3f35-40fb-bf5d-1f9bc43bf4f5', TIMESTAMPTZ '-infinity', '23cca870-0abe-4ef7-beb7-686ac4524a01', FALSE, 4, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('cb2ad7d7-7c68-4c1b-b5a7-4ea80b802917', '43bc9ad9-72ed-4e51-9830-0cc50361f249', 'Sân rất tốt, sẽ quay lại!', '8a61f04c-fa46-4722-a431-19b6c399c5c2', TIMESTAMPTZ '-infinity', '23cca870-0abe-4ef7-beb7-686ac4524a01', FALSE, 5, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('fa561d2e-666a-4d88-b422-d66a7734ea6d', '6d3c707d-d8b0-4bd4-965b-bf95de511c1c', 'Đèn chiếu sáng yếu vào ban đêm.', '8a61f04c-fa46-4722-a431-19b6c399c5c2', TIMESTAMPTZ '-infinity', '23cca870-0abe-4ef7-beb7-686ac4524a01', FALSE, 2, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('0af8cd32-7812-4b81-8b0f-39439b774f5c', '50abcbb7-e3e4-439d-9ee4-975cc834c04c', 'Booking #2 đã được xác nhận.', 'd8598918-3f35-40fb-bf5d-1f9bc43bf4f5', TIMESTAMPTZ '-infinity', FALSE, 'Đặt sân thành công', 'Booking', TIMESTAMPTZ '-infinity', '557436f5-9baf-4a6a-afe2-1c9f1db0f338');
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('4fd426e9-ab38-4fdd-ab85-e6b265730a22', '9d8bddb5-3531-4bdf-a38c-53bd23e2a972', 'Bạn có lịch chơi vào ngày mai.', 'ec7e0979-80d4-44ab-9335-05c2c6472c18', TIMESTAMPTZ '-infinity', FALSE, 'Nhắc nhở lịch chơi', 'Remind', TIMESTAMPTZ '-infinity', '5d51fb2e-57c6-4570-9bf6-a9bc5ff87d0b');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('571a8373-ec37-481c-aa5c-f2c440d194c2', '43bc9ad9-72ed-4e51-9830-0cc50361f249', 'Booking #1 đã được xác nhận.', '8a61f04c-fa46-4722-a431-19b6c399c5c2', TIMESTAMPTZ '-infinity', FALSE, TRUE, 'Đặt sân thành công', 'Booking', TIMESTAMPTZ '-infinity', '73fe8d83-9cc4-4d90-ae10-3b7e6209a769');
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('7d15e86b-8283-47be-be07-b6c9a6f80636', 'a8f70a71-66e9-46cc-be79-5f0e9bba35b7', 'Booking #4 đã bị huỷ. Tiền sẽ hoàn.', '471ec123-f0d7-4a6e-93b9-e77da0e264a1', TIMESTAMPTZ '-infinity', FALSE, TRUE, 'Huỷ booking', 'Cancel', TIMESTAMPTZ '-infinity', 'eab78c5c-73bc-4e0b-857c-e162001042de');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('d9fef0e5-ee05-47dc-846c-0170034158c5', '6d3c707d-d8b0-4bd4-965b-bf95de511c1c', 'Đã hoàn 360,000đ vào ví của bạn.', '8a61f04c-fa46-4722-a431-19b6c399c5c2', TIMESTAMPTZ '-infinity', FALSE, 'Hoàn tiền', 'Refund', TIMESTAMPTZ '-infinity', '73fe8d83-9cc4-4d90-ae10-3b7e6209a769');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('42731e30-e6db-4ec1-8ed0-fa656e9ab6e5', TIMESTAMPTZ '-infinity', DATE '2026-04-25', 0, TIME '17:00:00', FALSE, 220500.0, TIME '12:00:00', 'dff69c69-4418-4c3f-b684-2604d4e3918d', TIMESTAMPTZ '-infinity');
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('76e64f5a-b2ed-479a-8452-9b53a99b1465', TIMESTAMPTZ '-infinity', DATE '2026-04-25', 0, TIME '17:00:00', FALSE, 208400.0, TIME '12:00:00', '0765006d-fd8b-4c4b-870b-619d766dbc4b', TIMESTAMPTZ '-infinity');
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('7819a0ac-5140-4c6c-b765-03f3ba2044a4', TIMESTAMPTZ '-infinity', DATE '2026-04-25', 0, TIME '17:00:00', FALSE, 220800.0, TIME '12:00:00', 'ab2e1c7a-8686-48c8-8b84-fd4eb554e79f', TIMESTAMPTZ '-infinity');
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('cb8b5410-4d33-48c1-b1cc-2b94e85c4ed4', TIMESTAMPTZ '-infinity', DATE '2026-04-25', 0, TIME '17:00:00', FALSE, 2054000.0, TIME '12:00:00', 'a5fa4909-8314-4182-9189-c767f92e37c7', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "IsRecurring", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('dca1b132-8094-4cea-a9e0-1a6e2c3d553a', TIMESTAMPTZ '-infinity', DATE '-infinity', 1, TIME '20:00:00', FALSE, TRUE, 200000.0, TIME '18:00:00', '014f0353-cbf3-4e66-af7c-4eeee0e2bf2d', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('01c3f29a-d5f0-4a26-975a-7dc74ad3d87b', '6d3c707d-d8b0-4bd4-965b-bf95de511c1c', '471ec123-f0d7-4a6e-93b9-e77da0e264a1', TIMESTAMPTZ '-infinity', '23cca870-0abe-4ef7-beb7-686ac4524a01', FALSE, 'Thông tin giờ mở cửa sai.', 'Pending', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('07f7db54-6617-4d54-9295-b3850cdb4008', 'a8f70a71-66e9-46cc-be79-5f0e9bba35b7', 'ec7e0979-80d4-44ab-9335-05c2c6472c18', TIMESTAMPTZ '-infinity', '23cca870-0abe-4ef7-beb7-686ac4524a01', FALSE, 'Không hoàn tiền khi huỷ đúng hạn.', 'Rejected', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('60f6eae5-dfcd-41b6-829d-d641709403b4', '9d8bddb5-3531-4bdf-a38c-53bd23e2a972', 'd8598918-3f35-40fb-bf5d-1f9bc43bf4f5', TIMESTAMPTZ '-infinity', '23cca870-0abe-4ef7-beb7-686ac4524a01', FALSE, 'Cơ sở vật chất xuống cấp.', 'Pending', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('c08c1ced-901b-49cc-b8f8-5f8dab5ed1cc', '43bc9ad9-72ed-4e51-9830-0cc50361f249', 'ec7e0979-80d4-44ab-9335-05c2c6472c18', TIMESTAMPTZ '-infinity', 'ca54ded0-2e30-4ef9-b12f-7d819d25fb98', FALSE, 'Sân không đúng mô tả.', 'Pending', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('ff14b2e2-8527-4f37-90c2-0c626296b199', '50abcbb7-e3e4-439d-9ee4-975cc834c04c', '8a61f04c-fa46-4722-a431-19b6c399c5c2', TIMESTAMPTZ '-infinity', 'ca54ded0-2e30-4ef9-b12f-7d819d25fb98', FALSE, 'Chủ sân thái độ không tốt.', 'Resolved', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('03163b33-4181-4f53-a881-05ec3260824d', 'ACT004', 500000.0, 2000000.0, 1500000.0, '5678901234', 'REF004', '6d3c707d-d8b0-4bd4-965b-bf95de511c1c', TIMESTAMPTZ '-infinity', FALSE, 'SP004', 'SIG004', 'Success', 'Nạp tiền vào ví', 'Deposit', TIMESTAMPTZ '-infinity', 'd8121e37-6564-4774-909d-47465a53fc80');
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('17630ddc-48e9-4112-a1a5-84cbaa0b609b', 'ACT002', 270000.0, 3500000.0, 3770000.0, '3456789012', 'REF002', '50abcbb7-e3e4-439d-9ee4-975cc834c04c', TIMESTAMPTZ '-infinity', FALSE, 'SP002', 'SIG002', 'Success', 'Thanh toán booking #2', 'Payment', TIMESTAMPTZ '-infinity', 'd73a2d90-7caf-487f-8048-8ebc8e8e24d6');
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('b53dc8cc-1332-40b8-a6d8-f3f2b72fa976', 'ACT003', 200000.0, 2200000.0, 2000000.0, '4567890123', 'REF003', '9d8bddb5-3531-4bdf-a38c-53bd23e2a972', TIMESTAMPTZ '-infinity', FALSE, 'SP003', 'SIG003', 'Success', 'Hoàn tiền booking #4', 'Refund', TIMESTAMPTZ '-infinity', 'c8330d4e-2bca-4c11-b7a7-06062d5f164b');
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('c8150efb-db75-4245-bc1a-345b316364ae', 'ACT001', 180000.0, 2000000.0, 2180000.0, '2345678901', 'REF001', '43bc9ad9-72ed-4e51-9830-0cc50361f249', TIMESTAMPTZ '-infinity', FALSE, 'SP001', 'SIG001', 'Success', 'Thanh toán booking #1', 'Payment', TIMESTAMPTZ '-infinity', 'ac0327ea-1410-4906-907a-b5c4f3bd81c1');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501072209_checkdatabase') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20260501072209_checkdatabase', '8.0.0');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DROP INDEX "IX_ConfigSlots_SubCourtDetailId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = '25bb20cb-3237-4207-b8ca-37d104537d44';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = '98496677-2303-474f-86c5-e90a6a3dbe74';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = '9cc71f41-7c2c-4b08-ab39-9a96a4a6a410';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = 'b6028b6d-263f-4eac-93b5-450f68897579';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = 'c5eef06b-d205-4107-8bcb-60328ab8481f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "CampaignCourts"
    WHERE "Id" = '044916d7-f54a-46aa-989e-4e111eb3efe6';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "CampaignCourts"
    WHERE "Id" = '33bac512-ce42-497f-865b-06f61786f315';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "CampaignCourts"
    WHERE "Id" = '8f9a2c01-7c70-47db-8ddc-ac78687fd37b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "CampaignCourts"
    WHERE "Id" = 'b5b9d92b-b620-4eed-ac3e-45023b155ce1';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = '2097abf9-0ccd-43d7-9f47-e327343bb482';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = '3bba838f-ad78-4d0b-b513-45aafdf90829';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = '7464906e-1e0c-4904-bd19-a69bb3d29067';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = '9ef6ba3a-ba71-4925-ae36-7a2086efc68d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '01937a2a-8af7-434b-ba67-0a1dd25fc63f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '0b198d3c-1abc-4d2d-8f43-1e619da983df';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '0fe12a15-f60a-46ed-aafa-3c55b20a2d8f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '16433687-a6f4-4c66-9bc3-cd87d8c6469c';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '1ce5dacf-3103-414c-8d65-b675d5e2c642';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '29585fa4-cec4-4e2a-9af5-a22984000671';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '3276f7ec-994d-47d6-86c1-75ce4789f092';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '42c84960-5648-4e2b-8575-8c111e8e4677';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '45247902-28fb-49c9-816d-2ac4f252e7e0';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '474c3e1e-3040-4b6f-97bd-634f303f2678';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '6002f3e4-7ab4-4be2-b783-cf6d2ba72b48';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '64e2d27b-7969-4acb-b285-fceab2f3462a';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '6ec17ad0-3eca-4b60-9d62-c3071433fe8b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '757d7cc5-7007-4cc6-a35c-e5c6ecca2027';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '8b4c2793-e5ab-47df-9b33-b18976117c51';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '9ec06a3c-69c2-446f-b69a-10644bcdf13b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'a2aacd2c-ab6d-4416-b69f-9a15606a6fed';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'a4331885-604c-4ac1-8077-c9b2aee83a14';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'a721eb20-ba9d-4b9a-8966-7098682a0152';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'a861aca8-4794-4ffe-893b-6dba755de86e';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'b1aaa036-3372-4df0-841f-9902fd747b43';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'b7ccd409-629f-48e0-a97a-e72d560584d7';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'b8e47492-e950-4308-81d4-9c8c3a75868d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'ba10c483-e293-4e5f-a743-2a5ae4adcefe';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'c26ea46c-d013-4aa2-9573-9fc790cdf69f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'c6101f9b-ab75-4df6-a2fa-76b1f71af020';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'cab02943-17df-4ea1-a28c-1d8bd17489af';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'cc8628c3-8623-45ca-bb12-654e50e3020f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'd14a4c20-d86d-4cda-82cb-b79b598df8d2';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'e63fdcac-af31-45ca-aba2-52cf2b6c5d3f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'f0fc9fd2-335c-49bc-aacc-d05dfa344676';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'fb2f3a5b-ae85-40ac-935b-e53b34afccc4';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Exceptions"
    WHERE "Id" = '55900e21-684e-4e8e-b636-93bade58fd98';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Exceptions"
    WHERE "Id" = '77bce1ba-8bf4-453d-88f0-1c43944710f0';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Exceptions"
    WHERE "Id" = 'bbca5ce7-1a4c-45cd-bf6a-858fd5d907f7';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Exceptions"
    WHERE "Id" = 'c54c235e-b225-4787-a8ad-a1cb9d64a198';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = '48f652b5-918e-499a-b324-f9081da607b9';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = '6c152b49-3a9c-492b-9ed1-97d8d69da973';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = 'be619c6f-e98f-4967-84d2-91f603105bd4';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = 'cb2ad7d7-7c68-4c1b-b5a7-4ea80b802917';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = 'fa561d2e-666a-4d88-b422-d66a7734ea6d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = '00a10e93-db80-4e76-a25f-d57ee9a5f054';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = '01eed8bf-b5d9-45ee-b93f-adb7aa07b854';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = '4d93962d-ffa0-4e45-b4d1-578a6fd3b0a5';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = '70663472-bbf9-43e5-b942-f92694f8c46d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = 'ecfddaa5-fb08-45d2-a18d-e38d7fdc8978';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = '0af8cd32-7812-4b81-8b0f-39439b774f5c';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = '4fd426e9-ab38-4fdd-ab85-e6b265730a22';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = '571a8373-ec37-481c-aa5c-f2c440d194c2';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = '7d15e86b-8283-47be-be07-b6c9a6f80636';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = 'd9fef0e5-ee05-47dc-846c-0170034158c5';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = '42731e30-e6db-4ec1-8ed0-fa656e9ab6e5';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = '76e64f5a-b2ed-479a-8452-9b53a99b1465';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = '7819a0ac-5140-4c6c-b765-03f3ba2044a4';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = 'cb8b5410-4d33-48c1-b1cc-2b94e85c4ed4';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = 'dca1b132-8094-4cea-a9e0-1a6e2c3d553a';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "OwnerRequests"
    WHERE "Id" = '84e16218-8197-40db-867f-1e288b09da1f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "OwnerRequests"
    WHERE "Id" = 'f5cc46e4-fedb-4abb-9518-f3005b546c89';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Owners"
    WHERE "Id" = '368c7cb1-c8b5-4551-a4e5-cad41c18a1b0';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Reports"
    WHERE "Id" = '01c3f29a-d5f0-4a26-975a-7dc74ad3d87b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Reports"
    WHERE "Id" = '07f7db54-6617-4d54-9295-b3850cdb4008';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Reports"
    WHERE "Id" = '60f6eae5-dfcd-41b6-829d-d641709403b4';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Reports"
    WHERE "Id" = 'c08c1ced-901b-49cc-b8f8-5f8dab5ed1cc';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Reports"
    WHERE "Id" = 'ff14b2e2-8527-4f37-90c2-0c626296b199';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = '540d3f24-2824-493a-9d11-cb13b93436dd';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = '6eb874f4-2782-437d-bb4d-369b6e637112';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = 'ce5bc867-9947-421c-8603-48c0eedf9a4f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = '645deb9b-5b1c-44db-bdf0-ca3aab4ccba2';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = '7ed59841-5fe1-4ccd-bf86-1183fc748039';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = '88ea9d63-0c13-4a9c-8d0f-043fedffdb19';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = 'a5b4a9ae-036a-4dcf-a459-7a13080ca8f6';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = 'c11a4a61-e753-4923-bde6-2c05b7f28a3b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Transactions"
    WHERE "Id" = '03163b33-4181-4f53-a881-05ec3260824d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Transactions"
    WHERE "Id" = '17630ddc-48e9-4112-a1a5-84cbaa0b609b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Transactions"
    WHERE "Id" = 'b53dc8cc-1332-40b8-a6d8-f3f2b72fa976';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Transactions"
    WHERE "Id" = 'c8150efb-db75-4245-bc1a-345b316364ae';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Users"
    WHERE "Id" = '428293e2-af5c-403f-a42b-52bef4859b44';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = '43bc9ad9-72ed-4e51-9830-0cc50361f249';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = '50abcbb7-e3e4-439d-9ee4-975cc834c04c';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = '6d3c707d-d8b0-4bd4-965b-bf95de511c1c';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = '9d8bddb5-3531-4bdf-a38c-53bd23e2a972';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = 'a8f70a71-66e9-46cc-be79-5f0e9bba35b7';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = '014f0353-cbf3-4e66-af7c-4eeee0e2bf2d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = '0765006d-fd8b-4c4b-870b-619d766dbc4b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = 'a5fa4909-8314-4182-9189-c767f92e37c7';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = 'ab2e1c7a-8686-48c8-8b84-fd4eb554e79f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = 'dff69c69-4418-4c3f-b684-2604d4e3918d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Users"
    WHERE "Id" = '61485227-f8c7-4be5-b57b-93010b2561bf';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Wallets"
    WHERE "Id" = 'ac0327ea-1410-4906-907a-b5c4f3bd81c1';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Wallets"
    WHERE "Id" = 'c8330d4e-2bca-4c11-b7a7-06062d5f164b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Wallets"
    WHERE "Id" = 'd73a2d90-7caf-487f-8048-8ebc8e8e24d6';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Wallets"
    WHERE "Id" = 'd8121e37-6564-4774-909d-47465a53fc80';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = '127c6199-7c17-4a3b-9869-79505060b5c8';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = 'e0e04d5b-5b63-46b4-9d53-654fa05b996d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Courts"
    WHERE "Id" = '471ec123-f0d7-4a6e-93b9-e77da0e264a1';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Courts"
    WHERE "Id" = '8a61f04c-fa46-4722-a431-19b6c399c5c2';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Courts"
    WHERE "Id" = 'd8598918-3f35-40fb-bf5d-1f9bc43bf4f5';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Courts"
    WHERE "Id" = 'ec7e0979-80d4-44ab-9335-05c2c6472c18';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Customers"
    WHERE "Id" = '23cca870-0abe-4ef7-beb7-686ac4524a01';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Customers"
    WHERE "Id" = 'ca54ded0-2e30-4ef9-b12f-7d819d25fb98';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Owners"
    WHERE "Id" = '58ee84f5-d10c-4c4e-9881-c9cf9e5c7225';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Owners"
    WHERE "Id" = 'c071402c-7661-4302-807c-5ecf0b13d1c4';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Users"
    WHERE "Id" = '5d51fb2e-57c6-4570-9bf6-a9bc5ff87d0b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Users"
    WHERE "Id" = 'eab78c5c-73bc-4e0b-857c-e162001042de';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Users"
    WHERE "Id" = '557436f5-9baf-4a6a-afe2-1c9f1db0f338';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    DELETE FROM "Users"
    WHERE "Id" = '73fe8d83-9cc4-4d90-ae10-3b7e6209a769';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    ALTER TABLE "OverideSlots" DROP COLUMN "IsRecurring";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    ALTER TABLE "ConfigSlots" DROP COLUMN "Price";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    ALTER TABLE "OverideSlots" RENAME COLUMN "DayOfWeek" TO "SlotDuration";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    ALTER TABLE "SubCourts" ADD "ConfigSlotId" uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    ALTER TABLE "ConfigSlots" ADD "SlotDuration" integer NOT NULL DEFAULT 0;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('3ae2b7c3-9c76-4e47-bfd0-e0903de145c4', TIMESTAMPTZ '-infinity', 'admin@rallyhub.vn', 'Quản', FALSE, 'Trị', 'hashed_pw_1', '0900000001', 'Admin', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('411bc086-c78e-4a41-82c1-60d33ff06f10', TIMESTAMPTZ '-infinity', 'customer2@gmail.com', 'Bảo', FALSE, 'Châu', 'hashed_pw_5', '0900000005', 'Customer', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('4fa4220a-7d44-4ee2-b256-cf8e2d44e00c', TIMESTAMPTZ '-infinity', 'owner3@rallyhub.vn', 'Trần', FALSE, 'Phú', 'hashed_pw_6', '0900000006', 'Owner', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('5210ccb2-b019-4d53-822e-c90a67145553', TIMESTAMPTZ '-infinity', 'customer1@gmail.com', 'Lan', FALSE, 'Phương', 'hashed_pw_4', '0900000004', 'Customer', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('60d952c5-f6c6-4379-953d-b4dae01d5eef', TIMESTAMPTZ '-infinity', 'owner2@rallyhub.vn', 'Hải', FALSE, 'Đăng', 'hashed_pw_3', '0900000003', 'Owner', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('8c681d6e-d23d-42e2-944a-efa1ce28f23d', TIMESTAMPTZ '-infinity', 'owner1@rallyhub.vn', 'Minh', FALSE, 'Tuấn', 'hashed_pw_2', '0900000002', 'Owner', 'Active', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    INSERT INTO "Customers" ("Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId")
    VALUES ('975e3b6f-9706-4292-86ae-71efb214b812', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '411bc086-c78e-4a41-82c1-60d33ff06f10');
    INSERT INTO "Customers" ("Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId")
    VALUES ('9ec5b629-ffe9-4b5a-9fee-929dfbad3a1b', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '5210ccb2-b019-4d53-822e-c90a67145553');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    INSERT INTO "Owners" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId")
    VALUES ('19ad8abf-54fc-49e9-8d45-328b9c3e1243', 'Tôn Đức Thắng, HCM', NULL, 'Sân Cầu Lông Trần Phú', TIMESTAMPTZ '-infinity', NULL, NULL, NULL, FALSE, '98765434219', TIMESTAMPTZ '-infinity', '4fa4220a-7d44-4ee2-b256-cf8e2d44e00c');
    INSERT INTO "Owners" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId")
    VALUES ('7a7f870d-1918-4dfd-90cc-0ff5139b380e', '456 Lê Lợi, Q3, HCM', NULL, 'Trung Tâm Thể Thao Hải Đăng', TIMESTAMPTZ '-infinity', NULL, NULL, NULL, FALSE, '9876543210', TIMESTAMPTZ '-infinity', '60d952c5-f6c6-4379-953d-b4dae01d5eef');
    INSERT INTO "Owners" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId")
    VALUES ('fd4a372a-62af-48d0-bc9b-6e5a8dd43197', '123 Nguyễn Huệ, Q1, HCM', NULL, 'Sân Cầu Lông Minh Tuấn', TIMESTAMPTZ '-infinity', NULL, NULL, NULL, FALSE, '0123456789', TIMESTAMPTZ '-infinity', '8c681d6e-d23d-42e2-944a-efa1ce28f23d');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('33fff83e-5781-45af-861f-72e17f5634ac', TIMESTAMPTZ '-infinity', FALSE, 'OTP không gửi đến số điện thoại.', 'Pending', 'Không nhận được OTP', TIMESTAMPTZ '-infinity', '5210ccb2-b019-4d53-822e-c90a67145553');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('49b13035-2df1-484b-9ea8-5d8da6755c1c', TIMESTAMPTZ '-infinity', FALSE, 'Bản đồ không load được trên iOS.', 'Resolved', 'Lỗi hiển thị bản đồ', TIMESTAMPTZ '-infinity', '60d952c5-f6c6-4379-953d-b4dae01d5eef');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('4ea7fdc7-f028-4414-bea4-a8888ac41423', TIMESTAMPTZ '-infinity', FALSE, 'Số dư hiển thị không khớp lịch sử.', 'Resolved', 'Sai số dư sau giao dịch', TIMESTAMPTZ '-infinity', '411bc086-c78e-4a41-82c1-60d33ff06f10');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('7eb01f99-7308-4a89-b67c-d6e1d8746c2e', TIMESTAMPTZ '-infinity', FALSE, 'Không thể thanh toán qua ví.', 'Pending', 'Lỗi thanh toán', TIMESTAMPTZ '-infinity', '8c681d6e-d23d-42e2-944a-efa1ce28f23d');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('e1883bd0-e3f5-4328-afe6-ce23aa15611c', TIMESTAMPTZ '-infinity', FALSE, 'Crash khi mở trang tìm kiếm sân.', 'Pending', 'App bị crash', TIMESTAMPTZ '-infinity', '5210ccb2-b019-4d53-822e-c90a67145553');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('0e3a2b3b-e9f6-4218-a63b-a976100bb9eb', 3500000.0, '5678901234', 'VPBank', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '411bc086-c78e-4a41-82c1-60d33ff06f10', 0);
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('18085723-0a5b-4bf3-8eed-d26b6f455f72', 12000000.0, '2345678901', 'Techcombank', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '8c681d6e-d23d-42e2-944a-efa1ce28f23d', 0);
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('4f6d36e1-975a-4f5d-b5ef-91a6b6e4ddba', 2000000.0, '4567890123', 'MB Bank', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '5210ccb2-b019-4d53-822e-c90a67145553', 0);
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('cda7125c-6be8-4029-a5a5-539233993408', 8500000.0, '3456789012', 'BIDV', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '60d952c5-f6c6-4379-953d-b4dae01d5eef', 0);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('221f605c-c949-4fd0-bc14-e00d6207d063', 'LOYAL5', TIMESTAMPTZ '-infinity', 5.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 30000.0, 100000.0, '7a7f870d-1918-4dfd-90cc-0ff5139b380e', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 500, 87);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('50dc3bb4-c745-456a-8e24-cfddda14d3da', 'SUMMER25', TIMESTAMPTZ '-infinity', 10.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 50000.0, 200000.0, 'fd4a372a-62af-48d0-bc9b-6e5a8dd43197', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 100, 12);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('b9271ed7-57a5-4710-a2f2-cc704eae46b4', 'FLASH50', TIMESTAMPTZ '-infinity', 50.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 200000.0, 500000.0, 'fd4a372a-62af-48d0-bc9b-6e5a8dd43197', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 10, 10);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('c4e8ba3e-7e3b-460c-b209-48ac369b1cc5', 'WEEKEND10', TIMESTAMPTZ '-infinity', 15.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 75000.0, 250000.0, '7a7f870d-1918-4dfd-90cc-0ff5139b380e', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 200, 30);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('f2360016-a24b-4e0a-9d28-0d91b97000f6', 'YEUTH', TIMESTAMPTZ '-infinity', 5.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 30000.0, 100000.0, 'fd4a372a-62af-48d0-bc9b-6e5a8dd43197', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 500, 87);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('f5a2d1f1-5378-4ca0-8fed-816ba9d2e886', 'NEWUSER', TIMESTAMPTZ '-infinity', 20.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 100000.0, 300000.0, '7a7f870d-1918-4dfd-90cc-0ff5139b380e', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 50, 5);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('16725258-236b-42d6-8b08-f22df0cef404', '456 Lê Lợi, Q3, HCM', TIME '23:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.78, 106.69, 'https://maps.google.com/?q=10.78,106.69', 'Sân D - Hải Đăng', TIME '05:30:00', '7a7f870d-1918-4dfd-90cc-0ff5139b380e', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('46f63137-c4fc-4fac-9f0e-57dc828ec61d', '456 Lê Lợi, Q3, HCM', TIME '23:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.78, 106.69, 'https://maps.google.com/?q=10.78,106.69', 'Sân C - Hải Đăng', TIME '05:30:00', '7a7f870d-1918-4dfd-90cc-0ff5139b380e', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('5f036b5d-e52a-4db5-b60f-6bc25f278263', '123 Nguyễn Huệ, Q1, HCM', TIME '22:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.77, 106.7, 'https://maps.google.com/?q=10.77,106.70', 'Sân A - Minh Tuấn', TIME '06:00:00', 'fd4a372a-62af-48d0-bc9b-6e5a8dd43197', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('8c709ec3-c343-4864-b55c-f406b6bc9dbf', '123 Nguyễn Huệ, Q1, HCM', TIME '22:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.77, 106.7, 'https://maps.google.com/?q=10.77,106.70', 'Sân B - Minh Tuấn', TIME '06:00:00', 'fd4a372a-62af-48d0-bc9b-6e5a8dd43197', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    INSERT INTO "OwnerRequests" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "CustomerId", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "OwnerId", "RejectionReason", "Status", "TaxCode", "UpdatedAt")
    VALUES ('1fe06eb1-3978-4cf3-ae58-5f02c6689a45', '123 Nguyễn Huệ, Q1, HCM', 'https://cdn.rallyhub.vn/license/1.jpg', 'Sân Cầu Lông Minh Tuấn', TIMESTAMPTZ '-infinity', '9ec5b629-ffe9-4b5a-9fee-929dfbad3a1b', 'https://cdn.rallyhub.vn/cccd/1_back.jpg', 'https://cdn.rallyhub.vn/cccd/1_front.jpg', '079200012345', FALSE, 'fd4a372a-62af-48d0-bc9b-6e5a8dd43197', NULL, 'Approved', '0123456789', TIMESTAMPTZ '-infinity');
    INSERT INTO "OwnerRequests" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "CustomerId", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "OwnerId", "RejectionReason", "Status", "TaxCode", "UpdatedAt")
    VALUES ('460dc168-8739-49c1-b343-9b1f095138b0', '456 Lê Lợi, Q3, HCM', 'https://cdn.rallyhub.vn/license/2.jpg', 'Trung Tâm Thể Thao Hải Đăng', TIMESTAMPTZ '-infinity', '975e3b6f-9706-4292-86ae-71efb214b812', 'https://cdn.rallyhub.vn/cccd/2_back.jpg', 'https://cdn.rallyhub.vn/cccd/2_front.jpg', '079200054321', FALSE, '7a7f870d-1918-4dfd-90cc-0ff5139b380e', NULL, 'Approved', '9876543210', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('2dca5bad-6098-4c8d-adb4-e0a214eb2d4b', 'f5a2d1f1-5378-4ca0-8fed-816ba9d2e886', NULL, TIMESTAMPTZ '-infinity', '975e3b6f-9706-4292-86ae-71efb214b812', 0.0, 150000.0, FALSE, 'Complete', 150000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('3745bcdc-44a3-4324-9c45-1981a9f0de3e', 'f5a2d1f1-5378-4ca0-8fed-816ba9d2e886', 'Khách huỷ', TIMESTAMPTZ '-infinity', '975e3b6f-9706-4292-86ae-71efb214b812', 50000.0, 200000.0, FALSE, 'Cancel', 250000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('3c5eeabb-c2bc-4739-8b62-0a1de6665d30', 'f5a2d1f1-5378-4ca0-8fed-816ba9d2e886', NULL, TIMESTAMPTZ '-infinity', '975e3b6f-9706-4292-86ae-71efb214b812', 40000.0, 360000.0, FALSE, 'Banked', 400000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('b28b4391-9fb6-43df-a7e2-460b0931ba19', '50dc3bb4-c745-456a-8e24-cfddda14d3da', NULL, TIMESTAMPTZ '-infinity', '9ec5b629-ffe9-4b5a-9fee-929dfbad3a1b', 20000.0, 180000.0, FALSE, 'Complete', 200000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('dd8b2994-1a53-47c9-94bb-52212762a080', '50dc3bb4-c745-456a-8e24-cfddda14d3da', NULL, TIMESTAMPTZ '-infinity', '9ec5b629-ffe9-4b5a-9fee-929dfbad3a1b', 30000.0, 270000.0, FALSE, 'Banked', 300000.0, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('111488df-b69f-471b-970a-9707365d9854', '50dc3bb4-c745-456a-8e24-cfddda14d3da', '16725258-236b-42d6-8b08-f22df0cef404', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('45dea7bf-4437-4065-9db2-a5d561c0b751', 'f5a2d1f1-5378-4ca0-8fed-816ba9d2e886', '8c709ec3-c343-4864-b55c-f406b6bc9dbf', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('c13c8310-2f04-4da1-8071-c98c7b8953d9', 'f5a2d1f1-5378-4ca0-8fed-816ba9d2e886', '5f036b5d-e52a-4db5-b60f-6bc25f278263', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('f9c16986-6cea-4860-9efa-967d0371b99e', '50dc3bb4-c745-456a-8e24-cfddda14d3da', '46f63137-c4fc-4fac-9f0e-57dc828ec61d', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('1161b378-4456-42ad-b5f8-dd1a048b01cf', '16725258-236b-42d6-8b08-f22df0cef404', TIMESTAMPTZ '-infinity', '975e3b6f-9706-4292-86ae-71efb214b812', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('1f4ee854-dd23-4fcb-955c-a93642ad11a1', '46f63137-c4fc-4fac-9f0e-57dc828ec61d', TIMESTAMPTZ '-infinity', '975e3b6f-9706-4292-86ae-71efb214b812', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('a76deb62-cbec-4f16-9e89-58247a113e8d', '5f036b5d-e52a-4db5-b60f-6bc25f278263', TIMESTAMPTZ '-infinity', '975e3b6f-9706-4292-86ae-71efb214b812', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('cca389c3-28ce-458c-b359-9a268ba5056b', '5f036b5d-e52a-4db5-b60f-6bc25f278263', TIMESTAMPTZ '-infinity', '9ec5b629-ffe9-4b5a-9fee-929dfbad3a1b', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('d389a616-33ac-462d-8634-144cb59a65b5', '8c709ec3-c343-4864-b55c-f406b6bc9dbf', TIMESTAMPTZ '-infinity', '9ec5b629-ffe9-4b5a-9fee-929dfbad3a1b', FALSE, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    INSERT INTO "SubCourts" ("Id", "ConfigSlotId", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('130aa2cb-b355-48e9-803a-41a70aef0d9e', '00000000-0000-0000-0000-000000000000', '46f63137-c4fc-4fac-9f0e-57dc828ec61d', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ C2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "ConfigSlotId", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('2c5e90e0-5363-434b-9209-e9047b0ecb97', '00000000-0000-0000-0000-000000000000', '5f036b5d-e52a-4db5-b60f-6bc25f278263', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ A2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "ConfigSlotId", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('33252574-943a-4e6c-bf15-0db4c4c26a71', '00000000-0000-0000-0000-000000000000', '8c709ec3-c343-4864-b55c-f406b6bc9dbf', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ B2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "ConfigSlotId", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('612a04b7-5c34-45f6-b262-eb0dad6d6708', '00000000-0000-0000-0000-000000000000', '8c709ec3-c343-4864-b55c-f406b6bc9dbf', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ B1', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "ConfigSlotId", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('6f9f97cb-26fb-42c5-951e-857c918a8e2e', '00000000-0000-0000-0000-000000000000', '5f036b5d-e52a-4db5-b60f-6bc25f278263', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ A1', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "ConfigSlotId", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('a1db9a4e-f03e-439e-baf7-dfe930027552', '00000000-0000-0000-0000-000000000000', '16725258-236b-42d6-8b08-f22df0cef404', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ D2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "ConfigSlotId", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('c019be97-4bf5-4198-98eb-40225a967117', '00000000-0000-0000-0000-000000000000', '46f63137-c4fc-4fac-9f0e-57dc828ec61d', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ C1', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "ConfigSlotId", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('d199c60a-5e16-4473-bb9f-4d89cdf554a1', '00000000-0000-0000-0000-000000000000', '16725258-236b-42d6-8b08-f22df0cef404', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ D1', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtId", "UpdatedAt")
    VALUES ('898f43e2-b6cd-4aab-8ba3-9966ead33dd2', 'b28b4391-9fb6-43df-a7e2-460b0931ba19', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-26T17:18:04.901699+07:00', TIME '10:00:00', FALSE, 100000.0, TIME '08:00:00', '6f9f97cb-26fb-42c5-951e-857c918a8e2e', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtId", "UpdatedAt")
    VALUES ('d3c1d560-f450-4576-af10-d37f382ef38d', '2dca5bad-6098-4c8d-adb4-e0a214eb2d4b', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-28T17:18:04.901706+07:00', TIME '08:00:00', FALSE, 150000.0, TIME '07:00:00', 'c019be97-4bf5-4198-98eb-40225a967117', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtId", "UpdatedAt")
    VALUES ('d9f7f911-8155-4366-b053-88b87824761d', '3745bcdc-44a3-4324-9c45-1981a9f0de3e', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-28T17:18:04.901706+07:00', TIME '10:00:00', FALSE, 150000.0, TIME '06:00:00', 'd199c60a-5e16-4473-bb9f-4d89cdf554a1', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtId", "UpdatedAt")
    VALUES ('e3af85a3-f2fc-466c-83e6-fb7ddcbd9b42', '3c5eeabb-c2bc-4739-8b62-0a1de6665d30', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-05-02T17:18:04.901706+07:00', TIME '10:00:00', FALSE, 150000.0, TIME '09:00:00', '2c5e90e0-5363-434b-9209-e9047b0ecb97', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtId", "UpdatedAt")
    VALUES ('eef70a57-f0dc-4bfd-82f6-3af39341519d', 'dd8b2994-1a53-47c9-94bb-52212762a080', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-26T17:18:04.901705+07:00', TIME '07:00:00', FALSE, 100000.0, TIME '06:00:00', '612a04b7-5c34-45f6-b262-eb0dad6d6708', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('0a63c35d-7269-4f5e-b8fc-5a842daa2d2c', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 0, TIME '06:30:00', 'c019be97-4bf5-4198-98eb-40225a967117', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('0cc0b8cc-01f1-4029-b599-33ad6c7dc7c7', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 0, TIME '07:30:00', 'd199c60a-5e16-4473-bb9f-4d89cdf554a1', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('2e41096f-5358-498a-b904-52af3422d8af', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 0, TIME '07:30:00', '612a04b7-5c34-45f6-b262-eb0dad6d6708', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('34a83748-59e8-4cd6-8d3b-05340cc9c8ab', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 0, TIME '06:00:00', 'd199c60a-5e16-4473-bb9f-4d89cdf554a1', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('38066a9a-4b02-4db9-8cbe-77a9c5d15968', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 0, TIME '06:30:00', '612a04b7-5c34-45f6-b262-eb0dad6d6708', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('38c1956a-c4de-44b6-ae02-8be00c5036d3', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 0, TIME '09:30:00', '612a04b7-5c34-45f6-b262-eb0dad6d6708', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('39685de1-b5d3-44e2-ae2c-a7fcba3d23b4', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 0, TIME '07:00:00', '612a04b7-5c34-45f6-b262-eb0dad6d6708', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('5d340bdd-2e37-4f02-a7d2-b811fbd2bc00', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 0, TIME '08:00:00', 'c019be97-4bf5-4198-98eb-40225a967117', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('5ef2a13c-6cdf-4c22-a7e5-e0111915326d', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 0, TIME '06:00:00', '612a04b7-5c34-45f6-b262-eb0dad6d6708', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('68570785-0b8e-4fc9-b0db-e9bc1987b5bf', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 0, TIME '08:30:00', '612a04b7-5c34-45f6-b262-eb0dad6d6708', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('71d76388-f93a-411f-be71-1ba2559aa9f6', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 0, TIME '07:00:00', 'c019be97-4bf5-4198-98eb-40225a967117', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('729d141d-7bb6-45c2-b4fb-609d548df8fd', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 0, TIME '09:30:00', 'd199c60a-5e16-4473-bb9f-4d89cdf554a1', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('7c79baa8-9e05-49d2-b3d9-ebd3c5257a76', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 0, TIME '06:30:00', 'd199c60a-5e16-4473-bb9f-4d89cdf554a1', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('89a89005-b40c-43b5-bf7b-fcae55e66c45', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 0, TIME '09:30:00', 'c019be97-4bf5-4198-98eb-40225a967117', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('94544049-0abc-44e4-b372-e97a1013ea70', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 0, TIME '09:00:00', 'c019be97-4bf5-4198-98eb-40225a967117', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('9d041c3f-cd7c-480a-9636-97d62e27a6a1', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 0, TIME '08:30:00', '6f9f97cb-26fb-42c5-951e-857c918a8e2e', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('9df027b4-0a92-4cb9-96ac-7b01c5611254', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 0, TIME '07:30:00', '6f9f97cb-26fb-42c5-951e-857c918a8e2e', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('9fcf917b-47d9-492a-91ef-8ca4af6fc31c', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 0, TIME '07:00:00', '6f9f97cb-26fb-42c5-951e-857c918a8e2e', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('aeec7af0-280b-4f3c-9583-8cfcd13eca4c', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 0, TIME '09:00:00', '6f9f97cb-26fb-42c5-951e-857c918a8e2e', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('b269bf95-bda1-42e0-956d-c37a15d81582', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 0, TIME '06:30:00', '6f9f97cb-26fb-42c5-951e-857c918a8e2e', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('b3cfe1a7-202c-4444-942d-d40050a44124', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 0, TIME '08:00:00', '6f9f97cb-26fb-42c5-951e-857c918a8e2e', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('b6775496-b1c1-4e8d-811f-ef6183aa8e01', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 0, TIME '09:00:00', 'd199c60a-5e16-4473-bb9f-4d89cdf554a1', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('bd797625-f0b6-4c1a-b11b-bc66fe7b45ed', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 0, TIME '07:00:00', 'd199c60a-5e16-4473-bb9f-4d89cdf554a1', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('c3851f95-0da9-4c81-a4d5-f14c40193518', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 0, TIME '08:00:00', '612a04b7-5c34-45f6-b262-eb0dad6d6708', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('d8ffeebf-6cff-4d74-9275-1defc335c713', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 0, TIME '08:30:00', 'd199c60a-5e16-4473-bb9f-4d89cdf554a1', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('d97cc0dc-bf8c-4fb5-8286-61d306f4e056', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 0, TIME '09:30:00', '6f9f97cb-26fb-42c5-951e-857c918a8e2e', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('e00f645a-81d1-4a56-be9d-863e6684e887', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 0, TIME '08:00:00', 'd199c60a-5e16-4473-bb9f-4d89cdf554a1', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('e4084217-a95e-4655-a838-e7c6bca3e4e0', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 0, TIME '09:00:00', '612a04b7-5c34-45f6-b262-eb0dad6d6708', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('ee0d348a-6c78-4d71-85d9-cbdb479eb2d6', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 0, TIME '06:00:00', 'c019be97-4bf5-4198-98eb-40225a967117', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('f2a59d3b-c1d5-4d2d-9be1-e28ee5a75e0e', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 0, TIME '08:30:00', 'c019be97-4bf5-4198-98eb-40225a967117', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('f544fc3f-5774-4404-9fd4-493453620522', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 0, TIME '07:30:00', 'c019be97-4bf5-4198-98eb-40225a967117', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('f7c428e8-11b3-40c3-b023-c7e7f0ce4dc1', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 0, TIME '06:00:00', '6f9f97cb-26fb-42c5-951e-857c918a8e2e', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('58afc509-4d8e-4c67-84e1-648ad4cf8be6', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Sơn lại mặt sân', TIME '12:00:00', '612a04b7-5c34-45f6-b262-eb0dad6d6708', TIMESTAMPTZ '-infinity');
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('6619442f-4280-41c1-a5dd-c4ddfd4a2554', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Hỏng đèn chiếu sáng', TIME '12:00:00', 'c019be97-4bf5-4198-98eb-40225a967117', TIMESTAMPTZ '-infinity');
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('cd8e3d21-9a33-4a37-9ac3-52dd3918c3d1', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Bảo trì định kỳ', TIME '12:00:00', '6f9f97cb-26fb-42c5-951e-857c918a8e2e', TIMESTAMPTZ '-infinity');
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('d4897ffa-4ed8-43cc-a030-84ed8c697aa7', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Tổ chức sự kiện nội bộ', TIME '12:00:00', 'd199c60a-5e16-4473-bb9f-4d89cdf554a1', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('528d38fe-2482-4b62-b93c-ad2b60c10648', 'dd8b2994-1a53-47c9-94bb-52212762a080', 'Dịch vụ ổn, giá hợp lý.', '8c709ec3-c343-4864-b55c-f406b6bc9dbf', TIMESTAMPTZ '-infinity', '975e3b6f-9706-4292-86ae-71efb214b812', FALSE, 4, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('6f1ea553-3172-4087-acd2-e496117c7142', 'b28b4391-9fb6-43df-a7e2-460b0931ba19', 'Sân rất tốt, sẽ quay lại!', '5f036b5d-e52a-4db5-b60f-6bc25f278263', TIMESTAMPTZ '-infinity', '975e3b6f-9706-4292-86ae-71efb214b812', FALSE, 5, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('7e243d90-3ed9-418d-b30c-4d0bb0cb8d12', '3745bcdc-44a3-4324-9c45-1981a9f0de3e', 'Nhân viên thân thiện, sân sạch.', '8c709ec3-c343-4864-b55c-f406b6bc9dbf', TIMESTAMPTZ '-infinity', '9ec5b629-ffe9-4b5a-9fee-929dfbad3a1b', FALSE, 5, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('85dd6023-a9f2-4d50-aedd-c11400fcaa54', '2dca5bad-6098-4c8d-adb4-e0a214eb2d4b', 'Bình thường, sân hơi cũ.', '46f63137-c4fc-4fac-9f0e-57dc828ec61d', TIMESTAMPTZ '-infinity', '9ec5b629-ffe9-4b5a-9fee-929dfbad3a1b', FALSE, 3, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('b9355a74-b125-4d68-b416-d3694a793731', '3c5eeabb-c2bc-4739-8b62-0a1de6665d30', 'Đèn chiếu sáng yếu vào ban đêm.', '5f036b5d-e52a-4db5-b60f-6bc25f278263', TIMESTAMPTZ '-infinity', '975e3b6f-9706-4292-86ae-71efb214b812', FALSE, 2, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('49b0aff6-2907-46fb-bf9f-3b20279e9514', 'b28b4391-9fb6-43df-a7e2-460b0931ba19', 'Booking #1 đã được xác nhận.', '5f036b5d-e52a-4db5-b60f-6bc25f278263', TIMESTAMPTZ '-infinity', FALSE, TRUE, 'Đặt sân thành công', 'Booking', TIMESTAMPTZ '-infinity', '8c681d6e-d23d-42e2-944a-efa1ce28f23d');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('8ce0bae6-fd7f-4d3e-a965-9a3c879b204b', '2dca5bad-6098-4c8d-adb4-e0a214eb2d4b', 'Bạn có lịch chơi vào ngày mai.', '46f63137-c4fc-4fac-9f0e-57dc828ec61d', TIMESTAMPTZ '-infinity', FALSE, 'Nhắc nhở lịch chơi', 'Remind', TIMESTAMPTZ '-infinity', '5210ccb2-b019-4d53-822e-c90a67145553');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('a26f3101-2b94-41a1-bfb0-403e9cb1308c', '3745bcdc-44a3-4324-9c45-1981a9f0de3e', 'Booking #4 đã bị huỷ. Tiền sẽ hoàn.', '16725258-236b-42d6-8b08-f22df0cef404', TIMESTAMPTZ '-infinity', FALSE, TRUE, 'Huỷ booking', 'Cancel', TIMESTAMPTZ '-infinity', '411bc086-c78e-4a41-82c1-60d33ff06f10');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('a46b9578-a595-4640-87ee-a9ae9e96b29b', '3c5eeabb-c2bc-4739-8b62-0a1de6665d30', 'Đã hoàn 360,000đ vào ví của bạn.', '5f036b5d-e52a-4db5-b60f-6bc25f278263', TIMESTAMPTZ '-infinity', FALSE, 'Hoàn tiền', 'Refund', TIMESTAMPTZ '-infinity', '8c681d6e-d23d-42e2-944a-efa1ce28f23d');
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('d2d97f64-7e96-4cc0-a2f8-2a1d65db077f', 'dd8b2994-1a53-47c9-94bb-52212762a080', 'Booking #2 đã được xác nhận.', '8c709ec3-c343-4864-b55c-f406b6bc9dbf', TIMESTAMPTZ '-infinity', FALSE, 'Đặt sân thành công', 'Booking', TIMESTAMPTZ '-infinity', '60d952c5-f6c6-4379-953d-b4dae01d5eef');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('216c2a9c-9bc1-43e4-8db6-ce635cafd496', TIMESTAMPTZ '-infinity', DATE '-infinity', TIME '20:00:00', FALSE, 200000.0, 0, TIME '18:00:00', '2c5e90e0-5363-434b-9209-e9047b0ecb97', TIMESTAMPTZ '-infinity');
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('4764524a-d4f4-4c17-a525-577873712026', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 208400.0, 0, TIME '12:00:00', '6f9f97cb-26fb-42c5-951e-857c918a8e2e', TIMESTAMPTZ '-infinity');
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('5504f636-06a5-4c1c-8f69-d2867e2fa82a', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 2054000.0, 0, TIME '12:00:00', 'c019be97-4bf5-4198-98eb-40225a967117', TIMESTAMPTZ '-infinity');
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('7cb1de6c-1790-4dd6-a1c7-f93baa344a68', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 220500.0, 0, TIME '12:00:00', '612a04b7-5c34-45f6-b262-eb0dad6d6708', TIMESTAMPTZ '-infinity');
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "SlotDuration", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('9311cd1d-8989-497a-bad0-0003d485698f', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 220800.0, 0, TIME '12:00:00', 'd199c60a-5e16-4473-bb9f-4d89cdf554a1', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('5a21ed24-d617-4c22-ba91-d9e6452cc84d', '3c5eeabb-c2bc-4739-8b62-0a1de6665d30', '16725258-236b-42d6-8b08-f22df0cef404', TIMESTAMPTZ '-infinity', '975e3b6f-9706-4292-86ae-71efb214b812', FALSE, 'Thông tin giờ mở cửa sai.', 'Pending', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('772e3db8-2289-4af5-8c7f-4b5fe0e35479', '3745bcdc-44a3-4324-9c45-1981a9f0de3e', '46f63137-c4fc-4fac-9f0e-57dc828ec61d', TIMESTAMPTZ '-infinity', '975e3b6f-9706-4292-86ae-71efb214b812', FALSE, 'Không hoàn tiền khi huỷ đúng hạn.', 'Rejected', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('8f8dfd07-bb4a-4f06-92c2-255ae279d969', 'dd8b2994-1a53-47c9-94bb-52212762a080', '5f036b5d-e52a-4db5-b60f-6bc25f278263', TIMESTAMPTZ '-infinity', '9ec5b629-ffe9-4b5a-9fee-929dfbad3a1b', FALSE, 'Chủ sân thái độ không tốt.', 'Resolved', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('a2b96f21-673f-4561-be15-960f37575e15', 'b28b4391-9fb6-43df-a7e2-460b0931ba19', '46f63137-c4fc-4fac-9f0e-57dc828ec61d', TIMESTAMPTZ '-infinity', '9ec5b629-ffe9-4b5a-9fee-929dfbad3a1b', FALSE, 'Sân không đúng mô tả.', 'Pending', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('f9940dcb-224f-4abc-9456-e96b48370f00', '2dca5bad-6098-4c8d-adb4-e0a214eb2d4b', '8c709ec3-c343-4864-b55c-f406b6bc9dbf', TIMESTAMPTZ '-infinity', '975e3b6f-9706-4292-86ae-71efb214b812', FALSE, 'Cơ sở vật chất xuống cấp.', 'Pending', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('4c383116-229e-43ad-b92a-c81bfc4584ef', 'ACT002', 270000.0, 3500000.0, 3770000.0, '3456789012', 'REF002', 'dd8b2994-1a53-47c9-94bb-52212762a080', TIMESTAMPTZ '-infinity', FALSE, 'SP002', 'SIG002', 'Success', 'Thanh toán booking #2', 'Payment', TIMESTAMPTZ '-infinity', 'cda7125c-6be8-4029-a5a5-539233993408');
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('beb87493-7b59-438d-a4a4-8129eb0026c1', 'ACT004', 500000.0, 2000000.0, 1500000.0, '5678901234', 'REF004', '3c5eeabb-c2bc-4739-8b62-0a1de6665d30', TIMESTAMPTZ '-infinity', FALSE, 'SP004', 'SIG004', 'Success', 'Nạp tiền vào ví', 'Deposit', TIMESTAMPTZ '-infinity', '0e3a2b3b-e9f6-4218-a63b-a976100bb9eb');
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('cee539db-c032-481e-a8da-ee3d8ddde8f3', 'ACT001', 180000.0, 2000000.0, 2180000.0, '2345678901', 'REF001', 'b28b4391-9fb6-43df-a7e2-460b0931ba19', TIMESTAMPTZ '-infinity', FALSE, 'SP001', 'SIG001', 'Success', 'Thanh toán booking #1', 'Payment', TIMESTAMPTZ '-infinity', '18085723-0a5b-4bf3-8eed-d26b6f455f72');
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('f5c566a8-4d1e-45e4-8d7f-0a2e0bd257ea', 'ACT003', 200000.0, 2200000.0, 2000000.0, '4567890123', 'REF003', '2dca5bad-6098-4c8d-adb4-e0a214eb2d4b', TIMESTAMPTZ '-infinity', FALSE, 'SP003', 'SIG003', 'Success', 'Hoàn tiền booking #4', 'Refund', TIMESTAMPTZ '-infinity', '4f6d36e1-975a-4f5d-b5ef-91a6b6e4ddba');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    CREATE UNIQUE INDEX "IX_ConfigSlots_SubCourtDetailId" ON "ConfigSlots" ("SubCourtDetailId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501101805_checkDboule') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20260501101805_checkDboule', '8.0.0');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = 'da62a70e-94b9-4517-aa6f-30a60c8080e6';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = 'dfd3203d-2851-4ff2-9251-9d8ed7c7df96';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = 'e714b1f7-ffc0-4d2e-b6d2-9ba869861dad';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = 'f93730ad-8121-40d3-93fa-ad65af7f4cb6';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = 'ff838465-01a7-4f9d-8ce7-a86442b51ac5';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "CampaignCourts"
    WHERE "Id" = '68e9715d-a8b3-4cc7-9185-f942f1226e62';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "CampaignCourts"
    WHERE "Id" = '9c7d896d-d35f-4e33-b69e-e6c0f2fcad39';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "CampaignCourts"
    WHERE "Id" = 'ba03879c-f8de-4926-ad42-ba337da7fe38';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "CampaignCourts"
    WHERE "Id" = 'd7242e7c-3ce6-4b13-9129-8c4c8f083466';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = '42743bc5-c630-496b-a30d-6baacbec5f6f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = 'b831b0c7-7bc4-4f3f-86fb-be235e9db520';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = 'e96d0185-562e-4368-b915-7640daa4d6e7';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = 'f6ec7a65-05fe-4e82-8a3a-da51da5b775b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '0fe5965e-01ab-4e57-bcfd-98dc3ed4a9e4';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '12290f1a-5a85-438f-9758-a50050a43580';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '179252ae-ca95-443a-ac85-091500e3d5f9';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '1ad1dc94-71f8-48f5-8e7c-949d3808b68c';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '2ad4a992-5fae-4ea9-aa29-6000f9626835';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '2affca85-f54d-4883-8cda-59b6de11c117';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '2b551390-8cb7-47a1-a68e-545ae5d3e74c';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '2c26ce59-e108-495c-9a45-01993b8a071e';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '31c3ddab-3c01-4110-b925-df4700d5791d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '3431212d-84e8-4166-baae-894c17575796';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '3678b89f-0e0b-4191-a20c-a95907efb9ff';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '37c04cb5-2e1c-4742-9265-21441ddedf05';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '53a4a846-1542-4ced-aef3-c62bbb538fec';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '7191558e-a5cf-4a1b-b819-f0db5750aba7';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '750c6af2-60df-49d3-8e9d-94289f1e482e';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '795741a3-aed1-421d-84f5-0dd51daec831';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '79ab0407-780f-4857-b411-fe6d16e1a13e';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '82ad649d-9586-4f65-b98a-74fa1b33501e';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '8444c62b-8b69-422c-8b02-e590ff9d8f50';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '8b3e4fa6-f588-4d2b-a9ee-5f7739e0279a';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '90da06b6-a898-402f-aee5-08ba0d4e7f25';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '99623a2e-809e-4f3d-8044-45a36badec47';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'a5004e51-b57f-461b-9a42-398c7f0fa352';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'ae0aea54-a42d-41d9-8868-abffa74df46f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'b1f9f8fb-4428-4f06-a294-0be88f05ce1f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'b5932c36-d999-4a58-aafe-e0fb1b4509a4';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'b7721f55-cfbb-4c85-a847-49a825f16b2b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'b96f8849-4047-4da7-9ffa-7b01a9c95a90';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'c1202c49-b801-4ede-8096-4d0a7a7c54d9';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'd25bbd18-08e8-4eaa-8a9f-9364c13860e9';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'd262e143-a5fe-4a97-acb3-6a978a60613c';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'e62c767d-907f-47c9-9092-6d0f423a14d4';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Exceptions"
    WHERE "Id" = '40c5d037-81b9-4c26-a04d-2ad5028a05fd';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Exceptions"
    WHERE "Id" = '41806e89-a5b6-4404-9d5c-49ead9df56ac';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Exceptions"
    WHERE "Id" = '853053de-3f6e-4b0c-91c0-d72e9c1b1517';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Exceptions"
    WHERE "Id" = 'cff90351-df45-4514-8316-6ce354106ecb';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = '30a74e45-9839-4d57-87e1-d6f4769aa358';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = '5a60dc88-248a-4886-bb2c-63ff1dbd4f00';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = '8c6af176-81b9-4a0b-8e6f-97aad328ff29';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = '9d2f4910-f8d2-4800-8ec2-3252bf2bd317';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = 'fb2233f5-c08b-4763-b5b9-8905a808da7b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = '1541f971-9010-4506-86dc-05533890cca8';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = '2c5893b9-25d6-470f-a775-01bce00b561d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = '6e9be15c-4f68-4438-9ad2-45defcd6f24f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = 'c7fbbb97-9ed1-40c3-8e44-9edf4491befd';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = 'f9bc7b7a-ebae-4202-8bfb-53ae63a808a7';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = '05f904de-8ef0-4f4f-b46f-b2baac0a3afe';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = '1a3b95a2-faab-4f4f-9918-a30c8d3279bd';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = '6d55c45e-e0d6-4c33-838f-c9b58fe302a5';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = '7129634b-2ced-4328-b141-dbda4b8579d7';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = 'f51a171f-57d3-410c-91c7-f6030b487227';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = '02a95818-600b-4ded-898b-041c836d4c5e';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = '4aad9e2a-9f93-4666-9196-1c2e180438e8';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = '621eb4ab-451b-4c2b-a239-f6b8c91231a4';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = 'b240bf91-b514-417d-ad9d-a73724c424d5';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = 'fa2f9115-7ed1-451b-b36f-c5a22a3c2333';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "OwnerRequests"
    WHERE "Id" = '23be78b3-7ee3-4dc4-870a-44b36309c284';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "OwnerRequests"
    WHERE "Id" = '853a212c-66df-436c-8d61-ffb113f0eb54';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Owners"
    WHERE "Id" = 'e6faadf1-5124-48ab-8f11-5034c003d4b9';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Reports"
    WHERE "Id" = '0d389f5c-d243-4ae6-9819-2211a257d141';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Reports"
    WHERE "Id" = '588e77ad-bd00-409f-bab6-50e0b8e1b9c1';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Reports"
    WHERE "Id" = '940aa375-5e62-4b1b-a6e1-e16f438927c7';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Reports"
    WHERE "Id" = 'b5f3efd3-8039-4416-b1cd-a2db4ef90e27';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Reports"
    WHERE "Id" = 'e590cc75-eadf-486b-8851-9431052560a8';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = '0a99b240-4cac-4967-8cf1-c7eca180d738';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = '50a7d8a0-8750-441c-9ef7-a23e5024e8cb';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = '7a02a21e-c779-4f0f-8fb8-2b8280d2a0bc';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = '15df93ad-b66d-4c4e-9688-42d1f1b9c653';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = '3744f2bd-db27-4956-a8a0-c638949fb35e';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = 'a8a590ad-2ee6-4e3b-85a9-41a127710bcc';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = 'c105d213-903b-4f10-8349-17ad56b2fe1b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = 'ca831a17-a598-48dc-8383-663a4e07e689';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Transactions"
    WHERE "Id" = '24149845-41a1-49f5-ac27-a91559d7008b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Transactions"
    WHERE "Id" = '70dd923b-eebc-4b64-9e47-4136e1528eb6';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Transactions"
    WHERE "Id" = '8751cffe-20db-496c-8a00-04cc7ca18aaf';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Transactions"
    WHERE "Id" = 'c4e41946-4e7f-4531-b88d-71758688d13d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Users"
    WHERE "Id" = 'b1a78501-1cd4-4d15-8fee-437302bbced0';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = '2f305eaa-2245-4b04-9553-40f6fb3e0913';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = '931fc5e4-664d-4b3f-92ff-03ce5d2e2086';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = 'ad57c07f-a0b7-4898-bfce-23855acbeaff';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = 'adb1b67d-6fb5-4431-bb2c-0f6e92d0c926';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = 'e9c9db67-186d-4110-8a41-a88bea3124f5';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = '002afa91-87ea-4069-b01a-b0695f01d92c';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = 'cc307fef-d579-4b6b-9609-40c9bdb5a69d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = 'd09add50-3fab-4b28-be52-57a0046af06d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = 'e3890d76-d401-431f-9286-5b43571f8822';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = 'ed040c6f-86f0-42f0-ae2d-4bb4a7048cd8';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Users"
    WHERE "Id" = '9aa16a91-e515-4ab6-b804-83a012f7e2ca';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Wallets"
    WHERE "Id" = '20a79c42-5b41-459e-927c-ac58873b942f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Wallets"
    WHERE "Id" = '3e150f3d-5d55-4328-99a6-9c7186ce981d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Wallets"
    WHERE "Id" = '63632a52-abf9-444f-b919-6fc39f1e17f9';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Wallets"
    WHERE "Id" = '70e6c118-8e1b-4b12-b138-a29b47d2efd2';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = '150f1fa5-a12c-4076-b30d-f5be62ecf1b8';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = '756c7617-141a-4122-aa4b-a6375c5d4ded';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Courts"
    WHERE "Id" = '07c0a296-c6dc-455a-954b-82dd557f410a';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Courts"
    WHERE "Id" = '321c4900-68e7-4780-934d-2928414af7fe';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Courts"
    WHERE "Id" = '8c439a86-f874-46e1-825e-646f900d77aa';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Courts"
    WHERE "Id" = 'e70101df-01de-44e7-83c3-d6756b1cc56d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Customers"
    WHERE "Id" = '14204186-d031-4052-bb86-32af7692a2cc';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Customers"
    WHERE "Id" = 'ddb9a44b-0e25-4364-a5de-42c8d6c57b0a';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Owners"
    WHERE "Id" = '0127ab70-281c-4f47-827e-c0cf0445fbe7';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Owners"
    WHERE "Id" = '95fee089-85d9-4424-97d0-80ac7ecba45f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Users"
    WHERE "Id" = '74e2566a-4799-4776-aa99-afa7f9412d5c';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Users"
    WHERE "Id" = 'f014b885-130c-44a7-8b92-03240e56ddf5';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Users"
    WHERE "Id" = '3aa29cf2-fb4e-4883-9da7-09f01aad3a24';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    DELETE FROM "Users"
    WHERE "Id" = '70c426f7-2219-4083-b3a4-8a6e9f3aec90';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    ALTER TABLE "BookingDetails" ADD "Status" text NOT NULL DEFAULT '';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('325f11cc-89e2-4451-b9a1-63ad5a9d2cf9', TIMESTAMPTZ '-infinity', 'owner1@rallyhub.vn', 'Minh', FALSE, 'Tuấn', 'hashed_pw_2', '0900000002', 'Owner', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('7d631f5a-0726-4992-84ef-d309b7632cbf', TIMESTAMPTZ '-infinity', 'owner2@rallyhub.vn', 'Hải', FALSE, 'Đăng', 'hashed_pw_3', '0900000003', 'Owner', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('ca83159a-9822-4124-9ad5-37fa0136d450', TIMESTAMPTZ '-infinity', 'customer2@gmail.com', 'Bảo', FALSE, 'Châu', 'hashed_pw_5', '0900000005', 'Customer', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('d2fef88b-665b-440c-91c6-a002550e8c36', TIMESTAMPTZ '-infinity', 'customer1@gmail.com', 'Lan', FALSE, 'Phương', 'hashed_pw_4', '0900000004', 'Customer', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('f4f135f5-6f87-4a45-a6f0-af291a66bc07', TIMESTAMPTZ '-infinity', 'admin@rallyhub.vn', 'Quản', FALSE, 'Trị', 'hashed_pw_1', '0900000001', 'Admin', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('f7b58062-7c98-45a5-b9ab-607508f80db4', TIMESTAMPTZ '-infinity', 'owner3@rallyhub.vn', 'Trần', FALSE, 'Phú', 'hashed_pw_6', '0900000006', 'Owner', 'Active', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    INSERT INTO "Customers" ("Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId")
    VALUES ('5db088a1-de2e-4adb-b3b4-0d54573fe5f9', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', 'd2fef88b-665b-440c-91c6-a002550e8c36');
    INSERT INTO "Customers" ("Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId")
    VALUES ('f24d4bac-cc54-4c3b-be63-9111ec891d5d', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', 'ca83159a-9822-4124-9ad5-37fa0136d450');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    INSERT INTO "Owners" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId")
    VALUES ('1100acdf-9477-438f-910e-75dcba72801e', '456 Lê Lợi, Q3, HCM', NULL, 'Trung Tâm Thể Thao Hải Đăng', TIMESTAMPTZ '-infinity', NULL, NULL, NULL, FALSE, '9876543210', TIMESTAMPTZ '-infinity', '7d631f5a-0726-4992-84ef-d309b7632cbf');
    INSERT INTO "Owners" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId")
    VALUES ('85c74e92-8c48-43fd-82dc-b2d7cbe0b43f', '123 Nguyễn Huệ, Q1, HCM', NULL, 'Sân Cầu Lông Minh Tuấn', TIMESTAMPTZ '-infinity', NULL, NULL, NULL, FALSE, '0123456789', TIMESTAMPTZ '-infinity', '325f11cc-89e2-4451-b9a1-63ad5a9d2cf9');
    INSERT INTO "Owners" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId")
    VALUES ('a5a38fb8-8932-4f79-9a56-6b56e390ec3a', 'Tôn Đức Thắng, HCM', NULL, 'Sân Cầu Lông Trần Phú', TIMESTAMPTZ '-infinity', NULL, NULL, NULL, FALSE, '98765434219', TIMESTAMPTZ '-infinity', 'f7b58062-7c98-45a5-b9ab-607508f80db4');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('329f606a-ed7c-4ddb-9b5c-a3b1865b58e6', TIMESTAMPTZ '-infinity', FALSE, 'Không thể thanh toán qua ví.', 'Pending', 'Lỗi thanh toán', TIMESTAMPTZ '-infinity', '325f11cc-89e2-4451-b9a1-63ad5a9d2cf9');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('61678567-ccf7-4084-9577-77c1073839f4', TIMESTAMPTZ '-infinity', FALSE, 'Số dư hiển thị không khớp lịch sử.', 'Resolved', 'Sai số dư sau giao dịch', TIMESTAMPTZ '-infinity', 'ca83159a-9822-4124-9ad5-37fa0136d450');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('c252dad5-2305-445e-aa32-92dee9af8ec4', TIMESTAMPTZ '-infinity', FALSE, 'Crash khi mở trang tìm kiếm sân.', 'Pending', 'App bị crash', TIMESTAMPTZ '-infinity', 'd2fef88b-665b-440c-91c6-a002550e8c36');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('c5c75c62-6297-43be-947e-65d1eb14a558', TIMESTAMPTZ '-infinity', FALSE, 'OTP không gửi đến số điện thoại.', 'Pending', 'Không nhận được OTP', TIMESTAMPTZ '-infinity', 'd2fef88b-665b-440c-91c6-a002550e8c36');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('da34b554-e043-4e9f-9940-6d9d06ab9759', TIMESTAMPTZ '-infinity', FALSE, 'Bản đồ không load được trên iOS.', 'Resolved', 'Lỗi hiển thị bản đồ', TIMESTAMPTZ '-infinity', '7d631f5a-0726-4992-84ef-d309b7632cbf');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('28c6d71c-a906-454d-b390-6447c964d891', 3500000.0, '5678901234', 'VPBank', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', 'ca83159a-9822-4124-9ad5-37fa0136d450', 0);
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('43202ae3-0155-40e6-963c-b62a1b72050e', 12000000.0, '2345678901', 'Techcombank', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '325f11cc-89e2-4451-b9a1-63ad5a9d2cf9', 0);
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('7450d841-4ec7-4ac7-8acd-e8ec9bf2d3a0', 2000000.0, '4567890123', 'MB Bank', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', 'd2fef88b-665b-440c-91c6-a002550e8c36', 0);
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('96c26ae8-9546-43db-b175-d32b6275bf20', 8500000.0, '3456789012', 'BIDV', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '7d631f5a-0726-4992-84ef-d309b7632cbf', 0);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('0ec1770a-7e09-4a8a-8a99-ab1da7607167', 'FLASH50', TIMESTAMPTZ '-infinity', 50.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 200000.0, 500000.0, '85c74e92-8c48-43fd-82dc-b2d7cbe0b43f', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 10, 10);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('17966520-b824-43a1-acf8-099bac5edce5', 'YEUTH', TIMESTAMPTZ '-infinity', 5.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 30000.0, 100000.0, '85c74e92-8c48-43fd-82dc-b2d7cbe0b43f', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 500, 87);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('18290555-1ef8-40b4-b8e2-6b8c35b72bfa', 'WEEKEND10', TIMESTAMPTZ '-infinity', 15.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 75000.0, 250000.0, '1100acdf-9477-438f-910e-75dcba72801e', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 200, 30);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('48733b0b-3690-4e0c-9f73-bbcc04fc13ec', 'NEWUSER', TIMESTAMPTZ '-infinity', 20.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 100000.0, 300000.0, '1100acdf-9477-438f-910e-75dcba72801e', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 50, 5);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('aa4e8b51-98c1-4192-83b7-2ce4ba2931a8', 'LOYAL5', TIMESTAMPTZ '-infinity', 5.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 30000.0, 100000.0, '1100acdf-9477-438f-910e-75dcba72801e', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 500, 87);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('c93c9a2b-5664-475f-9b36-3d8268623351', 'SUMMER25', TIMESTAMPTZ '-infinity', 10.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 50000.0, 200000.0, '85c74e92-8c48-43fd-82dc-b2d7cbe0b43f', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 100, 12);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('8b57a628-37fd-4415-b9a6-69ecc76586cb', '123 Nguyễn Huệ, Q1, HCM', TIME '22:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.77, 106.7, 'https://maps.google.com/?q=10.77,106.70', 'Sân A - Minh Tuấn', TIME '06:00:00', '85c74e92-8c48-43fd-82dc-b2d7cbe0b43f', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('8dbd5c3e-f88a-4c67-b85c-0ce83e7af7b5', '456 Lê Lợi, Q3, HCM', TIME '23:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.78, 106.69, 'https://maps.google.com/?q=10.78,106.69', 'Sân D - Hải Đăng', TIME '05:30:00', '1100acdf-9477-438f-910e-75dcba72801e', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('a25167df-fd5b-4683-afeb-4aee66ca18ce', '123 Nguyễn Huệ, Q1, HCM', TIME '22:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.77, 106.7, 'https://maps.google.com/?q=10.77,106.70', 'Sân B - Minh Tuấn', TIME '06:00:00', '85c74e92-8c48-43fd-82dc-b2d7cbe0b43f', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('aa6c63d5-46ae-4fdd-91d4-04d6a1e549e1', '456 Lê Lợi, Q3, HCM', TIME '23:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.78, 106.69, 'https://maps.google.com/?q=10.78,106.69', 'Sân C - Hải Đăng', TIME '05:30:00', '1100acdf-9477-438f-910e-75dcba72801e', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    INSERT INTO "OwnerRequests" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "CustomerId", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "OwnerId", "RejectionReason", "Status", "TaxCode", "UpdatedAt")
    VALUES ('92e1ee5a-3cd3-48ee-a40c-d32cb150de1d', '123 Nguyễn Huệ, Q1, HCM', 'https://cdn.rallyhub.vn/license/1.jpg', 'Sân Cầu Lông Minh Tuấn', TIMESTAMPTZ '-infinity', '5db088a1-de2e-4adb-b3b4-0d54573fe5f9', 'https://cdn.rallyhub.vn/cccd/1_back.jpg', 'https://cdn.rallyhub.vn/cccd/1_front.jpg', '079200012345', FALSE, '85c74e92-8c48-43fd-82dc-b2d7cbe0b43f', NULL, 'Approved', '0123456789', TIMESTAMPTZ '-infinity');
    INSERT INTO "OwnerRequests" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "CustomerId", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "OwnerId", "RejectionReason", "Status", "TaxCode", "UpdatedAt")
    VALUES ('b46512b6-faaa-4008-a43a-ad964d770a8d', '456 Lê Lợi, Q3, HCM', 'https://cdn.rallyhub.vn/license/2.jpg', 'Trung Tâm Thể Thao Hải Đăng', TIMESTAMPTZ '-infinity', 'f24d4bac-cc54-4c3b-be63-9111ec891d5d', 'https://cdn.rallyhub.vn/cccd/2_back.jpg', 'https://cdn.rallyhub.vn/cccd/2_front.jpg', '079200054321', FALSE, '1100acdf-9477-438f-910e-75dcba72801e', NULL, 'Approved', '9876543210', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('1fd48624-e297-40dd-ba06-2c5150d8c6d2', 'c93c9a2b-5664-475f-9b36-3d8268623351', NULL, TIMESTAMPTZ '-infinity', '5db088a1-de2e-4adb-b3b4-0d54573fe5f9', 30000.0, 270000.0, FALSE, 'Banked', 300000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('41b1dbc3-9f3d-41fc-855f-8a6a18906b26', '48733b0b-3690-4e0c-9f73-bbcc04fc13ec', NULL, TIMESTAMPTZ '-infinity', 'f24d4bac-cc54-4c3b-be63-9111ec891d5d', 40000.0, 360000.0, FALSE, 'Banked', 400000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('4583bf0e-609b-4a67-9b29-d9cf1bf11ffb', 'c93c9a2b-5664-475f-9b36-3d8268623351', NULL, TIMESTAMPTZ '-infinity', '5db088a1-de2e-4adb-b3b4-0d54573fe5f9', 20000.0, 180000.0, FALSE, 'Complete', 200000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('bbfc87b8-2131-4991-8775-0c11521952c9', '48733b0b-3690-4e0c-9f73-bbcc04fc13ec', 'Khách huỷ', TIMESTAMPTZ '-infinity', 'f24d4bac-cc54-4c3b-be63-9111ec891d5d', 50000.0, 200000.0, FALSE, 'Cancel', 250000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('f2f3ef55-5551-44b4-98aa-a9ada2a0b508', '48733b0b-3690-4e0c-9f73-bbcc04fc13ec', NULL, TIMESTAMPTZ '-infinity', 'f24d4bac-cc54-4c3b-be63-9111ec891d5d', 0.0, 150000.0, FALSE, 'Complete', 150000.0, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('01ba8d87-8aed-40b8-9286-3850f0780e44', 'c93c9a2b-5664-475f-9b36-3d8268623351', '8dbd5c3e-f88a-4c67-b85c-0ce83e7af7b5', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('ba79058d-c94a-4dc2-acf0-6434ff1c0b31', '48733b0b-3690-4e0c-9f73-bbcc04fc13ec', '8b57a628-37fd-4415-b9a6-69ecc76586cb', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('d6bbba68-0271-4dae-97f5-046a86932e3b', 'c93c9a2b-5664-475f-9b36-3d8268623351', 'aa6c63d5-46ae-4fdd-91d4-04d6a1e549e1', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('e2837634-5344-4ac0-9091-117cb7141e40', '48733b0b-3690-4e0c-9f73-bbcc04fc13ec', 'a25167df-fd5b-4683-afeb-4aee66ca18ce', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('203e6f7d-177a-4836-a03c-934723709f78', 'a25167df-fd5b-4683-afeb-4aee66ca18ce', TIMESTAMPTZ '-infinity', '5db088a1-de2e-4adb-b3b4-0d54573fe5f9', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('213eb5cf-58a1-48bb-b322-71dece2d415e', '8b57a628-37fd-4415-b9a6-69ecc76586cb', TIMESTAMPTZ '-infinity', '5db088a1-de2e-4adb-b3b4-0d54573fe5f9', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('addb6faa-ab2a-4e85-a449-cd5bec9a9e2a', '8dbd5c3e-f88a-4c67-b85c-0ce83e7af7b5', TIMESTAMPTZ '-infinity', 'f24d4bac-cc54-4c3b-be63-9111ec891d5d', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('b06b17bb-712d-46e9-9fb4-42e550e12bcc', '8b57a628-37fd-4415-b9a6-69ecc76586cb', TIMESTAMPTZ '-infinity', 'f24d4bac-cc54-4c3b-be63-9111ec891d5d', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('b30d8f67-d69d-4990-85ba-2cca8fd0d666', 'aa6c63d5-46ae-4fdd-91d4-04d6a1e549e1', TIMESTAMPTZ '-infinity', 'f24d4bac-cc54-4c3b-be63-9111ec891d5d', FALSE, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('363f9158-a618-43c9-a9b4-f3c2f6231c0c', '8b57a628-37fd-4415-b9a6-69ecc76586cb', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ A2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('c8f92c43-3a5e-432a-848b-b88ae24d294d', '8b57a628-37fd-4415-b9a6-69ecc76586cb', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ A1', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('cdb5d991-7543-4e6c-af74-d81bec0d09a3', '8dbd5c3e-f88a-4c67-b85c-0ce83e7af7b5', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ D1', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('e170f840-afb6-4561-9686-06766bc538a1', '8dbd5c3e-f88a-4c67-b85c-0ce83e7af7b5', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ D2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('e27d0088-f2bc-486e-a831-f107483a17d4', 'aa6c63d5-46ae-4fdd-91d4-04d6a1e549e1', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ C2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('e312be50-0495-449e-ae79-813878141907', 'a25167df-fd5b-4683-afeb-4aee66ca18ce', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ B2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('fb624a13-2e8d-4083-913c-127eac000faa', 'aa6c63d5-46ae-4fdd-91d4-04d6a1e549e1', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ C1', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('fe2b77a8-3ae1-4beb-a011-8440afb4698c', 'a25167df-fd5b-4683-afeb-4aee66ca18ce', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ B1', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "Status", "SubCourtId", "UpdatedAt")
    VALUES ('198db1f2-6685-457b-8b3d-bbb07abc5bb8', '1fd48624-e297-40dd-ba06-2c5150d8c6d2', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-26T23:32:51.844121+07:00', TIME '07:00:00', FALSE, 100000.0, TIME '06:00:00', 'Banked', 'fe2b77a8-3ae1-4beb-a011-8440afb4698c', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "Status", "SubCourtId", "UpdatedAt")
    VALUES ('833bdf6c-bd56-4500-93a5-8b1f5155b02f', 'bbfc87b8-2131-4991-8775-0c11521952c9', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-28T23:32:51.844121+07:00', TIME '10:00:00', FALSE, 150000.0, TIME '06:00:00', 'Cancel', 'cdb5d991-7543-4e6c-af74-d81bec0d09a3', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "Status", "SubCourtId", "UpdatedAt")
    VALUES ('909d3931-8a15-407d-8205-330ccf798e74', '4583bf0e-609b-4a67-9b29-d9cf1bf11ffb', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-26T23:32:51.844115+07:00', TIME '10:00:00', FALSE, 100000.0, TIME '08:00:00', 'Banked', 'c8f92c43-3a5e-432a-848b-b88ae24d294d', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "Status", "SubCourtId", "UpdatedAt")
    VALUES ('a6616fb9-46f4-472b-93bd-562844b3027b', '41b1dbc3-9f3d-41fc-855f-8a6a18906b26', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-05-02T23:32:51.844123+07:00', TIME '10:00:00', FALSE, 150000.0, TIME '09:00:00', 'Banked', '363f9158-a618-43c9-a9b4-f3c2f6231c0c', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "Status", "SubCourtId", "UpdatedAt")
    VALUES ('e4839426-9230-47f4-b56f-45ab7904575b', 'f2f3ef55-5551-44b4-98aa-a9ada2a0b508', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-28T23:32:51.844121+07:00', TIME '08:00:00', FALSE, 150000.0, TIME '07:00:00', 'Banked', 'fb624a13-2e8d-4083-913c-127eac000faa', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('08e853c7-bb7c-47fa-8ca4-6d76ad2d5419', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 70000.0, TIME '06:00:00', 'fe2b77a8-3ae1-4beb-a011-8440afb4698c', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('09df1a62-b398-400d-974f-d83757c53370', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 35000.0, TIME '09:00:00', 'fb624a13-2e8d-4083-913c-127eac000faa', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('0cd28d7f-2210-40c3-a75b-dc84aa19d21f', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 35000.0, TIME '08:00:00', 'fb624a13-2e8d-4083-913c-127eac000faa', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('0fa59594-b609-4a17-83b0-5af02077e1b3', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 100000.0, TIME '08:30:00', 'cdb5d991-7543-4e6c-af74-d81bec0d09a3', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('30b3be9c-92e5-49ee-b9a8-bdb076401052', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 70000.0, TIME '07:00:00', 'fe2b77a8-3ae1-4beb-a011-8440afb4698c', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('5187b122-fc00-426d-bf47-406745797e01', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 100000.0, TIME '08:00:00', 'cdb5d991-7543-4e6c-af74-d81bec0d09a3', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('5373809d-00fd-4300-8fcd-48c9b657334e', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 70000.0, TIME '08:30:00', 'fe2b77a8-3ae1-4beb-a011-8440afb4698c', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('68d9bcd6-0580-4e14-9d76-5e88eff179fe', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 50000.0, TIME '06:00:00', 'c8f92c43-3a5e-432a-848b-b88ae24d294d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('6c4becf4-b700-4e50-9320-e3db1279850e', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 70000.0, TIME '09:00:00', 'fe2b77a8-3ae1-4beb-a011-8440afb4698c', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('6c993422-906f-498c-9992-42562cbc9826', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 100000.0, TIME '06:30:00', 'cdb5d991-7543-4e6c-af74-d81bec0d09a3', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('72771041-42ff-4acb-9cbf-d20edca36d2a', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 35000.0, TIME '06:30:00', 'fb624a13-2e8d-4083-913c-127eac000faa', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('7a5662d1-3974-4f72-8113-5a06c3999c0a', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 50000.0, TIME '09:00:00', 'c8f92c43-3a5e-432a-848b-b88ae24d294d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('7b44dcc0-6117-4729-b307-6e1ce0644cf0', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 100000.0, TIME '09:30:00', 'cdb5d991-7543-4e6c-af74-d81bec0d09a3', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('828244b8-297a-4fe0-9466-db8c8147cf63', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 35000.0, TIME '09:30:00', 'fb624a13-2e8d-4083-913c-127eac000faa', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('867dce7d-01a6-4ecc-b162-aa248b8ec221', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 70000.0, TIME '08:00:00', 'fe2b77a8-3ae1-4beb-a011-8440afb4698c', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('8844f2dc-5f67-409f-b9c3-ed0bb463ac12', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 100000.0, TIME '07:00:00', 'cdb5d991-7543-4e6c-af74-d81bec0d09a3', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('8be79f04-7873-48e3-a14b-9a54539c9c8e', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 50000.0, TIME '08:00:00', 'c8f92c43-3a5e-432a-848b-b88ae24d294d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('8f959bde-c9fd-4c29-adaa-455883ca23c6', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 35000.0, TIME '06:00:00', 'fb624a13-2e8d-4083-913c-127eac000faa', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('945bf0a2-746e-45b0-9d43-d14392ac6a2b', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 100000.0, TIME '07:30:00', 'cdb5d991-7543-4e6c-af74-d81bec0d09a3', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('97a74d21-efd4-473a-875e-2206829a9274', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 50000.0, TIME '09:30:00', 'c8f92c43-3a5e-432a-848b-b88ae24d294d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('a2f7874d-c339-4035-882e-4ebc67c53183', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 50000.0, TIME '08:30:00', 'c8f92c43-3a5e-432a-848b-b88ae24d294d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('a94a2dff-c563-400f-b57e-40bf4ae7e634', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 50000.0, TIME '07:30:00', 'c8f92c43-3a5e-432a-848b-b88ae24d294d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('a97f186a-fe1f-4620-9c2a-adac148325a8', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 100000.0, TIME '06:00:00', 'cdb5d991-7543-4e6c-af74-d81bec0d09a3', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('ad7a05d3-aa58-49eb-b21e-7917a82e4b56', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 70000.0, TIME '06:30:00', 'fe2b77a8-3ae1-4beb-a011-8440afb4698c', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('b4802639-1834-4eff-8faf-34dc278ff67c', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 50000.0, TIME '07:00:00', 'c8f92c43-3a5e-432a-848b-b88ae24d294d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('bbed2e85-1d70-4e33-b351-9f30947f0eb2', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 70000.0, TIME '09:30:00', 'fe2b77a8-3ae1-4beb-a011-8440afb4698c', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('be87b5fd-2e2d-435d-8dff-7b3118095e73', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 35000.0, TIME '08:30:00', 'fb624a13-2e8d-4083-913c-127eac000faa', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('c08e6b9c-05bc-4568-96cc-dd28a80a400e', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 35000.0, TIME '07:30:00', 'fb624a13-2e8d-4083-913c-127eac000faa', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('cc2984fc-10fb-4af9-9db6-bae55f162f02', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 50000.0, TIME '06:30:00', 'c8f92c43-3a5e-432a-848b-b88ae24d294d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('d029fa8a-5371-4457-9721-63afb989019b', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 35000.0, TIME '07:00:00', 'fb624a13-2e8d-4083-913c-127eac000faa', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('e1d57044-a906-4d94-aa9a-f26e50682780', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 70000.0, TIME '07:30:00', 'fe2b77a8-3ae1-4beb-a011-8440afb4698c', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('f5563ff6-3405-4a2d-8a32-ef2fc63148a8', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 100000.0, TIME '09:00:00', 'cdb5d991-7543-4e6c-af74-d81bec0d09a3', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('04a50a9d-2cea-4480-9517-6e2540cfd07f', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Tổ chức sự kiện nội bộ', TIME '12:00:00', 'cdb5d991-7543-4e6c-af74-d81bec0d09a3', TIMESTAMPTZ '-infinity');
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('2cba5610-b4eb-40e9-afed-bd6dbee98a38', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Bảo trì định kỳ', TIME '12:00:00', 'c8f92c43-3a5e-432a-848b-b88ae24d294d', TIMESTAMPTZ '-infinity');
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('3042a9e2-34e9-40fb-873e-9ff2e52de18b', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Sơn lại mặt sân', TIME '12:00:00', 'fe2b77a8-3ae1-4beb-a011-8440afb4698c', TIMESTAMPTZ '-infinity');
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('9cd9c90b-f84a-44c0-8332-df544cc170df', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Hỏng đèn chiếu sáng', TIME '12:00:00', 'fb624a13-2e8d-4083-913c-127eac000faa', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('39326c8a-1f33-497e-9272-2f383ae83a89', '1fd48624-e297-40dd-ba06-2c5150d8c6d2', 'Dịch vụ ổn, giá hợp lý.', 'a25167df-fd5b-4683-afeb-4aee66ca18ce', TIMESTAMPTZ '-infinity', 'f24d4bac-cc54-4c3b-be63-9111ec891d5d', FALSE, 4, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('6f43ce74-4d46-4d2d-88fa-5a6e6144327e', 'bbfc87b8-2131-4991-8775-0c11521952c9', 'Nhân viên thân thiện, sân sạch.', 'a25167df-fd5b-4683-afeb-4aee66ca18ce', TIMESTAMPTZ '-infinity', '5db088a1-de2e-4adb-b3b4-0d54573fe5f9', FALSE, 5, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('7749e2ec-f123-4def-87df-510af98c9836', '41b1dbc3-9f3d-41fc-855f-8a6a18906b26', 'Đèn chiếu sáng yếu vào ban đêm.', '8b57a628-37fd-4415-b9a6-69ecc76586cb', TIMESTAMPTZ '-infinity', 'f24d4bac-cc54-4c3b-be63-9111ec891d5d', FALSE, 2, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('d5ca9a9b-9bde-4f71-bb28-bd72c3ab9d47', '4583bf0e-609b-4a67-9b29-d9cf1bf11ffb', 'Sân rất tốt, sẽ quay lại!', '8b57a628-37fd-4415-b9a6-69ecc76586cb', TIMESTAMPTZ '-infinity', 'f24d4bac-cc54-4c3b-be63-9111ec891d5d', FALSE, 5, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('f885a7bb-b32b-4b92-ac84-0dab988c01ce', 'f2f3ef55-5551-44b4-98aa-a9ada2a0b508', 'Bình thường, sân hơi cũ.', 'aa6c63d5-46ae-4fdd-91d4-04d6a1e549e1', TIMESTAMPTZ '-infinity', '5db088a1-de2e-4adb-b3b4-0d54573fe5f9', FALSE, 3, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('070e7dd3-17d4-475b-9522-35d5c63bbf47', '1fd48624-e297-40dd-ba06-2c5150d8c6d2', 'Booking #2 đã được xác nhận.', 'a25167df-fd5b-4683-afeb-4aee66ca18ce', TIMESTAMPTZ '-infinity', FALSE, 'Đặt sân thành công', 'Booking', TIMESTAMPTZ '-infinity', '7d631f5a-0726-4992-84ef-d309b7632cbf');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('167cbc79-182b-4ef0-a0f0-b5e1caa07587', 'bbfc87b8-2131-4991-8775-0c11521952c9', 'Booking #4 đã bị huỷ. Tiền sẽ hoàn.', '8dbd5c3e-f88a-4c67-b85c-0ce83e7af7b5', TIMESTAMPTZ '-infinity', FALSE, TRUE, 'Huỷ booking', 'Cancel', TIMESTAMPTZ '-infinity', 'ca83159a-9822-4124-9ad5-37fa0136d450');
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('3de5364d-8547-4272-8d30-4f46e4592410', '4583bf0e-609b-4a67-9b29-d9cf1bf11ffb', 'Booking #1 đã được xác nhận.', '8b57a628-37fd-4415-b9a6-69ecc76586cb', TIMESTAMPTZ '-infinity', FALSE, TRUE, 'Đặt sân thành công', 'Booking', TIMESTAMPTZ '-infinity', '325f11cc-89e2-4451-b9a1-63ad5a9d2cf9');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('58174da7-fc09-408c-ad04-6d941835b712', 'f2f3ef55-5551-44b4-98aa-a9ada2a0b508', 'Bạn có lịch chơi vào ngày mai.', 'aa6c63d5-46ae-4fdd-91d4-04d6a1e549e1', TIMESTAMPTZ '-infinity', FALSE, 'Nhắc nhở lịch chơi', 'Remind', TIMESTAMPTZ '-infinity', 'd2fef88b-665b-440c-91c6-a002550e8c36');
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('d036c1ba-1581-4b39-803e-6b2f77b70d0a', '41b1dbc3-9f3d-41fc-855f-8a6a18906b26', 'Đã hoàn 360,000đ vào ví của bạn.', '8b57a628-37fd-4415-b9a6-69ecc76586cb', TIMESTAMPTZ '-infinity', FALSE, 'Hoàn tiền', 'Refund', TIMESTAMPTZ '-infinity', '325f11cc-89e2-4451-b9a1-63ad5a9d2cf9');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "IsRecurring", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('0e1587e0-e4f0-45b6-8534-ab3503e7abcd', TIMESTAMPTZ '-infinity', DATE '-infinity', 1, TIME '20:00:00', FALSE, TRUE, 200000.0, TIME '18:00:00', '363f9158-a618-43c9-a9b4-f3c2f6231c0c', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('34cfbbe8-42f9-4ae4-aef9-7814cdedd779', TIMESTAMPTZ '-infinity', DATE '2026-04-25', 0, TIME '17:00:00', FALSE, 220500.0, TIME '12:00:00', 'fe2b77a8-3ae1-4beb-a011-8440afb4698c', TIMESTAMPTZ '-infinity');
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('34dd16a2-385f-44ec-9425-2c931bbda3eb', TIMESTAMPTZ '-infinity', DATE '2026-04-25', 0, TIME '17:00:00', FALSE, 208400.0, TIME '12:00:00', 'c8f92c43-3a5e-432a-848b-b88ae24d294d', TIMESTAMPTZ '-infinity');
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('3d0592ef-05fe-4c8e-970e-88f29d7e4662', TIMESTAMPTZ '-infinity', DATE '2026-04-25', 0, TIME '17:00:00', FALSE, 2054000.0, TIME '12:00:00', 'fb624a13-2e8d-4083-913c-127eac000faa', TIMESTAMPTZ '-infinity');
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('486a3df9-5460-4b3a-9580-7707c5ff9f59', TIMESTAMPTZ '-infinity', DATE '2026-04-25', 0, TIME '17:00:00', FALSE, 220800.0, TIME '12:00:00', 'cdb5d991-7543-4e6c-af74-d81bec0d09a3', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('56ca3b3e-0c8e-423c-919a-5f949aa87c59', '4583bf0e-609b-4a67-9b29-d9cf1bf11ffb', 'aa6c63d5-46ae-4fdd-91d4-04d6a1e549e1', TIMESTAMPTZ '-infinity', '5db088a1-de2e-4adb-b3b4-0d54573fe5f9', FALSE, 'Sân không đúng mô tả.', 'Pending', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('98fb7f6d-7108-4906-8468-d79cf03278d8', '1fd48624-e297-40dd-ba06-2c5150d8c6d2', '8b57a628-37fd-4415-b9a6-69ecc76586cb', TIMESTAMPTZ '-infinity', '5db088a1-de2e-4adb-b3b4-0d54573fe5f9', FALSE, 'Chủ sân thái độ không tốt.', 'Resolved', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('bf715c82-38da-4609-93eb-2ea01863beb1', 'f2f3ef55-5551-44b4-98aa-a9ada2a0b508', 'a25167df-fd5b-4683-afeb-4aee66ca18ce', TIMESTAMPTZ '-infinity', 'f24d4bac-cc54-4c3b-be63-9111ec891d5d', FALSE, 'Cơ sở vật chất xuống cấp.', 'Pending', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('ca51cd91-1f09-473e-aae2-b4d8b0252a23', '41b1dbc3-9f3d-41fc-855f-8a6a18906b26', '8dbd5c3e-f88a-4c67-b85c-0ce83e7af7b5', TIMESTAMPTZ '-infinity', 'f24d4bac-cc54-4c3b-be63-9111ec891d5d', FALSE, 'Thông tin giờ mở cửa sai.', 'Pending', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('f78284e3-77bc-4354-851e-4abade426128', 'bbfc87b8-2131-4991-8775-0c11521952c9', 'aa6c63d5-46ae-4fdd-91d4-04d6a1e549e1', TIMESTAMPTZ '-infinity', 'f24d4bac-cc54-4c3b-be63-9111ec891d5d', FALSE, 'Không hoàn tiền khi huỷ đúng hạn.', 'Rejected', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('024ec366-2179-4916-a3ec-5322df3b9e83', 'ACT003', 200000.0, 2200000.0, 2000000.0, '4567890123', 'REF003', 'f2f3ef55-5551-44b4-98aa-a9ada2a0b508', TIMESTAMPTZ '-infinity', FALSE, 'SP003', 'SIG003', 'Success', 'Hoàn tiền booking #4', 'Refund', TIMESTAMPTZ '-infinity', '7450d841-4ec7-4ac7-8acd-e8ec9bf2d3a0');
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('32fc072e-9e37-4aa3-889b-13578e78721d', 'ACT001', 180000.0, 2000000.0, 2180000.0, '2345678901', 'REF001', '4583bf0e-609b-4a67-9b29-d9cf1bf11ffb', TIMESTAMPTZ '-infinity', FALSE, 'SP001', 'SIG001', 'Success', 'Thanh toán booking #1', 'Payment', TIMESTAMPTZ '-infinity', '43202ae3-0155-40e6-963c-b62a1b72050e');
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('5b664b4b-f247-49b1-a110-b4bbe518e357', 'ACT002', 270000.0, 3500000.0, 3770000.0, '3456789012', 'REF002', '1fd48624-e297-40dd-ba06-2c5150d8c6d2', TIMESTAMPTZ '-infinity', FALSE, 'SP002', 'SIG002', 'Success', 'Thanh toán booking #2', 'Payment', TIMESTAMPTZ '-infinity', '96c26ae8-9546-43db-b175-d32b6275bf20');
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('980d95a0-8b03-4591-9485-b08b4c3c9fea', 'ACT004', 500000.0, 2000000.0, 1500000.0, '5678901234', 'REF004', '41b1dbc3-9f3d-41fc-855f-8a6a18906b26', TIMESTAMPTZ '-infinity', FALSE, 'SP004', 'SIG004', 'Success', 'Nạp tiền vào ví', 'Deposit', TIMESTAMPTZ '-infinity', '28c6d71c-a906-454d-b390-6447c964d891');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260501163257_AddStatusBookingDetails') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20260501163257_AddStatusBookingDetails', '8.0.0');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE TABLE "Users" (
        "Id" uuid NOT NULL,
        "Email" character varying(50) NOT NULL,
        "PasswordHash" character varying(100) NOT NULL,
        "Role" character varying(50) NOT NULL DEFAULT 'Customer',
        "FirstName" character varying(100) NOT NULL,
        "LastName" character varying(100) NOT NULL,
        "PhoneNumber" character varying(11),
        "Status" character varying(50) NOT NULL DEFAULT 'Active',
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Users" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE TABLE "Customers" (
        "Id" uuid NOT NULL,
        "UserId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Customers" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Customers_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE TABLE "Owners" (
        "Id" uuid NOT NULL,
        "BusinessName" character varying(500) NOT NULL,
        "TaxCode" character varying(50) NOT NULL,
        "BusinessAddress" character varying(500) NOT NULL,
        "BusinessLicenseUrl" text,
        "IdentityNumber" text,
        "IdentityCardFrontUrl" text,
        "IdentityCardBackUrl" text,
        "UserId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Owners" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Owners_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE TABLE "SystemReports" (
        "Id" uuid NOT NULL,
        "Title" character varying(50) NOT NULL,
        "Reason" character varying(500) NOT NULL,
        "Status" text NOT NULL DEFAULT 'Pending',
        "UserId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_SystemReports" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_SystemReports_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE TABLE "Wallets" (
        "Id" uuid NOT NULL,
        "BankName" character varying(50) NOT NULL,
        "BankAccount" character varying(100) NOT NULL,
        "Balance" numeric(18,2) NOT NULL DEFAULT 0.0,
        "Version" integer NOT NULL,
        "UserId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Wallets" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Wallets_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE TABLE "Campaigns" (
        "Id" uuid NOT NULL,
        "Code" character varying(50) NOT NULL,
        "IsGlobal" boolean NOT NULL DEFAULT FALSE,
        "DiscountPercent" numeric(18,2) NOT NULL,
        "MaxDiscountAmount" numeric(18,2) NOT NULL,
        "MinBookingAmount" numeric(18,2),
        "UsageLimit" integer NOT NULL,
        "UsedCount" integer NOT NULL,
        "StartDate" timestamp with time zone NOT NULL,
        "EndDate" timestamp with time zone NOT NULL,
        "OwnerId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Campaigns" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Campaigns_Owners_OwnerId" FOREIGN KEY ("OwnerId") REFERENCES "Owners" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE TABLE "Courts" (
        "Id" uuid NOT NULL,
        "Name" character varying(50) NOT NULL,
        "Address" character varying(100) NOT NULL,
        "OpenTime" time without time zone NOT NULL,
        "CloseTime" time without time zone NOT NULL,
        "Status" character varying(50) NOT NULL DEFAULT 'Active',
        "Latitude" numeric(10,8) NOT NULL,
        "Longitude" numeric(11,8) NOT NULL,
        "MapUrl" character varying(200) NOT NULL,
        "PictureUrl" character varying(200) NOT NULL,
        "Description" text,
        "OwnerId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Courts" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Courts_Owners_OwnerId" FOREIGN KEY ("OwnerId") REFERENCES "Owners" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE TABLE "OwnerRequests" (
        "Id" uuid NOT NULL,
        "BusinessName" character varying(500) NOT NULL,
        "TaxCode" character varying(50) NOT NULL,
        "BusinessAddress" character varying(500) NOT NULL,
        "BusinessLicenseUrl" character varying(200) NOT NULL,
        "IdentityNumber" character varying(12) NOT NULL,
        "IdentityCardFrontUrl" character varying(200) NOT NULL,
        "IdentityCardBackUrl" character varying(200) NOT NULL,
        "Status" character varying(15) NOT NULL DEFAULT 'Pending',
        "RejectionReason" character varying(200),
        "OwnerId" uuid,
        "CustomerId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_OwnerRequests" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_OwnerRequests_Customers_CustomerId" FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_OwnerRequests_Owners_OwnerId" FOREIGN KEY ("OwnerId") REFERENCES "Owners" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE TABLE "Bookings" (
        "Id" uuid NOT NULL,
        "TotalPrice" numeric(18,2) NOT NULL,
        "DiscountAmount" numeric(18,2),
        "FinalPrice" numeric NOT NULL,
        "Status" character varying(100) NOT NULL DEFAULT 'Pending',
        "CancellationReason" character varying(500),
        "CampaignId" uuid NOT NULL,
        "CustomerId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Bookings" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Bookings_Campaigns_CampaignId" FOREIGN KEY ("CampaignId") REFERENCES "Campaigns" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_Bookings_Customers_CustomerId" FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE TABLE "CampaignCourts" (
        "Id" uuid NOT NULL,
        "CourtId" uuid NOT NULL,
        "CampaignId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_CampaignCourts" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_CampaignCourts_Campaigns_CampaignId" FOREIGN KEY ("CampaignId") REFERENCES "Campaigns" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_CampaignCourts_Courts_CourtId" FOREIGN KEY ("CourtId") REFERENCES "Courts" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE TABLE "LikeListDetails" (
        "Id" uuid NOT NULL,
        "CourtId" uuid NOT NULL,
        "CustomerId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_LikeListDetails" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_LikeListDetails_Courts_CourtId" FOREIGN KEY ("CourtId") REFERENCES "Courts" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_LikeListDetails_Customers_CustomerId" FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE TABLE "SubCourts" (
        "Id" uuid NOT NULL,
        "Name" character varying(50) NOT NULL,
        "CourtId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_SubCourts" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_SubCourts_Courts_CourtId" FOREIGN KEY ("CourtId") REFERENCES "Courts" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE TABLE "Feedbacks" (
        "Id" uuid NOT NULL,
        "Rating" integer NOT NULL,
        "Comment" character varying(500),
        "CourtId" uuid NOT NULL,
        "CustomerId" uuid NOT NULL,
        "BookingId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Feedbacks" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Feedbacks_Bookings_BookingId" FOREIGN KEY ("BookingId") REFERENCES "Bookings" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_Feedbacks_Courts_CourtId" FOREIGN KEY ("CourtId") REFERENCES "Courts" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_Feedbacks_Customers_CustomerId" FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE TABLE "Notifications" (
        "Id" uuid NOT NULL,
        "BookingId" uuid NOT NULL,
        "UserId" uuid NOT NULL,
        "Title" character varying(500) NOT NULL,
        "Content" character varying(500) NOT NULL,
        "Type" character varying(10) NOT NULL,
        "IsRead" boolean NOT NULL DEFAULT FALSE,
        "CourtId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Notifications" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Notifications_Bookings_BookingId" FOREIGN KEY ("BookingId") REFERENCES "Bookings" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_Notifications_Courts_CourtId" FOREIGN KEY ("CourtId") REFERENCES "Courts" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_Notifications_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE TABLE "Reports" (
        "Id" uuid NOT NULL,
        "Reason" character varying(500) NOT NULL,
        "Status" text NOT NULL DEFAULT 'Pending',
        "CustomerId" uuid NOT NULL,
        "CourtId" uuid NOT NULL,
        "BookingId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Reports" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Reports_Bookings_BookingId" FOREIGN KEY ("BookingId") REFERENCES "Bookings" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_Reports_Courts_CourtId" FOREIGN KEY ("CourtId") REFERENCES "Courts" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_Reports_Customers_CustomerId" FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE TABLE "Transactions" (
        "Id" uuid NOT NULL,
        "Type" character varying(15) NOT NULL,
        "Amount" numeric(18,2) NOT NULL,
        "BalanceBefore" numeric(18,2) NOT NULL,
        "BalanceAfter" numeric(18,2) NOT NULL,
        "SePayId" character varying(50) NOT NULL,
        "BankRefCode" character varying(50) NOT NULL,
        "BankAccountNumber" character varying(500) NOT NULL,
        "TransferContent" character varying(500) NOT NULL,
        "ActionCode" character varying(50) NOT NULL,
        "Signature" character varying(50) NOT NULL,
        "Status" text NOT NULL DEFAULT 'Success',
        "BookingId" uuid NOT NULL,
        "WalletId" uuid NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Transactions" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Transactions_Bookings_BookingId" FOREIGN KEY ("BookingId") REFERENCES "Bookings" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_Transactions_Wallets_WalletId" FOREIGN KEY ("WalletId") REFERENCES "Wallets" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE TABLE "BookingDetails" (
        "Id" uuid NOT NULL,
        "SubCourtId" uuid NOT NULL,
        "BookingId" uuid NOT NULL,
        "Date" timestamp with time zone NOT NULL,
        "StartTime" time NOT NULL,
        "EndTime" time NOT NULL,
        "Price" numeric(18,2) NOT NULL,
        "Status" text NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_BookingDetails" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_BookingDetails_Bookings_BookingId" FOREIGN KEY ("BookingId") REFERENCES "Bookings" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_BookingDetails_SubCourts_SubCourtId" FOREIGN KEY ("SubCourtId") REFERENCES "SubCourts" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE TABLE "ConfigSlots" (
        "Id" uuid NOT NULL,
        "SubCourtDetailId" uuid NOT NULL,
        "StartTime" time NOT NULL,
        "EndTime" time NOT NULL,
        "Price" numeric(18,2) NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_ConfigSlots" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_ConfigSlots_SubCourts_SubCourtDetailId" FOREIGN KEY ("SubCourtDetailId") REFERENCES "SubCourts" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE TABLE "Exceptions" (
        "Id" uuid NOT NULL,
        "SubCourtDetailId" uuid NOT NULL,
        "Date" date NOT NULL,
        "StartTime" time NOT NULL,
        "EndTime" time NOT NULL,
        "Reason" character varying(500) NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Exceptions" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Exceptions_SubCourts_SubCourtDetailId" FOREIGN KEY ("SubCourtDetailId") REFERENCES "SubCourts" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE TABLE "OverideSlots" (
        "Id" uuid NOT NULL,
        "SubCourtDetailId" uuid NOT NULL,
        "IsRecurring" boolean NOT NULL DEFAULT FALSE,
        "DayOfWeek" integer NOT NULL,
        "Date" date NOT NULL,
        "StartTime" time NOT NULL,
        "EndTime" time NOT NULL,
        "Price" numeric(18,2) NOT NULL,
        "CreatedAt" timestamp with time zone NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_OverideSlots" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_OverideSlots_SubCourts_SubCourtDetailId" FOREIGN KEY ("SubCourtDetailId") REFERENCES "SubCourts" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('007756b7-9945-40d8-bcb2-af4a57d5c7c3', TIMESTAMPTZ '-infinity', 'customer2@gmail.com', 'Bảo', FALSE, 'Châu', 'hashed_pw_5', '0900000005', 'Customer', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('02e1c393-904a-4e20-8e92-c05fc8d2b28a', TIMESTAMPTZ '-infinity', 'owner2@rallyhub.vn', 'Hải', FALSE, 'Đăng', 'hashed_pw_3', '0900000003', 'Owner', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('347a115f-d7f7-4197-b8d2-7e521b4b39bd', TIMESTAMPTZ '-infinity', 'owner3@rallyhub.vn', 'Trần', FALSE, 'Phú', 'hashed_pw_6', '0900000006', 'Owner', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('3ac9efdf-237c-4ec7-8265-6de0596d3fdc', TIMESTAMPTZ '-infinity', 'owner1@rallyhub.vn', 'Minh', FALSE, 'Tuấn', 'hashed_pw_2', '0900000002', 'Owner', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('659d4eb2-3195-42cf-b356-e4fe4e8d1100', TIMESTAMPTZ '-infinity', 'admin@rallyhub.vn', 'Quản', FALSE, 'Trị', 'hashed_pw_1', '0900000001', 'Admin', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('8a8d56ae-6adb-4eb1-b5c3-561c7a9ab17c', TIMESTAMPTZ '-infinity', 'customer1@gmail.com', 'Lan', FALSE, 'Phương', 'hashed_pw_4', '0900000004', 'Customer', 'Active', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "Customers" ("Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId")
    VALUES ('8c1e6256-ec2e-464e-8a56-695a17a5437c', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '8a8d56ae-6adb-4eb1-b5c3-561c7a9ab17c');
    INSERT INTO "Customers" ("Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId")
    VALUES ('bf1242d5-2ca9-44b2-a154-31fe49ec61ce', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '007756b7-9945-40d8-bcb2-af4a57d5c7c3');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "Owners" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId")
    VALUES ('42e339a8-add4-4cfa-bbc3-43bd73006276', '123 Nguyễn Huệ, Q1, HCM', NULL, 'Sân Cầu Lông Minh Tuấn', TIMESTAMPTZ '-infinity', NULL, NULL, NULL, FALSE, '0123456789', TIMESTAMPTZ '-infinity', '3ac9efdf-237c-4ec7-8265-6de0596d3fdc');
    INSERT INTO "Owners" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId")
    VALUES ('de0d9b34-98c9-448a-ab24-b2318b8578f1', '456 Lê Lợi, Q3, HCM', NULL, 'Trung Tâm Thể Thao Hải Đăng', TIMESTAMPTZ '-infinity', NULL, NULL, NULL, FALSE, '9876543210', TIMESTAMPTZ '-infinity', '02e1c393-904a-4e20-8e92-c05fc8d2b28a');
    INSERT INTO "Owners" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId")
    VALUES ('ec9d967d-c64f-45f0-b0cb-61c7550751aa', 'Tôn Đức Thắng, HCM', NULL, 'Sân Cầu Lông Trần Phú', TIMESTAMPTZ '-infinity', NULL, NULL, NULL, FALSE, '98765434219', TIMESTAMPTZ '-infinity', '347a115f-d7f7-4197-b8d2-7e521b4b39bd');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('2bbd8804-c7ed-400d-98f0-47e23b913391', TIMESTAMPTZ '-infinity', FALSE, 'Bản đồ không load được trên iOS.', 'Resolved', 'Lỗi hiển thị bản đồ', TIMESTAMPTZ '-infinity', '02e1c393-904a-4e20-8e92-c05fc8d2b28a');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('2bd21afb-85ef-49a0-a520-0bb0e2452270', TIMESTAMPTZ '-infinity', FALSE, 'Không thể thanh toán qua ví.', 'Pending', 'Lỗi thanh toán', TIMESTAMPTZ '-infinity', '3ac9efdf-237c-4ec7-8265-6de0596d3fdc');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('4ad7a970-f11a-4c79-84a6-39c89cb0ac58', TIMESTAMPTZ '-infinity', FALSE, 'OTP không gửi đến số điện thoại.', 'Pending', 'Không nhận được OTP', TIMESTAMPTZ '-infinity', '8a8d56ae-6adb-4eb1-b5c3-561c7a9ab17c');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('69c99ae5-b97d-413c-9165-904cddf0c50a', TIMESTAMPTZ '-infinity', FALSE, 'Crash khi mở trang tìm kiếm sân.', 'Pending', 'App bị crash', TIMESTAMPTZ '-infinity', '8a8d56ae-6adb-4eb1-b5c3-561c7a9ab17c');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('b9971a35-dc50-4465-a145-dca4f07ece8f', TIMESTAMPTZ '-infinity', FALSE, 'Số dư hiển thị không khớp lịch sử.', 'Resolved', 'Sai số dư sau giao dịch', TIMESTAMPTZ '-infinity', '007756b7-9945-40d8-bcb2-af4a57d5c7c3');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('364a2287-18b1-46fe-819a-290afbeaaf10', 2000000.0, '4567890123', 'MB Bank', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '8a8d56ae-6adb-4eb1-b5c3-561c7a9ab17c', 0);
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('aabf7e01-4a1f-47b7-9017-4301297ed444', 12000000.0, '2345678901', 'Techcombank', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '3ac9efdf-237c-4ec7-8265-6de0596d3fdc', 0);
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('c80f2532-ec76-4d23-8b2d-ddfc52ce5a9b', 3500000.0, '5678901234', 'VPBank', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '007756b7-9945-40d8-bcb2-af4a57d5c7c3', 0);
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('d5593a40-89a4-40e7-a7d1-0c77f1ed500e', 8500000.0, '3456789012', 'BIDV', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '02e1c393-904a-4e20-8e92-c05fc8d2b28a', 0);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('001ff462-faad-4101-98cc-310e60b1ee64', 'LOYAL5', TIMESTAMPTZ '-infinity', 5.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 30000.0, 100000.0, 'de0d9b34-98c9-448a-ab24-b2318b8578f1', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 500, 87);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('268b7f1f-41bf-484a-83e3-e6f1df0438bf', 'FLASH50', TIMESTAMPTZ '-infinity', 50.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 200000.0, 500000.0, '42e339a8-add4-4cfa-bbc3-43bd73006276', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 10, 10);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('2e4e25d5-d120-480f-815b-4a8595584c25', 'NEWUSER', TIMESTAMPTZ '-infinity', 20.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 100000.0, 300000.0, 'de0d9b34-98c9-448a-ab24-b2318b8578f1', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 50, 5);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('74bf655e-a955-4aa1-bdec-96a8f435cf96', 'WEEKEND10', TIMESTAMPTZ '-infinity', 15.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 75000.0, 250000.0, 'de0d9b34-98c9-448a-ab24-b2318b8578f1', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 200, 30);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('a5813ed1-6aa5-458a-8555-cceaa20bd699', 'YEUTH', TIMESTAMPTZ '-infinity', 5.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 30000.0, 100000.0, '42e339a8-add4-4cfa-bbc3-43bd73006276', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 500, 87);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('babc2b25-ae84-4352-8f99-a46de3b151cd', 'SUMMER25', TIMESTAMPTZ '-infinity', 10.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 50000.0, 200000.0, '42e339a8-add4-4cfa-bbc3-43bd73006276', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 100, 12);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('2cf45a54-0a51-4598-b2c8-77254599e42f', '123 Nguyễn Huệ, Q1, HCM', TIME '22:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.77, 106.7, 'https://maps.google.com/?q=10.77,106.70', 'Sân A - Minh Tuấn', TIME '06:00:00', '42e339a8-add4-4cfa-bbc3-43bd73006276', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('b03a205b-bf76-4798-b51b-d1b5b887cdf6', '456 Lê Lợi, Q3, HCM', TIME '23:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.78, 106.69, 'https://maps.google.com/?q=10.78,106.69', 'Sân C - Hải Đăng', TIME '05:30:00', 'de0d9b34-98c9-448a-ab24-b2318b8578f1', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('dd56afce-b997-40cb-95b9-8615e049b4d0', '123 Nguyễn Huệ, Q1, HCM', TIME '22:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.77, 106.7, 'https://maps.google.com/?q=10.77,106.70', 'Sân B - Minh Tuấn', TIME '06:00:00', '42e339a8-add4-4cfa-bbc3-43bd73006276', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('ed91b18c-9890-49c2-8ef6-a171a1196f9b', '456 Lê Lợi, Q3, HCM', TIME '23:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.78, 106.69, 'https://maps.google.com/?q=10.78,106.69', 'Sân D - Hải Đăng', TIME '05:30:00', 'de0d9b34-98c9-448a-ab24-b2318b8578f1', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "OwnerRequests" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "CustomerId", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "OwnerId", "RejectionReason", "Status", "TaxCode", "UpdatedAt")
    VALUES ('6056038b-c0e8-4248-8c91-18f0a3b34349', '456 Lê Lợi, Q3, HCM', 'https://cdn.rallyhub.vn/license/2.jpg', 'Trung Tâm Thể Thao Hải Đăng', TIMESTAMPTZ '-infinity', 'bf1242d5-2ca9-44b2-a154-31fe49ec61ce', 'https://cdn.rallyhub.vn/cccd/2_back.jpg', 'https://cdn.rallyhub.vn/cccd/2_front.jpg', '079200054321', FALSE, 'de0d9b34-98c9-448a-ab24-b2318b8578f1', NULL, 'Approved', '9876543210', TIMESTAMPTZ '-infinity');
    INSERT INTO "OwnerRequests" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "CustomerId", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "OwnerId", "RejectionReason", "Status", "TaxCode", "UpdatedAt")
    VALUES ('a5decf3b-a3bb-4572-b59a-d6b418ba56c6', '123 Nguyễn Huệ, Q1, HCM', 'https://cdn.rallyhub.vn/license/1.jpg', 'Sân Cầu Lông Minh Tuấn', TIMESTAMPTZ '-infinity', '8c1e6256-ec2e-464e-8a56-695a17a5437c', 'https://cdn.rallyhub.vn/cccd/1_back.jpg', 'https://cdn.rallyhub.vn/cccd/1_front.jpg', '079200012345', FALSE, '42e339a8-add4-4cfa-bbc3-43bd73006276', NULL, 'Approved', '0123456789', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('438c05d3-61ca-4c9a-b7bd-69b0b7937986', '2e4e25d5-d120-480f-815b-4a8595584c25', NULL, TIMESTAMPTZ '-infinity', 'bf1242d5-2ca9-44b2-a154-31fe49ec61ce', 0.0, 150000.0, FALSE, 'Complete', 150000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('673a8bcd-100d-48f0-a09d-a5262a6400dd', 'babc2b25-ae84-4352-8f99-a46de3b151cd', NULL, TIMESTAMPTZ '-infinity', '8c1e6256-ec2e-464e-8a56-695a17a5437c', 20000.0, 180000.0, FALSE, 'Complete', 200000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('6bdcb7bb-217d-46aa-9e35-628a4048ea39', 'babc2b25-ae84-4352-8f99-a46de3b151cd', NULL, TIMESTAMPTZ '-infinity', '8c1e6256-ec2e-464e-8a56-695a17a5437c', 30000.0, 270000.0, FALSE, 'Banked', 300000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('c0e0e9f8-06ed-40a2-8bd0-0c9557b81e14', '2e4e25d5-d120-480f-815b-4a8595584c25', NULL, TIMESTAMPTZ '-infinity', 'bf1242d5-2ca9-44b2-a154-31fe49ec61ce', 40000.0, 360000.0, FALSE, 'Banked', 400000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('ee356f49-0b41-4a34-9fbc-190e49273a70', '2e4e25d5-d120-480f-815b-4a8595584c25', 'Khách huỷ', TIMESTAMPTZ '-infinity', 'bf1242d5-2ca9-44b2-a154-31fe49ec61ce', 50000.0, 200000.0, FALSE, 'Cancel', 250000.0, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('0b4f2d7e-7ac7-45eb-af99-8109f73d2e9b', 'babc2b25-ae84-4352-8f99-a46de3b151cd', 'b03a205b-bf76-4798-b51b-d1b5b887cdf6', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('40a1bc0d-9c14-4824-8a11-36832615a0fa', '2e4e25d5-d120-480f-815b-4a8595584c25', 'dd56afce-b997-40cb-95b9-8615e049b4d0', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('c7bb1449-0cd5-4c77-85d7-8987a538017b', '2e4e25d5-d120-480f-815b-4a8595584c25', '2cf45a54-0a51-4598-b2c8-77254599e42f', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('e0cf3823-c68f-4567-9c64-32c02704fb46', 'babc2b25-ae84-4352-8f99-a46de3b151cd', 'ed91b18c-9890-49c2-8ef6-a171a1196f9b', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('145e57ee-e40d-46d0-b795-1ed4eacb4be3', 'ed91b18c-9890-49c2-8ef6-a171a1196f9b', TIMESTAMPTZ '-infinity', 'bf1242d5-2ca9-44b2-a154-31fe49ec61ce', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('321455a1-4c08-4200-8607-57ad0b7284b2', 'b03a205b-bf76-4798-b51b-d1b5b887cdf6', TIMESTAMPTZ '-infinity', 'bf1242d5-2ca9-44b2-a154-31fe49ec61ce', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('5613eb09-5b7a-4c87-adc5-8e2896802a0e', '2cf45a54-0a51-4598-b2c8-77254599e42f', TIMESTAMPTZ '-infinity', '8c1e6256-ec2e-464e-8a56-695a17a5437c', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('c68f7605-921b-4864-b7ae-e76e230c637c', 'dd56afce-b997-40cb-95b9-8615e049b4d0', TIMESTAMPTZ '-infinity', '8c1e6256-ec2e-464e-8a56-695a17a5437c', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('e5984f6d-0bae-4c2f-ad93-a0ecaff73134', '2cf45a54-0a51-4598-b2c8-77254599e42f', TIMESTAMPTZ '-infinity', 'bf1242d5-2ca9-44b2-a154-31fe49ec61ce', FALSE, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('1eb8ad64-6257-498d-89c3-bb66d7e0b45d', 'b03a205b-bf76-4798-b51b-d1b5b887cdf6', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ C1', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('252fe8fb-0b07-480a-b026-120423a49e05', '2cf45a54-0a51-4598-b2c8-77254599e42f', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ A2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('25b1b8f3-2bdf-44cc-8b94-9c88393208f4', 'dd56afce-b997-40cb-95b9-8615e049b4d0', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ B2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('2ef3e92b-c6d1-4604-8625-45f354c7da4a', 'ed91b18c-9890-49c2-8ef6-a171a1196f9b', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ D2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('3e232ee9-9ed1-4d72-865e-c50d0ee9409a', 'b03a205b-bf76-4798-b51b-d1b5b887cdf6', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ C2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('62a15e5f-1aea-4534-b9ed-6acee445ee16', 'dd56afce-b997-40cb-95b9-8615e049b4d0', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ B1', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('822b5250-e4ec-4798-9130-adb6425a59a0', '2cf45a54-0a51-4598-b2c8-77254599e42f', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ A1', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('d10e83d5-9df0-467e-9ec3-ed56d3b9eb0f', 'ed91b18c-9890-49c2-8ef6-a171a1196f9b', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ D1', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "Status", "SubCourtId", "UpdatedAt")
    VALUES ('0b3852c7-2a3f-4f45-b40d-575bdc9e2058', '438c05d3-61ca-4c9a-b7bd-69b0b7937986', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-30T18:58:49.214435+07:00', TIME '08:00:00', FALSE, 150000.0, TIME '07:00:00', 'Banked', '1eb8ad64-6257-498d-89c3-bb66d7e0b45d', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "Status", "SubCourtId", "UpdatedAt")
    VALUES ('2f3951bc-9d62-4aea-822f-ee7aaa9b52b3', '673a8bcd-100d-48f0-a09d-a5262a6400dd', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-28T18:58:49.21443+07:00', TIME '10:00:00', FALSE, 100000.0, TIME '08:00:00', 'Banked', '822b5250-e4ec-4798-9130-adb6425a59a0', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "Status", "SubCourtId", "UpdatedAt")
    VALUES ('383afe4b-d1a2-4df0-a4b6-e47de5bbcc5a', '6bdcb7bb-217d-46aa-9e35-628a4048ea39', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-28T18:58:49.214435+07:00', TIME '07:00:00', FALSE, 100000.0, TIME '06:00:00', 'Banked', '62a15e5f-1aea-4534-b9ed-6acee445ee16', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "Status", "SubCourtId", "UpdatedAt")
    VALUES ('8e4a63d8-7b3a-4a2b-8665-7268a2585dce', 'ee356f49-0b41-4a34-9fbc-190e49273a70', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-30T18:58:49.214435+07:00', TIME '10:00:00', FALSE, 150000.0, TIME '06:00:00', 'Cancel', 'd10e83d5-9df0-467e-9ec3-ed56d3b9eb0f', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "Status", "SubCourtId", "UpdatedAt")
    VALUES ('a488bb45-1583-4196-81b1-23c7fc274a93', 'c0e0e9f8-06ed-40a2-8bd0-0c9557b81e14', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-05-04T18:58:49.214436+07:00', TIME '10:00:00', FALSE, 150000.0, TIME '09:00:00', 'Banked', '252fe8fb-0b07-480a-b026-120423a49e05', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('0500448a-32ad-4d9f-8b96-b62155595118', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 35000.0, TIME '07:00:00', '1eb8ad64-6257-498d-89c3-bb66d7e0b45d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('05444bd2-e36d-4406-8ddb-dd7ec62e53ce', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 35000.0, TIME '09:30:00', '1eb8ad64-6257-498d-89c3-bb66d7e0b45d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('07426998-5ed0-47ea-93b8-91cb7a5cc28b', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 50000.0, TIME '07:30:00', '822b5250-e4ec-4798-9130-adb6425a59a0', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('097a464a-b2de-425f-bbba-7a8b37051101', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 35000.0, TIME '07:30:00', '1eb8ad64-6257-498d-89c3-bb66d7e0b45d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('2363ff7e-b017-4feb-b8d5-ba48da5710e4', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 70000.0, TIME '06:00:00', '62a15e5f-1aea-4534-b9ed-6acee445ee16', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('31f99ac5-8ec6-42a9-81db-0ad4d010138f', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 100000.0, TIME '09:30:00', 'd10e83d5-9df0-467e-9ec3-ed56d3b9eb0f', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('3a2a18f6-e19c-4656-a15a-85c1a8258027', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 100000.0, TIME '07:30:00', 'd10e83d5-9df0-467e-9ec3-ed56d3b9eb0f', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('4da2b9d9-cd25-43f9-a6cb-09d8d39aa542', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 70000.0, TIME '06:30:00', '62a15e5f-1aea-4534-b9ed-6acee445ee16', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('50d5f0fe-b691-4ac2-93d1-ea2ef10a5577', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 50000.0, TIME '09:00:00', '822b5250-e4ec-4798-9130-adb6425a59a0', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('510fc6d1-1ac6-4d5b-bdb9-ad95f2bed375', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 70000.0, TIME '08:00:00', '62a15e5f-1aea-4534-b9ed-6acee445ee16', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('69533c23-d1f6-437a-96c5-b9ffef616b1d', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 35000.0, TIME '08:00:00', '1eb8ad64-6257-498d-89c3-bb66d7e0b45d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('6d90e657-3778-4c86-b557-5579d89bf595', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 100000.0, TIME '06:30:00', 'd10e83d5-9df0-467e-9ec3-ed56d3b9eb0f', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('71304d68-3468-4b52-8332-39165627e4f6', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 50000.0, TIME '08:00:00', '822b5250-e4ec-4798-9130-adb6425a59a0', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('75ccbc4a-db6e-414b-8d20-f05ec2ca7e6a', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 35000.0, TIME '06:00:00', '1eb8ad64-6257-498d-89c3-bb66d7e0b45d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('786be79f-1aab-4b8e-8041-f1e4c8a2b220', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 50000.0, TIME '09:30:00', '822b5250-e4ec-4798-9130-adb6425a59a0', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('895df629-4279-47fb-a5f7-b2015206d799', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 100000.0, TIME '07:00:00', 'd10e83d5-9df0-467e-9ec3-ed56d3b9eb0f', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('8a209a3d-2fc7-4da1-ab44-a8073b79b739', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 70000.0, TIME '07:30:00', '62a15e5f-1aea-4534-b9ed-6acee445ee16', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('93d2807b-c8fb-4f07-933a-16721fcb368b', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 70000.0, TIME '09:30:00', '62a15e5f-1aea-4534-b9ed-6acee445ee16', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('9db8a943-7148-4654-bb36-f6df7e8b74f4', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 100000.0, TIME '08:00:00', 'd10e83d5-9df0-467e-9ec3-ed56d3b9eb0f', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('b37c66a6-ebde-4f1c-850e-468446262954', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 35000.0, TIME '06:30:00', '1eb8ad64-6257-498d-89c3-bb66d7e0b45d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('b488dca8-3860-4f6d-ae4b-cc4ab0e5a70a', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 50000.0, TIME '08:30:00', '822b5250-e4ec-4798-9130-adb6425a59a0', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('bc22ee6a-ae24-4af9-8b60-f0b50a341323', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 70000.0, TIME '07:00:00', '62a15e5f-1aea-4534-b9ed-6acee445ee16', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('c30a2787-fa93-42c6-b2a0-3aa043033317', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 70000.0, TIME '08:30:00', '62a15e5f-1aea-4534-b9ed-6acee445ee16', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('cda84114-bd1d-4c38-a338-53392a549ed6', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 70000.0, TIME '09:00:00', '62a15e5f-1aea-4534-b9ed-6acee445ee16', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('d985e9d2-a685-47fb-9e4e-d180d45abbd8', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 35000.0, TIME '09:00:00', '1eb8ad64-6257-498d-89c3-bb66d7e0b45d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('e27028df-3bf1-4333-94e8-7f9fcc50582c', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 100000.0, TIME '08:30:00', 'd10e83d5-9df0-467e-9ec3-ed56d3b9eb0f', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('ed6405c0-9a39-4a20-97ef-199e78b552ca', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 100000.0, TIME '09:00:00', 'd10e83d5-9df0-467e-9ec3-ed56d3b9eb0f', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('f6abebed-9250-4e93-bde7-74afe47c4044', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 35000.0, TIME '08:30:00', '1eb8ad64-6257-498d-89c3-bb66d7e0b45d', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('f6c7d1e3-86af-4705-9dec-0e3d664b75fb', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 50000.0, TIME '06:00:00', '822b5250-e4ec-4798-9130-adb6425a59a0', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('f6f52eb2-b89d-4835-b2b4-c8f1619d84a9', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 50000.0, TIME '06:30:00', '822b5250-e4ec-4798-9130-adb6425a59a0', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('fa0108d5-0e8d-48cf-98d0-69723b6368f9', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 50000.0, TIME '07:00:00', '822b5250-e4ec-4798-9130-adb6425a59a0', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('fb84ee70-f61f-45a0-b306-db4989ad20b4', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 100000.0, TIME '06:00:00', 'd10e83d5-9df0-467e-9ec3-ed56d3b9eb0f', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('7483dcc9-bdf7-4bbd-a0e5-1418c53c7148', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Tổ chức sự kiện nội bộ', TIME '12:00:00', 'd10e83d5-9df0-467e-9ec3-ed56d3b9eb0f', TIMESTAMPTZ '-infinity');
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('b488638e-d5b9-4adf-b49b-c6a285f32c0f', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Bảo trì định kỳ', TIME '12:00:00', '822b5250-e4ec-4798-9130-adb6425a59a0', TIMESTAMPTZ '-infinity');
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('cbb1f23d-a03b-4463-9a5f-b1f807a63bff', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Sơn lại mặt sân', TIME '12:00:00', '62a15e5f-1aea-4534-b9ed-6acee445ee16', TIMESTAMPTZ '-infinity');
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('e5069894-f9fd-4088-8aac-0728fa0dee10', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Hỏng đèn chiếu sáng', TIME '12:00:00', '1eb8ad64-6257-498d-89c3-bb66d7e0b45d', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('3cce34a9-6f68-4fee-95af-f196b510b75b', 'c0e0e9f8-06ed-40a2-8bd0-0c9557b81e14', 'Đèn chiếu sáng yếu vào ban đêm.', '2cf45a54-0a51-4598-b2c8-77254599e42f', TIMESTAMPTZ '-infinity', 'bf1242d5-2ca9-44b2-a154-31fe49ec61ce', FALSE, 2, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('90e0a278-7bfe-4568-b270-51c08cfac25d', '6bdcb7bb-217d-46aa-9e35-628a4048ea39', 'Dịch vụ ổn, giá hợp lý.', 'dd56afce-b997-40cb-95b9-8615e049b4d0', TIMESTAMPTZ '-infinity', 'bf1242d5-2ca9-44b2-a154-31fe49ec61ce', FALSE, 4, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('97350ede-3707-480c-80aa-035be1f14a9c', '438c05d3-61ca-4c9a-b7bd-69b0b7937986', 'Bình thường, sân hơi cũ.', 'b03a205b-bf76-4798-b51b-d1b5b887cdf6', TIMESTAMPTZ '-infinity', '8c1e6256-ec2e-464e-8a56-695a17a5437c', FALSE, 3, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('aa729731-2e13-4182-a1a2-eb373b0ce9f2', '673a8bcd-100d-48f0-a09d-a5262a6400dd', 'Sân rất tốt, sẽ quay lại!', '2cf45a54-0a51-4598-b2c8-77254599e42f', TIMESTAMPTZ '-infinity', 'bf1242d5-2ca9-44b2-a154-31fe49ec61ce', FALSE, 5, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('da9922ba-ad5c-4170-9c36-0a1c1e8d7999', 'ee356f49-0b41-4a34-9fbc-190e49273a70', 'Nhân viên thân thiện, sân sạch.', 'dd56afce-b997-40cb-95b9-8615e049b4d0', TIMESTAMPTZ '-infinity', '8c1e6256-ec2e-464e-8a56-695a17a5437c', FALSE, 5, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('0e809631-1043-4a28-9231-20a212a194b3', '438c05d3-61ca-4c9a-b7bd-69b0b7937986', 'Bạn có lịch chơi vào ngày mai.', 'b03a205b-bf76-4798-b51b-d1b5b887cdf6', TIMESTAMPTZ '-infinity', FALSE, 'Nhắc nhở lịch chơi', 'Remind', TIMESTAMPTZ '-infinity', '8a8d56ae-6adb-4eb1-b5c3-561c7a9ab17c');
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('109188ec-b8bb-43d9-805c-245a5824388c', '6bdcb7bb-217d-46aa-9e35-628a4048ea39', 'Booking #2 đã được xác nhận.', 'dd56afce-b997-40cb-95b9-8615e049b4d0', TIMESTAMPTZ '-infinity', FALSE, 'Đặt sân thành công', 'Booking', TIMESTAMPTZ '-infinity', '02e1c393-904a-4e20-8e92-c05fc8d2b28a');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('4ee93cbd-5097-48dd-a778-42bc6c9c05a8', '673a8bcd-100d-48f0-a09d-a5262a6400dd', 'Booking #1 đã được xác nhận.', '2cf45a54-0a51-4598-b2c8-77254599e42f', TIMESTAMPTZ '-infinity', FALSE, TRUE, 'Đặt sân thành công', 'Booking', TIMESTAMPTZ '-infinity', '3ac9efdf-237c-4ec7-8265-6de0596d3fdc');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('6f05e72a-8b3a-42ac-9f63-a8cf3b309e2b', 'c0e0e9f8-06ed-40a2-8bd0-0c9557b81e14', 'Đã hoàn 360,000đ vào ví của bạn.', '2cf45a54-0a51-4598-b2c8-77254599e42f', TIMESTAMPTZ '-infinity', FALSE, 'Hoàn tiền', 'Refund', TIMESTAMPTZ '-infinity', '3ac9efdf-237c-4ec7-8265-6de0596d3fdc');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('83390d52-1088-4486-a49c-1dabf75c179d', 'ee356f49-0b41-4a34-9fbc-190e49273a70', 'Booking #4 đã bị huỷ. Tiền sẽ hoàn.', 'ed91b18c-9890-49c2-8ef6-a171a1196f9b', TIMESTAMPTZ '-infinity', FALSE, TRUE, 'Huỷ booking', 'Cancel', TIMESTAMPTZ '-infinity', '007756b7-9945-40d8-bcb2-af4a57d5c7c3');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "IsRecurring", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('48f72045-d91c-475d-a30b-27549787e927', TIMESTAMPTZ '-infinity', DATE '-infinity', 1, TIME '20:00:00', FALSE, TRUE, 200000.0, TIME '18:00:00', '252fe8fb-0b07-480a-b026-120423a49e05', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('56ff5ba0-6e6e-4255-bf46-8a0bea2e0081', TIMESTAMPTZ '-infinity', DATE '2026-04-25', 0, TIME '17:00:00', FALSE, 220500.0, TIME '12:00:00', '62a15e5f-1aea-4534-b9ed-6acee445ee16', TIMESTAMPTZ '-infinity');
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('8f8f3bd9-e667-43e5-9e99-95d6349874f3', TIMESTAMPTZ '-infinity', DATE '2026-04-25', 0, TIME '17:00:00', FALSE, 208400.0, TIME '12:00:00', '822b5250-e4ec-4798-9130-adb6425a59a0', TIMESTAMPTZ '-infinity');
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('dc16324c-127c-49f9-9f05-d6eeba7f637e', TIMESTAMPTZ '-infinity', DATE '2026-04-25', 0, TIME '17:00:00', FALSE, 2054000.0, TIME '12:00:00', '1eb8ad64-6257-498d-89c3-bb66d7e0b45d', TIMESTAMPTZ '-infinity');
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('fb6bc211-116d-4106-87bb-185a6aef2e62', TIMESTAMPTZ '-infinity', DATE '2026-04-25', 0, TIME '17:00:00', FALSE, 220800.0, TIME '12:00:00', 'd10e83d5-9df0-467e-9ec3-ed56d3b9eb0f', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('34f769bd-dfbc-4b82-8b9f-f435b35af99f', '438c05d3-61ca-4c9a-b7bd-69b0b7937986', 'dd56afce-b997-40cb-95b9-8615e049b4d0', TIMESTAMPTZ '-infinity', 'bf1242d5-2ca9-44b2-a154-31fe49ec61ce', FALSE, 'Cơ sở vật chất xuống cấp.', 'Pending', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('4dad55d1-5578-446b-8e4c-1587318c598f', 'ee356f49-0b41-4a34-9fbc-190e49273a70', 'b03a205b-bf76-4798-b51b-d1b5b887cdf6', TIMESTAMPTZ '-infinity', 'bf1242d5-2ca9-44b2-a154-31fe49ec61ce', FALSE, 'Không hoàn tiền khi huỷ đúng hạn.', 'Rejected', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('78e30fe0-3932-4f11-9075-b322b2fcb4e0', '6bdcb7bb-217d-46aa-9e35-628a4048ea39', '2cf45a54-0a51-4598-b2c8-77254599e42f', TIMESTAMPTZ '-infinity', '8c1e6256-ec2e-464e-8a56-695a17a5437c', FALSE, 'Chủ sân thái độ không tốt.', 'Resolved', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('a6c5bda9-6f8c-43aa-9f7d-c7ef487cd05d', 'c0e0e9f8-06ed-40a2-8bd0-0c9557b81e14', 'ed91b18c-9890-49c2-8ef6-a171a1196f9b', TIMESTAMPTZ '-infinity', 'bf1242d5-2ca9-44b2-a154-31fe49ec61ce', FALSE, 'Thông tin giờ mở cửa sai.', 'Pending', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('e2c5b48f-2d06-4beb-a239-e5fb109b4dc4', '673a8bcd-100d-48f0-a09d-a5262a6400dd', 'b03a205b-bf76-4798-b51b-d1b5b887cdf6', TIMESTAMPTZ '-infinity', '8c1e6256-ec2e-464e-8a56-695a17a5437c', FALSE, 'Sân không đúng mô tả.', 'Pending', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('20c49364-f861-464e-bb1d-61fb6a08be67', 'ACT001', 180000.0, 2000000.0, 2180000.0, '2345678901', 'REF001', '673a8bcd-100d-48f0-a09d-a5262a6400dd', TIMESTAMPTZ '-infinity', FALSE, 'SP001', 'SIG001', 'Success', 'Thanh toán booking #1', 'Payment', TIMESTAMPTZ '-infinity', 'aabf7e01-4a1f-47b7-9017-4301297ed444');
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('229b887e-c4e8-4da7-972c-c43a253ae75a', 'ACT004', 500000.0, 2000000.0, 1500000.0, '5678901234', 'REF004', 'c0e0e9f8-06ed-40a2-8bd0-0c9557b81e14', TIMESTAMPTZ '-infinity', FALSE, 'SP004', 'SIG004', 'Success', 'Nạp tiền vào ví', 'Deposit', TIMESTAMPTZ '-infinity', 'c80f2532-ec76-4d23-8b2d-ddfc52ce5a9b');
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('260d7295-f8cd-4d57-990b-e87c8b044a51', 'ACT003', 200000.0, 2200000.0, 2000000.0, '4567890123', 'REF003', '438c05d3-61ca-4c9a-b7bd-69b0b7937986', TIMESTAMPTZ '-infinity', FALSE, 'SP003', 'SIG003', 'Success', 'Hoàn tiền booking #4', 'Refund', TIMESTAMPTZ '-infinity', '364a2287-18b1-46fe-819a-290afbeaaf10');
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('f296a440-e937-4610-b6ac-f871f4df86c2', 'ACT002', 270000.0, 3500000.0, 3770000.0, '3456789012', 'REF002', '6bdcb7bb-217d-46aa-9e35-628a4048ea39', TIMESTAMPTZ '-infinity', FALSE, 'SP002', 'SIG002', 'Success', 'Thanh toán booking #2', 'Payment', TIMESTAMPTZ '-infinity', 'd5593a40-89a4-40e7-a7d1-0c77f1ed500e');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_BookingDetails_BookingId" ON "BookingDetails" ("BookingId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_BookingDetails_SubCourtId" ON "BookingDetails" ("SubCourtId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_Bookings_CampaignId" ON "Bookings" ("CampaignId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_Bookings_CustomerId" ON "Bookings" ("CustomerId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_CampaignCourts_CampaignId" ON "CampaignCourts" ("CampaignId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_CampaignCourts_CourtId" ON "CampaignCourts" ("CourtId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE UNIQUE INDEX "IX_Campaigns_Code" ON "Campaigns" ("Code");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_Campaigns_OwnerId" ON "Campaigns" ("OwnerId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_ConfigSlots_SubCourtDetailId" ON "ConfigSlots" ("SubCourtDetailId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE UNIQUE INDEX "IX_Courts_Name" ON "Courts" ("Name");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_Courts_OwnerId" ON "Courts" ("OwnerId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE UNIQUE INDEX "IX_Customers_UserId" ON "Customers" ("UserId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_Exceptions_SubCourtDetailId" ON "Exceptions" ("SubCourtDetailId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_Feedbacks_BookingId" ON "Feedbacks" ("BookingId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_Feedbacks_CourtId" ON "Feedbacks" ("CourtId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_Feedbacks_CustomerId" ON "Feedbacks" ("CustomerId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_LikeListDetails_CourtId" ON "LikeListDetails" ("CourtId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_LikeListDetails_CustomerId" ON "LikeListDetails" ("CustomerId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_Notifications_BookingId" ON "Notifications" ("BookingId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_Notifications_CourtId" ON "Notifications" ("CourtId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_Notifications_UserId" ON "Notifications" ("UserId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_OverideSlots_SubCourtDetailId" ON "OverideSlots" ("SubCourtDetailId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_OwnerRequests_CustomerId" ON "OwnerRequests" ("CustomerId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE UNIQUE INDEX "IX_OwnerRequests_OwnerId" ON "OwnerRequests" ("OwnerId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE UNIQUE INDEX "IX_OwnerRequests_TaxCode" ON "OwnerRequests" ("TaxCode");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE UNIQUE INDEX "IX_Owners_TaxCode" ON "Owners" ("TaxCode");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE UNIQUE INDEX "IX_Owners_UserId" ON "Owners" ("UserId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_Reports_BookingId" ON "Reports" ("BookingId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_Reports_CourtId" ON "Reports" ("CourtId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_Reports_CustomerId" ON "Reports" ("CustomerId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_SubCourts_CourtId" ON "SubCourts" ("CourtId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_SystemReports_UserId" ON "SystemReports" ("UserId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE UNIQUE INDEX "IX_Transactions_ActionCode" ON "Transactions" ("ActionCode");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE UNIQUE INDEX "IX_Transactions_BankRefCode" ON "Transactions" ("BankRefCode");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_Transactions_BookingId" ON "Transactions" ("BookingId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE UNIQUE INDEX "IX_Transactions_SePayId" ON "Transactions" ("SePayId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE INDEX "IX_Transactions_WalletId" ON "Transactions" ("WalletId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE UNIQUE INDEX "IX_Users_Email" ON "Users" ("Email");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    CREATE UNIQUE INDEX "IX_Wallets_UserId" ON "Wallets" ("UserId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260503115849_add_Descriptioon') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20260503115849_add_Descriptioon', '8.0.0');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = '0b3852c7-2a3f-4f45-b40d-575bdc9e2058';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = '2f3951bc-9d62-4aea-822f-ee7aaa9b52b3';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = '383afe4b-d1a2-4df0-a4b6-e47de5bbcc5a';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = '8e4a63d8-7b3a-4a2b-8665-7268a2585dce';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "BookingDetails"
    WHERE "Id" = 'a488bb45-1583-4196-81b1-23c7fc274a93';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "CampaignCourts"
    WHERE "Id" = '0b4f2d7e-7ac7-45eb-af99-8109f73d2e9b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "CampaignCourts"
    WHERE "Id" = '40a1bc0d-9c14-4824-8a11-36832615a0fa';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "CampaignCourts"
    WHERE "Id" = 'c7bb1449-0cd5-4c77-85d7-8987a538017b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "CampaignCourts"
    WHERE "Id" = 'e0cf3823-c68f-4567-9c64-32c02704fb46';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = '001ff462-faad-4101-98cc-310e60b1ee64';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = '268b7f1f-41bf-484a-83e3-e6f1df0438bf';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = '74bf655e-a955-4aa1-bdec-96a8f435cf96';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = 'a5813ed1-6aa5-458a-8555-cceaa20bd699';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '0500448a-32ad-4d9f-8b96-b62155595118';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '05444bd2-e36d-4406-8ddb-dd7ec62e53ce';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '07426998-5ed0-47ea-93b8-91cb7a5cc28b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '097a464a-b2de-425f-bbba-7a8b37051101';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '2363ff7e-b017-4feb-b8d5-ba48da5710e4';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '31f99ac5-8ec6-42a9-81db-0ad4d010138f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '3a2a18f6-e19c-4656-a15a-85c1a8258027';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '4da2b9d9-cd25-43f9-a6cb-09d8d39aa542';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '50d5f0fe-b691-4ac2-93d1-ea2ef10a5577';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '510fc6d1-1ac6-4d5b-bdb9-ad95f2bed375';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '69533c23-d1f6-437a-96c5-b9ffef616b1d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '6d90e657-3778-4c86-b557-5579d89bf595';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '71304d68-3468-4b52-8332-39165627e4f6';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '75ccbc4a-db6e-414b-8d20-f05ec2ca7e6a';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '786be79f-1aab-4b8e-8041-f1e4c8a2b220';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '895df629-4279-47fb-a5f7-b2015206d799';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '8a209a3d-2fc7-4da1-ab44-a8073b79b739';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '93d2807b-c8fb-4f07-933a-16721fcb368b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = '9db8a943-7148-4654-bb36-f6df7e8b74f4';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'b37c66a6-ebde-4f1c-850e-468446262954';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'b488dca8-3860-4f6d-ae4b-cc4ab0e5a70a';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'bc22ee6a-ae24-4af9-8b60-f0b50a341323';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'c30a2787-fa93-42c6-b2a0-3aa043033317';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'cda84114-bd1d-4c38-a338-53392a549ed6';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'd985e9d2-a685-47fb-9e4e-d180d45abbd8';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'e27028df-3bf1-4333-94e8-7f9fcc50582c';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'ed6405c0-9a39-4a20-97ef-199e78b552ca';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'f6abebed-9250-4e93-bde7-74afe47c4044';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'f6c7d1e3-86af-4705-9dec-0e3d664b75fb';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'f6f52eb2-b89d-4835-b2b4-c8f1619d84a9';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'fa0108d5-0e8d-48cf-98d0-69723b6368f9';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "ConfigSlots"
    WHERE "Id" = 'fb84ee70-f61f-45a0-b306-db4989ad20b4';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Exceptions"
    WHERE "Id" = '7483dcc9-bdf7-4bbd-a0e5-1418c53c7148';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Exceptions"
    WHERE "Id" = 'b488638e-d5b9-4adf-b49b-c6a285f32c0f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Exceptions"
    WHERE "Id" = 'cbb1f23d-a03b-4463-9a5f-b1f807a63bff';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Exceptions"
    WHERE "Id" = 'e5069894-f9fd-4088-8aac-0728fa0dee10';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = '3cce34a9-6f68-4fee-95af-f196b510b75b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = '90e0a278-7bfe-4568-b270-51c08cfac25d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = '97350ede-3707-480c-80aa-035be1f14a9c';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = 'aa729731-2e13-4182-a1a2-eb373b0ce9f2';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Feedbacks"
    WHERE "Id" = 'da9922ba-ad5c-4170-9c36-0a1c1e8d7999';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = '145e57ee-e40d-46d0-b795-1ed4eacb4be3';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = '321455a1-4c08-4200-8607-57ad0b7284b2';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = '5613eb09-5b7a-4c87-adc5-8e2896802a0e';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = 'c68f7605-921b-4864-b7ae-e76e230c637c';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "LikeListDetails"
    WHERE "Id" = 'e5984f6d-0bae-4c2f-ad93-a0ecaff73134';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = '0e809631-1043-4a28-9231-20a212a194b3';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = '109188ec-b8bb-43d9-805c-245a5824388c';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = '4ee93cbd-5097-48dd-a778-42bc6c9c05a8';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = '6f05e72a-8b3a-42ac-9f63-a8cf3b309e2b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Notifications"
    WHERE "Id" = '83390d52-1088-4486-a49c-1dabf75c179d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = '48f72045-d91c-475d-a30b-27549787e927';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = '56ff5ba0-6e6e-4255-bf46-8a0bea2e0081';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = '8f8f3bd9-e667-43e5-9e99-95d6349874f3';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = 'dc16324c-127c-49f9-9f05-d6eeba7f637e';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "OverideSlots"
    WHERE "Id" = 'fb6bc211-116d-4106-87bb-185a6aef2e62';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "OwnerRequests"
    WHERE "Id" = '6056038b-c0e8-4248-8c91-18f0a3b34349';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "OwnerRequests"
    WHERE "Id" = 'a5decf3b-a3bb-4572-b59a-d6b418ba56c6';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Owners"
    WHERE "Id" = 'ec9d967d-c64f-45f0-b0cb-61c7550751aa';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Reports"
    WHERE "Id" = '34f769bd-dfbc-4b82-8b9f-f435b35af99f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Reports"
    WHERE "Id" = '4dad55d1-5578-446b-8e4c-1587318c598f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Reports"
    WHERE "Id" = '78e30fe0-3932-4f11-9075-b322b2fcb4e0';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Reports"
    WHERE "Id" = 'a6c5bda9-6f8c-43aa-9f7d-c7ef487cd05d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Reports"
    WHERE "Id" = 'e2c5b48f-2d06-4beb-a239-e5fb109b4dc4';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = '25b1b8f3-2bdf-44cc-8b94-9c88393208f4';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = '2ef3e92b-c6d1-4604-8625-45f354c7da4a';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = '3e232ee9-9ed1-4d72-865e-c50d0ee9409a';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = '2bbd8804-c7ed-400d-98f0-47e23b913391';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = '2bd21afb-85ef-49a0-a520-0bb0e2452270';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = '4ad7a970-f11a-4c79-84a6-39c89cb0ac58';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = '69c99ae5-b97d-413c-9165-904cddf0c50a';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "SystemReports"
    WHERE "Id" = 'b9971a35-dc50-4465-a145-dca4f07ece8f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Transactions"
    WHERE "Id" = '20c49364-f861-464e-bb1d-61fb6a08be67';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Transactions"
    WHERE "Id" = '229b887e-c4e8-4da7-972c-c43a253ae75a';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Transactions"
    WHERE "Id" = '260d7295-f8cd-4d57-990b-e87c8b044a51';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Transactions"
    WHERE "Id" = 'f296a440-e937-4610-b6ac-f871f4df86c2';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Users"
    WHERE "Id" = '659d4eb2-3195-42cf-b356-e4fe4e8d1100';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = '438c05d3-61ca-4c9a-b7bd-69b0b7937986';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = '673a8bcd-100d-48f0-a09d-a5262a6400dd';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = '6bdcb7bb-217d-46aa-9e35-628a4048ea39';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = 'c0e0e9f8-06ed-40a2-8bd0-0c9557b81e14';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Bookings"
    WHERE "Id" = 'ee356f49-0b41-4a34-9fbc-190e49273a70';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = '1eb8ad64-6257-498d-89c3-bb66d7e0b45d';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = '252fe8fb-0b07-480a-b026-120423a49e05';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = '62a15e5f-1aea-4534-b9ed-6acee445ee16';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = '822b5250-e4ec-4798-9130-adb6425a59a0';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "SubCourts"
    WHERE "Id" = 'd10e83d5-9df0-467e-9ec3-ed56d3b9eb0f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Users"
    WHERE "Id" = '347a115f-d7f7-4197-b8d2-7e521b4b39bd';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Wallets"
    WHERE "Id" = '364a2287-18b1-46fe-819a-290afbeaaf10';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Wallets"
    WHERE "Id" = 'aabf7e01-4a1f-47b7-9017-4301297ed444';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Wallets"
    WHERE "Id" = 'c80f2532-ec76-4d23-8b2d-ddfc52ce5a9b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Wallets"
    WHERE "Id" = 'd5593a40-89a4-40e7-a7d1-0c77f1ed500e';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = '2e4e25d5-d120-480f-815b-4a8595584c25';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Campaigns"
    WHERE "Id" = 'babc2b25-ae84-4352-8f99-a46de3b151cd';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Courts"
    WHERE "Id" = '2cf45a54-0a51-4598-b2c8-77254599e42f';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Courts"
    WHERE "Id" = 'b03a205b-bf76-4798-b51b-d1b5b887cdf6';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Courts"
    WHERE "Id" = 'dd56afce-b997-40cb-95b9-8615e049b4d0';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Courts"
    WHERE "Id" = 'ed91b18c-9890-49c2-8ef6-a171a1196f9b';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Customers"
    WHERE "Id" = '8c1e6256-ec2e-464e-8a56-695a17a5437c';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Customers"
    WHERE "Id" = 'bf1242d5-2ca9-44b2-a154-31fe49ec61ce';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Owners"
    WHERE "Id" = '42e339a8-add4-4cfa-bbc3-43bd73006276';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Owners"
    WHERE "Id" = 'de0d9b34-98c9-448a-ab24-b2318b8578f1';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Users"
    WHERE "Id" = '007756b7-9945-40d8-bcb2-af4a57d5c7c3';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Users"
    WHERE "Id" = '8a8d56ae-6adb-4eb1-b5c3-561c7a9ab17c';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Users"
    WHERE "Id" = '02e1c393-904a-4e20-8e92-c05fc8d2b28a';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    DELETE FROM "Users"
    WHERE "Id" = '3ac9efdf-237c-4ec7-8265-6de0596d3fdc';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('3e27b94e-1058-43f0-85c0-41a12dfe7d52', TIMESTAMPTZ '-infinity', 'owner2@rallyhub.vn', 'Hải', FALSE, 'Đăng', 'hashed_pw_3', '0900000003', 'Owner', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('53ff038a-8f14-4fc6-be8d-cdfe4181fd91', TIMESTAMPTZ '-infinity', 'customer2@gmail.com', 'Bảo', FALSE, 'Châu', 'hashed_pw_5', '0900000005', 'Customer', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('8e14cc18-e3c1-4e89-8f64-253319f25d0a', TIMESTAMPTZ '-infinity', 'owner1@rallyhub.vn', 'Minh', FALSE, 'Tuấn', 'hashed_pw_2', '0900000002', 'Owner', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('9d093d28-f757-4045-8827-b5d81623122f', TIMESTAMPTZ '-infinity', 'admin@rallyhub.vn', 'Quản', FALSE, 'Trị', 'hashed_pw_1', '0900000001', 'Admin', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('c0102316-7f20-4e81-af35-c8e7fe034c4d', TIMESTAMPTZ '-infinity', 'customer1@gmail.com', 'Lan', FALSE, 'Phương', 'hashed_pw_4', '0900000004', 'Customer', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Users" ("Id", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Role", "Status", "UpdatedAt")
    VALUES ('df0d012f-32d1-4b97-82aa-c815b93f78af', TIMESTAMPTZ '-infinity', 'owner3@rallyhub.vn', 'Trần', FALSE, 'Phú', 'hashed_pw_6', '0900000006', 'Owner', 'Active', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    INSERT INTO "Customers" ("Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId")
    VALUES ('4085bfd2-4cfb-4e95-9872-0db1563590db', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', 'c0102316-7f20-4e81-af35-c8e7fe034c4d');
    INSERT INTO "Customers" ("Id", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId")
    VALUES ('68218da8-c73f-4dff-8e80-76d98e701b87', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '53ff038a-8f14-4fc6-be8d-cdfe4181fd91');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    INSERT INTO "Owners" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId")
    VALUES ('c56ce0bf-3d96-4d2c-a0d0-a583491c2fce', '123 Nguyễn Huệ, Q1, HCM', NULL, 'Sân Cầu Lông Minh Tuấn', TIMESTAMPTZ '-infinity', NULL, NULL, NULL, FALSE, '0123456789', TIMESTAMPTZ '-infinity', '8e14cc18-e3c1-4e89-8f64-253319f25d0a');
    INSERT INTO "Owners" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId")
    VALUES ('cfa957dc-490a-468b-bf2c-70d523ca6e53', 'Tôn Đức Thắng, HCM', NULL, 'Sân Cầu Lông Trần Phú', TIMESTAMPTZ '-infinity', NULL, NULL, NULL, FALSE, '98765434219', TIMESTAMPTZ '-infinity', 'df0d012f-32d1-4b97-82aa-c815b93f78af');
    INSERT INTO "Owners" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "TaxCode", "UpdatedAt", "UserId")
    VALUES ('d21d1ffa-bdcf-425e-8de6-78663e356e55', '456 Lê Lợi, Q3, HCM', NULL, 'Trung Tâm Thể Thao Hải Đăng', TIMESTAMPTZ '-infinity', NULL, NULL, NULL, FALSE, '9876543210', TIMESTAMPTZ '-infinity', '3e27b94e-1058-43f0-85c0-41a12dfe7d52');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('207e6def-9f80-47eb-9c2b-4a689db21a65', TIMESTAMPTZ '-infinity', FALSE, 'Crash khi mở trang tìm kiếm sân.', 'Pending', 'App bị crash', TIMESTAMPTZ '-infinity', 'c0102316-7f20-4e81-af35-c8e7fe034c4d');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('2149372b-2d17-4b3e-944d-f5b1848d7560', TIMESTAMPTZ '-infinity', FALSE, 'Số dư hiển thị không khớp lịch sử.', 'Resolved', 'Sai số dư sau giao dịch', TIMESTAMPTZ '-infinity', '53ff038a-8f14-4fc6-be8d-cdfe4181fd91');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('9c1ec7a1-9ece-4dfb-b956-3dff71202d01', TIMESTAMPTZ '-infinity', FALSE, 'Bản đồ không load được trên iOS.', 'Resolved', 'Lỗi hiển thị bản đồ', TIMESTAMPTZ '-infinity', '3e27b94e-1058-43f0-85c0-41a12dfe7d52');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('ae605996-db3a-408f-a564-ac97c4cc0771', TIMESTAMPTZ '-infinity', FALSE, 'Không thể thanh toán qua ví.', 'Pending', 'Lỗi thanh toán', TIMESTAMPTZ '-infinity', '8e14cc18-e3c1-4e89-8f64-253319f25d0a');
    INSERT INTO "SystemReports" ("Id", "CreatedAt", "IsDeleted", "Reason", "Status", "Title", "UpdatedAt", "UserId")
    VALUES ('c30a289d-5d79-4725-9aa5-82275bad3994', TIMESTAMPTZ '-infinity', FALSE, 'OTP không gửi đến số điện thoại.', 'Pending', 'Không nhận được OTP', TIMESTAMPTZ '-infinity', 'c0102316-7f20-4e81-af35-c8e7fe034c4d');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('35550b9b-d9a3-4fae-906e-a51a24b1cb00', 12000000.0, '2345678901', 'Techcombank', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '8e14cc18-e3c1-4e89-8f64-253319f25d0a', 0);
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('37b1fcc0-ea53-4a64-ab01-d9f45d62323d', 8500000.0, '3456789012', 'BIDV', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '3e27b94e-1058-43f0-85c0-41a12dfe7d52', 0);
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('be76a585-c486-4ace-8522-687147c70eba', 2000000.0, '4567890123', 'MB Bank', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', 'c0102316-7f20-4e81-af35-c8e7fe034c4d', 0);
    INSERT INTO "Wallets" ("Id", "Balance", "BankAccount", "BankName", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId", "Version")
    VALUES ('d748004e-b3b1-4d1d-8ef0-abd92398a5f5', 3500000.0, '5678901234', 'VPBank', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity', '53ff038a-8f14-4fc6-be8d-cdfe4181fd91', 0);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('0f821e7e-4dbe-4f51-b3d7-272d4e9ef2ef', 'YEUTH', TIMESTAMPTZ '-infinity', 5.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 30000.0, 100000.0, 'c56ce0bf-3d96-4d2c-a0d0-a583491c2fce', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 500, 87);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('3acca8a1-9460-445a-bd0b-33f20df72092', 'WEEKEND10', TIMESTAMPTZ '-infinity', 15.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 75000.0, 250000.0, 'd21d1ffa-bdcf-425e-8de6-78663e356e55', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 200, 30);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('4b2518cf-daf7-41ac-8be0-ec6b3bde4947', 'FLASH50', TIMESTAMPTZ '-infinity', 50.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 200000.0, 500000.0, 'c56ce0bf-3d96-4d2c-a0d0-a583491c2fce', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 10, 10);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('6d7357e9-0efa-4484-8f62-4fe7fbb6ece8', 'NEWUSER', TIMESTAMPTZ '-infinity', 20.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 100000.0, 300000.0, 'd21d1ffa-bdcf-425e-8de6-78663e356e55', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 50, 5);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('99f7ebad-59f0-4051-bad4-441bae433464', 'SUMMER25', TIMESTAMPTZ '-infinity', 10.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 50000.0, 200000.0, 'c56ce0bf-3d96-4d2c-a0d0-a583491c2fce', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 100, 12);
    INSERT INTO "Campaigns" ("Id", "Code", "CreatedAt", "DiscountPercent", "EndDate", "IsDeleted", "MaxDiscountAmount", "MinBookingAmount", "OwnerId", "StartDate", "UpdatedAt", "UsageLimit", "UsedCount")
    VALUES ('ef0d6fc7-8683-4e80-8873-d05f403543fd', 'LOYAL5', TIMESTAMPTZ '-infinity', 5.0, TIMESTAMPTZ '2026-06-20T23:59:59Z', FALSE, 30000.0, 100000.0, 'd21d1ffa-bdcf-425e-8de6-78663e356e55', TIMESTAMPTZ '2026-06-12T00:00:00Z', TIMESTAMPTZ '-infinity', 500, 87);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('158c039c-b815-464b-bfbc-d33383178380', '123 Nguyễn Huệ, Q1, HCM', TIME '22:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.77, 106.7, 'https://maps.google.com/?q=10.77,106.70', 'Sân B - Minh Tuấn', TIME '06:00:00', 'c56ce0bf-3d96-4d2c-a0d0-a583491c2fce', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('27ef7bb4-e6d0-4477-806b-22ac447921f7', '456 Lê Lợi, Q3, HCM', TIME '23:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.78, 106.69, 'https://maps.google.com/?q=10.78,106.69', 'Sân D - Hải Đăng', TIME '05:30:00', 'd21d1ffa-bdcf-425e-8de6-78663e356e55', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('5a536171-1d44-401f-a2cd-375c95a2d12c', '456 Lê Lợi, Q3, HCM', TIME '23:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.78, 106.69, 'https://maps.google.com/?q=10.78,106.69', 'Sân C - Hải Đăng', TIME '05:30:00', 'd21d1ffa-bdcf-425e-8de6-78663e356e55', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    INSERT INTO "Courts" ("Id", "Address", "CloseTime", "CreatedAt", "Description", "IsDeleted", "Latitude", "Longitude", "MapUrl", "Name", "OpenTime", "OwnerId", "PictureUrl", "Status", "UpdatedAt")
    VALUES ('8ab48bd8-afec-4090-921a-2826a512fd90', '123 Nguyễn Huệ, Q1, HCM', TIME '22:00:00', TIMESTAMPTZ '-infinity', NULL, FALSE, 10.77, 106.7, 'https://maps.google.com/?q=10.77,106.70', 'Sân A - Minh Tuấn', TIME '06:00:00', 'c56ce0bf-3d96-4d2c-a0d0-a583491c2fce', 'https://images.example.com/courts/go-vap.jpg', 'Active', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    INSERT INTO "OwnerRequests" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "CustomerId", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "OwnerId", "RejectionReason", "Status", "TaxCode", "UpdatedAt")
    VALUES ('0408925c-bff3-4b10-8b9d-90a4962efeac', '456 Lê Lợi, Q3, HCM', 'https://cdn.rallyhub.vn/license/2.jpg', 'Trung Tâm Thể Thao Hải Đăng', TIMESTAMPTZ '-infinity', '68218da8-c73f-4dff-8e80-76d98e701b87', 'https://cdn.rallyhub.vn/cccd/2_back.jpg', 'https://cdn.rallyhub.vn/cccd/2_front.jpg', '079200054321', FALSE, 'd21d1ffa-bdcf-425e-8de6-78663e356e55', NULL, 'Approved', '9876543210', TIMESTAMPTZ '-infinity');
    INSERT INTO "OwnerRequests" ("Id", "BusinessAddress", "BusinessLicenseUrl", "BusinessName", "CreatedAt", "CustomerId", "IdentityCardBackUrl", "IdentityCardFrontUrl", "IdentityNumber", "IsDeleted", "OwnerId", "RejectionReason", "Status", "TaxCode", "UpdatedAt")
    VALUES ('0822004c-ad90-4dd0-acbd-6d5fc7d002e5', '123 Nguyễn Huệ, Q1, HCM', 'https://cdn.rallyhub.vn/license/1.jpg', 'Sân Cầu Lông Minh Tuấn', TIMESTAMPTZ '-infinity', '4085bfd2-4cfb-4e95-9872-0db1563590db', 'https://cdn.rallyhub.vn/cccd/1_back.jpg', 'https://cdn.rallyhub.vn/cccd/1_front.jpg', '079200012345', FALSE, 'c56ce0bf-3d96-4d2c-a0d0-a583491c2fce', NULL, 'Approved', '0123456789', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('12ec3881-d611-4cd3-8d9f-0eaf994e6119', '6d7357e9-0efa-4484-8f62-4fe7fbb6ece8', NULL, TIMESTAMPTZ '-infinity', '68218da8-c73f-4dff-8e80-76d98e701b87', 0.0, 150000.0, FALSE, 'Complete', 150000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('40094855-a269-4d9a-a656-6151e0064ebf', '6d7357e9-0efa-4484-8f62-4fe7fbb6ece8', NULL, TIMESTAMPTZ '-infinity', '68218da8-c73f-4dff-8e80-76d98e701b87', 40000.0, 360000.0, FALSE, 'Banked', 400000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('7ce3c694-31a4-46ea-8adf-8b4ed95ae694', '6d7357e9-0efa-4484-8f62-4fe7fbb6ece8', 'Khách huỷ', TIMESTAMPTZ '-infinity', '68218da8-c73f-4dff-8e80-76d98e701b87', 50000.0, 200000.0, FALSE, 'Cancel', 250000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('8ff8fef7-3982-4df1-98e7-9424f8aa76b9', '99f7ebad-59f0-4051-bad4-441bae433464', NULL, TIMESTAMPTZ '-infinity', '4085bfd2-4cfb-4e95-9872-0db1563590db', 20000.0, 180000.0, FALSE, 'Complete', 200000.0, TIMESTAMPTZ '-infinity');
    INSERT INTO "Bookings" ("Id", "CampaignId", "CancellationReason", "CreatedAt", "CustomerId", "DiscountAmount", "FinalPrice", "IsDeleted", "Status", "TotalPrice", "UpdatedAt")
    VALUES ('bc6b8020-a418-4498-aad0-13f6aa242707', '99f7ebad-59f0-4051-bad4-441bae433464', NULL, TIMESTAMPTZ '-infinity', '4085bfd2-4cfb-4e95-9872-0db1563590db', 30000.0, 270000.0, FALSE, 'Banked', 300000.0, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('023e036a-90d2-411a-b560-27f5fac50a0f', '99f7ebad-59f0-4051-bad4-441bae433464', '5a536171-1d44-401f-a2cd-375c95a2d12c', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('40312879-db5c-4f8a-9b2c-5346a976f08c', '99f7ebad-59f0-4051-bad4-441bae433464', '27ef7bb4-e6d0-4477-806b-22ac447921f7', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('a37d92bd-86a3-4605-81ad-f15755cf8fec', '6d7357e9-0efa-4484-8f62-4fe7fbb6ece8', '158c039c-b815-464b-bfbc-d33383178380', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "CampaignCourts" ("Id", "CampaignId", "CourtId", "CreatedAt", "IsDeleted", "UpdatedAt")
    VALUES ('c65a8b08-07a9-4a90-b106-44b57eedf78d', '6d7357e9-0efa-4484-8f62-4fe7fbb6ece8', '8ab48bd8-afec-4090-921a-2826a512fd90', TIMESTAMPTZ '-infinity', FALSE, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('0dc4079e-6045-43c3-a039-72a9f1125805', '27ef7bb4-e6d0-4477-806b-22ac447921f7', TIMESTAMPTZ '-infinity', '68218da8-c73f-4dff-8e80-76d98e701b87', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('139f6cb4-dac4-4e7c-84b7-343decab68eb', '8ab48bd8-afec-4090-921a-2826a512fd90', TIMESTAMPTZ '-infinity', '68218da8-c73f-4dff-8e80-76d98e701b87', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('688b8854-f200-467d-9855-965398c283d9', '5a536171-1d44-401f-a2cd-375c95a2d12c', TIMESTAMPTZ '-infinity', '68218da8-c73f-4dff-8e80-76d98e701b87', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('a77f39da-6fc1-4251-83f4-a1fb6fadf80f', '8ab48bd8-afec-4090-921a-2826a512fd90', TIMESTAMPTZ '-infinity', '4085bfd2-4cfb-4e95-9872-0db1563590db', FALSE, TIMESTAMPTZ '-infinity');
    INSERT INTO "LikeListDetails" ("Id", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "UpdatedAt")
    VALUES ('a9b52bc6-dc90-44fa-9b3d-ed30ae4f14aa', '158c039c-b815-464b-bfbc-d33383178380', TIMESTAMPTZ '-infinity', '4085bfd2-4cfb-4e95-9872-0db1563590db', FALSE, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('01facbeb-69f4-4a53-970d-6672ffe9467b', '158c039c-b815-464b-bfbc-d33383178380', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ B2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('63c09c2e-e3da-487c-8915-ffaad9cb32aa', '8ab48bd8-afec-4090-921a-2826a512fd90', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ A1', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('6975cb42-160f-4bd1-b16c-0abfb7de3984', '158c039c-b815-464b-bfbc-d33383178380', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ B1', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('8c75e3dc-3169-461a-90e9-987c5fd4d6c9', '8ab48bd8-afec-4090-921a-2826a512fd90', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ A2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('9d80eb68-6024-4405-924b-78670241374d', '5a536171-1d44-401f-a2cd-375c95a2d12c', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ C2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('b1522609-3a28-4b07-a6c9-8d34ef9768f4', '27ef7bb4-e6d0-4477-806b-22ac447921f7', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ D2', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('d4227d57-c838-470c-9f6b-6ab26d06380a', '5a536171-1d44-401f-a2cd-375c95a2d12c', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ C1', TIMESTAMPTZ '-infinity');
    INSERT INTO "SubCourts" ("Id", "CourtId", "CreatedAt", "IsDeleted", "Name", "UpdatedAt")
    VALUES ('e3a05ca2-e5d9-4399-a325-4354029387ca', '27ef7bb4-e6d0-4477-806b-22ac447921f7', TIMESTAMPTZ '-infinity', FALSE, 'Sân nhỏ D1', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "Status", "SubCourtId", "UpdatedAt")
    VALUES ('1d5883ef-1a99-454e-bc80-1cb9693203ee', '7ce3c694-31a4-46ea-8adf-8b4ed95ae694', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-05-01T15:27:53.803306+07:00', TIME '10:00:00', FALSE, 150000.0, TIME '06:00:00', 'Cancel', 'e3a05ca2-e5d9-4399-a325-4354029387ca', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "Status", "SubCourtId", "UpdatedAt")
    VALUES ('336c5c35-4374-45c6-ac28-0377bd610e35', '12ec3881-d611-4cd3-8d9f-0eaf994e6119', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-05-01T15:27:53.803305+07:00', TIME '08:00:00', FALSE, 150000.0, TIME '07:00:00', 'Banked', 'd4227d57-c838-470c-9f6b-6ab26d06380a', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "Status", "SubCourtId", "UpdatedAt")
    VALUES ('4b59b86d-9376-421f-9b54-964bb402880f', '8ff8fef7-3982-4df1-98e7-9424f8aa76b9', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-29T15:27:53.8033+07:00', TIME '10:00:00', FALSE, 100000.0, TIME '08:00:00', 'Banked', '63c09c2e-e3da-487c-8915-ffaad9cb32aa', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "Status", "SubCourtId", "UpdatedAt")
    VALUES ('eb4edcea-e35e-47b6-8ad2-b3296179ff34', '40094855-a269-4d9a-a656-6151e0064ebf', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-05-05T15:27:53.803306+07:00', TIME '10:00:00', FALSE, 150000.0, TIME '09:00:00', 'Banked', '8c75e3dc-3169-461a-90e9-987c5fd4d6c9', TIMESTAMPTZ '-infinity');
    INSERT INTO "BookingDetails" ("Id", "BookingId", "CreatedAt", "Date", "EndTime", "IsDeleted", "Price", "StartTime", "Status", "SubCourtId", "UpdatedAt")
    VALUES ('fd2eaa4a-514a-4ac0-ac71-6ff3745d4b36', 'bc6b8020-a418-4498-aad0-13f6aa242707', TIMESTAMPTZ '-infinity', TIMESTAMPTZ '2026-04-29T15:27:53.803305+07:00', TIME '07:00:00', FALSE, 100000.0, TIME '06:00:00', 'Banked', '6975cb42-160f-4bd1-b16c-0abfb7de3984', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('06b24e20-d8f5-4cfe-be64-1db97c779157', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 70000.0, TIME '09:30:00', '6975cb42-160f-4bd1-b16c-0abfb7de3984', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('0970687d-ac15-4ee7-bd0e-a6eaacaa8d21', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 35000.0, TIME '06:30:00', 'd4227d57-c838-470c-9f6b-6ab26d06380a', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('155af2f7-141a-4282-9e07-a4f3c350eb7e', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 35000.0, TIME '09:30:00', 'd4227d57-c838-470c-9f6b-6ab26d06380a', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('1bd0b502-e7b1-4d4c-b2bb-54bb742f835b', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 50000.0, TIME '07:30:00', '63c09c2e-e3da-487c-8915-ffaad9cb32aa', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('1d20ac47-f93d-4892-b854-cc7073a04d1d', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 100000.0, TIME '06:00:00', 'e3a05ca2-e5d9-4399-a325-4354029387ca', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('259c2300-bc27-4c72-8051-b2257cbaa503', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 70000.0, TIME '06:00:00', '6975cb42-160f-4bd1-b16c-0abfb7de3984', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('31827cf1-c046-4ba1-a810-d534e2505025', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 50000.0, TIME '08:00:00', '63c09c2e-e3da-487c-8915-ffaad9cb32aa', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('34be2162-54ff-4c57-a869-9c49d2cd5f83', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 70000.0, TIME '09:00:00', '6975cb42-160f-4bd1-b16c-0abfb7de3984', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('411489b3-abca-4744-a949-7833eed2bc10', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 70000.0, TIME '07:00:00', '6975cb42-160f-4bd1-b16c-0abfb7de3984', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('47e91cc4-67a3-4aec-9e63-70b72bd58879', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 50000.0, TIME '06:30:00', '63c09c2e-e3da-487c-8915-ffaad9cb32aa', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('4c22e932-ecef-4b03-abfc-6c849cff69b7', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 100000.0, TIME '07:00:00', 'e3a05ca2-e5d9-4399-a325-4354029387ca', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('5847b300-4247-4012-b988-a59c6b678e8e', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 50000.0, TIME '06:00:00', '63c09c2e-e3da-487c-8915-ffaad9cb32aa', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('619d553d-8bd9-45d4-bba7-a6e880970409', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 100000.0, TIME '06:30:00', 'e3a05ca2-e5d9-4399-a325-4354029387ca', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('66ae7c5b-a90e-44cc-9c3a-c32849876b03', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 100000.0, TIME '08:30:00', 'e3a05ca2-e5d9-4399-a325-4354029387ca', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('71e04453-e511-4436-afab-3970583e6c4b', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 35000.0, TIME '08:00:00', 'd4227d57-c838-470c-9f6b-6ab26d06380a', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('72b9129c-bbb9-4e33-9b9d-f3d1bf875125', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 35000.0, TIME '07:30:00', 'd4227d57-c838-470c-9f6b-6ab26d06380a', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('72c34d10-2bca-433b-8d30-54e1f3bd069e', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 70000.0, TIME '07:30:00', '6975cb42-160f-4bd1-b16c-0abfb7de3984', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('86e83ce2-c08b-4596-8e38-d9c0204b1e90', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 50000.0, TIME '07:00:00', '63c09c2e-e3da-487c-8915-ffaad9cb32aa', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('8c63fe52-3c22-4bd7-9d95-f0d72e70d306', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 100000.0, TIME '08:00:00', 'e3a05ca2-e5d9-4399-a325-4354029387ca', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('8df193bb-7002-4de7-a878-c4fa0c0cf46b', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 50000.0, TIME '08:30:00', '63c09c2e-e3da-487c-8915-ffaad9cb32aa', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('91136d4c-0058-4d75-adf6-037689c2719f', TIMESTAMPTZ '-infinity', TIME '08:30:00', FALSE, 70000.0, TIME '08:00:00', '6975cb42-160f-4bd1-b16c-0abfb7de3984', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('cd9f86c0-3aa6-41a4-a236-43f28264ca2b', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 70000.0, TIME '08:30:00', '6975cb42-160f-4bd1-b16c-0abfb7de3984', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('d0adb084-1eab-4470-811b-88cb6e498fcf', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 100000.0, TIME '09:30:00', 'e3a05ca2-e5d9-4399-a325-4354029387ca', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('e83ef7c7-9091-4023-8752-d7c4de8ca035', TIMESTAMPTZ '-infinity', TIME '07:00:00', FALSE, 70000.0, TIME '06:30:00', '6975cb42-160f-4bd1-b16c-0abfb7de3984', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('e85fe763-054a-4254-977b-85daebc73d8f', TIMESTAMPTZ '-infinity', TIME '07:30:00', FALSE, 35000.0, TIME '07:00:00', 'd4227d57-c838-470c-9f6b-6ab26d06380a', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('e8b46f24-77ac-4787-b434-e77aa8167c5a', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 50000.0, TIME '09:00:00', '63c09c2e-e3da-487c-8915-ffaad9cb32aa', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('e908a13e-45be-4186-976b-d36f6e3f784f', TIMESTAMPTZ '-infinity', TIME '09:00:00', FALSE, 35000.0, TIME '08:30:00', 'd4227d57-c838-470c-9f6b-6ab26d06380a', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('ea48ed38-fc78-4a37-a4af-f2bb1108ad0c', TIMESTAMPTZ '-infinity', TIME '08:00:00', FALSE, 100000.0, TIME '07:30:00', 'e3a05ca2-e5d9-4399-a325-4354029387ca', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('f52bde98-cb3e-4b50-941e-95e9ce27094e', TIMESTAMPTZ '-infinity', TIME '10:00:00', FALSE, 50000.0, TIME '09:30:00', '63c09c2e-e3da-487c-8915-ffaad9cb32aa', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('f53131bf-8f02-48b5-9e06-272984483763', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 35000.0, TIME '09:00:00', 'd4227d57-c838-470c-9f6b-6ab26d06380a', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('f5d7a395-bf2d-435d-992f-80c362f9b8bd', TIMESTAMPTZ '-infinity', TIME '09:30:00', FALSE, 100000.0, TIME '09:00:00', 'e3a05ca2-e5d9-4399-a325-4354029387ca', TIMESTAMPTZ '-infinity');
    INSERT INTO "ConfigSlots" ("Id", "CreatedAt", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('ffe87801-d969-473f-97fe-686438886e71', TIMESTAMPTZ '-infinity', TIME '06:30:00', FALSE, 35000.0, TIME '06:00:00', 'd4227d57-c838-470c-9f6b-6ab26d06380a', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('020d57da-5ecb-4b13-b8fd-851ebfb480fc', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Hỏng đèn chiếu sáng', TIME '12:00:00', 'd4227d57-c838-470c-9f6b-6ab26d06380a', TIMESTAMPTZ '-infinity');
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('046f3fdc-7b5b-4339-b041-539a28509e3a', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Sơn lại mặt sân', TIME '12:00:00', '6975cb42-160f-4bd1-b16c-0abfb7de3984', TIMESTAMPTZ '-infinity');
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('a36be787-4a77-45cf-b621-a2f39264f58b', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Tổ chức sự kiện nội bộ', TIME '12:00:00', 'e3a05ca2-e5d9-4399-a325-4354029387ca', TIMESTAMPTZ '-infinity');
    INSERT INTO "Exceptions" ("Id", "CreatedAt", "Date", "EndTime", "IsDeleted", "Reason", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('e00a9089-6e1d-47e3-8e10-86a2cd2ce6ff', TIMESTAMPTZ '-infinity', DATE '2026-04-25', TIME '17:00:00', FALSE, 'Bảo trì định kỳ', TIME '12:00:00', '63c09c2e-e3da-487c-8915-ffaad9cb32aa', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('1be6af10-2b32-4038-9a63-bf64ce1d5111', '40094855-a269-4d9a-a656-6151e0064ebf', 'Đèn chiếu sáng yếu vào ban đêm.', '8ab48bd8-afec-4090-921a-2826a512fd90', TIMESTAMPTZ '-infinity', '68218da8-c73f-4dff-8e80-76d98e701b87', FALSE, 2, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('6db9291b-da1e-42b8-a362-840ca8f1c04d', '8ff8fef7-3982-4df1-98e7-9424f8aa76b9', 'Sân rất tốt, sẽ quay lại!', '8ab48bd8-afec-4090-921a-2826a512fd90', TIMESTAMPTZ '-infinity', '68218da8-c73f-4dff-8e80-76d98e701b87', FALSE, 5, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('c3d9a825-027c-4f28-9d73-370821762799', '7ce3c694-31a4-46ea-8adf-8b4ed95ae694', 'Nhân viên thân thiện, sân sạch.', '158c039c-b815-464b-bfbc-d33383178380', TIMESTAMPTZ '-infinity', '4085bfd2-4cfb-4e95-9872-0db1563590db', FALSE, 5, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('c9d65781-5235-4ebf-9b41-93d4a58ee295', 'bc6b8020-a418-4498-aad0-13f6aa242707', 'Dịch vụ ổn, giá hợp lý.', '158c039c-b815-464b-bfbc-d33383178380', TIMESTAMPTZ '-infinity', '68218da8-c73f-4dff-8e80-76d98e701b87', FALSE, 4, TIMESTAMPTZ '-infinity');
    INSERT INTO "Feedbacks" ("Id", "BookingId", "Comment", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Rating", "UpdatedAt")
    VALUES ('e65313d3-b866-4dae-af12-645f9086812d', '12ec3881-d611-4cd3-8d9f-0eaf994e6119', 'Bình thường, sân hơi cũ.', '5a536171-1d44-401f-a2cd-375c95a2d12c', TIMESTAMPTZ '-infinity', '4085bfd2-4cfb-4e95-9872-0db1563590db', FALSE, 3, TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('1495be41-0599-4584-a6f0-85970c61b5f7', 'bc6b8020-a418-4498-aad0-13f6aa242707', 'Booking #2 đã được xác nhận.', '158c039c-b815-464b-bfbc-d33383178380', TIMESTAMPTZ '-infinity', FALSE, 'Đặt sân thành công', 'Booking', TIMESTAMPTZ '-infinity', '3e27b94e-1058-43f0-85c0-41a12dfe7d52');
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('5c081612-8902-4c90-a9f7-5bf86af04043', '40094855-a269-4d9a-a656-6151e0064ebf', 'Đã hoàn 360,000đ vào ví của bạn.', '8ab48bd8-afec-4090-921a-2826a512fd90', TIMESTAMPTZ '-infinity', FALSE, 'Hoàn tiền', 'Refund', TIMESTAMPTZ '-infinity', '8e14cc18-e3c1-4e89-8f64-253319f25d0a');
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('5e30d3e6-206b-45ed-bc16-928596611f74', '12ec3881-d611-4cd3-8d9f-0eaf994e6119', 'Bạn có lịch chơi vào ngày mai.', '5a536171-1d44-401f-a2cd-375c95a2d12c', TIMESTAMPTZ '-infinity', FALSE, 'Nhắc nhở lịch chơi', 'Remind', TIMESTAMPTZ '-infinity', 'c0102316-7f20-4e81-af35-c8e7fe034c4d');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('bdc7f1e4-b753-4c04-ba29-802cb4009bba', '8ff8fef7-3982-4df1-98e7-9424f8aa76b9', 'Booking #1 đã được xác nhận.', '8ab48bd8-afec-4090-921a-2826a512fd90', TIMESTAMPTZ '-infinity', FALSE, TRUE, 'Đặt sân thành công', 'Booking', TIMESTAMPTZ '-infinity', '8e14cc18-e3c1-4e89-8f64-253319f25d0a');
    INSERT INTO "Notifications" ("Id", "BookingId", "Content", "CourtId", "CreatedAt", "IsDeleted", "IsRead", "Title", "Type", "UpdatedAt", "UserId")
    VALUES ('e4729106-4694-4138-91de-ce266e78968f', '7ce3c694-31a4-46ea-8adf-8b4ed95ae694', 'Booking #4 đã bị huỷ. Tiền sẽ hoàn.', '27ef7bb4-e6d0-4477-806b-22ac447921f7', TIMESTAMPTZ '-infinity', FALSE, TRUE, 'Huỷ booking', 'Cancel', TIMESTAMPTZ '-infinity', '53ff038a-8f14-4fc6-be8d-cdfe4181fd91');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('a7e964b9-e20c-4aa7-a7a7-82c48557b962', TIMESTAMPTZ '-infinity', DATE '2026-04-25', 0, TIME '17:00:00', FALSE, 2054000.0, TIME '12:00:00', 'd4227d57-c838-470c-9f6b-6ab26d06380a', TIMESTAMPTZ '-infinity');
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('d68fd0c6-ea86-4d29-a23b-b7d70d003f3b', TIMESTAMPTZ '-infinity', DATE '2026-04-25', 0, TIME '17:00:00', FALSE, 208400.0, TIME '12:00:00', '63c09c2e-e3da-487c-8915-ffaad9cb32aa', TIMESTAMPTZ '-infinity');
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('dfee6812-1ae3-4088-acd5-adca8be60918', TIMESTAMPTZ '-infinity', DATE '2026-04-25', 0, TIME '17:00:00', FALSE, 220800.0, TIME '12:00:00', 'e3a05ca2-e5d9-4399-a325-4354029387ca', TIMESTAMPTZ '-infinity');
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('ec3bcbe8-12a9-45e6-9ea5-36deb3939cc9', TIMESTAMPTZ '-infinity', DATE '2026-04-25', 0, TIME '17:00:00', FALSE, 220500.0, TIME '12:00:00', '6975cb42-160f-4bd1-b16c-0abfb7de3984', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    INSERT INTO "OverideSlots" ("Id", "CreatedAt", "Date", "DayOfWeek", "EndTime", "IsDeleted", "IsRecurring", "Price", "StartTime", "SubCourtDetailId", "UpdatedAt")
    VALUES ('fe802f13-c423-45e2-87ce-e1e5c3b3cb19', TIMESTAMPTZ '-infinity', DATE '-infinity', 1, TIME '20:00:00', FALSE, TRUE, 200000.0, TIME '18:00:00', '8c75e3dc-3169-461a-90e9-987c5fd4d6c9', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('16e0fa17-9601-499a-b597-e57193f250d4', '7ce3c694-31a4-46ea-8adf-8b4ed95ae694', '5a536171-1d44-401f-a2cd-375c95a2d12c', TIMESTAMPTZ '-infinity', '68218da8-c73f-4dff-8e80-76d98e701b87', FALSE, 'Không hoàn tiền khi huỷ đúng hạn.', 'Rejected', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('18c6a7b8-14aa-4d4f-b93a-cddb3cc51c7b', '8ff8fef7-3982-4df1-98e7-9424f8aa76b9', '5a536171-1d44-401f-a2cd-375c95a2d12c', TIMESTAMPTZ '-infinity', '4085bfd2-4cfb-4e95-9872-0db1563590db', FALSE, 'Sân không đúng mô tả.', 'Pending', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('1cf7a0f4-9ef2-46f8-a275-5a0ee97f6356', '40094855-a269-4d9a-a656-6151e0064ebf', '27ef7bb4-e6d0-4477-806b-22ac447921f7', TIMESTAMPTZ '-infinity', '68218da8-c73f-4dff-8e80-76d98e701b87', FALSE, 'Thông tin giờ mở cửa sai.', 'Pending', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('82434ee5-4ee2-42de-9b37-437f3124ccfe', 'bc6b8020-a418-4498-aad0-13f6aa242707', '8ab48bd8-afec-4090-921a-2826a512fd90', TIMESTAMPTZ '-infinity', '4085bfd2-4cfb-4e95-9872-0db1563590db', FALSE, 'Chủ sân thái độ không tốt.', 'Resolved', TIMESTAMPTZ '-infinity');
    INSERT INTO "Reports" ("Id", "BookingId", "CourtId", "CreatedAt", "CustomerId", "IsDeleted", "Reason", "Status", "UpdatedAt")
    VALUES ('fcba7659-e27d-49e2-b1e3-4d5e899dd1aa', '12ec3881-d611-4cd3-8d9f-0eaf994e6119', '158c039c-b815-464b-bfbc-d33383178380', TIMESTAMPTZ '-infinity', '68218da8-c73f-4dff-8e80-76d98e701b87', FALSE, 'Cơ sở vật chất xuống cấp.', 'Pending', TIMESTAMPTZ '-infinity');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('0b4ec1ab-8f9c-4d62-9814-54dd2ecb95ca', 'ACT001', 180000.0, 2000000.0, 2180000.0, '2345678901', 'REF001', '8ff8fef7-3982-4df1-98e7-9424f8aa76b9', TIMESTAMPTZ '-infinity', FALSE, 'SP001', 'SIG001', 'Success', 'Thanh toán booking #1', 'Payment', TIMESTAMPTZ '-infinity', '35550b9b-d9a3-4fae-906e-a51a24b1cb00');
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('7f76f67c-96df-42e7-bf65-4ec6ceb03d8b', 'ACT003', 200000.0, 2200000.0, 2000000.0, '4567890123', 'REF003', '12ec3881-d611-4cd3-8d9f-0eaf994e6119', TIMESTAMPTZ '-infinity', FALSE, 'SP003', 'SIG003', 'Success', 'Hoàn tiền booking #4', 'Refund', TIMESTAMPTZ '-infinity', 'be76a585-c486-4ace-8522-687147c70eba');
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('a3e22164-078f-49db-afb5-c4b452bac161', 'ACT004', 500000.0, 2000000.0, 1500000.0, '5678901234', 'REF004', '40094855-a269-4d9a-a656-6151e0064ebf', TIMESTAMPTZ '-infinity', FALSE, 'SP004', 'SIG004', 'Success', 'Nạp tiền vào ví', 'Deposit', TIMESTAMPTZ '-infinity', 'd748004e-b3b1-4d1d-8ef0-abd92398a5f5');
    INSERT INTO "Transactions" ("Id", "ActionCode", "Amount", "BalanceAfter", "BalanceBefore", "BankAccountNumber", "BankRefCode", "BookingId", "CreatedAt", "IsDeleted", "SePayId", "Signature", "Status", "TransferContent", "Type", "UpdatedAt", "WalletId")
    VALUES ('bd8be82c-d210-41fc-894d-1bf743657ac4', 'ACT002', 270000.0, 3500000.0, 3770000.0, '3456789012', 'REF002', 'bc6b8020-a418-4498-aad0-13f6aa242707', TIMESTAMPTZ '-infinity', FALSE, 'SP002', 'SIG002', 'Success', 'Thanh toán booking #2', 'Payment', TIMESTAMPTZ '-infinity', '37b1fcc0-ea53-4a64-ab01-d9f45d62323d');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20260504082755_update_server') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20260504082755_update_server', '8.0.0');
    END IF;
END $EF$;
COMMIT;

