using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inmobiliaria.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createfinancialdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SaleFinancialData",
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
                    table.PrimaryKey("PK_SaleFinancialData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleFinancialData_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleFinancialData_SaleId",
                table: "SaleFinancialData",
                column: "SaleId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleFinancialData");
        }
    }
}
