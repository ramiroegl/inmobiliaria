using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inmobiliaria.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createcustomersandproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Names = table.Column<string>(type: "text", nullable: false),
                    LastNames = table.Column<string>(type: "text", nullable: false),
                    Identity_Type = table.Column<string>(type: "text", nullable: false),
                    Identity_Value = table.Column<string>(type: "text", nullable: false),
                    Identity_DateOfIssue = table.Column<string>(type: "text", nullable: false),
                    CivilStatus = table.Column<string>(type: "text", nullable: false),
                    Salary = table.Column<decimal>(type: "numeric", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    Coordinates_North = table.Column<string>(type: "text", nullable: false),
                    Coordinates_South = table.Column<string>(type: "text", nullable: false),
                    Coordinates_East = table.Column<string>(type: "text", nullable: false),
                    Coordinates_West = table.Column<string>(type: "text", nullable: false),
                    Tuition = table.Column<string>(type: "text", nullable: false),
                    Block = table.Column<string>(type: "text", nullable: false),
                    Lot = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
