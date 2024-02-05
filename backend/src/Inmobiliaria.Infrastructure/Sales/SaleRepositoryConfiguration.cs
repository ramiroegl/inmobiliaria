using Inmobiliaria.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inmobiliaria.Infrastructure.Sales;

public class SaleRepositoryConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ComplexProperty(sale => sale.PropertyData);
        builder.ComplexProperty(sale => sale.CustomerData);

        builder
            .HasOne(sale => sale.Customer)
            .WithMany(customer => customer.Sales)
            .HasForeignKey(sale => sale.CustomerId)
            .HasPrincipalKey(customer => customer.Id);

        builder
            .HasOne(sale => sale.Property)
            .WithMany(customer => customer.Sales)
            .HasForeignKey(sale => sale.PropertyId)
            .HasPrincipalKey(property => property.Id);
    }
}
