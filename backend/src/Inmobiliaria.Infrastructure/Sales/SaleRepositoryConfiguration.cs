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
    }
}
