CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Customer" (
    "Id" uuid NOT NULL,
    "Email" text NOT NULL,
    "Names" text NOT NULL,
    "LastNames" text NOT NULL,
    "CivilStatus" text NOT NULL,
    "Salary" numeric NOT NULL,
    "PhoneNumber" text NOT NULL,
    "Identity_DateOfIssue" date NOT NULL,
    "Identity_Type" text NOT NULL,
    "Identity_Value" text NOT NULL,
    "CreatedOn" timestamp with time zone NOT NULL,
    "UpdatedOn" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Customer" PRIMARY KEY ("Id")
);

CREATE TABLE "Property" (
    "Id" uuid NOT NULL,
    "Tuition" text NOT NULL,
    "Price" numeric NOT NULL,
    "Block" text NOT NULL,
    "Lot" text NOT NULL,
    "Coordinates_East" text NOT NULL,
    "Coordinates_North" text NOT NULL,
    "Coordinates_South" text NOT NULL,
    "Coordinates_West" text NOT NULL,
    "CreatedOn" timestamp with time zone NOT NULL,
    "UpdatedOn" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Property" PRIMARY KEY ("Id")
);

CREATE TABLE "Sale" (
    "Id" uuid NOT NULL,
    "CreatedOn" timestamp with time zone NOT NULL,
    "UpdatedOn" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Sale" PRIMARY KEY ("Id")
);

CREATE TABLE "AppraisalData" (
    "Id" uuid NOT NULL,
    "SaleId" uuid NOT NULL,
    "Payment" boolean NOT NULL,
    "RequestSubmissionOfDocuments" boolean NOT NULL,
    "Visit" boolean NOT NULL,
    "Report" boolean NOT NULL,
    "IssuanceByTheBankOfALetterOfRatification" boolean NOT NULL,
    "TitleStudyPayment" boolean NOT NULL,
    "SendingDocumentsForTitleStudy" boolean NOT NULL,
    "FamilyCodeInMinistryOfHousing" text NOT NULL,
    "CreatedOn" timestamp with time zone NOT NULL,
    "UpdatedOn" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_AppraisalData" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_AppraisalData_Sale_SaleId" FOREIGN KEY ("SaleId") REFERENCES "Sale" ("Id") ON DELETE CASCADE
);

CREATE TABLE "DeedCostsData" (
    "Id" uuid NOT NULL,
    "SaleId" uuid NOT NULL,
    "DeedCosts" numeric NOT NULL,
    "NotaryPayment" numeric NOT NULL,
    "PropertyPayment" numeric NOT NULL,
    "GovernmentPayment" numeric NOT NULL,
    "PublicInstrumentsPayment" numeric NOT NULL,
    "DeedDebt" numeric NOT NULL,
    "CreatedOn" timestamp with time zone NOT NULL,
    "UpdatedOn" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_DeedCostsData" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_DeedCostsData_Sale_SaleId" FOREIGN KEY ("SaleId") REFERENCES "Sale" ("Id") ON DELETE CASCADE
);

CREATE TABLE "DeedData" (
    "Id" uuid NOT NULL,
    "SaleId" uuid NOT NULL,
    "ConstructionCompanySignature" boolean NOT NULL,
    "CustomerSignature" boolean NOT NULL,
    "PropertySellerSignature" boolean NOT NULL,
    "BankSignature" boolean NOT NULL,
    "CopiesAndSettlement" boolean NOT NULL,
    "EntryDateIntoPublicInstruments" date NOT NULL,
    "CreatedOn" timestamp with time zone NOT NULL,
    "UpdatedOn" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_DeedData" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_DeedData_Sale_SaleId" FOREIGN KEY ("SaleId") REFERENCES "Sale" ("Id") ON DELETE CASCADE
);

CREATE TABLE "DeliveryData" (
    "Id" uuid NOT NULL,
    "SaleId" uuid NOT NULL,
    "ScannedDeliveryCertificate" boolean NOT NULL,
    "ScannedTaxAndRegistrationSlip" boolean NOT NULL,
    "ScannedDeed" boolean NOT NULL,
    "DisbursementInstruction" boolean NOT NULL,
    "PeaceAndSafetyPropertySeller" boolean NOT NULL,
    "ScannedCTL" boolean NOT NULL,
    "DeedSentToLawyer" boolean NOT NULL,
    "CreatedOn" timestamp with time zone NOT NULL,
    "UpdatedOn" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_DeliveryData" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_DeliveryData_Sale_SaleId" FOREIGN KEY ("SaleId") REFERENCES "Sale" ("Id") ON DELETE CASCADE
);

