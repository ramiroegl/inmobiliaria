using Inmobiliaria.Domain.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inmobiliaria.Infrastructure.Properties;

public class PropertyRepositoryConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder
            .ToTable(nameof(Property));
        builder
            .ComplexProperty(property => property.Coordinates);
        builder
            .HasMany(property => property.Sales)
            .WithOne(saleProperty => saleProperty.Property)
            .HasForeignKey(saleProperty => saleProperty.PropertyId);
    }
}
