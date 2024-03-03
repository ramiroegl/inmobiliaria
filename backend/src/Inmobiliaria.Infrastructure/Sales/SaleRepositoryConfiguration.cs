using Inmobiliaria.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inmobiliaria.Infrastructure.Sales;

public class SaleRepositoryConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder
            .ToTable(nameof(Sale));
        builder
            .Navigation(sale => sale.Customer)
            .AutoInclude();
        builder
            .Navigation(sale => sale.Property)
            .AutoInclude();
        builder
            .Navigation(sale => sale.FinancialData)
            .AutoInclude();
        builder
            .Navigation(sale => sale.DocumentaryData)
            .AutoInclude();
        builder
            .Navigation(sale => sale.AppraisalData)
            .AutoInclude();
        builder
            .Navigation(sale => sale.DeedData)
            .AutoInclude();
        builder
            .Navigation(sale => sale.DeedCostsData)
            .AutoInclude();
        builder
            .Navigation(sale => sale.DeliveryData)
            .AutoInclude();
        builder
            .Navigation(sale => sale.SubsidyData)
            .AutoInclude();
        builder
            .Navigation(sale => sale.ServicesData)
            .AutoInclude();
        builder
            .Navigation(sale => sale.VisitData)
            .AutoInclude();
        builder
            .HasOne(sale => sale.Customer)
            .WithOne(customer => customer.Sale)
            .HasForeignKey<SaleCustomer>(customer => customer.SaleId)
            .HasPrincipalKey<Sale>(sale => sale.Id);
        builder
            .HasOne(sale => sale.Property)
            .WithOne(customer => customer.Sale)
            .HasForeignKey<SaleProperty>(property => property.SaleId)
            .HasPrincipalKey<Sale>(sale => sale.Id);
        builder
            .HasOne(sale => sale.FinancialData)
            .WithOne(financialData => financialData.Sale)
            .HasForeignKey<FinancialData>(financialData => financialData.SaleId)
            .HasPrincipalKey<Sale>(sale => sale.Id);
        builder
            .HasOne(sale => sale.DocumentaryData)
            .WithOne(documentaryData => documentaryData.Sale)
            .HasForeignKey<DocumentaryData>(documentaryData => documentaryData.SaleId)
            .HasPrincipalKey<Sale>(sale => sale.Id);
        builder
            .HasOne(sale => sale.AppraisalData)
            .WithOne(appraisalData => appraisalData.Sale)
            .HasForeignKey<AppraisalData>(appraisalData => appraisalData.SaleId)
            .HasPrincipalKey<Sale>(sale => sale.Id);
        builder
            .HasOne(sale => sale.DeedData)
            .WithOne(deedData => deedData.Sale)
            .HasForeignKey<DeedData>(deedData => deedData.SaleId)
            .HasPrincipalKey<Sale>(sale => sale.Id);
        builder
            .HasOne(sale => sale.DeedCostsData)
            .WithOne(deedCostsData => deedCostsData.Sale)
            .HasForeignKey<DeedCostsData>(deedCostsData => deedCostsData.SaleId)
            .HasPrincipalKey<Sale>(sale => sale.Id);
        builder
            .HasOne(sale => sale.DeliveryData)
            .WithOne(deliveryData => deliveryData.Sale)
            .HasForeignKey<DeliveryData>(deliveryData => deliveryData.SaleId)
            .HasPrincipalKey<Sale>(sale => sale.Id);
        builder
            .HasOne(sale => sale.SubsidyData)
            .WithOne(subsidyData => subsidyData.Sale)
            .HasForeignKey<SubsidyData>(subsidyData => subsidyData.SaleId)
            .HasPrincipalKey<Sale>(sale => sale.Id);
        builder
            .HasOne(sale => sale.ServicesData)
            .WithOne(servicesData => servicesData.Sale)
            .HasForeignKey<ServicesData>(servicesData => servicesData.SaleId)
            .HasPrincipalKey<Sale>(sale => sale.Id);
        builder
            .HasOne(sale => sale.VisitData)
            .WithOne(visitData => visitData.Sale)
            .HasForeignKey<VisitData>(visitData => visitData.SaleId)
            .HasPrincipalKey<Sale>(sale => sale.Id);
    }
}
