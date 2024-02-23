﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Inmobiliaria.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Inmobiliaria.Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Inmobiliaria.Domain.Customers.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CivilStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastNames")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Names")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Salary")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.ComplexProperty<Dictionary<string, object>>("Identity", "Inmobiliaria.Domain.Customers.Customer.Identity#Identity", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<DateOnly>("DateOfIssue")
                                .HasColumnType("date");

                            b1.Property<string>("Type")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");
                        });

                    b.HasKey("Id");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("Inmobiliaria.Domain.Properties.Property", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Block")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Lot")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Tuition")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.ComplexProperty<Dictionary<string, object>>("Coordinates", "Inmobiliaria.Domain.Properties.Property.Coordinates#Coordinates", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("East")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("North")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("South")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("West")
                                .IsRequired()
                                .HasColumnType("text");
                        });

                    b.HasKey("Id");

                    b.ToTable("Property", (string)null);
                });

            modelBuilder.Entity("Inmobiliaria.Domain.Sales.AppraisalData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FamilyCodeInMinistryOfHousing")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IssuanceByTheBankOfALetterOfRatification")
                        .HasColumnType("boolean");

                    b.Property<bool>("Payment")
                        .HasColumnType("boolean");

                    b.Property<bool>("Report")
                        .HasColumnType("boolean");

                    b.Property<bool>("RequestSubmissionOfDocuments")
                        .HasColumnType("boolean");

                    b.Property<bool>("SendingDocumentsForTitleStudy")
                        .HasColumnType("boolean");

                    b.Property<bool>("TitleStudyPayment")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Visit")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("AppraisalData", (string)null);
                });

            modelBuilder.Entity("Inmobiliaria.Domain.Sales.DeedData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("ConstructionCompanySignature")
                        .HasColumnType("boolean");

                    b.Property<bool>("CopiesAndSettlement")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("CustomerSignature")
                        .HasColumnType("boolean");

                    b.Property<DateOnly>("EntryDateIntoPublicInstruments")
                        .HasColumnType("date");

                    b.Property<bool>("PropertySellerSignature")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("DeedData", (string)null);
                });

            modelBuilder.Entity("Inmobiliaria.Domain.Sales.DocumentaryData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ApprovalLetterNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CompensationFundRecordNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("CreditApprovalLetter")
                        .HasColumnType("boolean");

                    b.Property<bool>("DeliveryDocument")
                        .HasColumnType("boolean");

                    b.Property<bool>("IdentificationDocument")
                        .HasColumnType("boolean");

                    b.Property<bool>("MinistrySubsidyResolution")
                        .HasColumnType("boolean");

                    b.Property<Guid>("SaleId")
                        .HasColumnType("uuid");

                    b.Property<bool>("SignedPledge")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("SaleId")
                        .IsUnique();

                    b.ToTable("DocumentaryData", (string)null);
                });

            modelBuilder.Entity("Inmobiliaria.Domain.Sales.FinancialData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("CompensationFundSubsidy")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Debt")
                        .HasColumnType("numeric");

                    b.Property<string>("LoanEntity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("LoanValue")
                        .HasColumnType("numeric");

                    b.Property<decimal>("MinistryOfHousingSubsidy")
                        .HasColumnType("numeric");

                    b.Property<decimal>("OtherPayments")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<Guid>("SaleId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("ValueToSetAside")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("SaleId")
                        .IsUnique();

                    b.ToTable("FinancialData", (string)null);
                });

            modelBuilder.Entity("Inmobiliaria.Domain.Sales.Sale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AppraisalDataId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DeedDataId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AppraisalDataId");

                    b.HasIndex("DeedDataId");

                    b.ToTable("Sale", (string)null);
                });

            modelBuilder.Entity("Inmobiliaria.Domain.Sales.SaleCustomer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CivilStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastNames")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Names")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Salary")
                        .HasColumnType("numeric");

                    b.Property<Guid>("SaleId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.ComplexProperty<Dictionary<string, object>>("Identity", "Inmobiliaria.Domain.Sales.SaleCustomer.Identity#Identity", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<DateOnly>("DateOfIssue")
                                .HasColumnType("date");

                            b1.Property<string>("Type")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");
                        });

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SaleId")
                        .IsUnique();

                    b.ToTable("SaleCustomer", (string)null);
                });

            modelBuilder.Entity("Inmobiliaria.Domain.Sales.SaleProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Block")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Lot")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SaleId")
                        .HasColumnType("uuid");

                    b.Property<string>("Tuition")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.ComplexProperty<Dictionary<string, object>>("Coordinates", "Inmobiliaria.Domain.Sales.SaleProperty.Coordinates#Coordinates", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("East")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("North")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("South")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("West")
                                .IsRequired()
                                .HasColumnType("text");
                        });

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.HasIndex("SaleId")
                        .IsUnique();

                    b.ToTable("SaleProperty", (string)null);
                });

            modelBuilder.Entity("Inmobiliaria.Domain.Sales.DocumentaryData", b =>
                {
                    b.HasOne("Inmobiliaria.Domain.Sales.Sale", "Sale")
                        .WithOne("DocumentaryData")
                        .HasForeignKey("Inmobiliaria.Domain.Sales.DocumentaryData", "SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("Inmobiliaria.Domain.Sales.FinancialData", b =>
                {
                    b.HasOne("Inmobiliaria.Domain.Sales.Sale", "Sale")
                        .WithOne("FinancialData")
                        .HasForeignKey("Inmobiliaria.Domain.Sales.FinancialData", "SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("Inmobiliaria.Domain.Sales.Sale", b =>
                {
                    b.HasOne("Inmobiliaria.Domain.Sales.AppraisalData", "AppraisalData")
                        .WithMany()
                        .HasForeignKey("AppraisalDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inmobiliaria.Domain.Sales.DeedData", "DeedData")
                        .WithMany()
                        .HasForeignKey("DeedDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppraisalData");

                    b.Navigation("DeedData");
                });

            modelBuilder.Entity("Inmobiliaria.Domain.Sales.SaleCustomer", b =>
                {
                    b.HasOne("Inmobiliaria.Domain.Customers.Customer", "Customer")
                        .WithMany("Sales")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inmobiliaria.Domain.Sales.Sale", "Sale")
                        .WithOne("Customer")
                        .HasForeignKey("Inmobiliaria.Domain.Sales.SaleCustomer", "SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("Inmobiliaria.Domain.Sales.SaleProperty", b =>
                {
                    b.HasOne("Inmobiliaria.Domain.Properties.Property", "Property")
                        .WithMany("Sales")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inmobiliaria.Domain.Sales.Sale", "Sale")
                        .WithOne("Property")
                        .HasForeignKey("Inmobiliaria.Domain.Sales.SaleProperty", "SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("Inmobiliaria.Domain.Customers.Customer", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Inmobiliaria.Domain.Properties.Property", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Inmobiliaria.Domain.Sales.Sale", b =>
                {
                    b.Navigation("Customer")
                        .IsRequired();

                    b.Navigation("DocumentaryData")
                        .IsRequired();

                    b.Navigation("FinancialData")
                        .IsRequired();

                    b.Navigation("Property")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