CREATE TABLE "DocumentaryData" (
    "Id" uuid NOT NULL,
    "SaleId" uuid NOT NULL,
    "IdentificationDocument" boolean NOT NULL,
    "SignedPledge" boolean NOT NULL,
    "CreditApprovalLetter" boolean NOT NULL,
    "ApprovalLetterNumber" text NOT NULL,
    "CompensationFundRecordNumber" text NOT NULL,
    "MinistrySubsidyResolution" boolean NOT NULL,
    "DeliveryDocument" boolean NOT NULL,
    "CreatedOn" timestamp with time zone NOT NULL,
    "UpdatedOn" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_DocumentaryData" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_DocumentaryData_Sale_SaleId" FOREIGN KEY ("SaleId") REFERENCES "Sale" ("Id") ON DELETE CASCADE
);

CREATE TABLE "FinancialData" (
    "Id" uuid NOT NULL,
    "SaleId" uuid NOT NULL,
    "Price" numeric NOT NULL,
    "ValueToSetAside" numeric NOT NULL,
    "OtherPayments" numeric NOT NULL,
    "CompensationFundSubsidy" numeric NOT NULL,
    "MinistryOfHousingSubsidy" numeric NOT NULL,
    "LoanValue" numeric NOT NULL,
    "LoanEntity" text NOT NULL,
    "Debt" numeric NOT NULL,
    "CreatedOn" timestamp with time zone NOT NULL,
    "UpdatedOn" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_FinancialData" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_FinancialData_Sale_SaleId" FOREIGN KEY ("SaleId") REFERENCES "Sale" ("Id") ON DELETE CASCADE
);

CREATE TABLE "SaleCustomer" (
    "Id" uuid NOT NULL,
    "CustomerId" uuid NOT NULL,
    "SaleId" uuid NOT NULL,
    "Email" text NOT NULL,
    "Names" text NOT NULL,
    "LastNames" text NOT NULL,
    "CivilStatus" text NOT NULL,
    "Salary" numeric NOT NULL,
    "PhoneNumber" text NOT NULL,
    "Identity_DateOfIssue" date NOT NULL,
    "Identity_Type" text NOT NULL,
    "Identity_Value" text NOT NULL,
    "CreatedOn" timestamp with time zone NOT NULL,
    "UpdatedOn" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_SaleCustomer" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_SaleCustomer_Customer_CustomerId" FOREIGN KEY ("CustomerId") REFERENCES "Customer" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_SaleCustomer_Sale_SaleId" FOREIGN KEY ("SaleId") REFERENCES "Sale" ("Id") ON DELETE CASCADE
);

CREATE TABLE "SaleProperty" (
    "Id" uuid NOT NULL,
    "PropertyId" uuid NOT NULL,
    "SaleId" uuid NOT NULL,
    "Tuition" text NOT NULL,
    "Price" numeric NOT NULL,
    "Block" text NOT NULL,
    "Lot" text NOT NULL,
    "Coordinates_East" text NOT NULL,
    "Coordinates_North" text NOT NULL,
    "Coordinates_South" text NOT NULL,
    "Coordinates_West" text NOT NULL,
    "CreatedOn" timestamp with time zone NOT NULL,
    "UpdatedOn" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_SaleProperty" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_SaleProperty_Property_PropertyId" FOREIGN KEY ("PropertyId") REFERENCES "Property" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_SaleProperty_Sale_SaleId" FOREIGN KEY ("SaleId") REFERENCES "Sale" ("Id") ON DELETE CASCADE
);

