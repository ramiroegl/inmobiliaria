using Inmobiliaria.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inmobiliaria.Infrastructure.Sales;

public class SalePropertyRepositoryConfiguration : IEntityTypeConfiguration<SaleProperty>
{
    public void Configure(EntityTypeBuilder<SaleProperty> builder)
    {
        builder
            .ToTable(nameof(SaleProperty));
        builder
            .ComplexProperty(property => property.Coordinates);
    }
}
