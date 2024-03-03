using Inmobiliaria.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inmobiliaria.Infrastructure.Sales;

public class DeliveryDataRepositoryConfiguration : IEntityTypeConfiguration<DeliveryData>
{
    public void Configure(EntityTypeBuilder<DeliveryData> builder)
    {
        builder
            .ToTable(nameof(DeliveryData));
    }
}