CREATE TABLE "ServicesData" (
    "Id" uuid NOT NULL,
    "SaleId" uuid NOT NULL,
    "ElectricMeterValue" numeric NOT NULL,
    "InstalledElectricMeter" boolean NOT NULL,
    "InstalledWaterMeter" boolean NOT NULL,
    "CreatedOn" timestamp with time zone NOT NULL,
    "UpdatedOn" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_ServicesData" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_ServicesData_Sale_SaleId" FOREIGN KEY ("SaleId") REFERENCES "Sale" ("Id") ON DELETE CASCADE
);

CREATE TABLE "SubsidyData" (
    "Id" uuid NOT NULL,
    "SaleId" uuid NOT NULL,
    "DialedMinistryCollection" boolean NOT NULL,
    "MinistryPayment" boolean NOT NULL,
    "CompensationBoxSubsidyFiled" boolean NOT NULL,
    "CompensationCashPayment" boolean NOT NULL,
    "LoanDisbursementDate" date NOT NULL,
    "CreatedOn" timestamp with time zone NOT NULL,
    "UpdatedOn" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_SubsidyData" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_SubsidyData_Sale_SaleId" FOREIGN KEY ("SaleId") REFERENCES "Sale" ("Id") ON DELETE CASCADE
);

CREATE TABLE "VisitData" (
    "Id" uuid NOT NULL,
    "SaleId" uuid NOT NULL,
    "Visit" boolean NOT NULL,
    "Certified" boolean NOT NULL,
    "SentAfiniaDocuments" boolean NOT NULL,
    "CreatedOn" timestamp with time zone NOT NULL,
    "UpdatedOn" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_VisitData" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_VisitData_Sale_SaleId" FOREIGN KEY ("SaleId") REFERENCES "Sale" ("Id") ON DELETE CASCADE
);

CREATE UNIQUE INDEX "IX_AppraisalData_SaleId" ON "AppraisalData" ("SaleId");

CREATE UNIQUE INDEX "IX_DeedCostsData_SaleId" ON "DeedCostsData" ("SaleId");

CREATE UNIQUE INDEX "IX_DeedData_SaleId" ON "DeedData" ("SaleId");

CREATE UNIQUE INDEX "IX_DeliveryData_SaleId" ON "DeliveryData" ("SaleId");

CREATE UNIQUE INDEX "IX_DocumentaryData_SaleId" ON "DocumentaryData" ("SaleId");

CREATE UNIQUE INDEX "IX_FinancialData_SaleId" ON "FinancialData" ("SaleId");

CREATE INDEX "IX_SaleCustomer_CustomerId" ON "SaleCustomer" ("CustomerId");

CREATE UNIQUE INDEX "IX_SaleCustomer_SaleId" ON "SaleCustomer" ("SaleId");

CREATE INDEX "IX_SaleProperty_PropertyId" ON "SaleProperty" ("PropertyId");

CREATE UNIQUE INDEX "IX_SaleProperty_SaleId" ON "SaleProperty" ("SaleId");

CREATE UNIQUE INDEX "IX_ServicesData_SaleId" ON "ServicesData" ("SaleId");

CREATE UNIQUE INDEX "IX_SubsidyData_SaleId" ON "SubsidyData" ("SaleId");

CREATE UNIQUE INDEX "IX_VisitData_SaleId" ON "VisitData" ("SaleId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240303202812_initial', '8.0.0');

COMMIT;

START TRANSACTION;

ALTER TABLE "SaleCustomer" DROP COLUMN "Identity_DateOfIssue";

ALTER TABLE "Customer" DROP COLUMN "Identity_DateOfIssue";

ALTER TABLE "SaleCustomer" ADD "Identity_Expedition" text NOT NULL DEFAULT '';

ALTER TABLE "Customer" ADD "Identity_Expedition" text NOT NULL DEFAULT '';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240310172207_change-expiration-type-from-identity', '8.0.0');

COMMIT;

START TRANSACTION;

ALTER TABLE "Sale" ADD "Deleted" boolean NOT NULL DEFAULT FALSE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240318002022_logical-removal', '8.0.0');

COMMIT;

START TRANSACTION;

CREATE TABLE "User" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "LastName" text NOT NULL,
    "Email" text NOT NULL,
    "Password" text NOT NULL,
    "CreatedOn" timestamp with time zone NOT NULL,
    "UpdatedOn" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_User" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240403090102_add-user', '8.0.0');

COMMIT;