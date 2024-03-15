using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inmobiliaria.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeexpirationtypefromidentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identity_DateOfIssue",
                table: "SaleCustomer");

            migrationBuilder.DropColumn(
                name: "Identity_DateOfIssue",
                table: "Customer");

            migrationBuilder.AddColumn<string>(
                name: "Identity_Expedition",
                table: "SaleCustomer",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Identity_Expedition",
                table: "Customer",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identity_Expedition",
                table: "SaleCustomer");

            migrationBuilder.DropColumn(
                name: "Identity_Expedition",
                table: "Customer");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Identity_DateOfIssue",
                table: "SaleCustomer",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "Identity_DateOfIssue",
                table: "Customer",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
