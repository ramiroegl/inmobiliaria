﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inmobiliaria.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Names = table.Column<string>(type: "text", nullable: false),
                    LastNames = table.Column<string>(type: "text", nullable: false),
                    CivilStatus = table.Column<string>(type: "text", nullable: false),
                    Salary = table.Column<decimal>(type: "numeric", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Identity_Expedition = table.Column<string>(type: "text", nullable: false),
                    Identity_Type = table.Column<string>(type: "text", nullable: false),
                    Identity_Value = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Tuition = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Block = table.Column<string>(type: "text", nullable: false),
                    Lot = table.Column<string>(type: "text", nullable: false),
                    Coordinates_East = table.Column<string>(type: "text", nullable: false),
                    Coordinates_North = table.Column<string>(type: "text", nullable: false),
                    Coordinates_South = table.Column<string>(type: "text", nullable: false),
                    Coordinates_West = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppraisalData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SaleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Payment = table.Column<bool>(type: "boolean", nullable: false),
                    RequestSubmissionOfDocuments = table.Column<bool>(type: "boolean", nullable: false),
                    Visit = table.Column<bool>(type: "boolean", nullable: false),
                    Report = table.Column<bool>(type: "boolean", nullable: false),
                    IssuanceByTheBankOfALetterOfRatification = table.Column<bool>(type: "boolean", nullable: false),
                    TitleStudyPayment = table.Column<bool>(type: "boolean", nullable: false),
                    SendingDocumentsForTitleStudy = table.Column<bool>(type: "boolean", nullable: false),
                    FamilyCodeInMinistryOfHousing = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppraisalData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppraisalData_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeedCostsData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SaleId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeedCosts = table.Column<decimal>(type: "numeric", nullable: false),
                    NotaryPayment = table.Column<decimal>(type: "numeric", nullable: false),
                    PropertyPayment = table.Column<decimal>(type: "numeric", nullable: false),
                    GovernmentPayment = table.Column<decimal>(type: "numeric", nullable: false),
                    PublicInstrumentsPayment = table.Column<decimal>(type: "numeric", nullable: false),
                    DeedDebt = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeedCostsData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeedCostsData_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeedData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SaleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConstructionCompanySignature = table.Column<bool>(type: "boolean", nullable: false),
                    CustomerSignature = table.Column<bool>(type: "boolean", nullable: false),
                    PropertySellerSignature = table.Column<bool>(type: "boolean", nullable: false),
                    BankSignature = table.Column<bool>(type: "boolean", nullable: false),
                    CopiesAndSettlement = table.Column<bool>(type: "boolean", nullable: false),
                    EntryDateIntoPublicInstruments = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeedData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeedData_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SaleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScannedDeliveryCertificate = table.Column<bool>(type: "boolean", nullable: false),
                    ScannedTaxAndRegistrationSlip = table.Column<bool>(type: "boolean", nullable: false),
                    ScannedDeed = table.Column<bool>(type: "boolean", nullable: false),
                    DisbursementInstruction = table.Column<bool>(type: "boolean", nullable: false),
                    PeaceAndSafetyPropertySeller = table.Column<bool>(type: "boolean", nullable: false),
                    ScannedCTL = table.Column<bool>(type: "boolean", nullable: false),
                    DeedSentToLawyer = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryData_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentaryData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SaleId = table.Column<Guid>(type: "uuid", nullable: false),
                    IdentificationDocument = table.Column<bool>(type: "boolean", nullable: false),
                    SignedPledge = table.Column<bool>(type: "boolean", nullable: false),
                    CreditApprovalLetter = table.Column<bool>(type: "boolean", nullable: false),
                    ApprovalLetterNumber = table.Column<string>(type: "text", nullable: false),
                    CompensationFundRecordNumber = table.Column<string>(type: "text", nullable: false),
                    MinistrySubsidyResolution = table.Column<bool>(type: "boolean", nullable: false),
                    DeliveryDocument = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentaryData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentaryData_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinancialData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SaleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    ValueToSetAside = table.Column<decimal>(type: "numeric", nullable: false),
                    OtherPayments = table.Column<decimal>(type: "numeric", nullable: false),
                    CompensationFundSubsidy = table.Column<decimal>(type: "numeric", nullable: false),
                    MinistryOfHousingSubsidy = table.Column<decimal>(type: "numeric", nullable: false),
                    LoanValue = table.Column<decimal>(type: "numeric", nullable: false),
                    LoanEntity = table.Column<string>(type: "text", nullable: false),
                    Debt = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialData_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleCustomer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    SaleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Names = table.Column<string>(type: "text", nullable: false),
                    LastNames = table.Column<string>(type: "text", nullable: false),
                    CivilStatus = table.Column<string>(type: "text", nullable: false),
                    Salary = table.Column<decimal>(type: "numeric", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Identity_Expedition = table.Column<string>(type: "text", nullable: false),
                    Identity_Type = table.Column<string>(type: "text", nullable: false),
                    Identity_Value = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleCustomer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleCustomer_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleCustomer_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleProperty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uuid", nullable: false),
                    SaleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Tuition = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Block = table.Column<string>(type: "text", nullable: false),
                    Lot = table.Column<string>(type: "text", nullable: false),
                    Coordinates_East = table.Column<string>(type: "text", nullable: false),
                    Coordinates_North = table.Column<string>(type: "text", nullable: false),
                    Coordinates_South = table.Column<string>(type: "text", nullable: false),
                    Coordinates_West = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleProperty_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleProperty_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicesData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SaleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ElectricMeterValue = table.Column<decimal>(type: "numeric", nullable: false),
                    InstalledElectricMeter = table.Column<bool>(type: "boolean", nullable: false),
                    InstalledWaterMeter = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicesData_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubsidyData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SaleId = table.Column<Guid>(type: "uuid", nullable: false),
                    DialedMinistryCollection = table.Column<bool>(type: "boolean", nullable: false),
                    MinistryPayment = table.Column<bool>(type: "boolean", nullable: false),
                    CompensationBoxSubsidyFiled = table.Column<bool>(type: "boolean", nullable: false),
                    CompensationCashPayment = table.Column<bool>(type: "boolean", nullable: false),
                    LoanDisbursementDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubsidyData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubsidyData_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SaleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Visit = table.Column<bool>(type: "boolean", nullable: false),
                    Certified = table.Column<bool>(type: "boolean", nullable: false),
                    SentAfiniaDocuments = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitData_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppraisalData_SaleId",
                table: "AppraisalData",
                column: "SaleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeedCostsData_SaleId",
                table: "DeedCostsData",
                column: "SaleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeedData_SaleId",
                table: "DeedData",
                column: "SaleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryData_SaleId",
                table: "DeliveryData",
                column: "SaleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentaryData_SaleId",
                table: "DocumentaryData",
                column: "SaleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinancialData_SaleId",
                table: "FinancialData",
                column: "SaleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleCustomer_CustomerId",
                table: "SaleCustomer",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleCustomer_SaleId",
                table: "SaleCustomer",
                column: "SaleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleProperty_PropertyId",
                table: "SaleProperty",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProperty_SaleId",
                table: "SaleProperty",
                column: "SaleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServicesData_SaleId",
                table: "ServicesData",
                column: "SaleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubsidyData_SaleId",
                table: "SubsidyData",
                column: "SaleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VisitData_SaleId",
                table: "VisitData",
                column: "SaleId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppraisalData");

            migrationBuilder.DropTable(
                name: "DeedCostsData");

            migrationBuilder.DropTable(
                name: "DeedData");

            migrationBuilder.DropTable(
                name: "DeliveryData");

            migrationBuilder.DropTable(
                name: "DocumentaryData");

            migrationBuilder.DropTable(
                name: "FinancialData");

            migrationBuilder.DropTable(
                name: "SaleCustomer");

            migrationBuilder.DropTable(
                name: "SaleProperty");

            migrationBuilder.DropTable(
                name: "ServicesData");

            migrationBuilder.DropTable(
                name: "SubsidyData");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "VisitData");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "Sale");
        }
    }
}
